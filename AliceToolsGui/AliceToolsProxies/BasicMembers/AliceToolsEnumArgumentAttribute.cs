// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the argument used by alice-tools.
    /// </summary>
    /// <remarks>
    /// This attribute is only available at enum field currently.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class AliceToolsEnumArgumentAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AliceToolsEnumArgumentAttribute"/>,
        /// and specifies the argument string.
        /// </summary>
        /// <param name="name">The argument string.</param>
        /// <remarks>
        ///  <c>null</c> <paramref name="name"/> will be ignored by <see cref="AliceToolsArgumentsWriter"/>.
        /// </remarks>
        public AliceToolsEnumArgumentAttribute(string name = null) => Name = name;

        /// <summary>
        /// Gets the argument string used by alice-tools.
        /// </summary>
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? string.Empty : Name;

    }
}
