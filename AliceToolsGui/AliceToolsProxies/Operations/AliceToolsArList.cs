// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the list operation of alice archive files.
    /// </summary>
    public class AliceToolsArList : AliceArFileOperation
    {
        /// <inheritdoc/>
        public override string OperationName => "list";

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer) { }
    }

}
