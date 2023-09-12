using System.Drawing;

namespace Robot
{
    public partial class Program
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
    }
}
