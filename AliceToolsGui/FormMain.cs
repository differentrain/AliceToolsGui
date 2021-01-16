// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AliceToolsGui.AliceToolsProxies;
using AliceToolsGui.AliceToolsProxies.Abstracts;
using AliceToolsGui.GithubRepoReleases;

namespace AliceToolsGui
{
    public partial class FormMain : Form
    {
        public static readonly Version MyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        private AliceToolsProxy _proxy;

        private readonly AliceToolsAcxBuild _acxBuild = new AliceToolsAcxBuild();
        private readonly AliceToolsAcxDump _acxDump = new AliceToolsAcxDump();

        private readonly AliceToolsAinDump _ainDump = new AliceToolsAinDump();
        private readonly AliceToolsAinEdit _ainEdit = new AliceToolsAinEdit();


        private readonly AliceToolsArExtract _arExtract = new AliceToolsArExtract();
        private readonly AliceToolsArList _arList = new AliceToolsArList();

        private readonly AliceToolsExDump _exDump = new AliceToolsExDump();
        private readonly AliceToolsExBuild _exBuild = new AliceToolsExBuild();

        private readonly AliceToolsRelease _atClient = new AliceToolsRelease();
        private readonly AliceToolsGuiRelease _atGClient = new AliceToolsGuiRelease();


        public FormMain()
        {


            InitializeComponent();
            EncodingPanleOutput.SetUTF8();
            LinkLabelAT.Links.Add(0, LinkLabelAT.Text.Length, @"https://haniwa.technology/alice-tools/");
            LinkLabelATG.Links.Add(0, LinkLabelATG.Text.Length, @"https://github.com/differentrain/AliceToolsGui");
            LabelATGVersion.Text = MyVersion.ToString(3);
            try
            {
                _proxy = new AliceToolsProxy();
                LabelATVersion.Text = _proxy.Version.ToString(3);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                TextBoxOutput.Text = "alice-tools不可用，点击更新栏的更新按钮尝试下载。\r\n";
                ContextMenuStripOutput.Enabled = GroupBoxEncoding.Enabled = TabControlMain.Enabled = false;
            }
#pragma warning restore CA1031 // Do not catch general exception types

        }

        private void EncodingPanleInput_EncodingChanged(object sender, Encoding e)
        {
            _acxBuild.InputEncoding = e;
            _acxDump.InputEncoding = e;
            _ainDump.InputEncoding = e;
            _ainEdit.InputEncoding = e;
            _arExtract.InputEncoding = e;
            _arList.InputEncoding = e;
            _exDump.InputEncoding = e;
            _exBuild.InputEncoding = e;
        }

        private void EncodingPanleOutput_EncodingChanged(object sender, Encoding e)
        {
            _acxBuild.OutputEncoding = e;
            _acxDump.OutputEncoding = e;
            _ainDump.OutputEncoding = e;
            _ainEdit.OutputEncoding = e;
            _arExtract.OutputEncoding = e;
            _arList.OutputEncoding = e;
            _exDump.OutputEncoding = e;
            _exBuild.OutputEncoding = e;
        }

        private void ToolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            TextBoxOutput.Text = $"alice-tools 版本：{_proxy.Version}\r\n";
        }

        private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxOutput.Text);
        }



        private void BackgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(() =>
            {
                if (TextBoxOutput.Text.Length > TextBoxOutput.MaxLength - 2000)
                {
                    TextBoxOutput.Text = string.Empty;
                }
            });

            try
            {
                (e.Argument as Action).Invoke();
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {
                Invoke(() => TextBoxOutput.Text += "意外的异常。\r\n");

#pragma warning restore CA1031 // Do not catch general exception types
            }


            Invoke(() =>
            {
                FolderBrowserDialogMain.SelectedPath = string.Empty;
                SaveFileDialogMain.FileName = string.Empty;
                ButtonCheckAT.Text = ButtonCheckATG.Text = "更新";
                ButtonShutdown.Visible = false;
                TextBoxOutput.Text += "******************\r\n";
                ButtonCheckAT.Enabled = true;
                ButtonCheckATG.Enabled = true;
                ClearTemp();
                if (ContextMenuStripOutput.Enabled == true)
                {
                    GroupBoxEncoding.Enabled = true;
                    TabControlMain.Enabled = true;
                    GroupBoxUpdate.Enabled = true;
                }
            });
        }

        private void TextBoxOutput_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxOutput.Text.Length > 1)
            {
                TextBoxOutput.Select(TextBoxOutput.Text.Length - 1, 0);
                TextBoxOutput.ScrollToCaret();
            }
        }


        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string).Dispose();
        }


        #region fucking visual studio always auto generates these event methods!

        private void PathBoxAcxCSV_PathChanged(object sender, string e)
        {
            PathBoxAcxCSVPathChangedCore();
        }

        private void PathBoxAr_PathChanged(object sender, string e)
        {
            PathBoxArPathChangedCore();
        }

        private void PathBoxAinSource_PathChanged(object sender, string e)
        {
            PathBoxAinSourcePathChangedCore();
        }

        private void PathBoxInputAin_PathChanged(object sender, string e)
        {
            PathBoxInputAinPathChangedCore();
        }

        private void PathExSource_PathChanged(object sender, string e)
        {
            PathExSourcePathChangedCore();
        }

        private void PathBoxEx_PathChanged(object sender, string e)
        {
            PathBoxExPathChangedCore();
        }

        #endregion


        private void ProcessAliceFile(AliceFileOperation op)
        {
            GroupBoxUpdate.Enabled = false;
            GroupBoxEncoding.Enabled = false;
            TabControlMain.Enabled = false;
            BackgroundWorkerMain.RunWorkerAsync(new Action(() =>
            {
                AliceFileOperationAsync(op).Wait();
            }));
        }

        private async Task AliceFileOperationAsync(AliceFileOperation op)
        {
            try
            {
                AliceToolsOutput output = await _proxy.InvokeAsync(op);
                switch (output.State)
                {
                    case AliceToolsState.Successful:
                        if (!string.IsNullOrWhiteSpace(output.Output))
                        {
                            Invoke(() => TextBoxOutput.Text += output.Output);
                        }
                        Invoke(() => TextBoxOutput.Text += "操作完成。\r\n");
                        break;
                    case AliceToolsState.PartlySuccessful:
                        if (!string.IsNullOrWhiteSpace(output.Output))
                        {
                            Invoke(() => TextBoxOutput.Text += output.Output);
                        }
                        if (string.IsNullOrWhiteSpace(output.FailReason))
                        {
                            Invoke(() => TextBoxOutput.Text += "错误：只完成了部分操作。");
                        }
                        else
                        {
                            Invoke(() => TextBoxOutput.Text += $"部分完成：{output.FailReason}");
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
                Invoke(() => TextBoxOutput.Text += "任务被取消，或发生了内部错误。\r\n");
            }
#pragma warning restore CA1031 // Do not catch general exception types


        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _proxy?.Dispose();
        }

        private void ButtonShutdown_Click(object sender, EventArgs e)
        {
            ButtonShutdown.Visible = false;
            _proxy.Shutdown();
        }


    }
}
