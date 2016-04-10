using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Models;
using Robot_Simulator.Enums;

namespace Robot_Simulator.Services
{
    public interface IRobotReportingService
    {
        String Report(Robot robot);
    }
}
