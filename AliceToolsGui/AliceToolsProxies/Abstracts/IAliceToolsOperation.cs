// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Text;

namespace AliceToolsGui.AliceToolsProxies.Abstracts
{
    /// <summary>
    /// Represents a operation of alice-tools.
    /// </summary>
    public interface IAliceToolsOperation
    {
        /// <summary>
        /// Gets the output encoding.
        /// </summary>
        /// <remarks>
        /// Some <see cref="Encoding"/> may not be supported,
        /// uses <see cref="AliceToolsProxiesExtensions.IsLibiconvSupported(Encoding)"/> extension method to check.
        /// </remarks>
        Encoding OutputEncoding { get; }

        /// <summary>
        /// Gets the arguments represented by this instance.
        /// </summary>
        /// <returns>The arguments string.</returns>
        string GetArguments();
    }
}
