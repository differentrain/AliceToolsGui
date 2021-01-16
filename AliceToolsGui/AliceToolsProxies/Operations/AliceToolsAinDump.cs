// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the dump operation of .ain files.
    /// </summary>
    public class AliceToolsAinDump : AliceAinFileOperation
    {

        private AliceToolsAinDumpOption _option;

        /// <inheritdoc/>
        public override string OperationName => "dump";

        /// <summary>
        /// Output file path. 
        /// </summary>
        /// <remarks>
        /// If this value sets to <c>null</c>, the output message is stored in <see cref="AliceToolsOutput.Output"/>.
        /// </remarks>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the dump option.
        /// </summary>
        public AliceToolsAinDumpOption Option
        {
            get => _option; set
            {
                if (value > AliceToolsAinDumpOption.HLL || value < AliceToolsAinDumpOption.Code)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _option = value;
            }
        }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            if (!string.IsNullOrWhiteSpace(Output))
            {
                writer.Write($"-o {Output}");
            }
            writer.Write(Option);
        }
    }
}
