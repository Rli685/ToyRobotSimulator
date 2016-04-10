using Robot_Simulator.ConsoleUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.ConsoleUI.Controllers
{
    public interface ICommandControler
    {
        void Run(Command command);
    }
}
