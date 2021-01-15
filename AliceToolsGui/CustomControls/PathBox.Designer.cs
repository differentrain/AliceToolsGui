// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace AliceToolsGui.CustomControls
{
    partial class PathBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenFileDialogMain
            // 
            this.OpenFileDialogMain.Filter = "所有文件 (*.*)|*.*";
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.AllowDrop = true;
            this.TextBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPath.Location = new System.Drawing.Point(0, 0);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.ReadOnly = true;
            this.TextBoxPath.Size = new System.Drawing.Size(461, 21);
            this.TextBoxPath.TabIndex = 0;
            this.TextBoxPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxPath_DragDrop);
            this.TextBoxPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxPath_DragEnter);
            this.TextBoxPath.DragLeave += new System.EventHandler(this.TextBoxPath_DragLeave);
            this.TextBoxPath.DoubleClick += new System.EventHandler(this.TextBoxPath_DoubleClick);
            // 
            // PathBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.TextBoxPath);
            this.Name = "PathBox";
            this.Size = new System.Drawing.Size(461, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialogMain;
        private System.Windows.Forms.TextBox TextBoxPath;
    }
}
