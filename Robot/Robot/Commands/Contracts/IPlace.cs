using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Commands.Contracts
{
    public interface IPlace
    {
        RobotToy PlaceRobotOnTable(int xAxis, int yAxis, Direction direction, Table table);
    }
}
