using Robot.Commands.Contracts;
using Robot.Commands.Implementations;

namespace Robot.Tests.Commands
{
    public class ReportShould
    {
        [Test]
        public void GetPosition_ReturnsRobotPosition()
        {
            //Arrange
            IReport report = new Report();

            //Act & assert
            Assert.AreEqual("2,2,EAST", report.GetPosition(new Entities.Robot() { XAxis = 2, YAxis = 2, Direction = Direction.EAST }));
        }
    }
}
