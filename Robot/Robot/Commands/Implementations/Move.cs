using Robot.Commands.Contracts;
using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Commands.Implementations
{
    public class Move : IMove
    {
        public void MoveForward(RobotToy robot, Table table)
        {
            int nextForwardXPosition = robot.XAxis < 4 ? robot.XAxis + 1 : robot.XAxis;
            int nextForwardYPosition = robot.YAxis < 4 ? robot.YAxis + 1 : robot.YAxis;
            int nextBackwardXPosition = robot.XAxis > 0 ? robot.XAxis - 1 : robot.XAxis;
            int nextBackwardYPosition = robot.YAxis > 0 ? robot.YAxis - 1 : robot.YAxis;

            switch (robot.Direction)
            {
                case Direction.EAST:
                    robot.XAxis = nextForwardXPosition;
                    break;
                case Direction.WEST:
                    robot.XAxis = nextBackwardXPosition;
                    break;
                case Direction.NORTH:
                    robot.YAxis = nextForwardYPosition;
                    break;
                case Direction.SOUTH:
                    robot.YAxis = nextBackwardYPosition;
                    break;
            }
        }

        public void TurnLeft(RobotToy robot)
        {
            switch (robot.Direction)
            {
                case Direction.EAST:
                    robot.Direction = Direction.NORTH;
                    break;
                case Direction.WEST:
                    robot.Direction = Direction.SOUTH;
                    break;
                case Direction.NORTH:
                    robot.Direction = Direction.WEST;
                    break;
                case Direction.SOUTH:
                    robot.Direction = Direction.EAST;
                    break;
            }
        }

        public void TurnRight(RobotToy robot)
        {
            switch (robot.Direction)
            {
                case Direction.EAST:
                    robot.Direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    robot.Direction = Direction.NORTH;
                    break;
                case Direction.NORTH:
                    robot.Direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    robot.Direction = Direction.WEST;
                    break;
            }
        }
    }
}
