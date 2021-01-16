// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text;
using System.Windows.Forms;

namespace AliceToolsGui.CustomControls
{
    public partial class EncodingPanle : UserControl
    {



        public EncodingPanle()
        {
            InitializeComponent();

            RadioButtonJP.Tag = Encoding.GetEncoding(932);
            RadioButtonCHS.Tag = Encoding.GetEncoding(936);
            RadioButtonUTF8.Tag = Encoding.UTF8;
            RadioButtonJP.Checked = true;
        }

        public event EventHandler<Encoding> EncodingChanged;

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Checked)
            {
                EncodingChanged?.Invoke(this, rb.Tag as Encoding);
            }
        }

        public void SetUTF8() => RadioButtonUTF8.Checked = true;



    }
}
