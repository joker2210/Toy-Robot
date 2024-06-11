using Moq;
using Robot.Commands.Contracts;
using Robot.Entities;
using Robot.Simulation;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Tests.Simulation
{
    public class SimulatorShould
    {
        private ISimulator _simulator;
        Mock<IPlace> _placeMock;
        Mock<IMove> _moveMock;
        Mock<IReport> _reportMock;

        [SetUp]
        public void Setup()
        {
            _placeMock = new Mock<IPlace>();
            _moveMock = new Mock<IMove>();
            _reportMock = new Mock<IReport>();
        }

        [TearDown]
        public void Cleanup()
        {
            _placeMock = null;
            _moveMock = null;
            _reportMock = null;
        }

        [TestCase("PLACE dummy1 dummy2", TestName = "Start_PlaceCommandInvalidNumberOfInputArguments_PlaceCommandNotExecuted")]
        [TestCase("PLACE dummy1 dummy2 dummy3", TestName = "Start_PlaceCommandInvalidInputArguments_PlaceCommandNotExecuted")]
        public void Start_InvalidArguments_PlaceCommandNotExecuted(string placeCommand)
        {
            //Arrange
            _placeMock.Verify(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>()),
                                                       Times.Never);
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { placeCommand };

            //Act
            _simulator.Start(commands);

            //Assert
            Mock.VerifyAll();
        }

        [Test]
        public void Start_PlaceValidArguments_PlaceCommandExecuted()
        {
            //Arrange            
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { "PLACE 2,2 NORTH" };

            //Act
            _simulator.Start(commands);

            //Assert
            _placeMock.Verify(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>()),
                                                       Times.Once);

            //Assert
            Mock.VerifyAll();
        }

        [Test]
        public void Start_MoveValidArguments_MoveCommandExecuted()
        {
            //Arrange            
            _placeMock.Setup(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>())).Returns(new RobotToy());
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { "PLACE 0,0,EAST", "move" };

            //Act
            _simulator.Start(commands);

            //Assert
            _moveMock.Verify(x => x.MoveForward(It.IsAny<RobotToy>(),
                                                       It.IsAny<Table>()),
                                                       Times.Once);

            //Assert
            Mock.VerifyAll();
        }

        [Test]
        public void Start_TurnRightValidArguments_TurnRightCommandExecuted()
        {
            //Arrange            
            _placeMock.Setup(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>())).Returns(new RobotToy());
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { "PLACE 0,0,EAST", "right" };

            //Act
            _simulator.Start(commands);

            //Assert
            _moveMock.Verify(x => x.TurnRight(It.IsAny<RobotToy>()), Times.Once);

            //Assert
            Mock.VerifyAll();
        }

        [Test]
        public void Start_TurnLeftValidArguments_TurnLeftCommandExecuted()
        {
            //Arrange            
            _placeMock.Setup(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>())).Returns(new RobotToy());
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { "PLACE 0,0,EAST", "left" };

            //Act
            _simulator.Start(commands);

            //Assert
            _moveMock.Verify(x => x.TurnLeft(It.IsAny<RobotToy>()), Times.Once);

            //Assert
            Mock.VerifyAll();
        }

        [Test]
        public void Start_ReportValidArguments_ReportCommandExecuted()
        {
            //Arrange            
            _placeMock.Setup(x => x.PlaceRobotOnTable(It.IsAny<int>(),
                                                       It.IsAny<int>(),
                                                       It.IsAny<Direction>(),
                                                       It.IsAny<Table>())).Returns(new RobotToy());
            _reportMock.Setup(x => x.GetPosition(It.IsAny<RobotToy>())).Returns("0,0,EAST");
            _simulator = new Simulator(_placeMock.Object, _moveMock.Object, _reportMock.Object);
            var commands = new string[] { "PLACE 0,0,EAST", "report" };

            //Act
            _simulator.Start(commands);

            //Assert
            _reportMock.Verify(x => x.GetPosition(It.IsAny<RobotToy>()), Times.Once);

            //Assert
            Mock.VerifyAll();
        }
    }
}
