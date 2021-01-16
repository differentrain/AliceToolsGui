// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies.Abstracts
{
    /// <summary>
    /// Represents the operation of .ain files.
    /// </summary>
    public abstract class AliceAinFileOperation : AliceFileOperation
    {
        /// <inheritdoc/>
        public override string FileType => "ain";
    }
}
