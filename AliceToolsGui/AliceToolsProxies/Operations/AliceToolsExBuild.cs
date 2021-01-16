// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the build operation of .ex files.
    /// </summary>
    public class AliceToolsExBuild : AliceExFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "build";

        /// <summary>
        /// Gets or sets a value indicates that if target file belongs to an alice game which is older than Evenicle.
        /// </summary>
        public bool IsOldGame { get; set; } = false;

        /// <summary>
        /// Output file path. 
        /// </summary>
        public string OutputPath { get; set; }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            string.IsNullOrWhiteSpace(OutputPath).TrueThrowPropertyInvalidOperation(nameof(OutputPath));
            if (IsOldGame)
            {
                writer.Write("--old");
            }
            writer.Write($"-o {OutputPath}");
        }
    }

}
