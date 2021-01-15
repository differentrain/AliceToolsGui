// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AliceToolsGui.AliceToolsProxies;

namespace AliceToolsGui
{
    partial class FormMain
    {
        private void PathBoxInputAin_PathChanged(object sender, string e)
        {
            if (string.IsNullOrWhiteSpace(PathBoxInputAin.Path))
            {
                ButtonAinDump.Enabled = ButtonAinEdit.Enabled = false;
                return;
            }
            ButtonAinDump.Enabled = true;
            ButtonAinEdit.Enabled = !string.IsNullOrWhiteSpace(PathBoxAinSource.Path);
        }

        private void PathBoxAinSource_PathChanged(object sender, string e)
        {
            if (string.IsNullOrWhiteSpace(PathBoxAinSource.Path))
            {
                ButtonAinEdit.Enabled = false;
                return;
            }
            ButtonAinEdit.Enabled = !string.IsNullOrWhiteSpace(PathBoxInputAin.Path);

            switch (PathBoxAinSource.Extension)
            {
                case ".jam":
                    if (!RadioButtonAinUpdateCode.Checked && !RadioButtonAinAppendCode.Checked)
                    {
                        RadioButtonAinUpdateCode.Tag = "set";
                        RadioButtonAinUpdateCode.Checked = true;
                        RadioButtonAinUpdateCode.Tag = null;
                    }
                    break;
                case ".json":
                    RadioButtonAinUpdateCode.Tag = "set";
                    RadioButtonAinUpdateJson.Checked = true;
                    RadioButtonAinUpdateCode.Tag = null;
                    break;
                case ".txt":
                    RadioButtonAinUpdateCode.Tag = "set";
                    RadioButtonAinUpdateText.Checked = true;
                    RadioButtonAinUpdateCode.Tag = null;
                    break;
                default:
                    break;
            }



        }

        private void RadioButtonAinUpdateCode_CheckedChanged(object sender, EventArgs e)
        {
            if (!(RadioButtonAinUpdateCode.Tag is string tag && "set".Equals(tag))
                && (PathBoxAinSource.Extension.Equals(".txt") || PathBoxAinSource.Extension.Equals(".json")))
            {
                PathBoxAinSource.SetDefault();
                ButtonAinEdit.Enabled = false;
            }
        }

        private void RadioButtonAinUpdateJson_CheckedChanged(object sender, EventArgs e)
        {
            if (!(RadioButtonAinUpdateCode.Tag is string tag && "set".Equals(tag)))
            {
                PathBoxAinSource.SetDefault();
                ButtonAinEdit.Enabled = false;
            }
        }

        private void RadioButtonAinUpdateText_CheckedChanged(object sender, EventArgs e)
        {
            if (!(RadioButtonAinUpdateCode.Tag is string tag && "set".Equals(tag)))
            {
                PathBoxAinSource.SetDefault();
                ButtonAinEdit.Enabled = false;
            }
        }

        private void RadioButtonAinAppendCode_CheckedChanged(object sender, EventArgs e)
        {
            if (PathBoxAinSource.Extension.Equals(".txt") || PathBoxAinSource.Extension.Equals(".json"))
            {
                PathBoxAinSource.SetDefault();
                ButtonAinEdit.Enabled = false;
            }
        }


        private void ButtonAinDump_Click(object sender, EventArgs e)
        {
            if (RadioButtonAinCode.Checked)
            {
                _ainDump.Option = AliceToolsAinDumpOption.Code;
                SaveFileDialogMain.Filter = "Ain源码 (*.jam)|*.jam|所有文件 (*.*)|*.*";
            }
            else if (RadioButtonAinJson.Checked)
            {
                _ainDump.Option = AliceToolsAinDumpOption.Json;
                SaveFileDialogMain.Filter = "JSON文件 (*.json)|*.json";
            }
            else if (RadioButtonAinText.Checked)
            {
                _ainDump.Option = AliceToolsAinDumpOption.Text;
                SaveFileDialogMain.Filter = "文本文件 (*.txt)|*.txt";
            }

            if (SaveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                TextBoxOutput.Text += "开始提取Ain文件...";
                _ainDump.InputPath = PathBoxInputAin.Path;
                _ainDump.Output = SaveFileDialogMain.FileName;
                ProcessAliceFile(_ainDump);
            }
        }

        private void ButtonAinEdit_Click(object sender, EventArgs e)
        {
            SaveFileDialogMain.Filter = "Ain文件 (*.ain)|*.ain";
            if (SaveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                TextBoxOutput.Text += "开始建立新的AIN文件...";
                _ainEdit.InputPath = PathBoxInputAin.Path;
                _ainEdit.Source = PathBoxAinSource.Path;
                _ainEdit.OutputPath = SaveFileDialogMain.FileName;
                if (RadioButtonAinUpdateCode.Checked)
                {
                    _ainEdit.SourceType = AliceToolsAinSourceType.UpdatesCode;
                }
                else if (RadioButtonAinAppendCode.Checked)
                {
                    _ainEdit.SourceType = AliceToolsAinSourceType.AppendCode;
                }
                else if (RadioButtonAinUpdateJson.Checked)
                {
                    _ainEdit.SourceType = AliceToolsAinSourceType.UpdatesJson;
                }
                else if (RadioButtonAinUpdateText.Checked)
                {
                    _ainEdit.SourceType = AliceToolsAinSourceType.UpdatesText;
                }
                ProcessAliceFile(_ainEdit);
            }
        }

    }
}
