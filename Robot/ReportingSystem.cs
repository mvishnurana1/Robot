using System;
using System.Drawing;

namespace Robot
{
    public partial class Program
    {
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
