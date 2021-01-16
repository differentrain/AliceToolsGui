// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AliceToolsGui.CustomControls
{
    public partial class PathBox : UserControl
    {
        private static readonly Regex s_regex = new Regex(@"(?<=[\(;]\*)\.[*A-Za-z0-9]+(?=;|\))", RegexOptions.Singleline | RegexOptions.Compiled);

        private readonly List<string> _filters = new List<string>(32);
        private bool _allowAllFile = true;
        private string _pathTemp;

        public PathBox()
        {
            InitializeComponent();
            SetDefault();
        }

        public event EventHandler<string> PathChanged;

        public string Path { get; private set; }

        public string Extension { get; private set; }

        public string Filter
        {
            get => OpenFileDialogMain.Filter;
            set
            {
                OpenFileDialogMain.Filter = value;
                MatchCollection matches = s_regex.Matches(value);
                _allowAllFile = false;
                _filters.Clear();
                for (int i = 0; i < matches.Count; i++)
                {
                    string matchValue = matches[i].Value;
                    if (matchValue.Equals(".*"))
                    {
                        _allowAllFile = true;
                    }
                    else
                    {
                        _filters.Add(matchValue.ToLower());
                    }
                }


            }
        }

        private void TextBoxPath_DragEnter(object sender, DragEventArgs e)
        {
            SetDefault();
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files.Length != 1)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            try
            {
                var fi = new FileInfo(files[0]);
                string ex = fi.Extension.ToLower();
                if (!fi.Exists ||
                    (!_allowAllFile && !_filters.Contains(ex)))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                e.Effect = DragDropEffects.Link;
                _pathTemp = fi.FullName;
                TextBoxPath.Text = "松开鼠标以确认。";
                Extension = ex;

            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
            {

                e.Effect = DragDropEffects.None;
                PathChanged?.Invoke(this, Path);
            }
#pragma warning restore CA1031 // Do not catch general exception types
        }

        private void TextBoxPath_DragDrop(object sender, DragEventArgs e)
        {
            if (_pathTemp != null)
            {
                TextBoxPath.Text = Path = _pathTemp;
                _pathTemp = null;
                PathChanged?.Invoke(this, Path);
            }

        }

        private void TextBoxPath_DoubleClick(object sender, EventArgs e)
        {
            if (OpenFileDialogMain.ShowDialog() != DialogResult.OK)
            {
                SetDefault();
            }
            else
            {
                TextBoxPath.Text = Path = OpenFileDialogMain.FileName;
                var fi = new FileInfo(Path);
                Extension = fi.Extension.ToLower();

            }

            PathChanged?.Invoke(this, Path);
        }

        public void SetDefault(bool riseEnvet = false)
        {
            Path = _pathTemp = Extension = null;
            TextBoxPath.Text = "拖拽文件到这里/双击选择文件";
            if (riseEnvet)
            {
                PathChanged?.Invoke(this, Path);
            }
        }

        private void TextBoxPath_DragLeave(object sender, EventArgs e)
        {
            SetDefault();
        }
    }
}
