// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

using AliceToolsGui.AliceToolsProxies.Abstracts;

namespace AliceToolsGui
{
    partial class FormMain
    {
        private void PathBoxAcxCSVPathChangedCore()
        {

            if (PathBoxAcxCSV.Path == null)
            {
                ButtonAcxConvert.Enabled = false;
                return;
            }
            ButtonAcxConvert.Enabled = true;
            RadioButtonAcx2Csv.Tag = "set";
            if (PathBoxAcxCSV.Extension.Equals(".acx"))
            {
                RadioButtonAcx2Csv.Checked = true;
            }
            else
            {
                RadioButtonCsv2Acx.Checked = true;
            }
            RadioButtonAcx2Csv.Tag = null;
        }

        private void RadioButtonAcx2Csv_CheckedChanged(object sender, EventArgs e)
        {
            if (!(RadioButtonAcx2Csv.Tag is string tag && "set".Equals(tag)))
            {
                PathBoxAcxCSV.SetDefault();
                ButtonAcxConvert.Enabled = false;
            }
        }

        private void ButtonAcxConvert_Click(object sender, EventArgs e)
        {
            AliceFileOperation op;
            string tips;
            if (RadioButtonAcx2Csv.Checked)
            {
                tips = "开始将Acx文件转为CSV文件...\r\n";
                SaveFileDialogMain.Filter = "CSV文件 (*.csv)|*.csv";
                _acxDump.InputPath = PathBoxAcxCSV.Path;
                op = _acxDump;

            }
            else
            {
                tips = "开始将CSV文件转为Acx文件...\r\n";
                SaveFileDialogMain.Filter = "ACX文件 (*.acx)|*.acx";
                _acxBuild.InputPath = PathBoxAcxCSV.Path;
                op = _acxBuild;
            }

            if (SaveFileDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxOutput.Text += tips;
                _acxDump.OutputPath = _acxBuild.OutputPath = SaveFileDialogMain.FileName;

                ProcessAliceFile(op);
            }



        }



    }
}
