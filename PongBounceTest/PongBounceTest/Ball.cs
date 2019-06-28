using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongBounceTest
{
    class Ball
    {
        public int TotSpeed = 10;
        public double xSpeed;
        public double ySpeed;
        public int size = 15;
        public int Xlocation;
        public int Ylocation;

        public void UpdatePosition()
        {
            Xlocation = Convert.ToInt32(Xlocation + xSpeed);
            Ylocation = Convert.ToInt32(Ylocation + ySpeed);
        }

        public void Hit(Paddle paddle)
        {
            //how far above or below middle of paddle ball hits, negative means hits below middle
            double relativeHit = Convert.ToDouble((paddle.Ylocation + paddle.height / 2) - (Ylocation + size / 2)) / Convert.ToDouble(paddle.height / 2);

            //bounce angle from horizontal
            double Angle = Math.Abs(relativeHit * (Math.PI / 3)); //max angle is 60 degrees

            xSpeed = Math.Abs(TotSpeed * Math.Cos(Angle));
            ySpeed = Math.Abs(TotSpeed * Math.Sin(Angle));

            if (!paddle.hitDirection) //hits right paddle
            {
                xSpeed = -xSpeed;
            }
            if (relativeHit > 0) //hits above middle
            {
                ySpeed = -ySpeed;
            }
        }

        public void Launch(int height, string direction)
        {
            Xlocation = 200 - size / 2;
            Ylocation = height - size / 2;
            ySpeed = 0;

            if (direction == "left")
            {
                xSpeed = -TotSpeed;
            }
            else
            {
                xSpeed = TotSpeed;
            }
        }
    }
}
