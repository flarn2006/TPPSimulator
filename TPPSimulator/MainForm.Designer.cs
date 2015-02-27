namespace TPPSimulator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tsbPlayer = new System.Windows.Forms.ToolStripButton();
            this.tsbGoal = new System.Windows.Forms.ToolStripButton();
            this.tsbWall = new System.Windows.Forms.ToolStripButton();
            this.tsbLedge = new System.Windows.Forms.ToolStripButton();
            this.tsbSpinnerN = new System.Windows.Forms.ToolStripButton();
            this.tsbSpinnerS = new System.Windows.Forms.ToolStripButton();
            this.tsbSpinnerW = new System.Windows.Forms.ToolStripButton();
            this.tsbSpinnerE = new System.Windows.Forms.ToolStripButton();
            this.tsbSpinnerStop = new System.Windows.Forms.ToolStripButton();
            this.tsbShrub = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tileGrid = new TPPSimulator.TileGrid();
            this.inputGen = new TPPSimulator.InputGenerator();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStandard = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsSimulation = new System.Windows.Forms.ToolStrip();
            this.tsbAutorun = new System.Windows.Forms.ToolStripButton();
            this.tsbStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSimOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.inputCountText = new System.Windows.Forms.ToolStripTextBox();
            this.tsbResetCount = new System.Windows.Forms.ToolStripButton();
            this.tsMisc = new System.Windows.Forms.ToolStrip();
            this.tsbGen1Movement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStopSpinning = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbResizeMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDrawPath = new System.Windows.Forms.ToolStripButton();
            this.stepTimer = new System.Windows.Forms.Timer(this.components);
            this.docMgr = new TPPSimulator.DocumentManager(this.components);
            this.tsTools.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.tsStandard.SuspendLayout();
            this.tsSimulation.SuspendLayout();
            this.tsMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTools
            // 
            this.tsTools.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPlayer,
            this.tsbGoal,
            this.tsbWall,
            this.tsbLedge,
            this.tsbSpinnerN,
            this.tsbSpinnerS,
            this.tsbSpinnerW,
            this.tsbSpinnerE,
            this.tsbSpinnerStop,
            this.tsbShrub});
            this.tsTools.Location = new System.Drawing.Point(0, 3);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(24, 241);
            this.tsTools.TabIndex = 0;
            this.tsTools.Text = "Tools";
            this.tsTools.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbPlayer
            // 
            this.tsbPlayer.Checked = true;
            this.tsbPlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbPlayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlayer.Image = global::TPPSimulator.Properties.Resources.player_s;
            this.tsbPlayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlayer.Name = "tsbPlayer";
            this.tsbPlayer.Size = new System.Drawing.Size(22, 20);
            this.tsbPlayer.Text = "Player";
            this.tsbPlayer.Click += new System.EventHandler(this.tsbPlayer_Click);
            // 
            // tsbGoal
            // 
            this.tsbGoal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGoal.Image = global::TPPSimulator.Properties.Resources.goal;
            this.tsbGoal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGoal.Name = "tsbGoal";
            this.tsbGoal.Size = new System.Drawing.Size(22, 20);
            this.tsbGoal.Text = "Goal";
            this.tsbGoal.Click += new System.EventHandler(this.tsbGoal_Click);
            // 
            // tsbWall
            // 
            this.tsbWall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWall.Image = global::TPPSimulator.Properties.Resources.wall;
            this.tsbWall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWall.Name = "tsbWall";
            this.tsbWall.Size = new System.Drawing.Size(22, 20);
            this.tsbWall.Text = "Wall";
            this.tsbWall.Click += new System.EventHandler(this.tsbWall_Click);
            // 
            // tsbLedge
            // 
            this.tsbLedge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLedge.Image = global::TPPSimulator.Properties.Resources.ledge;
            this.tsbLedge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLedge.Name = "tsbLedge";
            this.tsbLedge.Size = new System.Drawing.Size(22, 20);
            this.tsbLedge.Text = "Ledge";
            this.tsbLedge.Click += new System.EventHandler(this.tsbLedge_Click);
            // 
            // tsbSpinnerN
            // 
            this.tsbSpinnerN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpinnerN.Image = global::TPPSimulator.Properties.Resources.spinner_n;
            this.tsbSpinnerN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpinnerN.Name = "tsbSpinnerN";
            this.tsbSpinnerN.Size = new System.Drawing.Size(22, 20);
            this.tsbSpinnerN.Text = "Spinner (N)";
            this.tsbSpinnerN.Click += new System.EventHandler(this.tsbSpinnerN_Click);
            // 
            // tsbSpinnerS
            // 
            this.tsbSpinnerS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpinnerS.Image = global::TPPSimulator.Properties.Resources.spinner_s;
            this.tsbSpinnerS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpinnerS.Name = "tsbSpinnerS";
            this.tsbSpinnerS.Size = new System.Drawing.Size(22, 20);
            this.tsbSpinnerS.Text = "Spinner (S)";
            this.tsbSpinnerS.Click += new System.EventHandler(this.tsbSpinnerS_Click);
            // 
            // tsbSpinnerW
            // 
            this.tsbSpinnerW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpinnerW.Image = global::TPPSimulator.Properties.Resources.spinner_w;
            this.tsbSpinnerW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpinnerW.Name = "tsbSpinnerW";
            this.tsbSpinnerW.Size = new System.Drawing.Size(22, 20);
            this.tsbSpinnerW.Text = "Spinner (W)";
            this.tsbSpinnerW.Click += new System.EventHandler(this.tsbSpinnerW_Click);
            // 
            // tsbSpinnerE
            // 
            this.tsbSpinnerE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpinnerE.Image = global::TPPSimulator.Properties.Resources.spinner_e;
            this.tsbSpinnerE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpinnerE.Name = "tsbSpinnerE";
            this.tsbSpinnerE.Size = new System.Drawing.Size(22, 20);
            this.tsbSpinnerE.Text = "Spinner (E)";
            this.tsbSpinnerE.Click += new System.EventHandler(this.tsbSpinnerE_Click);
            // 
            // tsbSpinnerStop
            // 
            this.tsbSpinnerStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpinnerStop.Image = global::TPPSimulator.Properties.Resources.spinner_stop;
            this.tsbSpinnerStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpinnerStop.Name = "tsbSpinnerStop";
            this.tsbSpinnerStop.Size = new System.Drawing.Size(22, 20);
            this.tsbSpinnerStop.Text = "Spinner (Stop)";
            this.tsbSpinnerStop.Click += new System.EventHandler(this.tsbSpinnerStop_Click);
            // 
            // tsbShrub
            // 
            this.tsbShrub.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShrub.Image = global::TPPSimulator.Properties.Resources.shrub;
            this.tsbShrub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShrub.Name = "tsbShrub";
            this.tsbShrub.Size = new System.Drawing.Size(22, 20);
            this.tsbShrub.Text = "toolStripButton1";
            this.tsbShrub.Click += new System.EventHandler(this.tsbShrub_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.inputGen);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(831, 494);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.tsTools);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(855, 568);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menu);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsStandard);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsSimulation);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsMisc);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tileGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 494);
            this.panel1.TabIndex = 0;
            // 
            // tileGrid
            // 
            this.tileGrid.Columns = 40;
            this.tileGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileGrid.LeftClickTile = null;
            this.tileGrid.Location = new System.Drawing.Point(0, 0);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.PathToDraw = null;
            this.tileGrid.Rows = 30;
            this.tileGrid.Size = new System.Drawing.Size(653, 490);
            this.tileGrid.TabIndex = 0;
            this.tileGrid.Text = "tileGrid1";
            this.tileGrid.GridChanged += new System.EventHandler(this.tileGrid_GridChanged);
            // 
            // inputGen
            // 
            this.inputGen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputGen.Dock = System.Windows.Forms.DockStyle.Right;
            this.inputGen.Location = new System.Drawing.Point(657, 0);
            this.inputGen.Name = "inputGen";
            this.inputGen.Size = new System.Drawing.Size(174, 494);
            this.inputGen.TabIndex = 1;
            this.inputGen.TileGrid = this.tileGrid;
            this.inputGen.StepIntervalChanged += new System.EventHandler(this.inputGen_StepIntervalChanged);
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(855, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.controlsToolStripMenuItem.Text = "&Controls";
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tsStandard
            // 
            this.tsStandard.Dock = System.Windows.Forms.DockStyle.None;
            this.tsStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton});
            this.tsStandard.Location = new System.Drawing.Point(3, 24);
            this.tsStandard.Name = "tsStandard";
            this.tsStandard.Size = new System.Drawing.Size(81, 25);
            this.tsStandard.TabIndex = 3;
            this.tsStandard.Text = "Standard";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // tsSimulation
            // 
            this.tsSimulation.Dock = System.Windows.Forms.DockStyle.None;
            this.tsSimulation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAutorun,
            this.tsbStep,
            this.toolStripSeparator1,
            this.tsbSimOptions,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.inputCountText,
            this.tsbResetCount});
            this.tsSimulation.Location = new System.Drawing.Point(84, 24);
            this.tsSimulation.Name = "tsSimulation";
            this.tsSimulation.Size = new System.Drawing.Size(411, 25);
            this.tsSimulation.TabIndex = 1;
            this.tsSimulation.Text = "Simulation Controls";
            // 
            // tsbAutorun
            // 
            this.tsbAutorun.CheckOnClick = true;
            this.tsbAutorun.Image = global::TPPSimulator.Properties.Resources.resultset_next;
            this.tsbAutorun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAutorun.Name = "tsbAutorun";
            this.tsbAutorun.Size = new System.Drawing.Size(108, 22);
            this.tsbAutorun.Text = "Run Simulation";
            this.tsbAutorun.Click += new System.EventHandler(this.tsbAutorun_Click);
            // 
            // tsbStep
            // 
            this.tsbStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStep.Image = global::TPPSimulator.Properties.Resources.resultset_last;
            this.tsbStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStep.Name = "tsbStep";
            this.tsbStep.Size = new System.Drawing.Size(23, 22);
            this.tsbStep.Text = "Step";
            this.tsbStep.Click += new System.EventHandler(this.tsbStep_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSimOptions
            // 
            this.tsbSimOptions.Checked = true;
            this.tsbSimOptions.CheckOnClick = true;
            this.tsbSimOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbSimOptions.Image = global::TPPSimulator.Properties.Resources.wrench;
            this.tsbSimOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSimOptions.Name = "tsbSimOptions";
            this.tsbSimOptions.Size = new System.Drawing.Size(101, 22);
            this.tsbSimOptions.Text = "Show Options";
            this.tsbSimOptions.Click += new System.EventHandler(this.tsbSimOptions_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Input Count:";
            // 
            // inputCountText
            // 
            this.inputCountText.Name = "inputCountText";
            this.inputCountText.ReadOnly = true;
            this.inputCountText.Size = new System.Drawing.Size(40, 25);
            this.inputCountText.Text = "0";
            this.inputCountText.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tsbResetCount
            // 
            this.tsbResetCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbResetCount.Image = ((System.Drawing.Image)(resources.GetObject("tsbResetCount.Image")));
            this.tsbResetCount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResetCount.Name = "tsbResetCount";
            this.tsbResetCount.Size = new System.Drawing.Size(39, 22);
            this.tsbResetCount.Text = "Reset";
            this.tsbResetCount.Click += new System.EventHandler(this.tsbResetCount_Click);
            // 
            // tsMisc
            // 
            this.tsMisc.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMisc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGen1Movement,
            this.toolStripSeparator3,
            this.tsbStopSpinning,
            this.toolStripSeparator2,
            this.tsbResizeMap,
            this.toolStripSeparator4,
            this.tsbMute,
            this.toolStripSeparator6,
            this.tsbDrawPath});
            this.tsMisc.Location = new System.Drawing.Point(3, 49);
            this.tsMisc.Name = "tsMisc";
            this.tsMisc.Size = new System.Drawing.Size(498, 25);
            this.tsMisc.TabIndex = 2;
            // 
            // tsbGen1Movement
            // 
            this.tsbGen1Movement.Checked = true;
            this.tsbGen1Movement.CheckOnClick = true;
            this.tsbGen1Movement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbGen1Movement.Image = global::TPPSimulator.Properties.Resources.arrow_undo;
            this.tsbGen1Movement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGen1Movement.Name = "tsbGen1Movement";
            this.tsbGen1Movement.Size = new System.Drawing.Size(130, 22);
            this.tsbGen1Movement.Text = "Gen 1 Style Turning";
            this.tsbGen1Movement.Click += new System.EventHandler(this.tsbGen1Movement_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbStopSpinning
            // 
            this.tsbStopSpinning.Image = global::TPPSimulator.Properties.Resources.spinner_stop;
            this.tsbStopSpinning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStopSpinning.Name = "tsbStopSpinning";
            this.tsbStopSpinning.Size = new System.Drawing.Size(101, 22);
            this.tsbStopSpinning.Text = "Stop Spinning";
            this.tsbStopSpinning.Click += new System.EventHandler(this.tsbStopSpinning_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbResizeMap
            // 
            this.tsbResizeMap.Image = global::TPPSimulator.Properties.Resources.arrow_out;
            this.tsbResizeMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbResizeMap.Name = "tsbResizeMap";
            this.tsbResizeMap.Size = new System.Drawing.Size(95, 22);
            this.tsbResizeMap.Text = "Resize Map...";
            this.tsbResizeMap.Click += new System.EventHandler(this.tsbResizeMap_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMute
            // 
            this.tsbMute.CheckOnClick = true;
            this.tsbMute.Image = global::TPPSimulator.Properties.Resources.sound_mute;
            this.tsbMute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMute.Name = "tsbMute";
            this.tsbMute.Size = new System.Drawing.Size(55, 22);
            this.tsbMute.Text = "Mute";
            this.tsbMute.Click += new System.EventHandler(this.tsbMute_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDrawPath
            // 
            this.tsbDrawPath.CheckOnClick = true;
            this.tsbDrawPath.Image = global::TPPSimulator.Properties.Resources.pencil_go;
            this.tsbDrawPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDrawPath.Name = "tsbDrawPath";
            this.tsbDrawPath.Size = new System.Drawing.Size(81, 22);
            this.tsbDrawPath.Text = "Draw Path";
            this.tsbDrawPath.Click += new System.EventHandler(this.tsbDrawPath_Click);
            // 
            // stepTimer
            // 
            this.stepTimer.Interval = 125;
            this.stepTimer.Tick += new System.EventHandler(this.stepTimer_Tick);
            // 
            // docMgr
            // 
            this.docMgr.AppTitle = "TPP Simulator PREVIEW";
            this.docMgr.OpenFilter = "Map files (*.tppmap)|*.tppmap|All files (*.*)|*.*";
            this.docMgr.SaveFilter = "Map files (*.tppmap)|*.tppmap|All files (*.*)|*.*";
            this.docMgr.AttemptOpenFile += new System.EventHandler<TPPSimulator.DocumentManager.AttemptOpenFileEventArgs>(this.docMgr_AttemptOpenFile);
            this.docMgr.AttemptSaveFile += new System.EventHandler<TPPSimulator.DocumentManager.AttemptOpenFileEventArgs>(this.docMgr_AttemptSaveFile);
            this.docMgr.TitleChanged += new System.EventHandler(this.saveMgr_TitleChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 568);
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Untitled - TPP Simulator PREVIEW";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tsStandard.ResumeLayout(false);
            this.tsStandard.PerformLayout();
            this.tsSimulation.ResumeLayout(false);
            this.tsSimulation.PerformLayout();
            this.tsMisc.ResumeLayout(false);
            this.tsMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripButton tsbWall;
        private System.Windows.Forms.ToolStripButton tsbLedge;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton tsbPlayer;
        private System.Windows.Forms.ToolStripButton tsbGoal;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsSimulation;
        private System.Windows.Forms.ToolStripButton tsbAutorun;
        private System.Windows.Forms.ToolStripButton tsbStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox inputCountText;
        private System.Windows.Forms.ToolStripButton tsbResetCount;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DocumentManager docMgr;
        private System.Windows.Forms.ToolStripButton tsbGen1Movement;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbStopSpinning;
        private System.Windows.Forms.ToolStripButton tsbSpinnerN;
        private System.Windows.Forms.ToolStripButton tsbSpinnerS;
        private System.Windows.Forms.ToolStripButton tsbSpinnerW;
        private System.Windows.Forms.ToolStripButton tsbSpinnerE;
        private System.Windows.Forms.ToolStripButton tsbSpinnerStop;
        private System.Windows.Forms.ToolStrip tsMisc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbResizeMap;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsStandard;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton tsbShrub;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbMute;
        private System.Windows.Forms.ToolStripButton tsbSimOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private InputGenerator inputGen;
        private System.Windows.Forms.Panel panel1;
        private TileGrid tileGrid;
        private System.Windows.Forms.Timer stepTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbDrawPath;

    }
}

