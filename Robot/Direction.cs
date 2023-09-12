using System;
using System.Collections.Generic;
using System.Drawing;

namespace Robot
{
    public partial class Program
    {
        public class Direction
        {
            /// <summary>
            /// Enum binding all the possible directions
            /// </summary>
            public enum direction
            {
                NORTH,
                EAST,
                SOUTH,
                WEST,
                UNASSIGNED
            }

            /// <summary>
            /// Movement in all the possible directions
            /// </summary>
            private static Dictionary<direction, Tuple<Point, string>> directionMapping = new Dictionary<direction, Tuple<Point, string>>
        {
            { direction.NORTH, new Tuple<Point, string>(new Point(0, 1), "north") },
            { direction.EAST, new Tuple<Point, string>(new Point(1, 0),  "east") },
            { direction.SOUTH, new Tuple<Point, string>(new Point(0, -1),  "south") },
            { direction.WEST, new Tuple<Point, string>(new Point(-1, 0), "west") },
            { direction.UNASSIGNED, new Tuple<Point, string>(new Point(0, 0), "unassigned") }
        };

            /// <summary>
            /// Represents the current direction of the robot
            /// </summary>
            public direction CurrentDirection { get; set; }

            /// <summary>
            /// works on characters takes a charater and 
            /// converts the char into an int
            /// </summary>
            /// <param name="userDirection"></param>
            public void DirectionFromString(string userDirection)
            {
                userDirection = userDirection.Replace(" ", "");

                direction output;

                if (direction.TryParse(userDirection, out output))
                {
                    CurrentDirection = output;
                }
                else
                {
                    CurrentDirection = direction.UNASSIGNED;
                }
            }

            /// <summary>
            /// returns the direction
            /// </summary>
            /// <returns></returns>        
            public Point DirectionVector()
            {
                return directionMapping[CurrentDirection].Item1;
            }

            /// <summary>
            /// returns the point with direction
            /// </summary>
            /// <returns></returns>
            public string NameDirections()
            {
                return directionMapping[CurrentDirection].Item2;
            }

            /// <summary>
            /// Represents the left turn by a robot. 
            /// </summary>
            public void TurnLeft()
            {
                switch (CurrentDirection)
                {
                    case direction.NORTH:
                        CurrentDirection = direction.WEST;
                        break;

                    case direction.EAST:
                        CurrentDirection = direction.NORTH;
                        break;

                    case direction.SOUTH:
                        CurrentDirection = direction.EAST;
                        break;

                    case direction.WEST:
                        CurrentDirection = direction.SOUTH;
                        break;
                }
            }

            /// <summary>
            /// Represents right turn by a robot. 
            /// </summary>
            public void TurnRight()
            {
                switch (CurrentDirection)
                {
                    case direction.NORTH:
                        CurrentDirection = direction.EAST;
                        break;

                    case direction.EAST:
                        CurrentDirection = direction.SOUTH;
                        break;

                    case direction.SOUTH:
                        CurrentDirection = direction.WEST;
                        break;

                    case direction.WEST:
                        CurrentDirection = direction.NORTH;
                        break;
                }
            }
        }
    }
}
