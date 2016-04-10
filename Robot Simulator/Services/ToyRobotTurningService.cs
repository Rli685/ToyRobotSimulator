using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;

namespace Robot_Simulator.Services
{
    public class ToyRobotTurningService : IRobotTurningService
    {
        public void TurnLeft(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (robot.Position == null) throw new ArgumentException(nameof(Robot));

            switch (robot.Facing)
            {
                case Facing.NORTH:
                    robot.Facing = Facing.WEST;
                    break;
                case Facing.SOUTH:
                    robot.Facing = Facing.EAST;
                    break;
                case Facing.EAST:
                    robot.Facing = Facing.NORTH;
                    break;
                case Facing.WEST:
                    robot.Facing = Facing.SOUTH;
                    break;
                default:
                    break;
            }
        }

        public void TurnRight(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (robot.Position == null) throw new ArgumentException(nameof(Robot));

            switch (robot.Facing)
            {
                case Facing.NORTH:
                    robot.Facing = Facing.EAST;
                    break;
                case Facing.SOUTH:
                    robot.Facing = Facing.WEST;
                    break;
                case Facing.EAST:
                    robot.Facing = Facing.SOUTH;
                    break;
                case Facing.WEST:
                    robot.Facing = Facing.NORTH;
                    break;
                default:
                    break;
            }

        }
    }
}
