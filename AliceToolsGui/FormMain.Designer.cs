
namespace AliceToolsGui
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupBoxEncoding = new System.Windows.Forms.GroupBox();
            this.TextBoxOutput = new System.Windows.Forms.TextBox();
            this.ContextMenuStripOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxAinPath = new System.Windows.Forms.GroupBox();
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageAin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBoxAinTranscode = new System.Windows.Forms.CheckBox();
            this.RadioButtonAinAppendCode = new System.Windows.Forms.RadioButton();
            this.ButtonAinEdit = new System.Windows.Forms.Button();
            this.RadioButtonAinUpdateText = new System.Windows.Forms.RadioButton();
            this.RadioButtonAinUpdateJson = new System.Windows.Forms.RadioButton();
            this.RadioButtonAinUpdateCode = new System.Windows.Forms.RadioButton();
            this.GroupBoxAinDump = new System.Windows.Forms.GroupBox();
            this.ButtonAinDump = new System.Windows.Forms.Button();
            this.RadioButtonAinText = new System.Windows.Forms.RadioButton();
            this.RadioButtonAinJson = new System.Windows.Forms.RadioButton();
            this.RadioButtonAinCode = new System.Windows.Forms.RadioButton();
            this.TabPageEx = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.CheckBoxExOld = new System.Windows.Forms.CheckBox();
            this.ButtonExBuild = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CheckBoxExSplite = new System.Windows.Forms.CheckBox();
            this.ButtonExDump = new System.Windows.Forms.Button();
            this.TabPageAr = new System.Windows.Forms.TabPage();
            this.CheckBoxArImg = new System.Windows.Forms.CheckBox();
            this.CheckBoxArForce = new System.Windows.Forms.CheckBox();
            this.CheckBoxArRaw = new System.Windows.Forms.CheckBox();
            this.ButtonArExtract = new System.Windows.Forms.Button();
            this.ButtonArList = new System.Windows.Forms.Button();
            this.ButtonArExtractAll = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ListBoxArItems = new System.Windows.Forms.ListBox();
            this.TabPageArPack = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ButtonArPack = new System.Windows.Forms.Button();
            this.TabPageAcx = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonAcxConvert = new System.Windows.Forms.Button();
            this.RadioButtonCsv2Acx = new System.Windows.Forms.RadioButton();
            this.RadioButtonAcx2Csv = new System.Windows.Forms.RadioButton();
            this.FolderBrowserDialogMain = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.GroupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.LinkLabelAT = new System.Windows.Forms.LinkLabel();
            this.LinkLabelATG = new System.Windows.Forms.LinkLabel();
            this.ButtonCheckAT = new System.Windows.Forms.Button();
            this.ButtonCheckATG = new System.Windows.Forms.Button();
            this.LabelATVersion = new System.Windows.Forms.Label();
            this.LabelATGVersion = new System.Windows.Forms.Label();
            this.BackgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.ButtonShutdown = new System.Windows.Forms.Button();
            this.EncodingPanleAinTranscode = new AliceToolsGui.CustomControls.EncodingPanle();
            this.PathBoxAinSource = new AliceToolsGui.CustomControls.PathBox();
            this.PathBoxInputAin = new AliceToolsGui.CustomControls.PathBox();
            this.PathExSource = new AliceToolsGui.CustomControls.PathBox();
            this.PathBoxEx = new AliceToolsGui.CustomControls.PathBox();
            this.PathBoxAr = new AliceToolsGui.CustomControls.PathBox();
            this.PathBoxArPack = new AliceToolsGui.CustomControls.PathBox();
            this.PathBoxAcxCSV = new AliceToolsGui.CustomControls.PathBox();
            this.EncodingPanleInput = new AliceToolsGui.CustomControls.EncodingPanle();
            this.EncodingPanleOutput = new AliceToolsGui.CustomControls.EncodingPanle();
            this.ButtonArSaveList = new System.Windows.Forms.Button();
            this.GroupBoxEncoding.SuspendLayout();
            this.ContextMenuStripOutput.SuspendLayout();
            this.GroupBoxAinPath.SuspendLayout();
            this.TabControlMain.SuspendLayout();
            this.TabPageAin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupBoxAinDump.SuspendLayout();
            this.TabPageEx.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.TabPageAr.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TabPageArPack.SuspendLayout();
            this.TabPageAcx.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GroupBoxUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "输出：";
            // 
            // GroupBoxEncoding
            // 
            this.GroupBoxEncoding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxEncoding.Controls.Add(this.EncodingPanleInput);
            this.GroupBoxEncoding.Controls.Add(this.label2);
            this.GroupBoxEncoding.Controls.Add(this.EncodingPanleOutput);
            this.GroupBoxEncoding.Controls.Add(this.label1);
            this.GroupBoxEncoding.Location = new System.Drawing.Point(9, 8);
            this.GroupBoxEncoding.Name = "GroupBoxEncoding";
            this.GroupBoxEncoding.Size = new System.Drawing.Size(374, 75);
            this.GroupBoxEncoding.TabIndex = 4;
            this.GroupBoxEncoding.TabStop = false;
            this.GroupBoxEncoding.Text = "编码";
            // 
            // TextBoxOutput
            // 
            this.TextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOutput.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TextBoxOutput.ContextMenuStrip = this.ContextMenuStripOutput;
            this.TextBoxOutput.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TextBoxOutput.Location = new System.Drawing.Point(10, 397);
            this.TextBoxOutput.MaxLength = 2147483647;
            this.TextBoxOutput.Multiline = true;
            this.TextBoxOutput.Name = "TextBoxOutput";
            this.TextBoxOutput.ReadOnly = true;
            this.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxOutput.Size = new System.Drawing.Size(627, 143);
            this.TextBoxOutput.TabIndex = 5;
            this.TextBoxOutput.TextChanged += new System.EventHandler(this.TextBoxOutput_TextChanged);
            // 
            // ContextMenuStripOutput
            // 
            this.ContextMenuStripOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClear,
            this.toolStripSeparator1,
            this.ToolStripMenuItemCopy});
            this.ContextMenuStripOutput.Name = "ContextMenuStripOutput";
            this.ContextMenuStripOutput.Size = new System.Drawing.Size(197, 54);
            // 
            // ToolStripMenuItemClear
            // 
            this.ToolStripMenuItemClear.Name = "ToolStripMenuItemClear";
            this.ToolStripMenuItemClear.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemClear.Text = "清除";
            this.ToolStripMenuItemClear.Click += new System.EventHandler(this.ToolStripMenuItemClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // ToolStripMenuItemCopy
            // 
            this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
            this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(196, 22);
            this.ToolStripMenuItemCopy.Text = "复制所有内容到剪切板";
            this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
            // 
            // GroupBoxAinPath
            // 
            this.GroupBoxAinPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxAinPath.Controls.Add(this.PathBoxInputAin);
            this.GroupBoxAinPath.Location = new System.Drawing.Point(6, 6);
            this.GroupBoxAinPath.Name = "GroupBoxAinPath";
            this.GroupBoxAinPath.Size = new System.Drawing.Size(611, 55);
            this.GroupBoxAinPath.TabIndex = 6;
            this.GroupBoxAinPath.TabStop = false;
            this.GroupBoxAinPath.Text = "目标ain文件路径";
            // 
            // TabControlMain
            // 
            this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControlMain.Controls.Add(this.TabPageAin);
            this.TabControlMain.Controls.Add(this.TabPageEx);
            this.TabControlMain.Controls.Add(this.TabPageAr);
            this.TabControlMain.Controls.Add(this.TabPageArPack);
            this.TabControlMain.Controls.Add(this.TabPageAcx);
            this.TabControlMain.Location = new System.Drawing.Point(9, 91);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(631, 300);
            this.TabControlMain.TabIndex = 7;
            // 
            // TabPageAin
            // 
            this.TabPageAin.Controls.Add(this.groupBox1);
            this.TabPageAin.Controls.Add(this.GroupBoxAinDump);
            this.TabPageAin.Controls.Add(this.GroupBoxAinPath);
            this.TabPageAin.Location = new System.Drawing.Point(4, 22);
            this.TabPageAin.Name = "TabPageAin";
            this.TabPageAin.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAin.Size = new System.Drawing.Size(623, 274);
            this.TabPageAin.TabIndex = 0;
            this.TabPageAin.Text = "ain文件";
            this.TabPageAin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.EncodingPanleAinTranscode);
            this.groupBox1.Controls.Add(this.CheckBoxAinTranscode);
            this.groupBox1.Controls.Add(this.RadioButtonAinAppendCode);
            this.groupBox1.Controls.Add(this.PathBoxAinSource);
            this.groupBox1.Controls.Add(this.ButtonAinEdit);
            this.groupBox1.Controls.Add(this.RadioButtonAinUpdateText);
            this.groupBox1.Controls.Add(this.RadioButtonAinUpdateJson);
            this.groupBox1.Controls.Add(this.RadioButtonAinUpdateCode);
            this.groupBox1.Location = new System.Drawing.Point(6, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 118);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "修改";
            // 
            // CheckBoxAinTranscode
            // 
            this.CheckBoxAinTranscode.AutoSize = true;
            this.CheckBoxAinTranscode.Location = new System.Drawing.Point(15, 89);
            this.CheckBoxAinTranscode.Name = "CheckBoxAinTranscode";
            this.CheckBoxAinTranscode.Size = new System.Drawing.Size(114, 16);
            this.CheckBoxAinTranscode.TabIndex = 7;
            this.CheckBoxAinTranscode.Text = "转换AIN文件编码";
            this.CheckBoxAinTranscode.UseVisualStyleBackColor = true;
            this.CheckBoxAinTranscode.CheckedChanged += new System.EventHandler(this.CheckBoxAinTranscode_CheckedChanged);
            // 
            // RadioButtonAinAppendCode
            // 
            this.RadioButtonAinAppendCode.AutoSize = true;
            this.RadioButtonAinAppendCode.Location = new System.Drawing.Point(293, 56);
            this.RadioButtonAinAppendCode.Name = "RadioButtonAinAppendCode";
            this.RadioButtonAinAppendCode.Size = new System.Drawing.Size(71, 16);
            this.RadioButtonAinAppendCode.TabIndex = 6;
            this.RadioButtonAinAppendCode.Text = "追加代码";
            this.RadioButtonAinAppendCode.UseVisualStyleBackColor = true;
            this.RadioButtonAinAppendCode.CheckedChanged += new System.EventHandler(this.RadioButtonAinAppendCode_CheckedChanged);
            // 
            // ButtonAinEdit
            // 
            this.ButtonAinEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAinEdit.Enabled = false;
            this.ButtonAinEdit.Location = new System.Drawing.Point(528, 53);
            this.ButtonAinEdit.Name = "ButtonAinEdit";
            this.ButtonAinEdit.Size = new System.Drawing.Size(77, 23);
            this.ButtonAinEdit.TabIndex = 4;
            this.ButtonAinEdit.Text = "更新";
            this.ButtonAinEdit.UseVisualStyleBackColor = true;
            this.ButtonAinEdit.Click += new System.EventHandler(this.ButtonAinEdit_Click);
            // 
            // RadioButtonAinUpdateText
            // 
            this.RadioButtonAinUpdateText.AutoSize = true;
            this.RadioButtonAinUpdateText.Location = new System.Drawing.Point(191, 56);
            this.RadioButtonAinUpdateText.Name = "RadioButtonAinUpdateText";
            this.RadioButtonAinUpdateText.Size = new System.Drawing.Size(95, 16);
            this.RadioButtonAinUpdateText.TabIndex = 2;
            this.RadioButtonAinUpdateText.Text = "更新文本内容";
            this.RadioButtonAinUpdateText.UseVisualStyleBackColor = true;
            this.RadioButtonAinUpdateText.CheckedChanged += new System.EventHandler(this.RadioButtonAinUpdateText_CheckedChanged);
            // 
            // RadioButtonAinUpdateJson
            // 
            this.RadioButtonAinUpdateJson.AutoSize = true;
            this.RadioButtonAinUpdateJson.Location = new System.Drawing.Point(90, 56);
            this.RadioButtonAinUpdateJson.Name = "RadioButtonAinUpdateJson";
            this.RadioButtonAinUpdateJson.Size = new System.Drawing.Size(95, 16);
            this.RadioButtonAinUpdateJson.TabIndex = 1;
            this.RadioButtonAinUpdateJson.Text = "更新Json代码";
            this.RadioButtonAinUpdateJson.UseVisualStyleBackColor = true;
            this.RadioButtonAinUpdateJson.CheckedChanged += new System.EventHandler(this.RadioButtonAinUpdateJson_CheckedChanged);
            // 
            // RadioButtonAinUpdateCode
            // 
            this.RadioButtonAinUpdateCode.AutoSize = true;
            this.RadioButtonAinUpdateCode.Checked = true;
            this.RadioButtonAinUpdateCode.Location = new System.Drawing.Point(15, 56);
            this.RadioButtonAinUpdateCode.Name = "RadioButtonAinUpdateCode";
            this.RadioButtonAinUpdateCode.Size = new System.Drawing.Size(71, 16);
            this.RadioButtonAinUpdateCode.TabIndex = 0;
            this.RadioButtonAinUpdateCode.TabStop = true;
            this.RadioButtonAinUpdateCode.Text = "更新代码";
            this.RadioButtonAinUpdateCode.UseVisualStyleBackColor = true;
            this.RadioButtonAinUpdateCode.CheckedChanged += new System.EventHandler(this.RadioButtonAinUpdateCode_CheckedChanged);
            // 
            // GroupBoxAinDump
            // 
            this.GroupBoxAinDump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxAinDump.Controls.Add(this.ButtonAinDump);
            this.GroupBoxAinDump.Controls.Add(this.RadioButtonAinText);
            this.GroupBoxAinDump.Controls.Add(this.RadioButtonAinJson);
            this.GroupBoxAinDump.Controls.Add(this.RadioButtonAinCode);
            this.GroupBoxAinDump.Location = new System.Drawing.Point(6, 67);
            this.GroupBoxAinDump.Name = "GroupBoxAinDump";
            this.GroupBoxAinDump.Size = new System.Drawing.Size(611, 50);
            this.GroupBoxAinDump.TabIndex = 7;
            this.GroupBoxAinDump.TabStop = false;
            this.GroupBoxAinDump.Text = "提取";
            // 
            // ButtonAinDump
            // 
            this.ButtonAinDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAinDump.Enabled = false;
            this.ButtonAinDump.Location = new System.Drawing.Point(528, 17);
            this.ButtonAinDump.Name = "ButtonAinDump";
            this.ButtonAinDump.Size = new System.Drawing.Size(77, 23);
            this.ButtonAinDump.TabIndex = 4;
            this.ButtonAinDump.Text = "提取";
            this.ButtonAinDump.UseVisualStyleBackColor = true;
            this.ButtonAinDump.Click += new System.EventHandler(this.ButtonAinDump_Click);
            // 
            // RadioButtonAinText
            // 
            this.RadioButtonAinText.AutoSize = true;
            this.RadioButtonAinText.Location = new System.Drawing.Point(191, 20);
            this.RadioButtonAinText.Name = "RadioButtonAinText";
            this.RadioButtonAinText.Size = new System.Drawing.Size(95, 16);
            this.RadioButtonAinText.TabIndex = 2;
            this.RadioButtonAinText.Text = "提取文本内容";
            this.RadioButtonAinText.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAinJson
            // 
            this.RadioButtonAinJson.AutoSize = true;
            this.RadioButtonAinJson.Location = new System.Drawing.Point(90, 20);
            this.RadioButtonAinJson.Name = "RadioButtonAinJson";
            this.RadioButtonAinJson.Size = new System.Drawing.Size(95, 16);
            this.RadioButtonAinJson.TabIndex = 1;
            this.RadioButtonAinJson.Text = "提取Json代码";
            this.RadioButtonAinJson.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAinCode
            // 
            this.RadioButtonAinCode.AutoSize = true;
            this.RadioButtonAinCode.Checked = true;
            this.RadioButtonAinCode.Location = new System.Drawing.Point(15, 20);
            this.RadioButtonAinCode.Name = "RadioButtonAinCode";
            this.RadioButtonAinCode.Size = new System.Drawing.Size(71, 16);
            this.RadioButtonAinCode.TabIndex = 0;
            this.RadioButtonAinCode.TabStop = true;
            this.RadioButtonAinCode.Text = "提取代码";
            this.RadioButtonAinCode.UseVisualStyleBackColor = true;
            // 
            // TabPageEx
            // 
            this.TabPageEx.Controls.Add(this.groupBox6);
            this.TabPageEx.Controls.Add(this.groupBox5);
            this.TabPageEx.Location = new System.Drawing.Point(4, 22);
            this.TabPageEx.Name = "TabPageEx";
            this.TabPageEx.Size = new System.Drawing.Size(623, 274);
            this.TabPageEx.TabIndex = 2;
            this.TabPageEx.Text = "ex文件";
            this.TabPageEx.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.CheckBoxExOld);
            this.groupBox6.Controls.Add(this.PathExSource);
            this.groupBox6.Controls.Add(this.ButtonExBuild);
            this.groupBox6.Location = new System.Drawing.Point(4, 90);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(610, 76);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "源文件";
            // 
            // CheckBoxExOld
            // 
            this.CheckBoxExOld.AutoSize = true;
            this.CheckBoxExOld.Location = new System.Drawing.Point(6, 54);
            this.CheckBoxExOld.Name = "CheckBoxExOld";
            this.CheckBoxExOld.Size = new System.Drawing.Size(192, 16);
            this.CheckBoxExOld.TabIndex = 6;
            this.CheckBoxExOld.Text = "老版本(夏娃年代记之前的游戏)";
            this.CheckBoxExOld.UseVisualStyleBackColor = true;
            // 
            // ButtonExBuild
            // 
            this.ButtonExBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonExBuild.Enabled = false;
            this.ButtonExBuild.Location = new System.Drawing.Point(527, 21);
            this.ButtonExBuild.Name = "ButtonExBuild";
            this.ButtonExBuild.Size = new System.Drawing.Size(77, 23);
            this.ButtonExBuild.TabIndex = 4;
            this.ButtonExBuild.Text = "生成";
            this.ButtonExBuild.UseVisualStyleBackColor = true;
            this.ButtonExBuild.Click += new System.EventHandler(this.ButtonExBuild_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.CheckBoxExSplite);
            this.groupBox5.Controls.Add(this.PathBoxEx);
            this.groupBox5.Controls.Add(this.ButtonExDump);
            this.groupBox5.Location = new System.Drawing.Point(4, 7);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(616, 77);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ex文件";
            // 
            // CheckBoxExSplite
            // 
            this.CheckBoxExSplite.AutoSize = true;
            this.CheckBoxExSplite.Checked = true;
            this.CheckBoxExSplite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxExSplite.Location = new System.Drawing.Point(6, 51);
            this.CheckBoxExSplite.Name = "CheckBoxExSplite";
            this.CheckBoxExSplite.Size = new System.Drawing.Size(108, 16);
            this.CheckBoxExSplite.TabIndex = 7;
            this.CheckBoxExSplite.Text = "拆分为多个文件";
            this.CheckBoxExSplite.UseVisualStyleBackColor = true;
            // 
            // ButtonExDump
            // 
            this.ButtonExDump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonExDump.Enabled = false;
            this.ButtonExDump.Location = new System.Drawing.Point(533, 21);
            this.ButtonExDump.Name = "ButtonExDump";
            this.ButtonExDump.Size = new System.Drawing.Size(77, 23);
            this.ButtonExDump.TabIndex = 4;
            this.ButtonExDump.Text = "提取";
            this.ButtonExDump.UseVisualStyleBackColor = true;
            this.ButtonExDump.Click += new System.EventHandler(this.ButtonExDump_Click);
            // 
            // TabPageAr
            // 
            this.TabPageAr.Controls.Add(this.ButtonArSaveList);
            this.TabPageAr.Controls.Add(this.CheckBoxArImg);
            this.TabPageAr.Controls.Add(this.CheckBoxArForce);
            this.TabPageAr.Controls.Add(this.CheckBoxArRaw);
            this.TabPageAr.Controls.Add(this.ButtonArExtract);
            this.TabPageAr.Controls.Add(this.ButtonArList);
            this.TabPageAr.Controls.Add(this.ButtonArExtractAll);
            this.TabPageAr.Controls.Add(this.groupBox4);
            this.TabPageAr.Controls.Add(this.ListBoxArItems);
            this.TabPageAr.Location = new System.Drawing.Point(4, 22);
            this.TabPageAr.Name = "TabPageAr";
            this.TabPageAr.Size = new System.Drawing.Size(623, 274);
            this.TabPageAr.TabIndex = 3;
            this.TabPageAr.Text = "afa/ald文件";
            this.TabPageAr.UseVisualStyleBackColor = true;
            // 
            // CheckBoxArImg
            // 
            this.CheckBoxArImg.AutoSize = true;
            this.CheckBoxArImg.Location = new System.Drawing.Point(169, 112);
            this.CheckBoxArImg.Name = "CheckBoxArImg";
            this.CheckBoxArImg.Size = new System.Drawing.Size(84, 16);
            this.CheckBoxArImg.TabIndex = 15;
            this.CheckBoxArImg.Text = "只提取图片";
            this.CheckBoxArImg.UseVisualStyleBackColor = true;
            // 
            // CheckBoxArForce
            // 
            this.CheckBoxArForce.AutoSize = true;
            this.CheckBoxArForce.Location = new System.Drawing.Point(266, 112);
            this.CheckBoxArForce.Name = "CheckBoxArForce";
            this.CheckBoxArForce.Size = new System.Drawing.Size(108, 16);
            this.CheckBoxArForce.TabIndex = 14;
            this.CheckBoxArForce.Text = "覆盖已有的文件";
            this.CheckBoxArForce.UseVisualStyleBackColor = true;
            // 
            // CheckBoxArRaw
            // 
            this.CheckBoxArRaw.AutoSize = true;
            this.CheckBoxArRaw.Location = new System.Drawing.Point(7, 112);
            this.CheckBoxArRaw.Name = "CheckBoxArRaw";
            this.CheckBoxArRaw.Size = new System.Drawing.Size(156, 16);
            this.CheckBoxArRaw.TabIndex = 11;
            this.CheckBoxArRaw.Text = "不遍历档案，不转换图片";
            this.CheckBoxArRaw.UseVisualStyleBackColor = true;
            // 
            // ButtonArExtract
            // 
            this.ButtonArExtract.Enabled = false;
            this.ButtonArExtract.Location = new System.Drawing.Point(507, 70);
            this.ButtonArExtract.Name = "ButtonArExtract";
            this.ButtonArExtract.Size = new System.Drawing.Size(113, 29);
            this.ButtonArExtract.TabIndex = 10;
            this.ButtonArExtract.Text = "提取所选文件";
            this.ButtonArExtract.UseVisualStyleBackColor = true;
            this.ButtonArExtract.Click += new System.EventHandler(this.ButtonArExtract_Click);
            // 
            // ButtonArList
            // 
            this.ButtonArList.Enabled = false;
            this.ButtonArList.Location = new System.Drawing.Point(240, 70);
            this.ButtonArList.Name = "ButtonArList";
            this.ButtonArList.Size = new System.Drawing.Size(113, 29);
            this.ButtonArList.TabIndex = 9;
            this.ButtonArList.Text = "加载文件列表";
            this.ButtonArList.UseVisualStyleBackColor = true;
            this.ButtonArList.Click += new System.EventHandler(this.ButtonArList_Click);
            // 
            // ButtonArExtractAll
            // 
            this.ButtonArExtractAll.Enabled = false;
            this.ButtonArExtractAll.Location = new System.Drawing.Point(6, 70);
            this.ButtonArExtractAll.Name = "ButtonArExtractAll";
            this.ButtonArExtractAll.Size = new System.Drawing.Size(113, 29);
            this.ButtonArExtractAll.TabIndex = 8;
            this.ButtonArExtractAll.Text = "提取全部文件";
            this.ButtonArExtractAll.UseVisualStyleBackColor = true;
            this.ButtonArExtractAll.Click += new System.EventHandler(this.ButtonArExtractAll_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.PathBoxAr);
            this.groupBox4.Location = new System.Drawing.Point(6, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "afa/ald文件路径";
            // 
            // ListBoxArItems
            // 
            this.ListBoxArItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxArItems.FormattingEnabled = true;
            this.ListBoxArItems.ItemHeight = 12;
            this.ListBoxArItems.Location = new System.Drawing.Point(7, 143);
            this.ListBoxArItems.Name = "ListBoxArItems";
            this.ListBoxArItems.ScrollAlwaysVisible = true;
            this.ListBoxArItems.Size = new System.Drawing.Size(607, 124);
            this.ListBoxArItems.TabIndex = 0;
            this.ListBoxArItems.SelectedIndexChanged += new System.EventHandler(this.ListBoxArItems_SelectedIndexChanged);
            // 
            // TabPageArPack
            // 
            this.TabPageArPack.Controls.Add(this.textBox1);
            this.TabPageArPack.Controls.Add(this.ButtonArPack);
            this.TabPageArPack.Controls.Add(this.PathBoxArPack);
            this.TabPageArPack.Location = new System.Drawing.Point(4, 22);
            this.TabPageArPack.Name = "TabPageArPack";
            this.TabPageArPack.Size = new System.Drawing.Size(623, 274);
            this.TabPageArPack.TabIndex = 4;
            this.TabPageArPack.Text = "Afa打包";
            this.TabPageArPack.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(19, 54);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(594, 204);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // ButtonArPack
            // 
            this.ButtonArPack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonArPack.Enabled = false;
            this.ButtonArPack.Location = new System.Drawing.Point(538, 16);
            this.ButtonArPack.Name = "ButtonArPack";
            this.ButtonArPack.Size = new System.Drawing.Size(75, 23);
            this.ButtonArPack.TabIndex = 1;
            this.ButtonArPack.Text = "打包";
            this.ButtonArPack.UseVisualStyleBackColor = true;
            this.ButtonArPack.Click += new System.EventHandler(this.ButtonArPack_Click);
            // 
            // TabPageAcx
            // 
            this.TabPageAcx.Controls.Add(this.label3);
            this.TabPageAcx.Controls.Add(this.groupBox3);
            this.TabPageAcx.Location = new System.Drawing.Point(4, 22);
            this.TabPageAcx.Name = "TabPageAcx";
            this.TabPageAcx.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAcx.Size = new System.Drawing.Size(623, 274);
            this.TabPageAcx.TabIndex = 1;
            this.TabPageAcx.Text = "acx文件";
            this.TabPageAcx.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(14, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "EXCEL 会破坏 CSV 文件格式，不要使用 EXCEL 进行编辑。";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.PathBoxAcxCSV);
            this.groupBox3.Controls.Add(this.ButtonAcxConvert);
            this.groupBox3.Controls.Add(this.RadioButtonCsv2Acx);
            this.groupBox3.Controls.Add(this.RadioButtonAcx2Csv);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 86);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "转换";
            // 
            // ButtonAcxConvert
            // 
            this.ButtonAcxConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAcxConvert.Enabled = false;
            this.ButtonAcxConvert.Location = new System.Drawing.Point(458, 53);
            this.ButtonAcxConvert.Name = "ButtonAcxConvert";
            this.ButtonAcxConvert.Size = new System.Drawing.Size(147, 23);
            this.ButtonAcxConvert.TabIndex = 4;
            this.ButtonAcxConvert.Text = "转换";
            this.ButtonAcxConvert.UseVisualStyleBackColor = true;
            this.ButtonAcxConvert.Click += new System.EventHandler(this.ButtonAcxConvert_Click);
            // 
            // RadioButtonCsv2Acx
            // 
            this.RadioButtonCsv2Acx.AutoSize = true;
            this.RadioButtonCsv2Acx.Location = new System.Drawing.Point(117, 56);
            this.RadioButtonCsv2Acx.Name = "RadioButtonCsv2Acx";
            this.RadioButtonCsv2Acx.Size = new System.Drawing.Size(83, 16);
            this.RadioButtonCsv2Acx.TabIndex = 2;
            this.RadioButtonCsv2Acx.Text = "CSV to ACX";
            this.RadioButtonCsv2Acx.UseVisualStyleBackColor = true;
            // 
            // RadioButtonAcx2Csv
            // 
            this.RadioButtonAcx2Csv.AutoSize = true;
            this.RadioButtonAcx2Csv.Checked = true;
            this.RadioButtonAcx2Csv.Location = new System.Drawing.Point(15, 56);
            this.RadioButtonAcx2Csv.Name = "RadioButtonAcx2Csv";
            this.RadioButtonAcx2Csv.Size = new System.Drawing.Size(83, 16);
            this.RadioButtonAcx2Csv.TabIndex = 0;
            this.RadioButtonAcx2Csv.TabStop = true;
            this.RadioButtonAcx2Csv.Text = "ACX to CSV";
            this.RadioButtonAcx2Csv.UseVisualStyleBackColor = true;
            this.RadioButtonAcx2Csv.CheckedChanged += new System.EventHandler(this.RadioButtonAcx2Csv_CheckedChanged);
            // 
            // GroupBoxUpdate
            // 
            this.GroupBoxUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxUpdate.Controls.Add(this.LinkLabelAT);
            this.GroupBoxUpdate.Controls.Add(this.LinkLabelATG);
            this.GroupBoxUpdate.Controls.Add(this.ButtonCheckAT);
            this.GroupBoxUpdate.Controls.Add(this.ButtonCheckATG);
            this.GroupBoxUpdate.Controls.Add(this.LabelATVersion);
            this.GroupBoxUpdate.Controls.Add(this.LabelATGVersion);
            this.GroupBoxUpdate.Location = new System.Drawing.Point(389, 8);
            this.GroupBoxUpdate.Name = "GroupBoxUpdate";
            this.GroupBoxUpdate.Size = new System.Drawing.Size(251, 75);
            this.GroupBoxUpdate.TabIndex = 8;
            this.GroupBoxUpdate.TabStop = false;
            this.GroupBoxUpdate.Text = "更新";
            // 
            // LinkLabelAT
            // 
            this.LinkLabelAT.AutoSize = true;
            this.LinkLabelAT.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkLabelAT.LinkColor = System.Drawing.SystemColors.ControlText;
            this.LinkLabelAT.Location = new System.Drawing.Point(6, 51);
            this.LinkLabelAT.Name = "LinkLabelAT";
            this.LinkLabelAT.Size = new System.Drawing.Size(119, 12);
            this.LinkLabelAT.TabIndex = 7;
            this.LinkLabelAT.TabStop = true;
            this.LinkLabelAT.Text = "alice-tools   版本:";
            this.LinkLabelAT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // LinkLabelATG
            // 
            this.LinkLabelATG.AutoSize = true;
            this.LinkLabelATG.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.LinkLabelATG.LinkColor = System.Drawing.SystemColors.ControlText;
            this.LinkLabelATG.Location = new System.Drawing.Point(6, 23);
            this.LinkLabelATG.Name = "LinkLabelATG";
            this.LinkLabelATG.Size = new System.Drawing.Size(119, 12);
            this.LinkLabelATG.TabIndex = 6;
            this.LinkLabelATG.TabStop = true;
            this.LinkLabelATG.Text = "AliceToolsGui 版本:";
            this.LinkLabelATG.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // ButtonCheckAT
            // 
            this.ButtonCheckAT.Location = new System.Drawing.Point(191, 46);
            this.ButtonCheckAT.Name = "ButtonCheckAT";
            this.ButtonCheckAT.Size = new System.Drawing.Size(53, 23);
            this.ButtonCheckAT.TabIndex = 5;
            this.ButtonCheckAT.Text = "更新";
            this.ButtonCheckAT.UseVisualStyleBackColor = true;
            this.ButtonCheckAT.Click += new System.EventHandler(this.ButtonCheckAT_Click);
            // 
            // ButtonCheckATG
            // 
            this.ButtonCheckATG.Location = new System.Drawing.Point(191, 19);
            this.ButtonCheckATG.Name = "ButtonCheckATG";
            this.ButtonCheckATG.Size = new System.Drawing.Size(53, 23);
            this.ButtonCheckATG.TabIndex = 4;
            this.ButtonCheckATG.Text = "更新";
            this.ButtonCheckATG.UseVisualStyleBackColor = true;
            this.ButtonCheckATG.Click += new System.EventHandler(this.ButtonCheckATG_Click);
            // 
            // LabelATVersion
            // 
            this.LabelATVersion.Location = new System.Drawing.Point(131, 51);
            this.LabelATVersion.Name = "LabelATVersion";
            this.LabelATVersion.Size = new System.Drawing.Size(53, 16);
            this.LabelATVersion.TabIndex = 3;
            // 
            // LabelATGVersion
            // 
            this.LabelATGVersion.Location = new System.Drawing.Point(131, 23);
            this.LabelATGVersion.Name = "LabelATGVersion";
            this.LabelATGVersion.Size = new System.Drawing.Size(53, 17);
            this.LabelATGVersion.TabIndex = 2;
            // 
            // BackgroundWorkerMain
            // 
            this.BackgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerMain_DoWork);
            // 
            // ButtonShutdown
            // 
            this.ButtonShutdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonShutdown.Location = new System.Drawing.Point(551, 407);
            this.ButtonShutdown.Name = "ButtonShutdown";
            this.ButtonShutdown.Size = new System.Drawing.Size(62, 33);
            this.ButtonShutdown.TabIndex = 9;
            this.ButtonShutdown.Text = "取消操作";
            this.ButtonShutdown.UseVisualStyleBackColor = true;
            this.ButtonShutdown.Visible = false;
            this.ButtonShutdown.Click += new System.EventHandler(this.ButtonShutdown_Click);
            // 
            // EncodingPanleAinTranscode
            // 
            this.EncodingPanleAinTranscode.AutoSize = true;
            this.EncodingPanleAinTranscode.Enabled = false;
            this.EncodingPanleAinTranscode.Location = new System.Drawing.Point(135, 84);
            this.EncodingPanleAinTranscode.Name = "EncodingPanleAinTranscode";
            this.EncodingPanleAinTranscode.Size = new System.Drawing.Size(319, 28);
            this.EncodingPanleAinTranscode.TabIndex = 8;
            // 
            // PathBoxAinSource
            // 
            this.PathBoxAinSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxAinSource.AutoScroll = true;
            this.PathBoxAinSource.Filter = "Ain文件源码 (*.jam)|*.jam|JSON文件 (*.json)|*.json|文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            this.PathBoxAinSource.Location = new System.Drawing.Point(6, 22);
            this.PathBoxAinSource.Name = "PathBoxAinSource";
            this.PathBoxAinSource.Size = new System.Drawing.Size(599, 21);
            this.PathBoxAinSource.TabIndex = 5;
            this.PathBoxAinSource.PathChanged += new System.EventHandler<string>(this.PathBoxAinSource_PathChanged);
            // 
            // PathBoxInputAin
            // 
            this.PathBoxInputAin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxInputAin.AutoScroll = true;
            this.PathBoxInputAin.Filter = "Ain文件 (*.ain)|*.ain";
            this.PathBoxInputAin.Location = new System.Drawing.Point(6, 20);
            this.PathBoxInputAin.Name = "PathBoxInputAin";
            this.PathBoxInputAin.Size = new System.Drawing.Size(599, 21);
            this.PathBoxInputAin.TabIndex = 1;
            this.PathBoxInputAin.PathChanged += new System.EventHandler<string>(this.PathBoxInputAin_PathChanged);
            // 
            // PathExSource
            // 
            this.PathExSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathExSource.AutoScroll = true;
            this.PathExSource.Filter = "ex源码表 (*.mx)|*.mx|ex源码 (*.x)|*.x|所有文件 (*.*)|*.*";
            this.PathExSource.Location = new System.Drawing.Point(6, 22);
            this.PathExSource.Name = "PathExSource";
            this.PathExSource.Size = new System.Drawing.Size(515, 21);
            this.PathExSource.TabIndex = 5;
            this.PathExSource.PathChanged += new System.EventHandler<string>(this.PathExSource_PathChanged);
            // 
            // PathBoxEx
            // 
            this.PathBoxEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxEx.AutoScroll = true;
            this.PathBoxEx.Filter = "Ex文件 (*.ex)|*.ex";
            this.PathBoxEx.Location = new System.Drawing.Point(6, 22);
            this.PathBoxEx.Name = "PathBoxEx";
            this.PathBoxEx.Size = new System.Drawing.Size(521, 21);
            this.PathBoxEx.TabIndex = 5;
            this.PathBoxEx.PathChanged += new System.EventHandler<string>(this.PathBoxEx_PathChanged);
            // 
            // PathBoxAr
            // 
            this.PathBoxAr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxAr.AutoScroll = true;
            this.PathBoxAr.Filter = "档案文件 (*.ald;*.afa)|*.ald;*.afa";
            this.PathBoxAr.Location = new System.Drawing.Point(6, 20);
            this.PathBoxAr.Name = "PathBoxAr";
            this.PathBoxAr.Size = new System.Drawing.Size(602, 21);
            this.PathBoxAr.TabIndex = 1;
            this.PathBoxAr.PathChanged += new System.EventHandler<string>(this.PathBoxAr_PathChanged);
            // 
            // PathBoxArPack
            // 
            this.PathBoxArPack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxArPack.AutoScroll = true;
            this.PathBoxArPack.Filter = "所有文件 (*.*)|*.*";
            this.PathBoxArPack.Location = new System.Drawing.Point(19, 17);
            this.PathBoxArPack.Name = "PathBoxArPack";
            this.PathBoxArPack.Size = new System.Drawing.Size(513, 21);
            this.PathBoxArPack.TabIndex = 0;
            this.PathBoxArPack.PathChanged += new System.EventHandler<string>(this.PathBoxArPack_PathChanged);
            // 
            // PathBoxAcxCSV
            // 
            this.PathBoxAcxCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBoxAcxCSV.AutoScroll = true;
            this.PathBoxAcxCSV.Filter = "ACX/CSV文件 (*.acx;*.csv)|*.acx;*.csv";
            this.PathBoxAcxCSV.Location = new System.Drawing.Point(6, 22);
            this.PathBoxAcxCSV.Name = "PathBoxAcxCSV";
            this.PathBoxAcxCSV.Size = new System.Drawing.Size(599, 21);
            this.PathBoxAcxCSV.TabIndex = 5;
            this.PathBoxAcxCSV.PathChanged += new System.EventHandler<string>(this.PathBoxAcxCSV_PathChanged);
            // 
            // EncodingPanleInput
            // 
            this.EncodingPanleInput.AutoSize = true;
            this.EncodingPanleInput.Location = new System.Drawing.Point(49, 16);
            this.EncodingPanleInput.Name = "EncodingPanleInput";
            this.EncodingPanleInput.Size = new System.Drawing.Size(319, 28);
            this.EncodingPanleInput.TabIndex = 2;
            this.EncodingPanleInput.EncodingChanged += new System.EventHandler<System.Text.Encoding>(this.EncodingPanleInput_EncodingChanged);
            // 
            // EncodingPanleOutput
            // 
            this.EncodingPanleOutput.AutoSize = true;
            this.EncodingPanleOutput.Location = new System.Drawing.Point(49, 43);
            this.EncodingPanleOutput.Name = "EncodingPanleOutput";
            this.EncodingPanleOutput.Size = new System.Drawing.Size(319, 28);
            this.EncodingPanleOutput.TabIndex = 3;
            this.EncodingPanleOutput.EncodingChanged += new System.EventHandler<System.Text.Encoding>(this.EncodingPanleOutput_EncodingChanged);
            // 
            // ButtonArSaveList
            // 
            this.ButtonArSaveList.Enabled = false;
            this.ButtonArSaveList.Location = new System.Drawing.Point(376, 70);
            this.ButtonArSaveList.Name = "ButtonArSaveList";
            this.ButtonArSaveList.Size = new System.Drawing.Size(113, 29);
            this.ButtonArSaveList.TabIndex = 16;
            this.ButtonArSaveList.Text = "导出文件列表";
            this.ButtonArSaveList.UseVisualStyleBackColor = true;
            this.ButtonArSaveList.Click += new System.EventHandler(this.ButtonArSaveList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 548);
            this.Controls.Add(this.ButtonShutdown);
            this.Controls.Add(this.GroupBoxUpdate);
            this.Controls.Add(this.TabControlMain);
            this.Controls.Add(this.TextBoxOutput);
            this.Controls.Add(this.GroupBoxEncoding);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(663, 587);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AliceToolsGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.GroupBoxEncoding.ResumeLayout(false);
            this.GroupBoxEncoding.PerformLayout();
            this.ContextMenuStripOutput.ResumeLayout(false);
            this.GroupBoxAinPath.ResumeLayout(false);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageAin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupBoxAinDump.ResumeLayout(false);
            this.GroupBoxAinDump.PerformLayout();
            this.TabPageEx.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.TabPageAr.ResumeLayout(false);
            this.TabPageAr.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.TabPageArPack.ResumeLayout(false);
            this.TabPageArPack.PerformLayout();
            this.TabPageAcx.ResumeLayout(false);
            this.TabPageAcx.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GroupBoxUpdate.ResumeLayout(false);
            this.GroupBoxUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CustomControls.EncodingPanle EncodingPanleInput;
        private CustomControls.EncodingPanle EncodingPanleOutput;
        private System.Windows.Forms.GroupBox GroupBoxEncoding;
        private System.Windows.Forms.TextBox TextBoxOutput;
        private System.Windows.Forms.GroupBox GroupBoxAinPath;
        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageAin;
        private System.Windows.Forms.TabPage TabPageAcx;
        private System.Windows.Forms.TabPage TabPageEx;
        private System.Windows.Forms.TabPage TabPageAr;
        private System.Windows.Forms.ListBox ListBoxArItems;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialogMain;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogMain;
        private CustomControls.PathBox PathBoxInputAin;
        private System.Windows.Forms.GroupBox GroupBoxAinDump;
        private System.Windows.Forms.RadioButton RadioButtonAinJson;
        private System.Windows.Forms.RadioButton RadioButtonAinCode;
        private System.Windows.Forms.Button ButtonAinDump;
        private System.Windows.Forms.RadioButton RadioButtonAinText;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomControls.PathBox PathBoxAinSource;
        private System.Windows.Forms.Button ButtonAinEdit;
        private System.Windows.Forms.RadioButton RadioButtonAinUpdateText;
        private System.Windows.Forms.RadioButton RadioButtonAinUpdateJson;
        private System.Windows.Forms.RadioButton RadioButtonAinUpdateCode;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripOutput;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomControls.PathBox PathBoxAcxCSV;
        private System.Windows.Forms.Button ButtonAcxConvert;
        private System.Windows.Forms.RadioButton RadioButtonCsv2Acx;
        private System.Windows.Forms.RadioButton RadioButtonAcx2Csv;
        private System.Windows.Forms.Button ButtonArExtract;
        private System.Windows.Forms.Button ButtonArList;
        private System.Windows.Forms.Button ButtonArExtractAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private CustomControls.PathBox PathBoxAr;
        private System.Windows.Forms.GroupBox groupBox6;
        private CustomControls.PathBox PathExSource;
        private System.Windows.Forms.Button ButtonExBuild;
        private System.Windows.Forms.GroupBox groupBox5;
        private CustomControls.PathBox PathBoxEx;
        private System.Windows.Forms.Button ButtonExDump;
        private System.Windows.Forms.CheckBox CheckBoxExOld;
        private System.Windows.Forms.CheckBox CheckBoxArRaw;
        private System.Windows.Forms.CheckBox CheckBoxArForce;
        private System.Windows.Forms.CheckBox CheckBoxArImg;
        private System.Windows.Forms.RadioButton RadioButtonAinAppendCode;
        private System.Windows.Forms.GroupBox GroupBoxUpdate;
        private System.Windows.Forms.Button ButtonCheckATG;
        private System.Windows.Forms.Label LabelATVersion;
        private System.Windows.Forms.Label LabelATGVersion;
        private System.Windows.Forms.Button ButtonCheckAT;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerMain;
        private System.Windows.Forms.LinkLabel LinkLabelAT;
        private System.Windows.Forms.LinkLabel LinkLabelATG;
        private System.Windows.Forms.Button ButtonShutdown;
        private System.Windows.Forms.CheckBox CheckBoxExSplite;
        private System.Windows.Forms.TabPage TabPageArPack;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ButtonArPack;
        private CustomControls.PathBox PathBoxArPack;
        private CustomControls.EncodingPanle EncodingPanleAinTranscode;
        private System.Windows.Forms.CheckBox CheckBoxAinTranscode;
        private System.Windows.Forms.Button ButtonArSaveList;
    }
}

