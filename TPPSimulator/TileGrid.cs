using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphUtils;

namespace TPPSimulator
{
    [DefaultEvent("GridChanged")]
    public partial class TileGrid : ScrollableControl
    {
        private int cols = 1, rows = 1;
        private TileType[,] grid;
        private const int tileSize = 16;
        private Bitmap bmp;
        private Player player;
        private TileType leftClickTile = null;
        private LeftClickMode leftClickMode = LeftClickMode.Player;
        private Point goalLocation = Point.Empty;
        private Point[] pathToDraw = null;

        public enum LeftClickMode { Player, Goal, Tile }

        public TileGrid()
        {
            InitializeComponent();
            InitializeGrid();
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime) {
                // Ugh, LicenseManager...never thought I'd actually be using that part of the .NET Framework.
                // Unfortunately it's the only way to check for runtime vs. design time. this.DesignMode doesn't work.
                // Don't worry, no DRM here.
                player = new Player(this);
                player.NeedsTileGridRedraw += player_NeedsTileGridRedraw;
                player.Moved += player_Moved;
            }
            DoubleBuffered = true;
            AutoScroll = true;
        }

        private void player_Moved(object sender, EventArgs e)
        {
            OnPlayerMoved();
            if (player.Location.Equals(goalLocation)) {
                OnGoalReached();
            }
        }

        public event EventHandler GridChanged;
        public event EventHandler PlayerMoved;
        public event EventHandler GoalMoved;
        public event EventHandler GoalReached;

        #region Event methods

        protected virtual void OnGridChanged(EventArgs e)
        {
            if (GridChanged != null) GridChanged(this, e);
        }

        protected void OnGridChanged()
        {
            OnGridChanged(EventArgs.Empty);
        }

        protected virtual void OnPlayerMoved(EventArgs e)
        {
            if (PlayerMoved != null) PlayerMoved(this, e);
        }

        protected void OnPlayerMoved()
        {
            OnPlayerMoved(EventArgs.Empty);
        }

        protected virtual void OnGoalMoved(EventArgs e)
        {
            if (GoalMoved != null) GoalMoved(this, e);
        }

        protected void OnGoalMoved()
        {
            OnGoalMoved(EventArgs.Empty);
        }

        protected virtual void OnGoalReached(EventArgs e)
        {
            if (GoalReached != null) GoalReached(this, e);
        }

        protected void OnGoalReached()
        {
            OnGoalReached(EventArgs.Empty);
        }

        #endregion

        private void player_NeedsTileGridRedraw(object sender, EventArgs e)
        {
            Invalidate();
        }

        public Player Player
        {
            get { return player; }
        }

