// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AliceToolsGui.GithubRepoReleases
{
    internal sealed class StreamCopyerInner : IDisposable
    {
        private static readonly ConcurrentBag<byte[]> s_bytesPool = new ConcurrentBag<byte[]>();

        private bool _disposedValue;
        private Stream _stream;

        public StreamCopyerInner(Stream stream) => _stream = stream;


        public async Task CopyToAsync(Stream dest, CancellationToken cancellationToken)
        {

            byte[] buffer = s_bytesPool.TryTake(out byte[] bytes) ? bytes : new byte[81920];
            int bytesRead;
            try
            {
                while ((bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false)) != 0)
                {
                    await dest.WriteAsync(buffer, 0, bytesRead, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                s_bytesPool.Add(buffer);
            }
        }


        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _stream.Dispose();
                }
                _stream = null;
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
