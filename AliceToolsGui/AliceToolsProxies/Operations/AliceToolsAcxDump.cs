// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the dump operation of .acx files.
    /// </summary>
    public class AliceToolsAcxDump : AliceAcxFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "dump";

        /// <summary>
        /// Output file path. 
        /// </summary>
        public string OutputPath { get; set; }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            string.IsNullOrWhiteSpace(OutputPath).TrueThrowPropertyInvalidOperation(nameof(OutputPath));
            writer.Write($"-o {OutputPath}");
        }
    }


}