        public void InitializeGrid()
        {
            grid = new TileType[rows, cols];
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    grid[y, x] = TileType.Empty;
                }
            }

            bmp = new Bitmap(tileSize * cols, tileSize * rows);
            FullImageUpdate();
            OnGridChanged();
        }

        [DefaultValue(LeftClickMode.Player), Category("Behavior"), Description("Indicates what happens when the left mouse button is clicked.")]
        public LeftClickMode ClickMode
        {
            get { return leftClickMode; }
            set { leftClickMode = value; }
        }

        [Browsable(false)]
        public TileType LeftClickTile
        {
            get { return leftClickTile; }
            set { leftClickTile = value; }
        }

        [DefaultValue(typeof(Point), "0, 0"), Category("Behavior"), Description("Indicates the location of the goal tile.")]
        public Point GoalLocation
        {
            get { return goalLocation; }
            set { goalLocation = value; OnGoalMoved(); Invalidate(); }
        }

        private void FullImageUpdate()
        {
            Graphics g = Graphics.FromImage(bmp);
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    DrawTile(g, x, y);
                }
            }
            Invalidate();
        }

        private void DrawTile(Graphics g, int tileX, int tileY)
        {
            if (grid[tileY, tileX] != null) {
                g.DrawImage(grid[tileY, tileX].Image, tileSize * tileX, tileSize * tileY);
            } else {
                g.FillRectangle(Brushes.Red, tileSize * tileX, tileSize * tileY, tileSize, tileSize);
            }
            Invalidate(new Rectangle(tileX * tileSize, tileY * tileSize, tileSize, tileSize));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.FillRectangle(SystemBrushes.AppWorkspace, pe.ClipRectangle);
            pe.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (grid != null) {
                pe.Graphics.DrawImage(bmp, Point.Empty);
                pe.Graphics.DrawImage(Properties.Resources.goal, goalLocation.X * tileSize, goalLocation.Y * tileSize);
                if (player != null) {
                    pe.Graphics.DrawImage(player.CurrentImage, player.Location.X * tileSize, player.Location.Y * tileSize);
                    pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    pe.Graphics.DrawImage(player.Menu.Image, ClientRectangle);
                }
            }

            if (pathToDraw != null) {
                if (pathToDraw.Length >= 2) {
                    pe.Graphics.DrawLines(Pens.Red, pathToDraw);
                }
            }
        }

        [DefaultValue(1), Category("Behavior"), Description("Indicates the number of tiles in the horizontal direction.")]
        public int Columns
        {
            get { return cols; }
            set { ResizeGrid(value, rows); }
        }

        [DefaultValue(1), Category("Behavior"), Description("Indicates the number of tiles in the vertical direction.")]
        public int Rows
        {
            get { return rows; }
            set { ResizeGrid(cols, value); }
        }

        public TileType GetTile(int x, int y)
        {
            return grid[y, x];
        }

        public TileType GetTile(Point location)
        {
            return grid[location.Y, location.X];
        }

        public void SetTile(int x, int y, TileType tile)
        {
            grid[y, x] = tile;
            DrawTile(Graphics.FromImage(bmp), x, y);
            OnGridChanged();
        }

        public void SetTile(Point location, TileType tile)
        {
            SetTile(location.X, location.Y, tile);
        }

        public void LoadMap(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            int row = -1;
            int playerX = 0, playerY = 0;
            int goalX = 0, goalY = 0;

            if (!sr.ReadLine().Equals("TPP Simulator Map File")) {
                throw new InvalidDataException("This is not a map file.");
            }

            while (!sr.EndOfStream) {
                string line = sr.ReadLine();
                if (row < 0) {
                    string left, right;
                    line.SplitOnce('=', out left, out right);
                    try {
                        if (left.Equals("PlayerX")) {
                            playerX = Int32.Parse(right);
                        } else if (left.Equals("PlayerY")) {
                            playerY = Int32.Parse(right);
                        } else if (left.Equals("GoalX")) {
                            goalX = Int32.Parse(right);
                        } else if (left.Equals("GoalY")) {
                            goalY = Int32.Parse(right);
                        } else if (left.Equals("Columns")) {
                            Columns = Int32.Parse(right);
                        } else if (left.Equals("Rows")) {
                            Rows = Int32.Parse(right);
                        } else if (left.Equals("StartMap")) {
                            Player.Location = new Point(playerX, playerY);
                            GoalLocation = new Point(goalX, goalY);
                            row = 0;
                        }
                    } catch (FormatException) {
                        throw new InvalidDataException("Error parsing numeric value");
                    }
                } else {
                    if (line.Length < Columns) {
                        throw new InvalidDataException("Unexpected end of line while reading row " + row);
                    }

                    if (row >= Rows) break;

                    for (int col = 0; col < Columns; col++) {
                        TileType tile = TileType.Empty;
                        switch (line[col]) {
                            case '#': tile = TileType.Wall; break;
                            case '_': tile = TileType.Ledge; break;
                            case '^': tile = TileType.SpinnerN; break;
                            case 'v': tile = TileType.SpinnerS; break;
                            case '<': tile = TileType.SpinnerW; break;
                            case '>': tile = TileType.SpinnerE; break;
                            case 'X': tile = TileType.SpinnerStop; break;
                            case 'S': tile = TileType.Shrub; break;
                        }
                        grid[row, col] = tile;
                    }

                    row++;
                }
            }

            sr.Close();
            FullImageUpdate();
        }

        private void PerformLeftClickAction(MouseEventArgs e)
        {
            switch (leftClickMode) {
                case LeftClickMode.Player:
                    player.Location = new Point(e.X / tileSize, e.Y / tileSize);
                    break;
                case LeftClickMode.Goal:
                    GoalLocation = new Point(e.X / tileSize, e.Y / tileSize);
                    break;
                case LeftClickMode.Tile:
                    SetTile(e.X / tileSize, e.Y / tileSize, leftClickTile);
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.X < tileSize * cols && e.Y < tileSize * rows) {
                if (e.Button == MouseButtons.Left) {
                    PerformLeftClickAction(e);
                } else if (e.Button == MouseButtons.Right) {
                    SetTile(e.X / tileSize, e.Y / tileSize, TileType.Empty);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.X < tileSize * cols && e.Y < tileSize * rows && e.X >= 0 && e.Y >= 0) {
                if ((MouseButtons & MouseButtons.Left) > 0) {
                    PerformLeftClickAction(e);
                } else if ((MouseButtons & MouseButtons.Right) > 0) {
                    SetTile(e.X / tileSize, e.Y / tileSize, TileType.Empty);
                }
            }
        }

        public void ResizeGrid(int cols, int rows)
        {
            TileType[,] oldGrid = grid;
            int minCols = Math.Min(this.cols, cols);
            int minRows = Math.Min(this.rows, rows);

            this.cols = cols;
            this.rows = rows;
            InitializeGrid();

            for (int y = 0; y < minRows; y++) {
                for (int x = 0; x < minCols; x++) {
                    grid[y, x] = oldGrid[y, x];
                }
            }

            AutoScrollMinSize = new Size(cols * tileSize, rows * tileSize);

            FullImageUpdate();
            OnGridChanged();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        [Browsable(false)]
        public Point[] PathToDraw
        {
            get { return pathToDraw; }
            set { pathToDraw = value; Invalidate(); }
        }
    }
}
