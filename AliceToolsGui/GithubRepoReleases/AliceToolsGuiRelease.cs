// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceToolsGui.GithubRepoReleases
{
    public sealed class AliceToolsGuiRelease : GithubReleaseClient
    {
        public override string OwnerName => "differentrain";

        public override string RepoName => "AliceToolsGui";
    }
}
