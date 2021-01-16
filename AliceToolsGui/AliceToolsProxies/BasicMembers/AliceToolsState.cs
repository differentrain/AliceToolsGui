// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represent the invoking result of alice-tools.
    /// </summary>
    public enum AliceToolsState
    {
        /// <summary>
        /// Successful.
        /// </summary>
        Successful,
        /// <summary>
        /// Partly successful.
        /// </summary>
        PartlySuccessful,
        /// <summary>
        /// alice-tools returns error.
        /// </summary>
        Fail,
        /// <summary>
        /// alice-tools have not run.
        /// </summary>
        NotRunning,
        /// <summary>
        /// Unknow exception.
        /// </summary>
        UnknowException
    }
}
