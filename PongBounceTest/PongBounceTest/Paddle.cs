using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongBounceTest
{
    class Paddle
    {
        public int height = 200;
        public int width = 10;
        public int Ylocation;
        public bool hitDirection; //true is left

        public Paddle(bool side)
        {
            Ylocation = 100;
            hitDirection = side;
        }
    }
}
