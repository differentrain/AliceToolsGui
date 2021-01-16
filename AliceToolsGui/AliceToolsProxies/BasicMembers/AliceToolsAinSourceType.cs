// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the type of ain source code should be updated.
    /// </summary>
    public enum AliceToolsAinSourceType
    {

        /// <summary>
        /// Updates Code section.
        /// </summary>
        [AliceToolsEnumArgument("-c")]
        UpdatesCode,
        /// <summary>
        /// Appends Code section.
        /// </summary>
        [AliceToolsEnumArgument("--jam")]
        AppendCode,
        /// <summary>
        /// Updates Raw mode Code.
        /// </summary>
        [AliceToolsEnumArgument("--raw -c")]
        UpdatesRawCode,
        /// <summary>
        /// Updates Alice .jaf source code file.
        /// </summary>
        [AliceToolsEnumArgument("--jaf")]
        UpdatesJaf,
        /// <summary>
        /// Updates Json data.
        /// </summary>
        [AliceToolsEnumArgument("-j")]
        UpdatesJson,
        /// <summary>
        /// Updates Alice project file.
        /// </summary>
        [AliceToolsEnumArgument("-p")]
        UpdatesProject,
        /// <summary>
        /// Updates strings/messages section.
        /// </summary>
        [AliceToolsEnumArgument("-t")]
        UpdatesText,
        /// <summary>
        /// Updates .ain file version.
        /// </summary>
        [AliceToolsEnumArgument("--ain-version")]
        UpdatesAinVersion,

    }
}
