// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AliceToolsGui.GithubRepoReleases
{
    public sealed class GitHubRepoRelease
    {
        private static readonly Regex s_regTag = new Regex(@"(?<=""tag_name""\s*:\s*"")(\d+\.)+\d+(?="")", RegexOptions.Compiled);
        private static readonly Regex s_regURL = new Regex(@"(?<=""browser_download_url""\s*:\s*"")\S+?(?="")", RegexOptions.Compiled);


        internal GitHubRepoRelease(string json, string repoName)
        {
            Match tarMatch = s_regTag.Match(json);
            Match urlMatch = s_regURL.Match(json);
            if (!tarMatch.Success || !urlMatch.Success)
            {
                throw new FormatException();
            }

            RepoName = repoName;
            Version = new Version(tarMatch.Value);
            Url = urlMatch.Value;
        }

        public string RepoName { get; }
        public Version Version { get; }
        public string Url { get; }
    }
}
