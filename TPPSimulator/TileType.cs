using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TPPSimulator
{
    public class TileType
    {
        public class StepEventArgs : EventArgs
        {
            private Player player;
            private Direction fromDir;
            private Point tileLocation;
            private bool denyMove = false;

            public Player Player
            {
                get { return player; }
                set { player = value; }
            }

            public Direction FromDirection
            {
                get { return fromDir; }
                set { fromDir = value; }
            }

            public Point TileLocation
            {
                get { return tileLocation; }
                set { tileLocation = value; }
            }

            public bool DenyMove
            {
                get { return denyMove; }
                set { denyMove = value; }
            }
        }

        public struct Passability
        {
            public bool top, bottom, left, right;
            
            public Passability(bool passable)
            {
                top = bottom = left = right = passable;
            }

            public Passability(bool fromTop, bool fromBottom, bool fromLeft, bool fromRight)
            {
                top = fromTop;
                bottom = fromBottom;
                left = fromLeft;
                right = fromRight;
            }

            public bool IsPassableFrom(Direction dir)
            {
                switch (dir) {
                    case Direction.Up: return top;
                    case Direction.Down: return bottom;
                    case Direction.Left: return left;
                    case Direction.Right: return right;
                    default: return true;
                }
            }
        }

        private Passability passable;
        private Image image;

        private static TileType empty, wall, ledge, spinnerN, spinnerS, spinnerW, spinnerE, spinnerStop, shrub;

        static TileType()
        {
            empty = new TileType { Passable = new Passability(true), Image = Properties.Resources.empty };
            wall = new TileType { Passable = new Passability(false), Image = Properties.Resources.wall };
            ledge = new TileType { Passable = new Passability(true, false, false, false), Image = Properties.Resources.ledge };
            ledge.Step += ledge_Step;
            spinnerN = new TileType { Passable = new Passability(true), Image = Properties.Resources.spinner_n };
            spinnerS = new TileType { Passable = new Passability(true), Image = Properties.Resources.spinner_s };
            spinnerW = new TileType { Passable = new Passability(true), Image = Properties.Resources.spinner_w };
            spinnerE = new TileType { Passable = new Passability(true), Image = Properties.Resources.spinner_e };
            spinnerStop = new TileType { Passable = new Passability(true), Image = Properties.Resources.spinner_stop };
            spinnerN.Step += spinnerN_Step;
            spinnerS.Step += spinnerS_Step;
            spinnerW.Step += spinnerW_Step;
            spinnerE.Step += spinnerE_Step;
            spinnerStop.Step += spinnerStop_Step;
            shrub = new TileType { Passable = new Passability(false), Image = Properties.Resources.shrub };
        }

        static void spinnerStop_Step(object sender, TileType.StepEventArgs e)
        {
            e.Player.SpinDirection = Direction.None;
        }

        static void spinnerE_Step(object sender, TileType.StepEventArgs e)
        {
            e.Player.SpinDirection = Direction.Right;
        }

        static void spinnerW_Step(object sender, TileType.StepEventArgs e)
        {
            e.Player.SpinDirection = Direction.Left;
        }

        static void spinnerS_Step(object sender, TileType.StepEventArgs e)
        {
            e.Player.SpinDirection = Direction.Down;
        }

        static void spinnerN_Step(object sender, TileType.StepEventArgs e)
        {
            e.Player.SpinDirection = Direction.Up;
        }

        public Passability Passable
        {
            get { return passable; }
            set { passable = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public event EventHandler<StepEventArgs> Step;

        protected virtual void OnStep(StepEventArgs e)
        {
            if (!e.DenyMove) {
                e.Player.Location = e.TileLocation;
            }
            if (Step != null) Step(this, e);
        }

        public bool AttemptStep(Player player, Direction fromDir, Point tileLocation)
        {
            if (passable.IsPassableFrom(fromDir)) {
                StepEventArgs e = new StepEventArgs { Player = player, FromDirection = fromDir, TileLocation = tileLocation };
                OnStep(e);
                return !e.DenyMove;
            } else {
                return false;
            }
        }

        private static void ledge_Step(object sender, StepEventArgs e)
        {
            e.Player.AttemptStep(Direction.Down);
        }

        public static TileType Empty { get { return empty; } }
        public static TileType Wall { get { return wall; } }
        public static TileType Ledge { get { return ledge; } }
        public static TileType SpinnerN { get { return spinnerN; } }
        public static TileType SpinnerS { get { return spinnerS; } }
        public static TileType SpinnerW { get { return spinnerW; } }
        public static TileType SpinnerE { get { return spinnerE; } }
        public static TileType SpinnerStop { get { return spinnerStop; } }
        public static TileType Shrub { get { return shrub; } }
    }
}
