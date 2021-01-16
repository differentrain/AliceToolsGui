// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies;
using AliceToolsGui.GithubRepoReleases;

namespace AliceToolsGui
{
    partial class FormMain
    {


        private void ButtonCheckAT_Click(object sender, EventArgs e)
        {
            if (ButtonCheckAT.Text.Equals("取消"))
            {
                _atClient.CancleAll();

            }
            else
            {

                ButtonCheckAT.Text = "取消";
                ButtonCheckATG.Enabled = false;
                GroupBoxEncoding.Enabled = false;
                TabControlMain.Enabled = false;

                BackgroundWorkerMain.RunWorkerAsync(new Action(() =>
                {
                    UpdateAliceToolsAsync().Wait();
                }));
            }


        }

        private void ButtonCheckATG_Click(object sender, EventArgs e)
        {
            if (ButtonCheckATG.Text.Equals("取消"))
            {
                _atClient.CancleAll();

            }
            else
            {
                ButtonCheckATG.Text = "取消";
                ButtonCheckAT.Enabled = false;
                GroupBoxEncoding.Enabled = false;
                TabControlMain.Enabled = false;

                BackgroundWorkerMain.RunWorkerAsync(new Action(() =>
                {
                    UpdateAliceToolsGuiAsync().Wait();
                }));
            }

        }

        private async Task UpdateAliceToolsAsync()
        {
            try
            {
                IEnumerable<FileInfo> fis = await GetUpdateTempFilesAsync(_atClient, _proxy?.Version).ConfigureAwait(false);
                if (fis == null)
                {
                    return;
                }
                foreach (FileInfo item in fis)
                {
                    string lowExt = item.Extension.ToLower();
                    if (lowExt.Equals(".dll") || lowExt.Equals(".exe"))
                    {
                        File.Copy(item.FullName, item.Name, true);
                    }
                }
                if (_proxy == null)
                {
                    _proxy = new AliceToolsProxy();

                    Invoke(() =>
                    {
                        LabelATVersion.Text = _proxy.Version.ToString(3);
                        TextBoxOutput.Text += $"初始化完成，alice-tools 版本：{LabelATVersion.Text}\r\n";
                        ContextMenuStripOutput.Enabled = true;
                    });
                    return;

                }
                else if (_proxy.Test())
                {
                    Invoke(() =>
                    {
                        LabelATVersion.Text = _proxy.Version.ToString(3);
                        TextBoxOutput.Text += $"更新完成，alice-tools 版本：{LabelATVersion.Text}\r\n";
                    });
                    return;
                }


                Invoke(() =>
                {
                    TextBoxOutput.Text += $"悲剧啊，不支持此 alice-tools 版本，n请手动下载旧版进行覆盖。\r\n";
                    ContextMenuStripOutput.Enabled = GroupBoxEncoding.Enabled = GroupBoxUpdate.Enabled = TabControlMain.Enabled = false;
                });

            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {

                Invoke(() => TextBoxOutput.Text += $"更新失败，请重启程序再试。\r\n");
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
                ClearTemp();
            }


        }


        private async Task UpdateAliceToolsGuiAsync()
        {
            try
            {
                IEnumerable<FileInfo> fis = await GetUpdateTempFilesAsync(_atGClient, s_myVersion).ConfigureAwait(false);
                if (fis == null)
                {
                    return;
                }

                Invoke(() => TextBoxOutput.Text += "为完成更新，程序将在5秒钟后重启...\r\n");

                await Task.Delay(5000).ConfigureAwait(false);

                FileInfo fi = fis.First(f => f.Extension.ToLower().Equals(".exe"));
                Process.Start(fi.FullName, $"update \"{fi.FullName}\"");
                Environment.Exit(0);

            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {

                Invoke(() => TextBoxOutput.Text += $"更新失败，请重启程序再试。\r\n");
            }
#pragma warning restore CA1031 // Do not catch general exception types
            finally
            {
                ClearTemp();
            }


        }

        private async Task<IEnumerable<FileInfo>> GetUpdateTempFilesAsync(GithubReleaseClient client, Version version)
        {
            Invoke(() => TextBoxOutput.Text += $"检查 {client.RepoName} 新版本...\r\n");
            GitHubRepoRelease release = await client.GetLatestAsync().ConfigureAwait(false);
            if (release == null)
            {
                Invoke(() => TextBoxOutput.Text += "检查新版本失败，请稍后重试。\r\n");
                return null;
            }
            if (version != null && release.Version.CompareTo(version) <= 0)
            {
                Invoke(() => TextBoxOutput.Text += "没有新的版本。\r\n");
                return null;
            }
            Invoke(() => TextBoxOutput.Text += $"发现 {client.RepoName} {release.Version.ToString(3)}, 开始下载...\r\n");
            bool success = await client.DownloadAsync(release, "alice_tools_gui_download.zip").ConfigureAwait(false);

            if (!success)
            {
                Invoke(() => TextBoxOutput.Text += $"下载失败，请稍后重试。\r\n");
                return null;
            }

            Invoke(() => TextBoxOutput.Text += $"下载完成，开始更新...\r\n");

            var di = new DirectoryInfo(@"alice_tools_gui_update_temp");

            if (di.Exists)
            {
                di.Delete(true);
                di.Create();
            }
            ZipFile.ExtractToDirectory("alice_tools_gui_download.zip", di.FullName);
            return di.EnumerateFiles("*.*", SearchOption.AllDirectories);
        }


        public static void ClearTemp()
        {
            try
            {
                if (Directory.Exists("alice_tools_gui_update_temp"))
                {
                    Directory.Delete("alice_tools_gui_update_temp", true);
                }
                if (File.Exists("alice_tools_gui_download.zip"))
                {
                    File.Delete("alice_tools_gui_download.zip");
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }


        private void Invoke(Action action) => Invoke(method: new Action(action));



    }
}
