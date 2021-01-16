// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliceToolsGui.GithubRepoReleases
{
    public abstract class GithubReleaseClient
    {
        private static readonly HttpClient s_client = new HttpClient(new HttpClientHandler()
        {
            AllowAutoRedirect = false,
            UseCookies = false,
            AutomaticDecompression = DecompressionMethods.GZip
        }, false);


        private CancellationTokenSource _cancellationTokenSouce = new CancellationTokenSource();


        static GithubReleaseClient()
        {
            s_client.Timeout = TimeSpan.FromSeconds(120);
            s_client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("AliceToolsGUI", FormMain.MyVersion.ToString(3)));
            // ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }



        public abstract string OwnerName { get; }
        public abstract string RepoName { get; }


        public void CancleAll()
        {
            _cancellationTokenSouce.Cancel();
            _cancellationTokenSouce.Dispose();
            _cancellationTokenSouce = new CancellationTokenSource();
        }

        public async Task<GitHubRepoRelease> GetLatestAsync()
        {
            try
            {
                return await GetReleaseInfoAsync($"https://api.github.com/repos/{OwnerName}/{RepoName}/releases/latest").ConfigureAwait(false);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                return await Task.FromResult<GitHubRepoRelease>(null);
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }





        public async Task<bool> DownloadAsync(GitHubRepoRelease version, string path)
        {

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return await DownloadReleaseAsync(version, path).ConfigureAwait(false);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }



        private async Task<GitHubRepoRelease> GetReleaseInfoAsync(string url)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await s_client.SendAsync(request, _cancellationTokenSouce.Token).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    using (StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false), Encoding.UTF8))
                    {
                        string json = await sr.ReadToEndAsync().ConfigureAwait(false);
                        return await Task.FromResult(new GitHubRepoRelease(json, RepoName)).ConfigureAwait(false);
                    }
                }
            }
        }



        private async Task<bool> DownloadReleaseAsync(GitHubRepoRelease version, string path)
        {
            Uri realUrl;
            using (HttpRequestMessage requestLocal = new HttpRequestMessage(HttpMethod.Head, version.Url))
            {
                using (HttpResponseMessage responseLocal = await s_client.SendAsync(requestLocal, HttpCompletionOption.ResponseHeadersRead, _cancellationTokenSouce.Token).ConfigureAwait(false))
                {
                    if (responseLocal.StatusCode != HttpStatusCode.Found)
                    {
                        return false;
                    }
                    realUrl = responseLocal.Headers.Location;
                }
            }
            bool rangesSuported;
            long contentLength;
            using (HttpRequestMessage requestFileSize = new HttpRequestMessage(HttpMethod.Head, realUrl))
            {
                using (HttpResponseMessage responseFileSize = await s_client.GetAsync(realUrl, HttpCompletionOption.ResponseHeadersRead, _cancellationTokenSouce.Token))
                {
                    if (responseFileSize.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                    rangesSuported = responseFileSize.Headers.AcceptRanges.Contains("bytes");
                    contentLength = responseFileSize.Content.Headers.ContentLength ?? 0;
                    if (contentLength == 0)
                    {
                        return false;
                    }
                }
            }
            return await Task.Run(() => DownLoadCore(realUrl, path, rangesSuported, contentLength)).ConfigureAwait(false);


        }

        private bool DownLoadCore(Uri url, string path, bool rangesSuported, long contentLength)
        {
            if (!rangesSuported)
            {
                return DownloadPartAsync(url, path, null, null).Result;
            }

            int ThreadCount = Environment.ProcessorCount;
            long part = contentLength / ThreadCount;
            long partMod = contentLength % ThreadCount;
            Task<bool>[] tasks;
            if (part == 0)
            {
                tasks = new Task<bool>[1];
            }
            else
            {
                tasks = new Task<bool>[ThreadCount];
            }

            File.Create(path).Dispose();

            int endIndex = tasks.Length - 1;

            long from = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                if (i == endIndex)
                {
                    part += partMod;
                }
                long to = from + part - 1;
                tasks[i] = DownloadPartAsync(url, path, from, to);
                from = to + 1;
            }

            Task.WaitAll(tasks, _cancellationTokenSouce.Token);
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Result == false)
                {
                    return false;
                }
                tasks[i].Dispose();
            }
            return true;
        }


        private async Task<bool> DownloadPartAsync(Uri url, string path, long? from, long? to)
        {
            using (HttpRequestMessage requestFileSize = new HttpRequestMessage(HttpMethod.Get, url))
            {
                if (from.HasValue)
                {
                    requestFileSize.Headers.Range = new RangeHeaderValue(from, to);
                }
                using (HttpResponseMessage respone = await s_client.SendAsync(requestFileSize, HttpCompletionOption.ResponseHeadersRead, _cancellationTokenSouce.Token).ConfigureAwait(false))
                {
                    if (respone.StatusCode != HttpStatusCode.PartialContent &&
                         respone.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.Write))
                    {
                        using (var copyer = new StreamCopyerInner(await respone.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                        {
                            fs.Position = from.Value;
                            await copyer.CopyToAsync(fs, _cancellationTokenSouce.Token).ConfigureAwait(false);
                            return true;
                        }
                    }
                }
            }

        }



    }

}
