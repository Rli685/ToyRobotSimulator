using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.ConsoleUI.Models;

namespace Robot_Simulator.ConsoleUI.Services
{
    public interface ICommandLineParser
    {
        Command Parsing(string input);
    }
}
