using Robot.Entities;
using RobotToy = Robot.Entities.Robot;
namespace Robot.Commands.Contracts
{
    public interface IMove
    {
        void MoveForward(RobotToy robot, Table table);
        void TurnLeft(RobotToy robot);
        void TurnRight(RobotToy robot);
    }
}
