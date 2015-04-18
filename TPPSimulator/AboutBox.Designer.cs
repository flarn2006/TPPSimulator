namespace TPPSimulator
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHelix = new System.Windows.Forms.Button();
            this.btnDome = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contributorsTable = new System.Windows.Forms.TableLayoutPanel();
            this.linkContributors = new System.Windows.Forms.LinkLabel();
            this.linkGithub = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelix
            // 
            this.btnHelix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnHelix.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnHelix.Location = new System.Drawing.Point(21, 234);
            this.btnHelix.Name = "btnHelix";
            this.btnHelix.Size = new System.Drawing.Size(106, 34);
            this.btnHelix.TabIndex = 0;
            this.btnHelix.Text = "Praise Helix";
            this.btnHelix.UseVisualStyleBackColor = true;
            // 
            // btnDome
            // 
            this.btnDome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDome.Enabled = false;
            this.btnDome.Location = new System.Drawing.Point(133, 234);
            this.btnDome.Name = "btnDome";
            this.btnDome.Size = new System.Drawing.Size(106, 34);
            this.btnDome.TabIndex = 0;
            this.btnDome.Text = "Praise Dome";
            this.btnDome.UseVisualStyleBackColor = true;
            this.btnDome.Click += new System.EventHandler(this.btnDome_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TPP Simulator 1.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.contributorsTable);
            this.groupBox1.Controls.Add(this.linkContributors);
            this.groupBox1.Controls.Add(this.linkGithub);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 224);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // contributorsTable
            // 
            this.contributorsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contributorsTable.ColumnCount = 2;
            this.contributorsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contributorsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contributorsTable.Location = new System.Drawing.Point(9, 91);
            this.contributorsTable.Name = "contributorsTable";
            this.contributorsTable.RowCount = 2;
            this.contributorsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contributorsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contributorsTable.Size = new System.Drawing.Size(218, 127);
            this.contributorsTable.TabIndex = 4;
            this.contributorsTable.Visible = false;
            // 
            // linkContributors
            // 
            this.linkContributors.AutoSize = true;
            this.linkContributors.Location = new System.Drawing.Point(6, 75);
            this.linkContributors.Name = "linkContributors";
            this.linkContributors.Size = new System.Drawing.Size(78, 13);
            this.linkContributors.TabIndex = 3;
            this.linkContributors.TabStop = true;
            this.linkContributors.Text = "[+] Contributors";
            this.linkContributors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkContributors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkContributors_LinkClicked);
            // 
            // linkGithub
            // 
            this.linkGithub.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkGithub.AutoSize = true;
            this.linkGithub.Location = new System.Drawing.Point(14, 48);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(208, 13);
            this.linkGithub.TabIndex = 2;
            this.linkGithub.TabStop = true;
            this.linkGithub.Text = "http://github.com/flarn2006/TPPSimulator";
            this.linkGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGithub_LinkClicked);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.btnHelix;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 280);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDome);
            this.Controls.Add(this.btnHelix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelix;
        private System.Windows.Forms.Button btnDome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkGithub;
        private System.Windows.Forms.LinkLabel linkContributors;
        private System.Windows.Forms.TableLayoutPanel contributorsTable;
    }
}