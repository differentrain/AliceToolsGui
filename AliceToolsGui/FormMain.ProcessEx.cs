// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;

namespace AliceToolsGui
{
    partial class FormMain
    {
        private void PathBoxExPathChangedCore()
        {
            if (string.IsNullOrWhiteSpace(PathBoxEx.Path))
            {
                ButtonExDump.Enabled = false;
                return;
            }
            ButtonExDump.Enabled = true;
        }

        private void PathExSourcePathChangedCore()
        {
            if (string.IsNullOrWhiteSpace(PathExSource.Path))
            {
                ButtonExBuild.Enabled = false;
                return;
            }
            ButtonExBuild.Enabled = true;

        }

        private void ButtonExDump_Click(object sender, EventArgs e)
        {
            bool isInvoke = false;

            if (CheckBoxExSplite.Checked)
            {
                if (FolderBrowserDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fi = new FileInfo(PathBoxEx.Path);
                    _exDump.Split = true;
                    _exDump.OutputPath = $@"{FolderBrowserDialogMain.SelectedPath}\{fi.Name}.mx";
                    isInvoke = true;
                }
            }
            else
            {
                SaveFileDialogMain.Filter = "ex源码 (*.x)|*.x|所有文件 (*.*)|*.*";
                if (SaveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _exDump.Split = false;
                    _exDump.OutputPath = SaveFileDialogMain.FileName;
                    isInvoke = true;
                }
            }

            if (isInvoke)
            {
                _exDump.InputPath = PathBoxEx.Path;
                TextBoxOutput.Text = $"开始提取Ex文件...";
                ProcessAliceFile(_exDump);
            }
        }

        private void ButtonExBuild_Click(object sender, EventArgs e)
        {
            SaveFileDialogMain.Filter = "Ex文件 (*.ex)|*.ex";
            if (SaveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxOutput.Text = "开始生成Ex文件...";
                _exBuild.InputPath = PathExSource.Path;
                _exBuild.OutputPath = SaveFileDialogMain.FileName;
                _exBuild.IsOldGame = CheckBoxExOld.Checked;
                ProcessAliceFile(_exBuild);
            }
        }
    }
}
