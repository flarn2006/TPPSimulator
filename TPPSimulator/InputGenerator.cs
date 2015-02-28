using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphUtils;

namespace TPPSimulator
{
    public interface IInputGenerator
    {
        Input GetNextInput();
    }

    public partial class InputGenerator : UserControl, IInputGenerator
    {
        private static Random rng;

        static InputGenerator()
        {
            rng = new Random();
        }

        private Queue<Input> inputQueue;
        private TileGrid tileGrid = null;
        private Graph<Point> graph;
        private IEnumerable<Point> path = null;
        private bool drawPath = false;

        public InputGenerator()
        {
            InitializeComponent();
            inputQueue = new Queue<Input>();
        }

        public event EventHandler StepIntervalChanged;

        protected virtual void OnStepIntervalChanged(EventArgs e)
        {
            if (StepIntervalChanged != null) StepIntervalChanged(this, e);
        }

        protected void OnStepIntervalChanged()
        {
            OnStepIntervalChanged(EventArgs.Empty);
        }

        public Input GetPathInput()
        {
            if (tileGrid.Player.Menu.State != null) {
                return Input.B;
            } else {
                Direction[] directions = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
                Point pt = tileGrid.Player.Location;
                Node<Point> predecessor = graph.GetNode(pt).PathPredecessor;
                if (predecessor == null) return Input.None;
                foreach (Direction dir in directions) {
                    if (pt.Move(dir).Equals(predecessor.Data)) {
                        return dir.ToInput();
                    }
                }
                return Input.None;
            }
        }

        public Input GetNextInputForQueue()
        {
            TrackBar[] sliders = new TrackBar[] { tbPath, tbUp, tbDown, tbLeft, tbRight, tbA, tbB, tbSelect, tbStart, tbNone };
            Input[] inputs = new Input[] { Input.None, Input.Up, Input.Down, Input.Left, Input.Right, Input.A, Input.B, Input.Select, Input.Start, Input.None };

            int total = 0;
            foreach (TrackBar tb in sliders) {
                total += tb.Value;
            }

            if (total == 0) return Input.None;

            int random = rng.Next(total);

            total = 0;
            for (int i = 0; i < 10; i++) {
                total += sliders[i].Value;
                if (random < total) {
                    if (i == 0)
                        return GetPathInput();
                    else
                        return inputs[i];
                }
            }

            throw new Exception("Only way code should reach here is if the random number wasn't in the correct range.");
        }

        public void UpdateProgressBar()
        {
            if (udStreamDelay.Value == 0) {
                queueBar.Value = queueBar.Maximum;
                btnClearQueue.Enabled = false;
                btnFillQueue.Enabled = false;
            } else {
                queueBar.Maximum = (int)udStreamDelay.Value;
                queueBar.Value = Math.Min(inputQueue.Count, queueBar.Maximum);
                btnClearQueue.Enabled = (inputQueue.Count > 0);
                btnFillQueue.Enabled = (inputQueue.Count < udStreamDelay.Value);
            }
        }

        public Input GetNextInput()
        {
            Input result;
            UpdateProgressBar();
            if (udStreamDelay.Value == 0) {
                result = GetNextInputForQueue();
            } else {
                if (inputQueue.Count < udStreamDelay.Value) {
                    inputQueue.Enqueue(GetNextInputForQueue());
                    result = Input.None;
                } else {
                    if (inputQueue.Count == udStreamDelay.Value) {
                        inputQueue.Enqueue(GetNextInputForQueue());
                    }
                    result = inputQueue.Dequeue();
                }
            }

            if (result != Input.None) {
                lastInputs.Items.Insert(0, result);
                if (lastInputs.Items.Count > (lastInputs.Height / lastInputs.ItemHeight)) {
                    lastInputs.Items.RemoveAt(lastInputs.Items.Count - 1);
                }
            }

            return result;
        }

        private void AdjustUpDownAndClamp(NumericUpDown control, decimal delta)
        {
            decimal newValue = control.Value + delta;
            if (newValue < control.Minimum) newValue = control.Minimum;
            else if (newValue > control.Maximum) newValue = control.Maximum;
            control.Value = newValue;
        }

        private void vdlStepInterval_ValueDrag(object sender, ValueDragLabel.ValueDragEventArgs e)
        {
            AdjustUpDownAndClamp(udStepInterval, 10 * e.Delta);
        }

        private void vdlStreamDelay_ValueDrag(object sender, ValueDragLabel.ValueDragEventArgs e)
        {
            AdjustUpDownAndClamp(udStreamDelay, 10 * e.Delta);
        }

