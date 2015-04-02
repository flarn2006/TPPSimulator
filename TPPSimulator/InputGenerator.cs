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
using TPPSimulator.PieChart;

namespace TPPSimulator
{
    public interface IInputGenerator
    {
        Input GetNextInput();
        void MapChanged(bool silent = false);
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
        private bool shownImpossibleMessage = false;
        TrackBar[] sliders;
        Color[] pieSliceColors;
        Dictionary<TrackBar, PieSlice> pieSlices;

        public InputGenerator()
        {
            InitializeComponent();
            inputQueue = new Queue<Input>();
            sliders = new TrackBar[] { tbPath, tbUp, tbDown, tbLeft, tbRight, tbA, tbB, tbSelect, tbStart, tbNone };
            pieSliceColors = new Color[] { Color.Silver, Color.Blue, Color.FromArgb(0, 0, 192), Color.Navy, Color.FromArgb(0, 0, 64), Color.Green, Color.Red, Color.Magenta, Color.Orange, Color.Black };
            pieSlices = new Dictionary<TrackBar, PieSlice>();
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

        private Direction GetNextDirection(Node<Point> node)
        {
            if (node.PathPredecessor != null) {
                Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
                foreach (Direction dir in directions) {
                    if (node.Data.Move(dir).Equals(node.PathPredecessor.Data)) {
                        return dir;
                    }
                }
                return Direction.None;
            } else {
                return Direction.None;
            }
        }

        public Input GetPathInput()
        {
            // First, check if there's a shrub nearby. If so, do Start and A.
            bool foundShrub = false;
            Node<Point> node = graph.GetNode(tileGrid.Player.Location);
            for (int i = 0; i < 3; i++) {
                if (node == null) break;
                if (tileGrid.GetTile(node.Data) == TileType.Shrub) {
                    foundShrub = true;
                    break;
                }
                node = node.PathPredecessor;
            }

            if (foundShrub) {
                // Try to use Cut
                Direction nextDir = GetNextDirection(graph.GetNode(tileGrid.Player.Location));
                lblAIMonitor.Text = "Spam Start and A to use Cut!\r\nAlso, a little up, down, and B.\r\nAnd " + nextDir.ToString() + " as well.";
                Input[] choices = new Input[] { Input.Start, Input.Start, Input.Start, Input.Start, Input.Start, Input.A, Input.A, Input.A, Input.A, Input.A, Input.Up, Input.Down, Input.B, nextDir.ToInput(), nextDir.ToInput() };
                return choices[rng.Next(choices.Length)];
            } else {
                if (tileGrid.Player.Menu.State != null) {
                    lblAIMonitor.Text = "Spam B! Get out of the menu!";
                    return Input.B;
                } else {
                    // Get the predecessor of the player's node (remember, the path is reversed) and a few before that, and pick a random one
                    
                    node = graph.GetNode(tileGrid.Player.Location);
                    if (node.PathPredecessor == null) {
                        if (tileGrid.Player.Location.Equals(tileGrid.GoalLocation)) {
                            lblAIMonitor.Text = "TEH URN!";
                        } else {
                            lblAIMonitor.Text = "This is impossible!\r\nヽ༼ຈل͜ຈ༽ﾉ RIOT ヽ༼ຈل͜ຈ༽ﾉ";
                        }
                        return Input.None;
                    }

                    List<Direction> choices = new List<Direction>();

                    for (int i = 0; i < 5; i++) {
                        if (node.PathPredecessor == null) break;

                        // Determine which direction it went
                        Direction nextDir = GetNextDirection(node);
                        if (nextDir != Direction.None) choices.Add(nextDir);

                        // Now set the current node to its predecessor for the next step
                        node = node.PathPredecessor;
                        if (node == null) break;
                    }

                    if (choices.Count == 0) {
                        return Input.None;
                    } else {
                        StringBuilder sb = new StringBuilder("Next steps are:\r\n");
                        for (int i = 0; i < choices.Count; i++) {
                            sb.Append(choices[i]);
                            if (i < choices.Count - 1) sb.Append(", ");
                        }
                        sb.Append("\r\n\r\nI'll go ");
                        Direction choice = choices[rng.Next(choices.Count)];
                        sb.Append(choice);
                        lblAIMonitor.Text = sb.ToString();
                        return choice.ToInput();
                    }
                }
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
Note that this slider's maximum is 9 times more than the others.", "Explanation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tileGrid.GoalMoved -= tileGrid_PlayerOrGoalMoved;
                    tileGrid.PlayerMoved -= tileGrid_PlayerOrGoalMoved;

                }
                tileGrid = value;
                tileGrid.GridChanged += tileGrid_GridChanged;
                tileGrid.GoalMoved += tileGrid_PlayerOrGoalMoved;
                tileGrid.PlayerMoved += tileGrid_PlayerOrGoalMoved;
                if (tileGrid.Player != null) UpdateGraph();
            }
        }

        private void tileGrid_PlayerOrGoalMoved(object sender, EventArgs e)
        {
            RecalculatePath();
        }

        private void tileGrid_GridChanged(object sender, EventArgs e)
        {
            //UpdateGraph();
        }

