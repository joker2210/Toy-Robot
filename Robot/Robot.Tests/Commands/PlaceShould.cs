using Robot.Commands.Contracts;
using Robot.Commands.Implementations;
using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Tests.Commands
{
    internal class PlaceShould
    {
        [Test]
        public void PlaceRobotOnTable_InvalidLocation_ReturnsNull()
        {
            //Arrange
            IPlace place = new Place();

            //Act & assert
            Assert.IsNull(place.PlaceRobotOnTable(-2, -2, Direction.EAST, new Table(5)));
        }

        [Test]
        public void PlaceRobotOnTable_ValidLocation_ReturnsPlacedRobot()
        {
            //Arrange
            IPlace place = new Place();

            //Act
            Assert.IsInstanceOf<RobotToy>(place.PlaceRobotOnTable(1,1,Direction.EAST, new Table(5)));
        }
    }
}
