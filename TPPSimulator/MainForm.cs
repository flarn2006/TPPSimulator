using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPPSimulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private int _inputCount = 0;

        private int InputCount
        {
            get { return _inputCount; }
            set { _inputCount = value; inputCountText.Text = _inputCount.ToString(); }
        }

        private void DeselectAllTools()
        {
            foreach (ToolStripItem tsi in tsTools.Items) {
                if (tsi is ToolStripButton) {
                    ((ToolStripButton)tsi).Checked = false;
                }
            }
        }

        #region Tool button click event handlers

        private void tsbPlayer_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbPlayer.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Player;
        }

        private void tsbGoal_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbGoal.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Goal;
        }

        private void tsbWall_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbWall.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.Wall;
        }

        private void tsbLedge_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbLedge.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.Ledge;
        }

        private void tsbSpinnerN_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbSpinnerN.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.SpinnerN;
        }

        private void tsbSpinnerS_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbSpinnerS.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.SpinnerS;
        }

        private void tsbSpinnerW_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbSpinnerW.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.SpinnerW;
        }

        private void tsbSpinnerE_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbSpinnerE.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.SpinnerE;
        }

        private void tsbSpinnerStop_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbSpinnerStop.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.SpinnerStop;
        }

        private void tsbShrub_Click(object sender, EventArgs e)
        {
            DeselectAllTools();
            tsbShrub.Checked = true;
            tileGrid.ClickMode = TileGrid.LeftClickMode.Tile;
            tileGrid.LeftClickTile = TileType.Shrub;
        }

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift) {
                if (e.KeyCode == Keys.D) {
                    debugToolStripMenuItem.Visible = true;
                }
                return;
            }

            Input input = Input.None;

            switch (e.KeyCode) {
                case Keys.W: input = Input.Up; break;
                case Keys.S: input = Input.Down; break;
                case Keys.A: input = Input.Left; break;
                case Keys.D: input = Input.Right; break;
                case Keys.H: input = Input.Select; break;
                case Keys.J: input = Input.Start; break;
                case Keys.K: input = Input.B; break;
                case Keys.L: input = Input.A; break;
            }

            if (input != Input.None) {
                InputCount++;
                tileGrid.Player.Input(input);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*if (MessageBox.Show(@"I haven't actually implemented the code to simulate inputs yet, but you can move around manually using WASD.
In the mean time, enjoy this preview!", "Welcome!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel) {
                MessageBox.Show("If you're not going to enjoy it, I'll save you the trouble of quitting. Kappa", "Fine then.");
                Application.Exit();
            }*/
        }

        private void tsbResetCount_Click(object sender, EventArgs e)
        {
            InputCount = 0;
        }

        private void docMgr_TitleChanged(object sender, PropertyChangedEventArgs e)
        {
            Text = docMgr.WindowTitle;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            docMgr.SuppressTitleChangedEvents = true;
            if (docMgr.NewDocument()) {
                tileGrid.ResizeGrid(40, 30);
                tileGrid.InitializeGrid();
                tileGrid.Player.Location = Point.Empty;
                tileGrid.GoalLocation = new Point(tileGrid.Columns - 1, tileGrid.Rows - 1);
                docMgr.Dirty = false;
            }
            docMgr.SuppressTitleChangedEvents = false;
            Text = docMgr.WindowTitle;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            docMgr.Open();
        }

        private void SaveMap(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("TPP Simulator Map File");
            sw.WriteLine("PlayerX=" + tileGrid.Player.Location.X);
            sw.WriteLine("PlayerY=" + tileGrid.Player.Location.Y);
            sw.WriteLine("GoalX=" + tileGrid.GoalLocation.X);
            sw.WriteLine("GoalY=" + tileGrid.GoalLocation.Y);
            sw.WriteLine("Columns=" + tileGrid.Columns);
            sw.WriteLine("Rows=" + tileGrid.Rows);
            sw.WriteLine("StartMap");

            for (int y = 0; y < tileGrid.Rows; y++) {
                for (int x = 0; x < tileGrid.Columns; x++) {
                    TileType tile = tileGrid.GetTile(x, y);
                    char ch = '?';
                    if (tile == TileType.Empty) ch = '.';
                    else if (tile == TileType.Wall) ch = '#';
                    else if (tile == TileType.Ledge) ch = '_';
                    else if (tile == TileType.SpinnerN) ch = '^';
                    else if (tile == TileType.SpinnerS) ch = 'v';
                    else if (tile == TileType.SpinnerW) ch = '<';
                    else if (tile == TileType.SpinnerE) ch = '>';
                    else if (tile == TileType.SpinnerStop) ch = 'X';
                    else if (tile == TileType.Shrub || tile == TileType.ShrubRemoved) ch = 'S';
                    sw.Write(ch);
                }
                sw.WriteLine();
            }

            sw.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            docMgr.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            docMgr.SaveAs();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !docMgr.PromptBeforeExit();
        }

        private void tileGrid_GridChanged(object sender, EventArgs e)
        {
            docMgr.Dirty = true;
            inputGen.RebuildGraphEnabled = true;
        }

        private void tsbGen1Movement_Click(object sender, EventArgs e)
        {
            tileGrid.Player.Gen1Movement = tsbGen1Movement.Checked;
        }

        private void tsbStopSpinning_Click(object sender, EventArgs e)
        {
            tileGrid.Player.SpinDirection = Direction.None;
        }

        private void docMgr_AttemptOpenFile(object sender, DocumentManager.AttemptOpenFileEventArgs e)
        {
            try {
                tileGrid.LoadMap(e.Path);
            } catch (InvalidDataException ex) {
                MessageBox.Show(ex.Message, "Error reading map", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            } catch (IOException ex) {
                MessageBox.Show(ex.Message, "Error reading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void docMgr_AttemptSaveFile(object sender, DocumentManager.AttemptOpenFileEventArgs e)
        {
            try {
                SaveMap(e.Path);
            } catch (IOException ex) {
                MessageBox.Show(ex.Message, "Error saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void tsbResizeMap_Click(object sender, EventArgs e)
        {
            if (ResizeMapDialog.PromptToResize(tileGrid) == DialogResult.OK) {
                inputGen.UpdateGraph();
            }
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"W = Up
S = Down
A = Left
D = Right
H = Select
J = Start
K = B
L = A", "Manual Input Controls", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbMute_Click(object sender, EventArgs e)
        {
            SoundPlayer.Enabled = !tsbMute.Checked;
        }

        private void tsbSimOptions_Click(object sender, EventArgs e)
        {
            inputGen.Visible = tsbSimOptions.Checked;
        }

        private void DoStep()
        {
            Input input = inputGen.GetNextInput();
            tileGrid.Player.Input(input);
            if (input != Input.None) InputCount++;
        }

        private void tsbStep_Click(object sender, EventArgs e)
        {
            DoStep();
        }

        private void stepTimer_Tick(object sender, EventArgs e)
        {
            DoStep();
        }

        private void inputGen_StepIntervalChanged(object sender, EventArgs e)
        {
            stepTimer.Interval = inputGen.StepInterval;
        }

        private void tsbAutorun_Click(object sender, EventArgs e)
        {
            stepTimer.Enabled = tsbAutorun.Checked;
            if (tsbAutorun.Checked) {
                inputGen.UpdateGraph();
            }
        }

        private void tsbDrawPath_Click(object sender, EventArgs e)
        {
            inputGen.DrawPath = tsbDrawPath.Checked;
        }

        private void exportGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Trivial Graph Format (*.tgf)|*.tgf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK) {
                StreamWriter sw = new StreamWriter(dlg.FileName, false);
                inputGen.Graph.ExportTGF(sw);
                sw.Close();
            }
        }

        private void displayGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugShowGraphForm.DisplayGraph(inputGen.Graph, tileGrid.Columns, tileGrid.Rows);
        }

        private void inputGen_Load(object sender, EventArgs e)
        {

        }

        private void tileGrid_GoalReached(object sender, EventArgs e)
        {
            tsbAutorun.Checked = false;
            stepTimer.Enabled = false;
            SoundPlayer.Play(Properties.Resources.goal_snd);
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(tileGrid.Columns * TileGrid.TileSize, tileGrid.Rows * TileGrid.TileSize);
            tileGrid.DrawMapImage(Graphics.FromImage(bmp));
            if (exportImageDlg.ShowDialog() == DialogResult.OK) {
                bool done = false;
                while (!done) {
                    try {
                        bmp.Save(exportImageDlg.FileName, ImageFormat.Png);
                        done = true;
                    } catch (IOException ex) {
                        if (MessageBox.Show(ex.Message, exportImageDlg.Title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel) {
                            done = true;
                        }
                    }
                }
            }
        }

        private void pastebinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            if (PastebinImportForm.ImportMap(out filename) == DialogResult.OK) {
                docMgr.Open(filename);
            }
        }
    }
}
