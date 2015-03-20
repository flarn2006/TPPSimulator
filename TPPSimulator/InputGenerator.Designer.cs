namespace TPPSimulator
{
    partial class InputGenerator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFillQueue = new System.Windows.Forms.Button();
            this.streamDelayLabel = new System.Windows.Forms.Label();
            this.queueBar = new System.Windows.Forms.ProgressBar();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.udStreamDelay = new System.Windows.Forms.NumericUpDown();
            this.udStepInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbNone = new System.Windows.Forms.TrackBar();
            this.tbStart = new System.Windows.Forms.TrackBar();
            this.tbSelect = new System.Windows.Forms.TrackBar();
            this.tbB = new System.Windows.Forms.TrackBar();
            this.tbA = new System.Windows.Forms.TrackBar();
            this.tbRight = new System.Windows.Forms.TrackBar();
            this.tbLeft = new System.Windows.Forms.TrackBar();
            this.tbDown = new System.Windows.Forms.TrackBar();
            this.tbUp = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TrackBar();
            this.pathLink = new System.Windows.Forms.LinkLabel();
            this.lastInputs = new System.Windows.Forms.ListBox();
            this.btnRebuildGraph = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chatInputList = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblAIMonitor = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pieChart = new TPPSimulator.PieChart.PieChart();
            this.vdlStreamDelay = new TPPSimulator.ValueDragLabel();
            this.vdlStepInterval = new TPPSimulator.ValueDragLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStreamDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStepInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPath)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnFillQueue);
            this.groupBox1.Controls.Add(this.streamDelayLabel);
            this.groupBox1.Controls.Add(this.queueBar);
            this.groupBox1.Controls.Add(this.btnClearQueue);
            this.groupBox1.Controls.Add(this.vdlStreamDelay);
            this.groupBox1.Controls.Add(this.udStreamDelay);
            this.groupBox1.Controls.Add(this.vdlStepInterval);
            this.groupBox1.Controls.Add(this.udStepInterval);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Timing";
            // 
            // btnFillQueue
            // 
            this.btnFillQueue.Enabled = false;
            this.btnFillQueue.Image = global::TPPSimulator.Properties.Resources.time_go;
            this.btnFillQueue.Location = new System.Drawing.Point(139, 89);
            this.btnFillQueue.Name = "btnFillQueue";
            this.btnFillQueue.Size = new System.Drawing.Size(23, 23);
            this.btnFillQueue.TabIndex = 7;
            this.btnFillQueue.UseVisualStyleBackColor = true;
            this.btnFillQueue.Click += new System.EventHandler(this.btnFillQueue_Click);
            // 
            // streamDelayLabel
            // 
            this.streamDelayLabel.AutoSize = true;
            this.streamDelayLabel.Location = new System.Drawing.Point(6, 73);
            this.streamDelayLabel.Name = "streamDelayLabel";
            this.streamDelayLabel.Size = new System.Drawing.Size(104, 13);
            this.streamDelayLabel.TabIndex = 6;
            this.streamDelayLabel.Text = "Stream delay: (none)";
            // 
            // queueBar
            // 
            this.queueBar.Location = new System.Drawing.Point(6, 89);
            this.queueBar.Name = "queueBar";
            this.queueBar.Size = new System.Drawing.Size(127, 23);
            this.queueBar.TabIndex = 5;
            this.queueBar.Value = 100;
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.Enabled = false;
            this.btnClearQueue.Image = global::TPPSimulator.Properties.Resources.joystick_delete;
            this.btnClearQueue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearQueue.Location = new System.Drawing.Point(6, 118);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(156, 23);
            this.btnClearQueue.TabIndex = 4;
            this.btnClearQueue.Text = "Clear Input Queue";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.clearQueueBtn_Click);
            // 
            // udStreamDelay
            // 
            this.udStreamDelay.Location = new System.Drawing.Point(6, 45);
            this.udStreamDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udStreamDelay.Name = "udStreamDelay";
            this.udStreamDelay.Size = new System.Drawing.Size(51, 20);
            this.udStreamDelay.TabIndex = 2;
            this.udStreamDelay.ValueChanged += new System.EventHandler(this.udStreamDelay_ValueChanged);
            // 
            // udStepInterval
            // 
            this.udStepInterval.Location = new System.Drawing.Point(6, 19);
            this.udStepInterval.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.udStepInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStepInterval.Name = "udStepInterval";
            this.udStepInterval.Size = new System.Drawing.Size(51, 20);
            this.udStepInterval.TabIndex = 0;
            this.udStepInterval.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.udStepInterval.ValueChanged += new System.EventHandler(this.udStepInterval_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(3, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 311);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Selection Weight";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbNone, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.tbStart, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.tbSelect, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbB, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbA, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbRight, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbLeft, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbUp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pathLink, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(162, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbNone
            // 
            this.tbNone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNone.Location = new System.Drawing.Point(51, 264);
            this.tbNone.Maximum = 100;
            this.tbNone.Name = "tbNone";
            this.tbNone.Size = new System.Drawing.Size(108, 23);
            this.tbNone.TabIndex = 20;
            this.tbNone.TickFrequency = 10;
            this.tbNone.Value = 10;
            this.tbNone.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbNone.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbNone.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbStart
            // 
            this.tbStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStart.Location = new System.Drawing.Point(51, 235);
            this.tbStart.Maximum = 100;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(108, 23);
            this.tbStart.TabIndex = 19;
            this.tbStart.TickFrequency = 10;
            this.tbStart.Value = 50;
            this.tbStart.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbStart.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbStart.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbSelect
            // 
            this.tbSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSelect.Location = new System.Drawing.Point(51, 206);
            this.tbSelect.Maximum = 100;
            this.tbSelect.Name = "tbSelect";
            this.tbSelect.Size = new System.Drawing.Size(108, 23);
            this.tbSelect.TabIndex = 18;
            this.tbSelect.TickFrequency = 10;
            this.tbSelect.Value = 50;
            this.tbSelect.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbSelect.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbSelect.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbB
            // 
            this.tbB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbB.Location = new System.Drawing.Point(51, 177);
            this.tbB.Maximum = 100;
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(108, 23);
            this.tbB.TabIndex = 17;
            this.tbB.TickFrequency = 10;
            this.tbB.Value = 50;
            this.tbB.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbB.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbB.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbA
            // 
            this.tbA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbA.Location = new System.Drawing.Point(51, 148);
            this.tbA.Maximum = 100;
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(108, 23);
            this.tbA.TabIndex = 16;
            this.tbA.TickFrequency = 10;
            this.tbA.Value = 50;
            this.tbA.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbA.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbA.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbRight
            // 
            this.tbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRight.Location = new System.Drawing.Point(51, 119);
            this.tbRight.Maximum = 100;
            this.tbRight.Name = "tbRight";
            this.tbRight.Size = new System.Drawing.Size(108, 23);
            this.tbRight.TabIndex = 15;
            this.tbRight.TickFrequency = 10;
            this.tbRight.Value = 50;
            this.tbRight.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbRight.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbRight.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbLeft
            // 
            this.tbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLeft.Location = new System.Drawing.Point(51, 90);
            this.tbLeft.Maximum = 100;
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.Size = new System.Drawing.Size(108, 23);
            this.tbLeft.TabIndex = 14;
            this.tbLeft.TickFrequency = 10;
            this.tbLeft.Value = 50;
            this.tbLeft.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbLeft.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbLeft.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbDown
            // 
            this.tbDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDown.Location = new System.Drawing.Point(51, 61);
            this.tbDown.Maximum = 100;
            this.tbDown.Name = "tbDown";
            this.tbDown.Size = new System.Drawing.Size(108, 23);
            this.tbDown.TabIndex = 13;
            this.tbDown.TickFrequency = 10;
            this.tbDown.Value = 50;
            this.tbDown.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbDown.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbDown.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // tbUp
            // 
            this.tbUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUp.Location = new System.Drawing.Point(51, 32);
            this.tbUp.Maximum = 100;
            this.tbUp.Name = "tbUp";
            this.tbUp.Size = new System.Drawing.Size(108, 23);
            this.tbUp.TabIndex = 11;
            this.tbUp.TickFrequency = 10;
            this.tbUp.Value = 50;
            this.tbUp.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbUp.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbUp.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 29);
            this.label10.TabIndex = 9;
            this.label10.Text = "Wait";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 29);
            this.label9.TabIndex = 8;
            this.label9.Text = "Right";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "Start";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Left";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Select";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Down";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "B";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Up";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPath
            // 
            this.tbPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPath.Location = new System.Drawing.Point(51, 3);
            this.tbPath.Maximum = 900;
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(108, 23);
            this.tbPath.TabIndex = 10;
            this.tbPath.TickFrequency = 50;
            this.tbPath.Value = 500;
            this.tbPath.Scroll += new System.EventHandler(this.inputSliders_Scroll);
            this.tbPath.MouseEnter += new System.EventHandler(this.inputSliders_MouseEnter);
            this.tbPath.MouseLeave += new System.EventHandler(this.inputSliders_MouseLeave);
            // 
            // pathLink
            // 
            this.pathLink.AutoSize = true;
            this.pathLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLink.LinkArea = new System.Windows.Forms.LinkArea(5, 1);
            this.pathLink.Location = new System.Drawing.Point(3, 0);
            this.pathLink.Name = "pathLink";
            this.pathLink.Size = new System.Drawing.Size(42, 29);
            this.pathLink.TabIndex = 12;
            this.pathLink.TabStop = true;
            this.pathLink.Text = "Path ?";
            this.pathLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pathLink.UseCompatibleTextRendering = true;
            this.pathLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pathLink_LinkClicked);
            // 
            // lastInputs
            // 
            this.lastInputs.BackColor = System.Drawing.Color.Black;
            this.lastInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lastInputs.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastInputs.ForeColor = System.Drawing.Color.White;
            this.lastInputs.FormattingEnabled = true;
            this.lastInputs.IntegralHeight = false;
            this.lastInputs.ItemHeight = 23;
            this.lastInputs.Location = new System.Drawing.Point(3, 3);
            this.lastInputs.Name = "lastInputs";
            this.lastInputs.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lastInputs.Size = new System.Drawing.Size(154, 120);
            this.lastInputs.TabIndex = 2;
            // 
            // btnRebuildGraph
            // 
            this.btnRebuildGraph.Image = global::TPPSimulator.Properties.Resources.chart_organisation;
            this.btnRebuildGraph.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRebuildGraph.Location = new System.Drawing.Point(3, 156);
            this.btnRebuildGraph.Name = "btnRebuildGraph";
            this.btnRebuildGraph.Size = new System.Drawing.Size(168, 33);
            this.btnRebuildGraph.TabIndex = 3;
            this.btnRebuildGraph.Text = "Recompile Map";
            this.btnRebuildGraph.UseVisualStyleBackColor = true;
            this.btnRebuildGraph.Click += new System.EventHandler(this.btnRebuildGraph_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 509);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(168, 152);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chatInputList);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(160, 126);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Chat Inputs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chatInputList
            // 
            this.chatInputList.BackColor = System.Drawing.Color.Black;
            this.chatInputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatInputList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatInputList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.chatInputList.FormattingEnabled = true;
            this.chatInputList.IntegralHeight = false;
            this.chatInputList.ItemHeight = 14;
            this.chatInputList.Location = new System.Drawing.Point(0, 0);
            this.chatInputList.Name = "chatInputList";
            this.chatInputList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.chatInputList.Size = new System.Drawing.Size(160, 126);
            this.chatInputList.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lastInputs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(160, 126);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inputs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblAIMonitor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(160, 126);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AI Monitor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblAIMonitor
            // 
            this.lblAIMonitor.BackColor = System.Drawing.Color.Black;
            this.lblAIMonitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAIMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAIMonitor.ForeColor = System.Drawing.Color.Lime;
            this.lblAIMonitor.Location = new System.Drawing.Point(3, 3);
            this.lblAIMonitor.Name = "lblAIMonitor";
            this.lblAIMonitor.Size = new System.Drawing.Size(154, 120);
            this.lblAIMonitor.TabIndex = 0;
            this.lblAIMonitor.Text = "Inputs are broken!\r\nヽ༼ຈل͜ຈ༽ﾉ RIOT ヽ༼ຈل͜ຈ༽ﾉ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pieChart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(160, 126);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pieChart
            // 
            this.pieChart.BackColor = System.Drawing.Color.White;
            this.pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart.Location = new System.Drawing.Point(0, 0);
            this.pieChart.Name = "pieChart";
            this.pieChart.PieMargin = 0;
            this.pieChart.Size = new System.Drawing.Size(160, 126);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "pieChart1";
            // 
            // vdlStreamDelay
            // 
            this.vdlStreamDelay.AutoSize = true;
            this.vdlStreamDelay.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vdlStreamDelay.Location = new System.Drawing.Point(63, 47);
            this.vdlStreamDelay.Name = "vdlStreamDelay";
            this.vdlStreamDelay.Size = new System.Drawing.Size(94, 13);
            this.vdlStreamDelay.TabIndex = 3;
            this.vdlStreamDelay.Text = "steps stream delay";
            this.vdlStreamDelay.ValueDrag += new System.EventHandler<TPPSimulator.ValueDragLabel.ValueDragEventArgs>(this.vdlStreamDelay_ValueDrag);
            // 
            // vdlStepInterval
            // 
            this.vdlStepInterval.AutoSize = true;
            this.vdlStepInterval.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.vdlStepInterval.Location = new System.Drawing.Point(63, 21);
            this.vdlStepInterval.Name = "vdlStepInterval";
            this.vdlStepInterval.Size = new System.Drawing.Size(92, 13);
            this.vdlStepInterval.TabIndex = 1;
            this.vdlStepInterval.Text = "ms between steps";
            this.vdlStepInterval.ValueDrag += new System.EventHandler<TPPSimulator.ValueDragLabel.ValueDragEventArgs>(this.vdlStepInterval_ValueDrag);
            // 
            // InputGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRebuildGraph);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "InputGenerator";
            this.Size = new System.Drawing.Size(174, 664);
            this.Load += new System.EventHandler(this.InputGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udStreamDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStepInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPath)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udStepInterval;
        private ValueDragLabel vdlStepInterval;
        private System.Windows.Forms.Button btnClearQueue;
        private ValueDragLabel vdlStreamDelay;
        private System.Windows.Forms.NumericUpDown udStreamDelay;
        private System.Windows.Forms.ProgressBar queueBar;
        private System.Windows.Forms.Label streamDelayLabel;
        private System.Windows.Forms.Button btnFillQueue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar tbUp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbPath;
        private System.Windows.Forms.LinkLabel pathLink;
        private System.Windows.Forms.TrackBar tbNone;
        private System.Windows.Forms.TrackBar tbStart;
        private System.Windows.Forms.TrackBar tbSelect;
        private System.Windows.Forms.TrackBar tbB;
        private System.Windows.Forms.TrackBar tbA;
        private System.Windows.Forms.TrackBar tbRight;
        private System.Windows.Forms.TrackBar tbLeft;
        private System.Windows.Forms.TrackBar tbDown;
        private System.Windows.Forms.ListBox lastInputs;
        private System.Windows.Forms.Button btnRebuildGraph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblAIMonitor;
        private System.Windows.Forms.TabPage tabPage3;
        private PieChart.PieChart pieChart;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox chatInputList;

    }
}
