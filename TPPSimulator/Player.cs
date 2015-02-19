using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public Player(TileGrid grid)
        {
            tileGrid = grid;
        }

        public event EventHandler Moved;
        public event EventHandler InputWhileFrozen;

        #region Event methods

        protected virtual void OnMoved(EventArgs e)
        {
            if (Moved != null) Moved(this, e);
        }

        protected void OnMoved()
        {
            OnMoved(EventArgs.Empty);
        }

        protected virtual void OnInputWhileFrozen(EventArgs e)
        {
            if (InputWhileFrozen != null) InputWhileFrozen(this, e);
        }

        protected void OnInputWhileFrozen()
        {
            OnInputWhileFrozen(EventArgs.Empty);
        }

        #endregion

        public Point Location
        {
            get { return location; }
            set { location = value; OnMoved(); }
        }

        public Direction Facing
        {
            get { return facing; }
            set { facing = value; OnMoved(); }
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
            if (FrozenForInputs == 0) {
                if (SpinDirection == Direction.None) {
                    switch (button) {
                        case TPPSimulator.Input.Up:
                        case TPPSimulator.Input.Down:
                        case TPPSimulator.Input.Left:
                        case TPPSimulator.Input.Right:
                            Direction dir = button.ToDirection();
                            if (Facing != dir.Opposite() || Gen1Movement) {
                                AttemptStep(dir);
                            } else {
                                Facing = dir;
                            }
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
                FrozenForInputs--;
            }
        }
    }
}
