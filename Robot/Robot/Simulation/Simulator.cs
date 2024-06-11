using Robot.Commands.Contracts;
using Robot.Entities;
using RobotToy = Robot.Entities.Robot;

namespace Robot.Simulation
{
    public class Simulator : ISimulator
    {
        private IPlace _placeCommad;
        private IMove _moveCommand;
        private IReport _reportCommad;
        private RobotToy _robot;
        private Table _table;

        private string _message = string.Empty;

        public Simulator(IPlace placeCommad, IMove moveCommand, IReport reportCommad)
        {
            _table = new Table(5);
            _placeCommad = placeCommad;
            _moveCommand = moveCommand;
            _reportCommad = reportCommad;
        }

        public void Start(string[] commands)
        {
            foreach (string command in commands)
            {
                // A robot that is not on the table will ignore the MOVE, LEFT, RIGHT and REPORT commands.
                // Process MOVE, LEFT, RIGHT and REPORT commands only when robot is places
                if (StartsWithPlaceCommand(command) || _robot != null)
                {
                    ProcessCommand(command);
                }

                if (_message.Length > 0)
                {
                    Console.WriteLine(_message);
                    _message = "";
                }
            }
        }

        #region Private methods
        private void ProcessCommand(string command)
        {
            if (StartsWithPlaceCommand(command))
            {
                HandlePlaceCommand(command);
            }

            else if (command.Equals("MOVE", StringComparison.InvariantCultureIgnoreCase))
            {
                _moveCommand.MoveForward(_robot, _table);
            }

            else if (command.Equals("RIGHT", StringComparison.InvariantCultureIgnoreCase))
            {
                _moveCommand.TurnRight(_robot);
            }

            else if (command.Equals("LEFT", StringComparison.InvariantCultureIgnoreCase))
            {
                _moveCommand.TurnLeft(_robot);
            }

            else if (command.Equals("REPORT", StringComparison.InvariantCultureIgnoreCase))
            {
                _message = _reportCommad.GetPosition(_robot);
            }
        }

        private bool StartsWithPlaceCommand(string command)
        {
            return command.StartsWith("PLACE", StringComparison.InvariantCultureIgnoreCase);
        }

        private void HandlePlaceCommand(string command)
        {
            string[] coordinates = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (coordinates.Length == 4)
            {
                int east;
                int north;
                Direction direction;
                if (int.TryParse(coordinates[1], out east) &&
                    int.TryParse(coordinates[2], out north) &&
                    Enum.TryParse(coordinates[3].ToUpper(), out direction))
                {
                    _robot = _placeCommad.PlaceRobotOnTable(east, north, direction, _table);
                }
            }
        }

        #endregion
    }
}
