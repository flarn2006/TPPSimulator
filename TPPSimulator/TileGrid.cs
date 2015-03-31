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
using System.Security.Cryptography;
using GraphUtils;

namespace TPPSimulator
{
    [DefaultEvent("GridChanged")]
    public partial class TileGrid : ScrollableControl
    {
        private int cols = 1, rows = 1;
        private TileType[,] grid;
        private Bitmap bmp;
        private Player player;
        private TileType leftClickTile = null;
        private LeftClickMode leftClickMode = LeftClickMode.Player;
        private Point goalLocation = Point.Empty;
        private Point[] pathToDraw = null;
        private MD5 md5;
        private IInputGenerator inputGen;

        public enum LeftClickMode { Player, Goal, Tile }

        public const int TileSize = 16;

        public TileGrid()
        {
            InitializeComponent();
            md5 = MD5.Create();
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

            bmp = new Bitmap(TileSize * cols, TileSize * rows);
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
                Image img = grid[tileY, tileX].Image;
                if (grid[tileY, tileX].ImageAlt != null) {
                    if (md5.ComputeHash(new byte[] { (byte)(tileX & 255), (byte)(tileY & 255) })[0] < 16) {
                        img = grid[tileY, tileX].ImageAlt;
                    }
                }
                g.DrawImage(img, TileSize * tileX, TileSize * tileY);
            } else {
                g.FillRectangle(Brushes.Red, TileSize * tileX, TileSize * tileY, TileSize, TileSize);
            }
            Invalidate(new Rectangle(tileX * TileSize, tileY * TileSize, TileSize, TileSize));
        }

        public void DrawMapImage(Graphics g)
        {
            g.DrawImage(bmp, Point.Empty);
            g.DrawImage(Properties.Resources.goal, goalLocation.X * TileSize, goalLocation.Y * TileSize);
            if (player != null) {
                g.DrawImage(player.CurrentImage, player.Location.X * TileSize, player.Location.Y * TileSize);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.FillRectangle(SystemBrushes.AppWorkspace, pe.ClipRectangle);
            pe.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (grid != null) {
                DrawMapImage(pe.Graphics);
                if (player != null) {
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
            int columns = 40, rows = 30;
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
                            columns = Int32.Parse(right);
                        } else if (left.Equals("Rows")) {
                            rows = Int32.Parse(right);
                        } else if (left.Equals("StartMap")) {
                            ResizeGrid(columns, rows);
                            goalLocation = new Point(goalX, goalY);
                            player.SetLocationInternal(new Point(playerX, playerY));
                            FullImageUpdate();
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
                        grid[row, col] = TileType.FromChar(line[col]);
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
                    player.Location = new Point(e.X / TileSize, e.Y / TileSize);
                    break;
                case LeftClickMode.Goal:
                    GoalLocation = new Point(e.X / TileSize, e.Y / TileSize);
                    break;
                case LeftClickMode.Tile:
                    SetTile(e.X / TileSize, e.Y / TileSize, leftClickTile);
                    break;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.X < TileSize * cols && e.Y < TileSize * rows) {
                if (e.Button == MouseButtons.Left) {
                    PerformLeftClickAction(e);
                } else if (e.Button == MouseButtons.Right) {
                    SetTile(e.X / TileSize, e.Y / TileSize, TileType.Empty);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.X < TileSize * cols && e.Y < TileSize * rows && e.X >= 0 && e.Y >= 0) {
                if ((MouseButtons & MouseButtons.Left) > 0) {
                    PerformLeftClickAction(e);
                } else if ((MouseButtons & MouseButtons.Right) > 0) {
                    SetTile(e.X / TileSize, e.Y / TileSize, TileType.Empty);
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

            AutoScrollMinSize = new Size(cols * TileSize, rows * TileSize);

            FullImageUpdate();
            if (inputGen != null) inputGen.MapChanged();
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

        [DefaultValue(null), Category("Behavior")]
        [Description("The input generator associated with this tile grid.")]
        public IInputGenerator InputGen
        {
            get { return inputGen; }
            set { inputGen = value; }
        }
    }
}
