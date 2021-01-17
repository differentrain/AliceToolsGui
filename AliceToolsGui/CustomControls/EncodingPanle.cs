// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AliceToolsGui.AliceToolsProxies;

namespace AliceToolsGui.CustomControls
{
    public partial class EncodingPanle : UserControl
    {

        private static readonly LibiconvFriendlyEncoding[] s_encodings = Encoding.GetEncodings().Where(e => e.IsLibiconvSupported()).Select(e => new LibiconvFriendlyEncoding(e)).ToArray();


        public EncodingPanle()
        {
            InitializeComponent();
            ComboBoxCustom.Items.AddRange(s_encodings);
            ComboBoxCustom.SelectedIndex = 0;
            Encoding = Encoding.GetEncoding(932);
            RadioButtonJP.Tag = Encoding;
            RadioButtonCHS.Tag = Encoding.GetEncoding(936);
            RadioButtonUTF8.Tag = Encoding.UTF8;
            RadioButtonJP.Checked = true;
        }

        public event EventHandler<Encoding> EncodingChanged;

        public Encoding Encoding { get; private set; }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb.Checked)
            {
                Encoding = rb.Tag as Encoding;
                EncodingChanged?.Invoke(this, Encoding);
            }
        }

        public void SetUTF8() => RadioButtonUTF8.Checked = true;

        private void RadioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxCustom.Enabled = RadioButtonCustom.Checked;
            ComboBoxCustom_SelectedIndexChanged(sender, e);
        }

        private void ComboBoxCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonCustom.Checked && ComboBoxCustom.SelectedIndex >= 0)
            {
                Encoding = (ComboBoxCustom.SelectedItem as LibiconvFriendlyEncoding).Encoding;
                EncodingChanged?.Invoke(this, Encoding);
            }
        }


        private sealed class LibiconvFriendlyEncoding
        {
            public LibiconvFriendlyEncoding(EncodingInfo ei)
            {
                Encoding = ei.GetEncoding();
                DisplayName = ei.DisplayName;
            }

            public Encoding Encoding { get; }

            public string DisplayName { get; }

            public override string ToString() => DisplayName;

        }

    }


}
