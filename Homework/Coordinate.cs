using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Coordinate : IEquatable<Coordinate>
    {

        public Coordinate(int y, int x)
        {
            this.y = y;
            this.x = x;
        }
        public int y { get; set; }
        public int x { get; set; }

        public bool Equals(Coordinate other)
        {
            if (this.y == other.y && this.x == other.x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
