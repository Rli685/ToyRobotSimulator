using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;

namespace Robot_Simulator.Services
{
    public class ToyRobotReportingService : IRobotReportingService
    {
        public string Report(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (robot.Position == null) throw new ArgumentException(nameof(Robot));
            return String.Format("Output: {0},{1},{2}", robot.Position.X, robot.Position.Y, robot.Facing.ToString("G"));
        }
    }
}
