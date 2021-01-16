// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the option for .ain file dump opetation.
    /// </summary>
    public enum AliceToolsAinDumpOption
    {
        /// <summary>
        /// Dump code section.
        /// </summary>
        [AliceToolsEnumArgument("-c")]
        Code,
        /// <summary>
        /// Dump strings and messages, sorted by function.
        /// </summary>
        [AliceToolsEnumArgument("-t")]
        Text,
        /// <summary>
        ///  Dump to JSON format.
        /// </summary>
        [AliceToolsEnumArgument("-j")]
        Json,
        /// <summary>
        ///  Don't use macros in code output.
        /// </summary>
        [AliceToolsEnumArgument("--no-macros -c")]
        NoMacrosCode,
        /// <summary>
        ///  Dump code section in raw mode.
        /// </summary>
        [AliceToolsEnumArgument("-C")]
        RawCode,
        /// <summary>
        ///  Dump messages section.
        /// </summary>
        [AliceToolsEnumArgument("-m")]
        Messages,
        /// <summary>
        ///  Dump strings section.
        /// </summary>
        [AliceToolsEnumArgument("-s")]
        Strings,
        /// <summary>
        ///  Dump functions section.
        /// </summary>
        [AliceToolsEnumArgument("-f")]
        Functions,
        /// <summary>
        ///  Dump globals section.
        /// </summary>
        [AliceToolsEnumArgument("-g")]
        Globals,
        /// <summary>
        ///  Dump structures section.
        /// </summary>
        [AliceToolsEnumArgument("-S")]
        Structures,
        /// <summary>
        ///  Dump libraries section.
        /// </summary>
        [AliceToolsEnumArgument("-l")]
        Libraries,
        /// <summary>
        ///  Dump filenames.
        /// </summary>
        [AliceToolsEnumArgument("-F")]
        Filenames,
        /// <summary>
        ///  Dump function types section.
        /// </summary>
        [AliceToolsEnumArgument("--function-types")]
        FunctionTypes,
        /// <summary>
        ///  Dump delegate types section.
        /// </summary>
        [AliceToolsEnumArgument("--delegates")]
        Delegates,
        /// <summary>
        ///  Dump global group names section.
        /// </summary>
        [AliceToolsEnumArgument("--global-group-names")]
        GlobalGroupNames,
        /// <summary>
        ///  Dump enums section.
        /// </summary>
        [AliceToolsEnumArgument("-e")]
        Enums,
        /// <summary>
        /// Dump keycode value.
        /// </summary>
        [AliceToolsEnumArgument("--keycode")]
        KeyCode,
        /// <summary>
        /// Dump main function index.
        /// </summary>
        [AliceToolsEnumArgument("--main")]
        Main,
        /// <summary>
        /// Dump message function index.
        /// </summary>
        [AliceToolsEnumArgument("--msgf")]
        MessageFunction,
        /// <summary>
        /// Dump .ain file version.
        /// </summary>
        [AliceToolsEnumArgument("--ain-version")]
        AinVersion,
        /// <summary>
        /// Dump game version.
        /// </summary>
        [AliceToolsEnumArgument("--game-version")]
        GameVersion,
        /// <summary>
        /// Dump OJMP value.
        /// </summary>
        [AliceToolsEnumArgument("--ojmp")]
        OJMP,
        /// <summary>
        /// Dump decrypted .ain file.
        /// </summary>
        [AliceToolsEnumArgument("-d")]
        Decrypt,
        /// <summary>
        ///  Dump ain file map.
        /// </summary>
        [AliceToolsEnumArgument("--map")]
        Map,
        /// <summary>
        ///  Dump HLL files.
        /// </summary>
        [AliceToolsEnumArgument("--hll")]
        HLL

    }
}
