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
    /// Represents the extract operation of alice archive files..
    /// </summary>
    public class AliceToolsArExtract : AliceArFileOperation
    {
        private AliceToolsArExtractOptions _options = AliceToolsArExtractOptions.Default;

        /// <inheritdoc/>
        public override string OperationName => "extract";

        /// <summary>
        /// Output file or directory path. 
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// Gets or sets the item to be extracted.
        /// </summary>
        /// <remarks>
        /// Extracts all item in archive if this value set to <c>null</c>.
        /// </remarks>
        public AliceArchiveItem TargetItem { get; set; }

        /// <summary>
        /// Gets or set the table of contents file.
        /// </summary>
        public string TOC { get; set; }

        /// <summary>
        /// Gets or sets the options for archive files operation. 
        /// </summary>
        public AliceToolsArExtractOptions Options
        {
            get => _options;
            set
            {
                const AliceToolsArExtractOptions all = AliceToolsArExtractOptions.Default | AliceToolsArExtractOptions.Raw |
                                                       AliceToolsArExtractOptions.Png | AliceToolsArExtractOptions.WebP |
                                                       AliceToolsArExtractOptions.Force | AliceToolsArExtractOptions.ImagesOnly;

                if (value < AliceToolsArExtractOptions.Default || value > all)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                if (value.HasFlag(AliceToolsArExtractOptions.Raw))
                {
                    if (value.HasFlag(AliceToolsArExtractOptions.Png) ||
                        value.HasFlag(AliceToolsArExtractOptions.WebP))
                    {
                        throw new InvalidOperationException("AliceToolsArExtractOptions.Raw can not be set with AliceToolsArExtractOptions.Png or AliceToolsArExtractOptions.WebP");
                    }
                }
                else if (value.HasFlag(AliceToolsArExtractOptions.Png | AliceToolsArExtractOptions.WebP))
                {
                    throw new InvalidOperationException("AliceToolsArExtractOptions.Png can not be set with AliceToolsArExtractOptions.WebP.");
                }
                _options = value;
            }
        }

        /// <inheritdoc/>
        protected override void WriteCustomArguments(ref AliceToolsArgumentsWriter writer)
        {

            if (Options.HasFlag(AliceToolsArExtractOptions.ImagesOnly) && TargetItem != null)
            {
                throw new InvalidOperationException("AliceToolsArExtractOptions.ImagesOnly is set when TargetItem is not null.");
            }
            writer.Write(Options);
            if (TargetItem != null)
            {
                writer.Write($"-i {TargetItem.Index} ");
            }
            if (!string.IsNullOrWhiteSpace(OutputPath))
            {
                writer.Write($"-o {OutputPath}");
            }

            if (TOC != null)
            {
               File.Exists(TOC).TrueThrowPropertyInvalidOperation(nameof(TOC));
                writer.Write($"--toc {TOC}");
            }
        }
    }

}
