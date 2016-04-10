using Robot_Simulator.Enums;
using Robot_Simulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.ConsoleUI.Models
{
    public class Command_Place : Command
    {
        public Position Position { get; set; }
        public Facing Facing { get; set; }

        public Command_Place(Position position, Facing facing)
        {
            Position = position;
            Facing = facing;
        }
    }
}
