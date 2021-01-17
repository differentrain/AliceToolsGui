// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AliceToolsGui.AliceToolsProxies.InternalMembers
{
    internal sealed class ProcessOutputReaderInner : IDisposable
    {
        private static readonly ConcurrentBag<StringBuilder> s_sbPool = new ConcurrentBag<StringBuilder>();

        private Process _process;
        private StringBuilder _sbOutput;
        private StringBuilder _sbError;
        private ProcessState _state;
        private bool _stopValue;

        public ProcessOutputReaderInner(ProcessStartInfo startInfo)
        {
            _process = new Process
            {
                StartInfo = startInfo,
                EnableRaisingEvents = true
            };
            _process.ErrorDataReceived += Process_ErrorDataReceived;
            _process.OutputDataReceived += Process_OutputDataReceived;
            _process.Exited += Process_Exited;

            _sbOutput = s_sbPool.TryTake(out StringBuilder sbO) ? sbO : new StringBuilder(81920);
            _sbError = s_sbPool.TryTake(out StringBuilder sbE) ? sbE : new StringBuilder(81920);
        }


        public async Task<AliceToolsOutput> ReadAsync()
        {
            Process process = _process;

            if (!process.Start())
            {
                return await CreateOutputMessageAsync(AliceToolsState.NotRunning, null, "alice-tools have not run.").ConfigureAwait(false);
            }
            _stopValue = false;
            _state = ProcessState.Start;
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await Task.Run(() =>
            {
                int i = 0;
                while (!_stopValue && _state < (ProcessState.StopError | ProcessState.StopOutput))
                {
                    Thread.Sleep(100);
                    if (_state == ProcessState.Start && _sbOutput.Length == 0 && _sbError.Length == 0)
                    {
                        i += 100;
                        if (i > 10000)
                        {
                            break;
                        }
                    }
                }
            }).ConfigureAwait(false);

            if (!process.HasExited || _state != (ProcessState.StopError | ProcessState.StopOutput | ProcessState.Exited))
            {
                ShutDown();
                return await CreateOutputMessageAsync(AliceToolsState.UnknowException, null, "Unknow exception.").ConfigureAwait(false);
            }

            string output = _sbOutput.ToString();
            string error = _sbError.ToString();

            if (!string.IsNullOrEmpty(output))
            {
                if (process.ExitCode != 0 || !string.IsNullOrWhiteSpace(error))
                {
                    return await CreateErrorAsync(error, AliceToolsState.PartlySuccessful, output).ConfigureAwait(false);
                }
                return await CreateOutputMessageAsync(AliceToolsState.Successful, output).ConfigureAwait(false);
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                if (process.ExitCode == 0)
                {
                    return await CreateErrorAsync(error, AliceToolsState.PartlySuccessful, output).ConfigureAwait(false);
                }
                return await CreateErrorAsync(error, AliceToolsState.Fail).ConfigureAwait(false);
            }
            if (process.ExitCode == 0)
            {
                return await CreateOutputMessageAsync(AliceToolsState.Successful, string.Empty).ConfigureAwait(false);
            }
            return await CreateOutputMessageAsync(AliceToolsState.UnknowException, null, "Unknow exception.").ConfigureAwait(false);
        }


        public void ShutDown()
        {
            try
            {
                if (_process != null && !_process.HasExited)
                {
                    _process.Kill();
                    _process.CancelOutputRead();
                    _process.CancelErrorRead();
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch { }
#pragma warning restore CA1031 // Do not catch general exception types
            _stopValue = true;
        }


        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                _sbOutput.Append(e.Data).Append("\r\n");
            }
            else
            {
                _state |= ProcessState.StopOutput;
                try
                {
                    _process.CancelOutputRead();
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch { }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                _sbError.Append(e.Data).Append("\r\n");
            }
            else
            {
                _state |= ProcessState.StopError;
                try
                {
                    _process.CancelErrorRead();
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch { }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }


        private void Process_Exited(object sender, EventArgs e)
        {
            _state |= ProcessState.Exited;
        }

        private bool _disposedValue;
        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    ShutDown();
                    _process.Exited -= Process_Exited;
                    _process.ErrorDataReceived -= Process_ErrorDataReceived;
                    _process.OutputDataReceived -= Process_OutputDataReceived;
                    _process.Dispose();
                    s_sbPool.Add(_sbOutput.Clear());
                    s_sbPool.Add(_sbError.Clear());
                }
                _sbOutput = _sbError = null;
                _process = null;
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }



        private static async Task<AliceToolsOutput> CreateOutputMessageAsync(AliceToolsState state, string msg = null, string error = null) =>
                         await Task.FromResult(new AliceToolsOutput(state, msg, error)).ConfigureAwait(false);


        private static async Task<AliceToolsOutput> CreateErrorAsync(string error, AliceToolsState state, string msg = null) =>
           await CreateOutputMessageAsync(state, msg, error).ConfigureAwait(false);


        [Flags]
        private enum ProcessState
        {
            Start = 0,
            StopOutput = 1,
            StopError = 2,
            Exited = 4
        }

    }
}