        private Point GetSpinDestination(Point tile, Direction spinDir = Direction.None)
        {
            // First, check if we're on a spinner tile, and change the direction accordingly.
            TileType tileType = tileGrid.GetTile(tile);
            if (tileType == TileType.SpinnerN) spinDir = Direction.Up;
            else if (tileType == TileType.SpinnerS) spinDir = Direction.Down;
            else if (tileType == TileType.SpinnerW) spinDir = Direction.Left;
            else if (tileType == TileType.SpinnerE) spinDir = Direction.Right;
            else if (tileType == TileType.SpinnerStop) spinDir = Direction.None;

            // If we're no longer spinning, we're at the end, so return that point.
            if (spinDir == Direction.None) return tile;

            // If the spinning will take us off the map or into a wall, that also means we're done.
            Point nextTile = tile.Move(spinDir);
            if (nextTile.X < 0 || nextTile.X >= tileGrid.Columns || nextTile.Y < 0 || nextTile.Y >= tileGrid.Rows) return tile;
            TileType nextTileType = tileGrid.GetTile(nextTile);
            if (!nextTileType.Passable.IsPassableFrom(spinDir.Opposite())) return tile;

            // If we're about to land on another spin tile, just return that as the end.
            // This serves two purposes: to prevent infinite recursion, and so the "draw path" function looks correct.
            if (nextTileType == TileType.SpinnerN || nextTileType == TileType.SpinnerS || nextTileType == TileType.SpinnerW || nextTileType == TileType.SpinnerE) {
                return nextTile;
            }

            // But if we're still spinning, call the function on the next tile.
            return GetSpinDestination(nextTile, spinDir);
        }

        public void UpdateGraph(bool recalculatePath = true)
        {
            if (tileGrid == null) return;

            shownImpossibleMessage = false;
            graph = new Graph<Point>((uint)(tileGrid.Rows * tileGrid.Columns));

            for (int y = 0; y < tileGrid.Rows; y++) {
                for (int x = 0; x < tileGrid.Columns; x++) {
                    graph.AddNode(new Point(x, y));
                }
            }

            for (int y = 0; y < tileGrid.Rows; y++) {
                for (int x = 0; x < tileGrid.Columns; x++) {
                    Point pt = new Point(x, y);
                    TileType thisTileType = tileGrid.GetTile(pt);

                    if (thisTileType == TileType.SpinnerN || thisTileType == TileType.SpinnerS || thisTileType == TileType.SpinnerW || thisTileType == TileType.SpinnerE) {
                        // If this is a spinner tile, just connect it to (well, from) its destination, because you can't just get off. (don't forget, you're here forever!)
                        graph.GetNode(GetSpinDestination(pt)).ConnectToNode(pt, 10);
                    } else {
                        // Otherwise, just connect it "to" its adjacent tiles depending on what can be reached.
                        Direction[] directions = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
                        foreach (Direction dir in directions) {
                            Point adjacent = pt.Move(dir);
                            if (adjacent.X >= 0 && adjacent.X < tileGrid.Columns && adjacent.Y >= 0 && adjacent.Y < tileGrid.Rows) {
                                TileType adjacentTileType = tileGrid.GetTile(adjacent);
                                if (adjacentTileType.Passable.IsPassableFrom(dir.Opposite()) || adjacentTileType == TileType.Shrub) {
                                    // Note: edges are reversed, as the player moves much more often than the goal does!
                                    graph.GetNode(adjacent).ConnectToNode(pt, adjacentTileType == TileType.Shrub ? 100 : 1);
                                }
                            }
                        }
                    }
                }
            }

            graph.BuildPathfindingData(graph.GetNode(tileGrid.GoalLocation));

            if (recalculatePath) RecalculatePath();

            //btnRebuildGraph.Enabled = false;
        }

        /*
        [DefaultValue(true), Category("Appearance"), Description("Indicates whether the \"Recompile Map\" button can be selected.")]
        public bool RebuildGraphEnabled
        {
            get { return btnRebuildGraph.Enabled; }
            set { btnRebuildGraph.Enabled = value; }
        }
        */

        public void RecalculatePath()
        {
            if (graph == null) UpdateGraph(false);
            if (drawPath) {
                try {
                    path = graph.GetNode(tileGrid.GoalLocation).FindPath(tileGrid.Player.Location).Select(node => node.Data);
                    tileGrid.PathToDraw = path.Select(p => new Point(16 * p.X + 8, 16 * p.Y + 8)).ToArray();
                    shownImpossibleMessage = false;
                } catch (NullReferenceException) {
                    if (!shownImpossibleMessage) {
                        shownImpossibleMessage = true;
                        MessageBox.Show("Not even Democracy would make this map possible.", "Impossible!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    tileGrid.PathToDraw = null;
                }
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

        [Browsable(false)]
        public Graph<Point> Graph
        {
            get { return graph; }
        }

        private void InputGenerator_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TrackBar tb in sliders) {
                PieSlice slice = pieChart.PieSlices.Add(tb.Value, pieSliceColors[i]);
                pieSlices.Add(tb, slice);
                i++;
            }
        }

        private void inputSliders_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            pieSlices[tb].Value = tb.Value;
        }

        private void inputSliders_MouseEnter(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            pieSlices[tb].BorderColor = pieSlices[tb].FillColor.Invert();
        }

        private void inputSliders_MouseLeave(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            pieSlices[tb].BorderColor = Color.Transparent;
        }

        public void MapChanged(bool silent = false)
        {
            UpdateGraph(!silent);
        }
    }
}
