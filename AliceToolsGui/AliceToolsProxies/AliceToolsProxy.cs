// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the proxy of alice-tools to invoke it's console commands. 
    /// </summary>
    public sealed class AliceToolsProxy : IDisposable
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private readonly ProcessStartInfo _startInfo;


        /// <summary>
        /// Initializes a new instance of <see cref="AliceToolsProxy"/> class.
        /// </summary>
        /// <param name="aliceToolsPath">The path of alice-tools.</param>
        /// <exception cref="ArgumentException">
        /// The <paramref name="aliceToolsPath"/> to alice-tools does not exist.
        /// <para>- or -</para>
        /// The <paramref name="aliceToolsPath"/> to alice-tools can not be supported.
        /// </exception>
        /// <remarks>
        /// If <paramref name="aliceToolsPath"/> set to <c>null</c>,
        /// program will use relative path "alice".
        /// </remarks>
        public AliceToolsProxy(string aliceToolsPath = null)
        {
            _startInfo = EnsureAndCreateStartInfo(aliceToolsPath);
            if (!Test())
            {
                throw new ArgumentException("The path to alice-tools can not be supported.");
            }
        }

        /// <summary>
        /// Gets the absolute path of alice-tools.
        /// </summary>
        public string AliceToolsPath { get; private set; }

        /// <summary>
        /// Gets the absolute version of alice-tools.
        /// </summary>
        public Version Version { get; private set; }

        /// <summary>
        /// Returns a value indicates that if the specified alice-tools is available.
        /// </summary>
        /// <returns><c>true</c> if alice-tools is available; Otherwise, <c>false</c>.</returns>
        public bool Test()
        {
            try
            {
                AliceToolsOutput msg = InvokeAsync(GetVersionOperationInner.Default).Result;
                if (msg.State != AliceToolsState.Successful)
                {
                    return false;
                }
                Version version = VersionReaderInner.Defalut.Convert(msg);
                if (version == null)
                {
                    return false;
                }
                Version = version;
                AliceToolsPath = new FileInfo(_startInfo.FileName).FullName;
                return true;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                return false;
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        /// <summary>
        /// Invokes specified operation, and convert the output to the specified <typeparamref name="TOutput"/> by <paramref name="converter"/>.
        /// </summary>
        /// <typeparam name="TOutput">Output type.</typeparam>
        /// <param name="operation">The operation to be invoked.</param>
        /// <param name="converter">The convert for output convertion.</param>
        /// <param name="allowPartlySuccessful">Specifies that whether the <paramref name="converter"/> should convert the partly successful result.</param>
        /// <returns>The <typeparamref name="TOutput"/> result.</returns>
        /// <exception cref="ObjectDisposedException">This instance has been disposed.</exception>
        public async Task<TOutput> InvokeAsync<TOutput>(IAliceToolsOperation operation, AliceToolsOutputConverter<TOutput> converter, bool allowPartlySuccessful = false)
        {
            AliceToolsOutput output = await InvokeAsync(operation).ConfigureAwait(false);
            return await converter.ConvertAsync(output, allowPartlySuccessful).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes specified operation, and convert the output to the wapper of specified <typeparamref name="TOutput"/> by <paramref name="converter"/>.
        /// </summary>
        /// <typeparam name="TOutput">Output type.</typeparam>
        /// <param name="operation">The operation to be invoked.</param>
        /// <param name="converter">The convert for output convertion.</param>
        /// <returns>The wapper of <typeparamref name="TOutput"/> result.</returns>
        /// <exception cref="ObjectDisposedException">This instance has been disposed.</exception>
        public async Task<OutputConvertionResult<TOutput>> InvokeAsync<TOutput>(IAliceToolsOperation operation, AliceToolsOutputConverter<TOutput> converter)
        {
            AliceToolsOutput output = await InvokeAsync(operation).ConfigureAwait(false);
            return await converter.ConvertToWapperAsync(output).ConfigureAwait(false);
        }

        /// <summary>
        /// Invokes specified operation.
        /// </summary>
        /// <param name="operation">The operation to be invoked.</param>
        /// <returns>The invoking result.</returns>
        /// <exception cref="ObjectDisposedException">This instance has been disposed.</exception>
        public async Task<AliceToolsOutput> InvokeAsync(IAliceToolsOperation operation)
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException("AliceToolsProxy");
            }
            await _semaphore.WaitAsync();
            try
            {
                return await InvokeCoreAsync(operation, _startInfo).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Returns the path and the version of alice-tools.
        /// </summary>
        /// <returns>The path and the version of alice-tools</returns>
        public override string ToString() => $"alice-tools: \"{AliceToolsPath}\" ;  Version: {Version}";

        /// <summary>
        /// Shutdown alice-tools process invoked by this instance.
        /// </summary>
        public void Shutdown() => _processReader?.ShutDown();




        private async Task<AliceToolsOutput> InvokeCoreAsync(IAliceToolsOperation operation, ProcessStartInfo startInfo)
        {
            startInfo = EnsureOperationAndUpdateStartInfo(operation, startInfo);
            return await ProcessRunAsync(startInfo).ConfigureAwait(false);
        }

        private ProcessOutputReaderInner _processReader;

        private async Task<AliceToolsOutput> ProcessRunAsync(ProcessStartInfo startInfo)
        {
            var reader = new ProcessOutputReaderInner(startInfo);
            _processReader = reader;
            try
            {
                return await reader.ReadAsync().ConfigureAwait(false);
            }
            finally
            {
                _processReader = null;
            }
        }

        #region static members

        private static Encoding s_inputEncoding = null;
        private static Encoding s_outputEncoding = null;

        /// <summary>
        ///  Gets or set default input encoding.
        /// </summary>
        /// <exception cref="NotSupportedException">The Encoding instance set to this property does not have libiconv friendly name.</exception>
        /// <remarks>
        /// Some <see cref="Encoding"/> may not be supported,
        /// uses <see cref="AliceToolsProxiesExtensions.IsLibiconvSupported(Encoding)"/> extension method to check.
        /// <para>This property influences the initial value of <c>InputEncoding</c> of the class derived form <see cref="AliceFileOperation"/>.</para>
        /// </remarks>
        public static Encoding DefaultInputEncoding { get => s_inputEncoding; set => s_inputEncoding = value.EnsurePropertyEncoding(); }

        /// <summary>
        ///  Gets or set default output encoding.
        /// </summary>
        /// <exception cref="NotSupportedException">The Encoding instance set to this property does not have libiconv friendly name.</exception>
        /// <remarks>
        /// Some <see cref="Encoding"/> may not be supported,
        /// uses <see cref="AliceToolsProxiesExtensions.IsLibiconvSupported(Encoding)"/> extension method to check.
        /// <para>This property influences the initial value of <c>OutputEncoding</c> property of the class derived form <see cref="AliceFileOperation"/>.</para>
        /// </remarks>
        public static Encoding DefaultOutputEncoding { get => s_outputEncoding; set => s_outputEncoding = value.EnsurePropertyEncoding(); }

        #endregion

        #region private static members

        private static ProcessStartInfo EnsureAndCreateStartInfo(string aliceToolsPath)
        {
            if (string.IsNullOrWhiteSpace(aliceToolsPath))
            {
                aliceToolsPath = "alice.exe";
            }
            if (!File.Exists(aliceToolsPath))
            {
                throw new ArgumentException("aliceToolsPath does not exist.", nameof(aliceToolsPath));
            }
            Encoding outputEncoding = DefaultOutputEncoding ?? Encoding.UTF8;
            return new ProcessStartInfo(aliceToolsPath)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                StandardErrorEncoding = outputEncoding,
                StandardOutputEncoding = outputEncoding,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        private static ProcessStartInfo EnsureOperationAndUpdateStartInfo(IAliceToolsOperation operation, ProcessStartInfo startInfo)
        {
            string args = operation.EnsureArgumentNull(nameof(operation)).GetArguments();
            if (string.IsNullOrWhiteSpace(args))
            {
                throw new ArgumentException("The GetArguments() method of operation returns invalid arguments string.", nameof(operation));
            }
            startInfo.Arguments = args;
            Encoding outputEncoding = operation.OutputEncoding;
            if (outputEncoding != null)
            {
                startInfo.StandardErrorEncoding = startInfo.StandardOutputEncoding = outputEncoding;
            }
            return startInfo;
        }
        #endregion

        #region Dispose
        private bool _disposedValue;
        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Shutdown();
                    _semaphore.Dispose();
                }
                _disposedValue = true;
            }
        }
        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
