// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AliceToolsGui.AliceToolsProxies;

namespace AliceToolsGui
{
    partial class FormMain
    {
        private void PathBoxArPathChangedCore()
        {
            ListBoxArItems.Items.Clear();
            ButtonArExtract.Enabled = false;
            if (string.IsNullOrWhiteSpace(PathBoxAr.Path))
            {
                ButtonArExtractAll.Enabled = ButtonArList.Enabled = false;
                return;
            }
            ButtonArExtractAll.Enabled = ButtonArList.Enabled = true;
        }

        private void ListBoxArItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxArItems.SelectedIndex >= 0)
            {
                ButtonArExtract.Enabled = true;
                return;
            }
            ButtonArExtract.Enabled = false;
        }

        private void ButtonArExtractAll_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _arExtract.InputPath = PathBoxAr.Path;
                TextBoxOutput.Text += $"开始提取所有文件...\r\n";
                _arExtract.TargetItem = null;
                _arExtract.Options = AliceToolsArExtractOptions.Default;
                if (CheckBoxArForce.Checked)
                {
                    _arExtract.Options |= AliceToolsArExtractOptions.Force;
                }
                if (CheckBoxArImg.Checked)
                {
                    _arExtract.Options |= AliceToolsArExtractOptions.ImagesOnly;
                }
                if (CheckBoxArRaw.Checked)
                {
                    _arExtract.Options |= AliceToolsArExtractOptions.Raw;
                }
 
                _arExtract.OutputPath = FolderBrowserDialogMain.SelectedPath;
                ButtonShutdown.Visible = true;
                ProcessAliceFile(_arExtract);
            }


        }

        private void ButtonArExtract_Click(object sender, EventArgs e)
        {
            _arExtract.TargetItem = ListBoxArItems.SelectedItem as AliceArchiveItem;
            _arExtract.Options = AliceToolsArExtractOptions.Force;
            SaveFileDialogMain.Filter = "所有文件 (*.*)|*.*";
            SaveFileDialogMain.FileName = _arExtract.TargetItem.FileName;
            if (SaveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _arExtract.InputPath = PathBoxAr.Path;
                TextBoxOutput.Text += $"开始提取 {_arExtract.TargetItem.FileName} ...\r\n";
                _arExtract.OutputPath = SaveFileDialogMain.FileName;
                ProcessAliceFile(_arExtract);
            }
        }

        private void ButtonArList_Click(object sender, EventArgs e)
        {
            GroupBoxUpdate.Enabled = false;
            GroupBoxEncoding.Enabled = false;
            TabControlMain.Enabled = false;
            _arList.InputPath = PathBoxAr.Path;
            ListBoxArItems.Items.Clear();
            TextBoxOutput.Text += $"开始加载文件列表...\r\n";
            BackgroundWorkerMain.RunWorkerAsync(new Action(() =>
            {
                GetArList().Wait();
            }));
        }


        private async Task GetArList()
        {
            try
            {
                AliceToolsOutput output = await _proxy.InvokeAsync(_arList).ConfigureAwait(false);
                switch (output.State)
                {
                    case AliceToolsState.Successful:
                        List<AliceArchiveItem> list = await AliceArchiveItemConverter.Default.ConvertAsync(output.Output).ConfigureAwait(false);
                        Invoke(() =>
                        {
                            ListBoxArItems.Items.AddRange(list.ToArray());
                            TextBoxOutput.Text += "操作完成。\r\n";
                        });
                        break;
                    case AliceToolsState.PartlySuccessful:
                        if (!string.IsNullOrWhiteSpace(output.Output))
                        {
                            List<AliceArchiveItem> part = await AliceArchiveItemConverter.Default.ConvertAsync(output.Output).ConfigureAwait(false);
                            Invoke(() =>
                            {
                                ListBoxArItems.Items.AddRange(part.ToArray());
                                TextBoxOutput.Text += $"操作部分完成。{output.FailReason}";
                            });
                        }
                        break;
                    case AliceToolsState.Fail:
                        Invoke(() => TextBoxOutput.Text += $"错误：{output.FailReason}");
                        break;
                    case AliceToolsState.NotRunning:
                        Invoke(() => TextBoxOutput.Text += "错误：无法启动alice-tools.\r\n");
                        break;
                    default:
                        Invoke(() => TextBoxOutput.Text += "错误：意外的错误，请联系PU树脂哈尼。\r\n");
                        break;
                }
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch 
            {
                Invoke(() => TextBoxOutput.Text += "错误：发生了内部错误。\r\n");
            }
#pragma warning restore CA1031 // Do not catch general exception types


        }

    }
}
