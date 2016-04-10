using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot_Simulator.Enums;
using Robot_Simulator.Models;

namespace Robot_Simulator.Services
{
    public class ToyRobotMovingService : IRobotMovingService
    {
        
        public bool Move(Robot robot, TableTop tableTop)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (tableTop == null) throw new ArgumentNullException(nameof(TableTop));
            if (robot.Position == null) throw new ArgumentException(nameof(Robot));

            Position newPosition = nextPosition(robot);
            if (IsValid(newPosition, tableTop))
            {
                robot.Position = newPosition;
                return true;
            }
            else
                return false;
        }


        public bool Place(Robot robot, TableTop tableTop, Position position, Facing facing)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));
            if (tableTop == null) throw new ArgumentNullException(nameof(TableTop));
            if (position == null) throw new ArgumentNullException(nameof(Position));

            if (IsValid(position, tableTop))
            {
                robot.Position = position;
                robot.Facing = facing;
                return true;
            }
            else
                return false;
        }

        private Position nextPosition(Robot robot)
        {
            if (robot == null) throw new ArgumentNullException(nameof(Robot));

            Position p=robot.Position;
            switch (robot.Facing)
            {
                case Facing.EAST:
                    return new Position(p.X + 1, p.Y);
                case Facing.WEST:
                    return new Position(p.X - 1, p.Y);
                case Facing.NORTH:
                    return new Position(p.X, p.Y + 1);
                case Facing.SOUTH:
                    return new Position(p.X, p.Y - 1);
                default:
                    throw new NotImplementedException();
            }
            
        }

        private bool IsValid(Position position, TableTop table)
        {
            if (position.X >= 0 && position.Y >= 0 &&
                position.X < table.Width && position.Y < table.Height)
                return true;
            else
                return false;
        }
    }
}
