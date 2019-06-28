using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball
    {
        public int TotSpeed = 9;
        public double xSpeed;
        public double ySpeed;
        public int size = 15;
        public int Xlocation;
        public int Ylocation;
        Random rnd = new Random();

        public void UpdatePosition()
        {
            if (Ylocation <= 0 || Ylocation >= 600) //hits top or bottom edge
            {
                Bounce();
            }

            Xlocation = Convert.ToInt32(Xlocation + xSpeed);
            Ylocation = Convert.ToInt32(Ylocation + ySpeed);
        }

        public void Bounce()
        {
            ySpeed = -ySpeed;
        }

        public void Hit(Paddle paddle)
        {
            //how far above or below middle of paddle ball hits, negative means hits below middle
            double relativeHit = Convert.ToDouble((paddle.Ylocation + paddle.height / 2) - (Ylocation + size / 2)) / Convert.ToDouble(paddle.height/2);
           
            //bounce angle from horizontal
            double Angle = Math.Abs(relativeHit * (Math.PI/3)); //max angle is 60 degrees

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

        public void Launch(int width)
        {
            Xlocation = width/2 -1 - size / 2;
            Ylocation = width/2 -1 - size / 2;
            xSpeed = TotSpeed * Math.Cos(11* Math.PI / 36); //launch angle is 55 degrees
            ySpeed = TotSpeed * Math.Sin(11 * Math.PI / 36);

            if (rnd.Next(2) == 1)
            {
                xSpeed = -xSpeed;
            }
            if (rnd.Next(2) == 1)
            {
                ySpeed = -ySpeed;
            }
        }
    }
}
