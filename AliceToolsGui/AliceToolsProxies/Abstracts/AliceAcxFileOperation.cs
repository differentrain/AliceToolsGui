// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceToolsGui.AliceToolsProxies.Abstracts
{
    /// <summary>
    /// Represents the operation of .acx files.
    /// </summary>
    public abstract class AliceAcxFileOperation : AliceFileOperation
    {
        /// <inheritdoc/>
        public override string FileType => "acx";
    }
}
