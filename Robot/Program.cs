using System;
using System.Collections.Generic;
using System.Drawing;

namespace Robot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rob = new Robot();
            rob.Position = new Point(0, 0);
            rob.Direction = new Direction();
            rob.Direction.DirectionFromString("NORTH");

            var repo = new ReportingSystem(ref rob);
            repo.Action("MOVE");
            repo.Action("REPORT");

            var robo = new Robot();
            robo.Position = new Point(0, 0);
            robo.Direction = new Direction();
            robo.Direction.DirectionFromString("NORTH");

            var rep = new ReportingSystem(ref robo);
            rep.Action("LEFT");
            rep.Action("REPORT");

            var robot = new Robot();
            robot.Position = new Point(1, 2);
            robot.Direction = new Direction();
            robot.Direction.DirectionFromString("EAST");

            var report = new ReportingSystem(ref robot);
            report.Action("MOVE");
            report.Action("MOVE");
            report.Action("LEFT");
            report.Action("MOVE");
            report.Action("REPORT");
        }

        public class Robot
        {
            public Point Position { get; set; }
            public Direction Direction { get; set; }

            public bool WithinRange(Point one, Point two)
            {
                if (Position.X < one.X || Position.X > two.X || Position.Y < one.Y || Position.Y > two.Y)
                {
                    return false;
                }
                return true;
            }
        }

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

        public class ReportingSystem
        {
            private Robot robo = new Robot();

            public ReportingSystem(ref Robot rob)
            {
                robo = rob;
            }

            /// <summary>
            /// The method performs all the actions on the
            /// robot based up on the INPUT string. 
            /// </summary>
            /// <param name="action">Action on the robot</param>
            public void Action(string action)
            {
                switch (action)
                {
                    case "RIGHT":
                        robo.Direction.TurnRight();
                        break;

                    case "LEFT":
                        robo.Direction.TurnLeft();
                        break;

                    case "MOVE":
                        var pos = robo.Position;
                        var temp = robo.Position;

                        temp.X = robo.Position.X + robo.Direction.DirectionVector().X;
                        temp.Y = robo.Position.Y + robo.Direction.DirectionVector().Y;

                        robo.Position = temp;

                        if (!robo.WithinRange(new Point(0, 0), new Point(4, 4)))
                        {
                            robo.Position = pos;
                        }

                        break;

                    case "REPORT":
                        Console.Write(robo.Position.X + ", " + robo.Position.Y + ", " + robo.Direction.CurrentDirection + "\n");
                        break;
                }
            }

            public Point PLACE(Point point)
            {
                return point;
            }
        }
    }
}
