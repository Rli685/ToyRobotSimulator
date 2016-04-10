using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.ConsoleUI.Models;
using Robot_Simulator.Models;
using Robot_Simulator.Enums;

namespace Robot_Simulator.ConsoleUI.Services
{
    public class RobotSimulatorCommandLineParser : ICommandLineParser
    {
        public Command Parsing(string input)
        {
            if (input == null) return null;
            string trimedInput = input.Trim();
            if (trimedInput.Length == 0) return null;

            char[] separator =new char[] { ' '};
            string[] parameters = trimedInput.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            string cmd = parameters[0];
            int numberOfParameters = parameters.Count();
            switch (cmd)
            {
                case "MOVE":
                    if (numberOfParameters == 1)
                        return new Command_Move();
                    else
                        return null;
                case "LEFT":
                    if (numberOfParameters == 1)
                        return new Command_Left();
                    else
                        return null;
                case "RIGHT":
                    if (numberOfParameters == 1)
                        return new Command_Right();
                    else
                        return null;
                case "REPORT":
                    if (numberOfParameters == 1)
                        return new Command_Report();
                    else
                        return null;
                case "PLACE":
                    if (numberOfParameters >1)
                    {
                        char[] separator2 = new char[] { ',' };
                        string[] arguments = String.Join(" ", parameters.Skip(1)).Split(separator2, StringSplitOptions.RemoveEmptyEntries);
                        if (arguments.Count() != 3) return null;
                        int x, y;
                        if(int.TryParse(arguments[0].Trim(), out x)  &&
                           int.TryParse(arguments[1].Trim(), out y) )
                        {
                            Position position = new Position(x, y);
                            switch (arguments[2].Trim())
                            {
                                case "NORTH":
                                    return new Command_Place(position, Facing.NORTH);
                                case "SOUTH":
                                    return new Command_Place(position, Facing.SOUTH);
                                case "EAST":
                                    return new Command_Place(position, Facing.EAST);
                                case "WEST":
                                    return new Command_Place(position, Facing.WEST);
                                default:
                                    break;
                            }
                        }
                    }
                    return null;

                default:
                    return null;
            }
        }
    }
}