        private void udStepInterval_ValueChanged(object sender, EventArgs e)
        {
            UpdateStreamDelayLabel();
            OnStepIntervalChanged(e);
        }

        [DefaultValue(125)]
        public int StepInterval
        {
            get { return (int)udStepInterval.Value; }
            set { udStepInterval.Value = value; }
        }

        private void udStreamDelay_ValueChanged(object sender, EventArgs e)
        {
            UpdateStreamDelayLabel();
            UpdateProgressBar();
        }

        private void UpdateStreamDelayLabel()
        {
            if (udStreamDelay.Value == 0) {
                streamDelayLabel.Text = "Stream delay: (none)";
            } else {
                streamDelayLabel.Text = String.Format("Stream delay: {0} sec", udStreamDelay.Value * udStepInterval.Value / 1000);
            }
        }

        private void pathLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(@"This controls the weight to give whatever input is determined to be ""best"" according to a pathfinding algorithm.
Note that this slider's maximum is 10 times more than the others.
This function is not yet implemented.", "Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFillQueue_Click(object sender, EventArgs e)
        {
            while (inputQueue.Count < udStreamDelay.Value) {
                GetNextInput();
            }
            UpdateProgressBar();
        }

        private void clearQueueBtn_Click(object sender, EventArgs e)
        {
            inputQueue.Clear();
            UpdateProgressBar();
        }

        [DefaultValue(null), Category("Behavior"), Description("The tile grid for which the inputs are generated.")]
        public TileGrid TileGrid
        {
            get { return tileGrid; }
            set
            {
                if (tileGrid != null) {
                    tileGrid.GridChanged -= tileGrid_GridChanged;
                    tileGrid.GoalMoved -= tileGrid_GoalMoved;
                }
                tileGrid = value;
                tileGrid.GridChanged += tileGrid_GridChanged;
                tileGrid.GoalMoved += tileGrid_GoalMoved;
                if (tileGrid.Player != null) UpdateGraph();
            }
        }

        private void tileGrid_GoalMoved(object sender, EventArgs e)
        {
            RecalculatePath();
        }

        private void tileGrid_GridChanged(object sender, EventArgs e)
        {
            //UpdateGraph();
        }

        public void UpdateGraph(bool recalculatePath = true)
        {
            graph = new Graph<Point>((uint)(tileGrid.Rows * tileGrid.Columns));

            for (int y = 0; y < tileGrid.Rows; y++) {
                for (int x = 0; x < tileGrid.Columns; x++) {
                    graph.AddNode(new Point(x, y));
                }
            }

            for (int y = 0; y < tileGrid.Rows; y++) {
                for (int x = 0; x < tileGrid.Columns; x++) {
                    Point pt = new Point(x, y);
                    Direction[] directions = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
                    foreach (Direction dir in directions) {
                        Point adjacent = pt.Move(dir);
                        if (adjacent.X >= 0 && adjacent.X < tileGrid.Columns && adjacent.Y >= 0 && adjacent.Y < tileGrid.Rows) {
                            if (tileGrid.GetTile(adjacent).Passable.IsPassableFrom(dir.Opposite())) {
                                // Note: edges are reversed, as the player moves much more often than the goal does!
                                graph.GetNode(adjacent).ConnectToNode(pt);
                            }
                        }
                    }
                }
            }

            graph.BuildPathfindingData(graph.GetNode(tileGrid.GoalLocation));

            if (recalculatePath) RecalculatePath();

            btnRebuildGraph.Enabled = false;
        }

        [DefaultValue(true), Category("Appearance"), Description("Indicates whether the \"Recompile Map\" button can be selected.")]
        public bool RebuildGraphEnabled
        {
            get { return btnRebuildGraph.Enabled; }
            set { btnRebuildGraph.Enabled = value; }
        }

        public void RecalculatePath()
        {
            if (graph == null) UpdateGraph(false);
            if (drawPath) {
                path = graph.GetNode(tileGrid.GoalLocation).FindPath(tileGrid.Player.Location).Select(node => node.Data);
                tileGrid.PathToDraw = path.Select(p => new Point(16 * p.X + 8, 16 * p.Y + 8)).ToArray();
            }
        }

        [DefaultValue(false), Category("Appearance"), Description("Indicates whether or not to draw the calculated path on the tile grid.")]
        public bool DrawPath
        {
            get { return drawPath; }
            set
            {
                drawPath = value;
                if (drawPath) {
                    RecalculatePath();
                } else {
                    tileGrid.PathToDraw = null;
                }
            }
        }

        private void btnRebuildGraph_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        [Browsable(false)]
        public Graph<Point> Graph
        {
            get { return graph; }
        }
    }
}
