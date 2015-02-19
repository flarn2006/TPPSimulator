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
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void ThereIsOnlyHelix()
        {
            btnDome.Visible = false;
            btnHelix.Left = Width / 2 - btnHelix.Width / 2;
        }

        private void btnDome_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("I take it you edited the form and enabled the control?", "Really?", MessageBoxButtons.YesNo);
            while (result == DialogResult.No) {
                result = MessageBox.Show("Don't lie to me! You did, didn't you?", "Kappa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            MessageBox.Show("That's what I thought.", "Knew it.");
            btnDome.Visible = false;
            btnHelix.Left = Width / 2 - btnHelix.Width / 2;
        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkGithub.Text);
        }

        private void linkSilk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.famfamfam.com/lab/icons/silk/");
        }
    }
}
