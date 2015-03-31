using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator
{
    public partial class TextCopyDialog : Form
    {
        public TextCopyDialog()
        {
            InitializeComponent();
        }

        private void TextCopyDialog_Load(object sender, EventArgs e)
        {
            btnCopy.Focus();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox.Text);
        }

        public static DialogResult ShowDialog(string text, string title = "Copy Text")
        {
            TextCopyDialog dlg = new TextCopyDialog();
            dlg.Text = title;
            dlg.textBox.Text = text;
            return dlg.ShowDialog();
        }
    }
}
