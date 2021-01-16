// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// A wapper for <typeparamref name="TOutput"/>, with error message.
    /// </summary>
    /// <typeparam name="TOutput"></typeparam>
    public sealed class OutputConvertionResult<TOutput>
    {

        internal OutputConvertionResult(TOutput data, string additionalInfo = null)
        {
            Data = data;
            AdditionalInfo = additionalInfo;
            PartlySuccess = string.IsNullOrEmpty(additionalInfo);

        }

        /// <summary>
        /// Gets a value represents that if <see cref="AliceToolsOutput.State"/> is <see cref="AliceToolsState.PartlySuccessful"/>. 
        /// </summary>
        public bool PartlySuccess { get; }

        /// <summary>
        /// Gets the converted <typeparamref name="TOutput"/> data.
        /// </summary>
        public TOutput Data { get; }
        /// <summary>
        /// Gets a <see cref="string"/> represents additional error infoamtion when <see cref="PartlySuccess"/> returns <c>true</c>.
        /// </summary>
        public string AdditionalInfo { get; }

    }
}
