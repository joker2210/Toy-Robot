using RobotToy = Robot.Entities.Robot;

namespace Robot.Commands.Contracts
{
    public interface IReport
    {
        string GetPosition(RobotToy robot);
    }
}
