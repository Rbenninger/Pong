using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Paddle
    {
        public int height = 90;
        public int width = 10;
        public int speed = 6;
        public int Ylocation;
        public int direction; //1 up, 0 neutral, -1 down
        public bool hitDirection; //true is left

        public Paddle(bool side)
        {
            Ylocation = 275;
            direction = 0;
            hitDirection = side;
        }

        public void UpdatePosition()
        {
            if (direction == 1 && Ylocation > 0) //moving up
            {
                Ylocation -= speed;
            }
            else if (direction == -1 && Ylocation < 600 - height) //moving down
            {
                Ylocation += speed;
            }
        }
    }
}
