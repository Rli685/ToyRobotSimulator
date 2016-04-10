using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator.Models
{
    public class TableTop
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public TableTop(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}
