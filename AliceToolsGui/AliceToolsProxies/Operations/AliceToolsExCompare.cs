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
    /// Represents the compare operation of .ex files.
    /// </summary>
    public class AliceToolsExCompare : AliceExFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "compare";

        /// <summary>
        /// The .ex file to be compared with the file <see cref="AliceFileOperation.InputPath"/>.
        /// </summary>
        public string ComparedFile { get; set; }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            string.IsNullOrWhiteSpace(ComparedFile).TrueThrowPropertyInvalidOperation(nameof(ComparedFile));
            writer.Write(ComparedFile);
        }
    }

}
