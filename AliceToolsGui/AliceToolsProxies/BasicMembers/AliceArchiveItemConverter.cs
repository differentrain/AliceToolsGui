// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents a converter to convert result of <see cref="AliceToolsArList"/> operation to <see cref="AliceArchiveItem"/> list.
    /// </summary>
    public sealed class AliceArchiveItemConverter : AliceToolsOutputConverter<List<AliceArchiveItem>>
    {
        /// <summary>
        /// Defaule converter.
        /// </summary>
        public static readonly AliceArchiveItemConverter Default = new AliceArchiveItemConverter();

        private static readonly Regex s_reg = new Regex(
            @"(^\d+)(?:\s*:\s*)(\S+)(?=\s*)",
            RegexOptions.Multiline | RegexOptions.Compiled);

        private AliceArchiveItemConverter() { }

        /// <inheritdoc/>
        protected override List<AliceArchiveItem> ConvertCore(string message)
        {
            MatchCollection matches = s_reg.Matches(message);
            if (matches.Count == 0)
            {
                return new List<AliceArchiveItem>(0);
            }
            return matches.Cast<Match>()
                .Select(m => new AliceArchiveItem(m.Groups[1].Value, m.Groups[2].Value))
                .ToList();
        }
    }
}
