// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies.Abstracts
{
    /// <summary>
    /// Provides members to convert the output message of alice-tools to specified <typeparamref name="TOutput"/>
    /// </summary>
    /// <typeparam name="TOutput">The <typeparamref name="TOutput"/> to be converted from message.</typeparam>
    public abstract class AliceToolsOutputConverter<TOutput>
    {
        /// <summary>
        /// Converts <paramref name="message"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="message">The message to be converted.</param>
        /// <returns>The <typeparamref name="TOutput"/> result of convertion.</returns>
        protected abstract TOutput ConvertCore(string message);

        /// <summary>
        ///  Converts <paramref name="message"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="message">The message to be converted.</param>
        /// <exception cref="ArgumentException"><paramref name="message"/> is null or empty or only contains white space.</exception>
        /// <returns>The <typeparamref name="TOutput"/> result of convertion.</returns>
        public TOutput Convert(string message) => ConvertCore(message.EnsureArgumentNullOrWhiteSpace(nameof(message)));

        /// <summary>
        ///  Converts <paramref name="message"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="message">The message to be converted.</param>
        /// <exception cref="ArgumentException"><paramref name="message"/> is null or empty or only contains white space.</exception>
        /// <returns>The <typeparamref name="TOutput"/> result of convertion.</returns>
        public async Task<TOutput> ConvertAsync(string message) => await Task.Run(() => ConvertCore(message.EnsureArgumentNullOrWhiteSpace(nameof(message))));

        /// <summary>
        /// Converts <paramref name="outputResult"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="outputResult">The original output message to be converted.</param>
        /// <param name="allowPartlySuccessful">Specifies if this convert allows partly successful result.</param>
        /// <exception cref="ArgumentNullException"><paramref name="outputResult"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <paramref name="outputResult"/> can not be converted.</exception>
        /// <returns>The <typeparamref name="TOutput"/> result of convertion.</returns>
        public TOutput Convert(AliceToolsOutput outputResult, bool allowPartlySuccessful = false)
        {
            outputResult.EnsureArgumentNull(nameof(outputResult));
            switch (outputResult.State)
            {
                case AliceToolsState.Successful:
                    return Convert(outputResult.Output);
                case AliceToolsState.PartlySuccessful:
                    return allowPartlySuccessful ? Convert(outputResult.Output) : throw CreateException(outputResult);
                default:
                    throw CreateException(outputResult);
            }
        }

        /// <summary>
        /// Converts <paramref name="outputResult"/> to <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="outputResult">The original output message to be converted.</param>
        /// <param name="allowPartlySuccessful">Specifies if this convert allows partly successful result.</param>
        /// <exception cref="ArgumentNullException"><paramref name="outputResult"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <paramref name="outputResult"/> can not be converted.</exception>
        /// <returns>The <typeparamref name="TOutput"/> result of convertion.</returns>
        public async Task<TOutput> ConvertAsync(AliceToolsOutput outputResult, bool allowPartlySuccessful = false) =>
                                    await Task.Run(() => Convert(outputResult, allowPartlySuccessful)).ConfigureAwait(false);

        /// <summary>
        /// Converts <paramref name="outputResult"/> to <typeparamref name="TOutput"/> wrapped by <see cref="OutputConvertionResult{TOutput}"/>.
        /// </summary>
        /// <param name="outputResult">The original output message to be converted.</param>
        /// <returns>The wrapper of <typeparamref name="TOutput"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="outputResult"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <paramref name="outputResult"/> can not be converted.</exception>
        public OutputConvertionResult<TOutput> ConvertToWapper(AliceToolsOutput outputResult)
        {
            outputResult.EnsureArgumentNull(nameof(outputResult));
            switch (outputResult.State)
            {
                case AliceToolsState.Successful:
                case AliceToolsState.PartlySuccessful:
                    return new OutputConvertionResult<TOutput>(Convert(outputResult.Output), outputResult.FailReason);
                default:
                    throw CreateException(outputResult);
            }
        }

        /// <summary>
        /// Converts <paramref name="outputResult"/> to <typeparamref name="TOutput"/> wrapped by <see cref="OutputConvertionResult{TOutput}"/>.
        /// </summary>
        /// <param name="outputResult">The original output message to be converted.</param>
        /// <returns>The wrapper of <typeparamref name="TOutput"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="outputResult"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <paramref name="outputResult"/> can not be converted.</exception>
        public async Task<OutputConvertionResult<TOutput>> ConvertToWapperAsync(AliceToolsOutput outputResult) =>
                 await Task.Run(() => ConvertToWapper(outputResult)).ConfigureAwait(false);


        private InvalidOperationException CreateException(AliceToolsOutput outputResult)
        {
            string tips = outputResult.State == AliceToolsState.PartlySuccessful ? "Only partly successful" : "Error";
            return new InvalidOperationException($"{tips}: {outputResult.FailReason}");
        }


    }
}
