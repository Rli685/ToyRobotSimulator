using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.ConsoleUI.Models;

namespace Robot_Simulator.ConsoleUI.Controllers
{
    class RobotSimulatorCommandController : ICommandControler
    {
        private RobotSimulator _simulator;

        public RobotSimulatorCommandController(RobotSimulator simulator)
        {
            if (simulator == null) throw new ArgumentNullException(nameof(RobotSimulator));
            _simulator = simulator;
        }
        public void Run(Command command)
        {
            if(command==null) throw new ArgumentNullException(nameof(Command));

            if (command is Command_Left)
            {
                _simulator.TurnLeft();
            }
            else if (command is Command_Right)
            {
                _simulator.TurnRight();
            }
            else if (command is Command_Move)
            {
                _simulator.Move();
            }
            else if (command is Command_Place)
            {
                Command_Place cp = (Command_Place)command;
                _simulator.Place(cp.Position, cp.Facing);
            }
            else if (command is Command_Report)
            {
                string message = _simulator.Report();
                if (message != null)
                    System.Console.WriteLine(message);
            }
            else
                return;
        }
    }
}
