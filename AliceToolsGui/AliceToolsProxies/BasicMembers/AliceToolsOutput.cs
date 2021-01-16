// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the invoking state and output message returned by alice-tools.
    /// </summary>
    public sealed class AliceToolsOutput
    {
        internal AliceToolsOutput(AliceToolsState state, string output, string error)
        {
            State = state;
            Output = output;
            FailReason = error;
        }

        /// <summary>
        /// Gets a values shows the invoking result of alice-tools.
        /// </summary>
        public AliceToolsState State { get; }
        /// <summary>
        /// Gets the alice-tools output message.
        /// </summary>
        public string Output { get; }
        /// <summary>
        /// Gets the alice-tools error message.
        /// </summary>
        public string FailReason { get; }




    }
}
