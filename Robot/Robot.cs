using System.Drawing;

namespace Robot
{
    public partial class Program
    {
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
    }
}
