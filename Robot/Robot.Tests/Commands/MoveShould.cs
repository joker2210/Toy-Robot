using Robot.Commands.Contracts;
using Robot.Commands.Implementations;
using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Tests.Commands
{
    public class MoveShould
    {
        [TestCase(2, 3, Direction.EAST, 3, TestName = "MoveForward_EastDirection_MovesALongXAxis")]
        [TestCase(2, 3, Direction.WEST, 1, TestName = "MoveForward_WesrDirection_MovesALongXAxis")]
        [TestCase(2, 3, Direction.NORTH, 4, TestName = "MoveForward_NorthDirection_MovesALongYAxis")]
        [TestCase(2, 3, Direction.SOUTH, 2, TestName = "MoveForward_SouthDirection_MovesALongYAxis")]
        public void MoveForward_ValidLocations_RobotMoves(int xAxis, int yAxis, Direction direction, int expected)
        {
            //Arrange
            IMove move = new Move();
            RobotToy robot = new RobotToy() { XAxis = xAxis, YAxis = yAxis, Direction = direction };
            Table table = new Table(5);

            //Act
            move.MoveForward(robot, table);

            //Assert
            if (direction == Direction.EAST || direction == Direction.WEST)
            {
                Assert.AreEqual(expected, robot.XAxis);
            }

            if (direction == Direction.SOUTH || direction == Direction.NORTH)
            {
                Assert.AreEqual(expected, robot.YAxis);
            }
        }

        [TestCase(Direction.EAST, Direction.NORTH, TestName = "TurnLeft_CurrentEast_MovesNorth")]
        [TestCase(Direction.WEST, Direction.SOUTH, TestName = "TurnLeft_CurrentWest_MovesSouth")]
        [TestCase(Direction.NORTH, Direction.WEST, TestName = "TurnLeft_CurrentNorth_MovesWest")]
        [TestCase(Direction.SOUTH, Direction.EAST, TestName = "TurnLeft_CurrentSouth_MovesEast")]
        public void TurnLeft_TurnsLeftFromCurrentDirection(Direction current, Direction expected)
        {
            //Arrange
            IMove move = new Move();
            RobotToy robot = new RobotToy() { Direction = current };

            //Act
            move.TurnLeft(robot);

            //Assert
            Assert.AreEqual(expected, robot.Direction);
        }

        [TestCase(Direction.EAST, Direction.SOUTH, TestName = "TurnRight_CurrentEast_MovesSouth")]
        [TestCase(Direction.WEST, Direction.NORTH, TestName = "TurnRight_CurrentWest_MovesNorth")]
        [TestCase(Direction.NORTH, Direction.EAST, TestName = "TurnRight_CurrentNorth_MovesEast")]
        [TestCase(Direction.SOUTH, Direction.WEST, TestName = "TurnRight_CurrentSouth_MovesWest")]
        public void TurnRight_TurnsRightFromCurrentDirection(Direction current, Direction expected)
        {
            //Arrange
            IMove move = new Move();
            RobotToy robot = new RobotToy() { Direction = current };

            //Act
            move.TurnRight(robot);

            //Assert
            Assert.AreEqual(expected, robot.Direction);
        }
    }
}
