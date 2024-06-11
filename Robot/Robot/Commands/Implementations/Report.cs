using Robot.Commands.Contracts;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Commands.Implementations
{
    public class Report : IReport
    {
        public string GetPosition(RobotToy robot)
        {
            return robot.XAxis + "," + robot.YAxis + "," + robot.Direction.ToString().ToUpper();
        }
    }
}
