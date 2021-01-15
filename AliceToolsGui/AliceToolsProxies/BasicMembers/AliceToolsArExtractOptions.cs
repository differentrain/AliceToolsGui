// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents options for alice archive files extraction
    /// </summary>
    [Flags]
    public enum AliceToolsArExtractOptions
    {
        [AliceToolsEnumArgument()]
        Default = 0,
        /// <summary>
        /// Do not recursively extracted files, and do not converte images.
        /// </summary>
        [AliceToolsEnumArgument("--raw")]
        Raw = 1,
        /// <summary>
        /// Convert image to PNG format.
        /// </summary>
        [AliceToolsEnumArgument("--image-format png")]
        Png = 2,
        /// <summary>
        /// Convert image to WebP format.
        /// </summary>
        [AliceToolsEnumArgument("--image-format webp")]
        WebP = 4,
        /// <summary>
        /// Allow overwriting existing files.
        /// </summary>
        [AliceToolsEnumArgument("--force")]
        Force = 8,
        /// <summary>
        ///  Only extract images.
        /// </summary>
        [AliceToolsEnumArgument("--images-only")]
        ImagesOnly = 16

    }
}
