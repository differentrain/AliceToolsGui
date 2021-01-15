// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the dump operation of .ex files.
    /// </summary>
    public class AliceToolsExDump : AliceExFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "dump";

        /// <summary>
        /// Gets or sets a value shows that if dump the .ex file into multiple files.
        /// </summary>
        public bool Split { get; set; }

        /// <summary>
        /// Gets or sets a value shows that if decrypt .ex file only.
        /// </summary>
        public bool DecryptOnly { get; set; }

        /// <summary>
        /// Output file or directory path. 
        /// </summary>
        public string OutputPath { get; set; }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            
            string.IsNullOrWhiteSpace(OutputPath).TrueThrowPropertyInvalidOperation(nameof(OutputPath));
            if (DecryptOnly)
            {
                writer.Write("--decrypt");
            }
            if (Split)
            {
                writer.Write("--split");
            }
            writer.Write($"-o {OutputPath}");
        }
    }

}
