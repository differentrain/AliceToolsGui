// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.AliceToolsProxies.InternalMembers;

namespace AliceToolsGui.AliceToolsProxies
{
    /// <summary>
    /// Represents the edit operation of .ain files.
    /// </summary>
    public class AliceToolsAinEdit : AliceAinFileOperation
    {
        private AliceToolsAinSourceType _sourceType = AliceToolsAinSourceType.UpdatesText;

        private Encoding _transCode;

        /// <inheritdoc/>
        public override string OperationName => "edit";

        /// <summary>
        /// Output file path;
        /// <para>Or represents the ain file version if <see cref="SourceType"/> is <see cref="AliceToolsAinSourceType.UpdatesAinVersion"/>.</para>
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// If <see cref="SourceType"/> is <see cref="AliceToolsAinSourceType.UpdatesAinVersion"/>, this value should be a numeric string betweens 4-12;
        /// <para>Otherwrise, this value is regarded as the path of source code.</para>
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the type of <see cref="Source"/>.
        /// </summary>
        public AliceToolsAinSourceType SourceType
        {
            get => _sourceType; set
            {
                if (value < AliceToolsAinSourceType.UpdatesCode ||
                    value > AliceToolsAinSourceType.UpdatesAinVersion)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _sourceType = value;
            }
        }

        /// <summary>
        /// Get a value shows that if run in silent mode. (No output.)
        /// </summary>
        public bool Silent { get; set; }

        /// <summary>
        /// Change the .ain file's text encoding.
        /// </summary>
        public Encoding TransCode { get => _transCode; set => _transCode = value.EnsurePropertyEncoding(); }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {
            string.IsNullOrWhiteSpace(OutputPath).TrueThrowPropertyInvalidOperation(nameof(OutputPath));

            bool throwSource = SourceType == AliceToolsAinSourceType.UpdatesAinVersion ?
                                            (!int.TryParse(Source, out int version) || version < 4 || version > 12) :
                                            !File.Exists(Source);
            throwSource.TrueThrowPropertyInvalidOperation(nameof(Source));

            if (Silent)
            {
                writer.Write("--silent");
            }
            if (TransCode != null)
            {
                writer.Write($"--transcode {TransCode.GetLibiconvFriendlyName()}");
            }

            writer.Write(SourceType);
            writer.Write($"{Source}");
            writer.Write($"-o {OutputPath}");
        }
    }

}
