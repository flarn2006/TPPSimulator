using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace TPPSimulator
{
    public partial class PastebinImportForm : Form
    {
        private Exception downloadError = null;
        private string filename = null;

        public PastebinImportForm()
        {
            InitializeComponent();
        }

        private async void PastebinImportForm_Load(object sender, EventArgs e)
        {
            string clipboard = Clipboard.GetText();
            txtURL.SelectAll();
            lblStatus.Text = "";
            if (clipboard.StartsWith("http://") || clipboard.StartsWith("https://")) {
                txtURL.Text = clipboard;
                await DownloadMap();
            }
        }

        public async Task DownloadMap()
        {
            Match match = Regex.Match(txtURL.Text, "^(?:https?:\\/\\/)?(?:www\\.)?pastebin\\.com\\/([A-Za-z0-9]+)$");
            if (match.Success) {
                txtURL.Text = "http://pastebin.com/raw.php?i=" + match.Groups[1].Value;
            }

            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 5);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, txtURL.Text);

            lblStatus.ForeColor = Color.Olive;
            lblStatus.Text = "Downloading...";
            downloadError = null;
            lblStatus.Cursor = Cursors.Default;
            btnOK.Enabled = false;

            try {
                if (txtURL.Text.Length == 0) {
                    lblStatus.Text = "";
                } else {
                    HttpResponseMessage resp = await client.SendAsync(req);
                    if (resp.Content.Headers.ContentType.MediaType.Equals("text/plain")) {
                        byte[] content = await resp.Content.ReadAsByteArrayAsync();
                        filename = Path.Combine(Path.GetTempPath(), "Imported.tppmap");
                        FileStream file = File.OpenWrite(filename);
                        file.Write(content, 0, content.Length);
                        file.Close();
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Downloaded";
                        btnOK.Enabled = true;
                        btnOK.Focus();
                    } else {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Wrong content type";
                    }
                }
            } catch (InvalidOperationException) {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Invalid URL";
            } catch (Exception ex) {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Error, click for more info";
                downloadError = ex;
                lblStatus.Cursor = Cursors.Hand;
            }
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            if (downloadError != null) {
                string message = downloadError.GetType().FullName + ":\r\n" + downloadError.Message;
                MessageBox.Show(message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static DialogResult ImportMap(out string filename)
        {
            PastebinImportForm form = new PastebinImportForm();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK) {
                filename = form.filename;
            } else {
                filename = null;
            }
            return result;
        }

        private void txtURL_Enter(object sender, EventArgs e)
        {
            txtURL.SelectAll();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            downloadError = null;
            btnOK.Enabled = false;
        }

        private async void txtURL_Validating(object sender, CancelEventArgs e)
        {
            if (!btnOK.Enabled) {
                await DownloadMap();
            }
        }

        private void linkWikiPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/flarn2006/TPPSimulator/wiki/Custom-Maps");
        }
    }
}
