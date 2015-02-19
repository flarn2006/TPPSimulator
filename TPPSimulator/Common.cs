using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TPPSimulator
{
    enum Direction { Up, Down, Left, Right, None }
    enum Input { Up, Down, Left, Right, A, B, Start, Select }

    static class DirectionHelper
    {
        public static Input ToInput(this Direction direction)
        {
            switch (direction) {
                case Direction.Up: return Input.Up;
                case Direction.Down: return Input.Down;
                case Direction.Left: return Input.Left;
                case Direction.Right: return Input.Right;
                default: throw new ArgumentOutOfRangeException("Invalid direction specified!");
            }
        }

        public static Direction ToDirection(this Input input)
        {
            switch (input) {
                case Input.Up: return Direction.Up;
                case Input.Down: return Direction.Down;
                case Input.Left: return Direction.Left;
                case Input.Right: return Direction.Right;
                default: return Direction.None;
            }
        }

        public static Point Move(this Point startingPoint, Direction direction)
        {
            switch (direction) {
                case Direction.Up: return new Point(startingPoint.X, startingPoint.Y - 1);
                case Direction.Down: return new Point(startingPoint.X, startingPoint.Y + 1);
                case Direction.Left: return new Point(startingPoint.X - 1, startingPoint.Y);
                case Direction.Right: return new Point(startingPoint.X + 1, startingPoint.Y);
                default: return startingPoint;
            }
        }

        public static void Move(ref Point point, Direction direction)
        {
            point = point.Move(direction);
        }

        public static Direction Opposite(this Direction direction)
        {
            switch (direction) {
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                default: return Direction.None;
            }
        }

        public static Direction CounterClockwise(this Direction direction)
        {
            switch (direction) {
                case Direction.Up: return Direction.Left;
                case Direction.Down: return Direction.Right;
                case Direction.Left: return Direction.Down;
                case Direction.Right: return Direction.Up;
                default: return Direction.None;
            }
        }

        public static Direction Clockwise(this Direction direction)
        {
            switch (direction) {
                case Direction.Up: return Direction.Right;
                case Direction.Down: return Direction.Left;
                case Direction.Left: return Direction.Up;
                case Direction.Right: return Direction.Down;
                default: return Direction.None;
            }
        }
    }

    static class MiscExtensions
    {
        public static bool SplitOnce(this string str, char splitAt, out string left, out string right)
        {
            int index = str.IndexOf(splitAt);
            if (index < 0) {
                left = str;
                right = "";
                return false;
            } else {
                left = str.Substring(0, index);
                right = str.Substring(index + 1);
                return true;
            }
        }
    }
}
