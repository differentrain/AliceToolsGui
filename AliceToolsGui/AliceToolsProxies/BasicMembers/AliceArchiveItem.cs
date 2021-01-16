// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents an item in alice archives.
    /// </summary>
    public sealed class AliceArchiveItem
    {
        internal AliceArchiveItem(string index, string fileName)
        {
            Index = index;
            FileName = fileName;
        }
        /// <summary>
        /// Get the index of the item in archive.
        /// </summary>
        public string Index { get; }
        /// <summary>
        /// Get the index of the item in archive.
        /// </summary>
        public string FileName { get; }

        /// <inheritdoc/>
        public override string ToString() => $"{Index}: {FileName}";
    }
}
