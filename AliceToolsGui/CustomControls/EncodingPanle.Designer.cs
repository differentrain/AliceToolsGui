// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


namespace AliceToolsGui.CustomControls
{
    partial class EncodingPanle
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
            this.RadioButtonCHS = new System.Windows.Forms.RadioButton();
            this.RadioButtonJP = new System.Windows.Forms.RadioButton();
            this.RadioButtonUTF8 = new System.Windows.Forms.RadioButton();
            this.RadioButtonCustom = new System.Windows.Forms.RadioButton();
            this.ComboBoxCustom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // RadioButtonCHS
            // 
            this.RadioButtonCHS.AutoSize = true;
            this.RadioButtonCHS.Location = new System.Drawing.Point(56, 5);
            this.RadioButtonCHS.Name = "RadioButtonCHS";
            this.RadioButtonCHS.Size = new System.Drawing.Size(47, 16);
            this.RadioButtonCHS.TabIndex = 0;
            this.RadioButtonCHS.TabStop = true;
            this.RadioButtonCHS.Text = "简中";
            this.RadioButtonCHS.UseVisualStyleBackColor = true;
            this.RadioButtonCHS.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonJP
            // 
            this.RadioButtonJP.AutoSize = true;
            this.RadioButtonJP.Location = new System.Drawing.Point(3, 5);
            this.RadioButtonJP.Name = "RadioButtonJP";
            this.RadioButtonJP.Size = new System.Drawing.Size(47, 16);
            this.RadioButtonJP.TabIndex = 2;
            this.RadioButtonJP.TabStop = true;
            this.RadioButtonJP.Text = "日文";
            this.RadioButtonJP.UseVisualStyleBackColor = true;
            this.RadioButtonJP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonUTF8
            // 
            this.RadioButtonUTF8.AutoSize = true;
            this.RadioButtonUTF8.Location = new System.Drawing.Point(109, 5);
            this.RadioButtonUTF8.Name = "RadioButtonUTF8";
            this.RadioButtonUTF8.Size = new System.Drawing.Size(53, 16);
            this.RadioButtonUTF8.TabIndex = 3;
            this.RadioButtonUTF8.TabStop = true;
            this.RadioButtonUTF8.Text = "UTF-8";
            this.RadioButtonUTF8.UseVisualStyleBackColor = true;
            this.RadioButtonUTF8.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // RadioButtonCustom
            // 
            this.RadioButtonCustom.AutoSize = true;
            this.RadioButtonCustom.Location = new System.Drawing.Point(168, 7);
            this.RadioButtonCustom.Name = "RadioButtonCustom";
            this.RadioButtonCustom.Size = new System.Drawing.Size(14, 13);
            this.RadioButtonCustom.TabIndex = 4;
            this.RadioButtonCustom.TabStop = true;
            this.RadioButtonCustom.UseVisualStyleBackColor = true;
            this.RadioButtonCustom.CheckedChanged += new System.EventHandler(this.RadioButtonCustom_CheckedChanged);
            // 
            // ComboBoxCustom
            // 
            this.ComboBoxCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBoxCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCustom.Enabled = false;
            this.ComboBoxCustom.FormattingEnabled = true;
            this.ComboBoxCustom.Location = new System.Drawing.Point(188, 3);
            this.ComboBoxCustom.Name = "ComboBoxCustom";
            this.ComboBoxCustom.Size = new System.Drawing.Size(148, 20);
            this.ComboBoxCustom.TabIndex = 5;
            this.ComboBoxCustom.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCustom_SelectedIndexChanged);
            // 
            // EncodingPanle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ComboBoxCustom);
            this.Controls.Add(this.RadioButtonCustom);
            this.Controls.Add(this.RadioButtonUTF8);
            this.Controls.Add(this.RadioButtonJP);
            this.Controls.Add(this.RadioButtonCHS);
            this.Name = "EncodingPanle";
            this.Size = new System.Drawing.Size(342, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RadioButtonCHS;
        private System.Windows.Forms.RadioButton RadioButtonJP;
        private System.Windows.Forms.RadioButton RadioButtonUTF8;
        private System.Windows.Forms.RadioButton RadioButtonCustom;
        private System.Windows.Forms.ComboBox ComboBoxCustom;
    }
}
