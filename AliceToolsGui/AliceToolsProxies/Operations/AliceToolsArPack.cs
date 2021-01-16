// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the pack operation of alice archive files.
    /// </summary>
    public class AliceToolsArPack : AliceArFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "pack";

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer) { }
    }

}
