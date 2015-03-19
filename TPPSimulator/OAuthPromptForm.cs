using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sharkbite.Irc;

namespace TPPSimulator
{
    public partial class OAuthPromptForm : Form
    {
        public OAuthPromptForm()
        {
            InitializeComponent();
        }

        private void oauthLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitchapps.com/tmi/");
        }

        private void OAuthPromptForm_Load(object sender, EventArgs e)
        {

        }

        public static DialogResult PromptForLogin(out string username, out string oauth)
        {
            OAuthPromptForm form = new OAuthPromptForm();
            DialogResult result = form.ShowDialog();
            username = form.txtUsername.Text;
            oauth = form.txtOAuth.Text;
            return result;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (txtUsername.Text.Length > 0);
        }

        private bool TestConnection()
        {
            ConnectionArgs ca = new ConnectionArgs(txtUsername.Text, "irc.twitch.tv");
            ca.UserName = txtUsername.Text;
            ca.ServerPassword = txtOAuth.Text;
            Connection con = new Connection(ca, false, true);
            try {
                con.Connect();
                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            } finally {
                if (con.Connected) con.Disconnect("bye");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (TestConnection()) {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
