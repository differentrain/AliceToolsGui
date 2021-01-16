// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.RegularExpressions;

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui.AliceToolsProxies.InternalMembers
{
    internal sealed class VersionReaderInner : AliceToolsOutputConverter<Version>
    {
        public static readonly VersionReaderInner Defalut = new VersionReaderInner();

        private static readonly Regex s_reg =
              new Regex(@"(?<=^alice-tools\s+version\s+)(\d\.)+\d+(?=(\s)*$)",
                 RegexOptions.Compiled);

        private VersionReaderInner() { }

        protected override Version ConvertCore(string message)
        {
            Match match = s_reg.Match(message);
            if (match.Success)
            {
                return new Version(match.Value);
            }
            return null;
        }
    }
}
