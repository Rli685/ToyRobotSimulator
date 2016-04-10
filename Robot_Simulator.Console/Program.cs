using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using Robot_Simulator.Services;
using Robot_Simulator.ConsoleUI.Services;
using Robot_Simulator.ConsoleUI.Controllers;
using Robot_Simulator.ConsoleUI.Models;

namespace Robot_Simulator.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            TableTop table = new SquareTableTop(5);
            IRobotMovingService movingService = new ToyRobotMovingService();
            IRobotReportingService reportingService = new ToyRobotReportingService();
            IRobotTurningService turningService = new ToyRobotTurningService();

            RobotSimulator simulator = new RobotSimulator(robot, table, movingService, turningService, reportingService);

            RobotSimulatorCommandLineParser parser = new RobotSimulatorCommandLineParser();
            RobotSimulatorCommandController controler = new RobotSimulatorCommandController(simulator);

            while (true)
            {
                string input = Console.ReadLine();
                Command command = parser.Parsing(input);
                if (command != null)
                    controler.Run(command);
            }
        }
    }
}
