// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;
using System.Text;

using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies.Abstracts
{
    /// <summary>
    /// Represents the file opertaion of alice-tools.
    /// </summary>
    public abstract class AliceFileOperation : IAliceToolsOperation
    {
        private Encoding _inputEncoding = AliceToolsProxy.DefaultInputEncoding;
        private Encoding _outputEncoding = AliceToolsProxy.DefaultOutputEncoding;

        /// <summary>
        /// Gets the alice file type used by this operation. 
        /// </summary>
        public abstract string FileType { get; }

        /// <summary>
        /// Gets the name of this operation. 
        /// </summary>
        public abstract string OperationName { get; }

        /// <summary>
        /// Gets or sets the input file path for this operation.
        /// </summary>
        public string InputPath { get; set; }

        /// <summary>
        ///  Gets or set the output encoding.
        /// </summary>
        /// <exception cref="NotSupportedException">The Encoding instance set to this property does not have libiconv friendly name.</exception>
        /// <remarks>
        /// Some <see cref="Encoding"/> may not be supported,
        /// uses <see cref="AliceToolsProxiesExtensions.IsLibiconvSupported(Encoding)"/> extension method to check.
        /// </remarks>
        public Encoding InputEncoding { get => _inputEncoding; set => _inputEncoding = value.EnsurePropertyEncoding(); }

        /// <summary>
        /// Gets or set the output encoding.
        /// </summary>
        /// <exception cref="NotSupportedException">The Encoding instance set to this property does not have libiconv friendly name.</exception>
        /// <remarks><inheritdoc/></remarks>
        public Encoding OutputEncoding { get => _outputEncoding; set => _outputEncoding = value.EnsurePropertyEncoding(); }

        /// <summary>
        /// Writes custom arguments to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The writer to wirte custom arguments.</param>
        protected abstract void WriteCustomArguments(ref AliceToolsArgumentsWriter writer);


        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">
        /// <see cref="FileType"/> or <see cref="OperationName"/> returns invalid value.
        /// <para>- or -</para>
        /// <see cref="InputPath"/> is not exist.
        /// </exception>
        public string GetArguments()
        {
            string.IsNullOrWhiteSpace(FileType).TrueThrowPropertyInvalidOperation(nameof(FileType));
            string.IsNullOrWhiteSpace(OperationName).TrueThrowPropertyInvalidOperation(nameof(OperationName));
            (!File.Exists(InputPath)).TrueThrowPropertyInvalidOperation(nameof(InputPath));

            var writer = new AliceToolsArgumentsWriter(fakeArgument: 0);
            StringBuilder sb = writer._innerStringBuilder;
            sb.Append(FileType).Append(' ').Append(OperationName).Append(' ');
            if (InputEncoding != null)
            {
                sb.Append("--input-encoding ").Append(InputEncoding.GetLibiconvFriendlyName()).Append(' ');
            }
            if (OutputEncoding != null)
            {
                sb.Append("--output-encoding ").Append(OutputEncoding.GetLibiconvFriendlyName()).Append(' ');
            }
            try
            {
                WriteCustomArguments(ref writer);
                return sb.Append(' ').Append(InputPath).ToString();
            }
            finally
            {
                writer.Release();
            }
        }





    }
}
