using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.Services
{
    public interface IRobotMovingService
    {
        //Move to the next Position, return true when movement sucessful, return false if Robot cannot move
        bool Move(Robot robot, TableTop tableTop);

        //Set Robot to the new Position, return true when the new Position is valid, return false if invalid Position
        bool Place(Robot robot, TableTop tableTop, Position position, Facing facing);

        
    }
}
