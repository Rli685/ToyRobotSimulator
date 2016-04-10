using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Models;

namespace Robot_Simulator.Services
{
    public interface IRobotTurningService
    {
        void TurnLeft(Robot robot);

        void TurnRight(Robot robot);
    }
}
