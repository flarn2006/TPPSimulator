using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TPPSimulator
{
    public class Player
    {
        private Point location;
        private Direction facing = Direction.Down;
        private Direction spinDir = Direction.None;
        private TileGrid tileGrid;
        private bool gen1Movement = true;
        private int frozenForInputs = 0;
        private Menu menu;

        public Player(TileGrid grid)
        {
            tileGrid = grid;

            bool cantLoad = false;
            try {
                menu = new Menu();
                menu.StateChanged += menu_StateChanged;
                menu.Cut += menu_Cut;
            } catch (System.IO.FileNotFoundException) {
                cantLoad = true;
            } catch (System.IO.DirectoryNotFoundException) {
                cantLoad = true;
            }

            if (cantLoad) {
                MessageBox.Show("Error loading menu data! Make sure the Menu folder is in the same directory as the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void menu_Cut(object sender, EventArgs e)
        {
            bool canCut = false;
            Point cutTile = location.Move(facing);
            if (cutTile.X >= 0 && cutTile.X < tileGrid.Columns && cutTile.Y >= 0 && cutTile.Y < tileGrid.Rows) {
                if (tileGrid.GetTile(cutTile) == TileType.Shrub) {
                    canCut = true;
                }
            }

            if (canCut) {
                menu.StateID = "pokemon_cut_success";
                tileGrid.SetTile(cutTile, TileType.ShrubRemoved);
            } else {
                menu.StateID = "pokemon_cut_fail";
            }
        }

        private void menu_StateChanged(object sender, EventArgs e)
        {
            OnNeedsTileGridRedraw();
        }

        public event EventHandler NeedsTileGridRedraw;
        public event EventHandler InputWhileFrozen;
        public event EventHandler Moved;

        #region Event methods

        protected virtual void OnNeedsTileGridRedraw(EventArgs e)
        {
            if (NeedsTileGridRedraw != null) NeedsTileGridRedraw(this, e);
        }

        protected void OnNeedsTileGridRedraw()
        {
            OnNeedsTileGridRedraw(EventArgs.Empty);
        }

        protected virtual void OnInputWhileFrozen(EventArgs e)
        {
            if (InputWhileFrozen != null) InputWhileFrozen(this, e);
        }

        protected void OnInputWhileFrozen()
        {
            OnInputWhileFrozen(EventArgs.Empty);
        }

        protected virtual void OnMoved(EventArgs e)
        {
            if (Moved != null) Moved(this, e);
        }

        protected void OnMoved()
        {
            OnMoved(EventArgs.Empty);
        }

        #endregion

        public Point Location
        {
            get { return location; }
            set { location = value; OnMoved(); OnNeedsTileGridRedraw(); }
        }

        public Direction Facing
        {
            get { return facing; }
            set { facing = value; OnNeedsTileGridRedraw(); }
        }

        public Image CurrentImage
        {
            get
            {
                switch (Facing) {
                    case Direction.Up: return Properties.Resources.player_n;
                    case Direction.Down: return Properties.Resources.player_s;
                    case Direction.Left: return Properties.Resources.player_w;
                    case Direction.Right: return Properties.Resources.player_e;
                    default: throw new InvalidOperationException("Current direction isn't valid--something went wrong!");
                }
            }
        }

        public Menu Menu
        {
            get { return menu; }
        }

        public bool Gen1Movement
        {
            get { return gen1Movement; }
            set { gen1Movement = value; }
        }

        public int FrozenForInputs
        {
            get { return frozenForInputs; }
            set { frozenForInputs = value; }
        }

        public Direction SpinDirection
        {
            get { return spinDir; }
            set { spinDir = value; }
        }

        public bool AttemptStep(Direction dir)
        {
            Facing = dir;
            Point newLocation = Location.Move(dir);
            if (newLocation.X < 0 || newLocation.X >= tileGrid.Columns || newLocation.Y < 0 || newLocation.Y >= tileGrid.Rows) {
                return false;
            } else {
                return tileGrid.GetTile(newLocation.X, newLocation.Y).AttemptStep(this, dir.Opposite(), newLocation);
            }
        }

        public void Input(Input button)
        {
            if (menu.State == null) {
                if (FrozenForInputs == 0) {
                    if (SpinDirection == Direction.None) {
                        switch (button) {
                            case TPPSimulator.Input.Up:
                            case TPPSimulator.Input.Down:
                            case TPPSimulator.Input.Left:
                            case TPPSimulator.Input.Right:
                                Direction dir = button.ToDirection();
                                if (Facing != dir.Opposite() || Gen1Movement) {
                                    if (!AttemptStep(dir)) SoundPlayer.Play(Properties.Resources.wall_snd);
                                } else {
                                    Facing = dir;
                                }
                                break;
                            case TPPSimulator.Input.Start:
                                menu.Open();
                                break;
                        }
                    } else {
                        // Don't forget, you're here forever!
                        Direction wasFacing = Facing;
                        if (AttemptStep(SpinDirection)) {
                            Facing = wasFacing.CounterClockwise();
                        } else {
                            SpinDirection = Direction.None;
                        }
                    }
                } else {
                    if (FrozenForInputs > 0) FrozenForInputs--;
                }
            } else {
                try {
                    menu.Input(button);
                } catch (KeyNotFoundException ex) {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Menu error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
    }
}
