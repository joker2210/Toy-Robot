using Robot.Commands.Contracts;
using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Commands.Implementations
{
    public class Place : IPlace
    {
        public RobotToy PlaceRobotOnTable(int xAxis, int yAxis, Direction direction, Table table)
        {
            if (table.IsValidLocation(xAxis, yAxis))
            {
                return new RobotToy()
                {
                    Direction = direction,
                    XAxis = xAxis,
                    YAxis = yAxis
                };
            }

            return null;
        }
    }
}
