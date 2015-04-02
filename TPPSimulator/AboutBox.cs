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
        private const int heightContributorsOff = 196;
        private int heightContributorsOn = 0; //This is set to whatever height is set for the dialog in the designer.

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

        private void linkContributors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contributorsTable.Visible = !contributorsTable.Visible;
            Height = contributorsTable.Visible ? heightContributorsOn : heightContributorsOff;
            linkContributors.Text = String.Format("[{0}] Contributors", contributorsTable.Visible ? '-' : '+');
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            heightContributorsOn = Height;
            Height = heightContributorsOff;
            string[] names = new string[] { "flarn2006", "Game Freak", "pigdevil2010", "famfamfam.org" };
            string[] credits = new string[] { "Main developer", "Pokémon Red assets", "Graphics in icon", "Silk icon set" };

            contributorsTable.RowCount = names.Length;
            float heightPercent = 100.0f / names.Length;
            contributorsTable.RowStyles.Clear();

            for (int i = 0; i < names.Length; i++) {
                Label nameLabel = new Label();
                nameLabel.Text = names[i];
                nameLabel.Dock = DockStyle.Fill;
                contributorsTable.Controls.Add(nameLabel, 0, i);

                Label creditLabel = new Label();
                creditLabel.Text = credits[i];
                creditLabel.Dock = DockStyle.Fill;
                creditLabel.TextAlign = ContentAlignment.TopRight;
                contributorsTable.Controls.Add(creditLabel, 1, i);

                contributorsTable.RowStyles.Add(new RowStyle(SizeType.Percent, heightPercent));
            }
        }
    }
}
