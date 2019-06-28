using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace PongBounceTest
{
    public partial class BouceTest : Form
    {
        public BouceTest()
        {
            InitializeComponent();
            leftPaddle = new Paddle(true);
            rightPaddle = new Paddle(false);
            ball = new Ball();
            counter = 0;
            Start();
            height = 115;
            DoneLeft = false;
        }

        Paddle leftPaddle;
        Paddle rightPaddle;
        Ball ball;
        System.Timers.Timer clock;
        int BoxWidth = 400;
        int counter;
        int height;
        bool DoneLeft;

        private void Start()
        {
            clock = new System.Timers.Timer();
            clock.Elapsed += new ElapsedEventHandler(TimerTick);
            clock.Interval = 10;
            clock.Enabled = true;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            ball.UpdatePosition();
            counter++;
            if (counter == 50)
            {
                if (!DoneLeft)
                {
                    ball.Launch(height, "left");
                }
                else
                {
                    ball.Launch(height, "right");
                    if (height > 300)
                    {
                        clock.Enabled = false;
                    }
                }               
                counter = 0;
                height += 10;
            }
            if (height > 315)
            {
                DoneLeft = true;
                height = 115;
            }

            if (ball.Xlocation <= 10 + leftPaddle.width && ball.Xlocation >= 10 && ball.Ylocation >= leftPaddle.Ylocation && ball.Ylocation <= leftPaddle.Ylocation + leftPaddle.height)
            {

                ball.Hit(leftPaddle);
            }
            if (ball.Xlocation >= BoxWidth - 10 - rightPaddle.width - ball.size && ball.Xlocation <= BoxWidth - 10 - ball.size && ball.Ylocation >= rightPaddle.Ylocation && ball.Ylocation <= rightPaddle.Ylocation + rightPaddle.height)
            {

                ball.Hit(rightPaddle);
            }

            BounceBox.Invalidate();
        }

        private void BouceTest_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(400,400);
        }

        private void BounceBox_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush myBrush = new SolidBrush(Color.White);

            g.FillRectangle(myBrush, 10, leftPaddle.Ylocation, leftPaddle.width, leftPaddle.height);
            g.FillRectangle(myBrush, BoxWidth - 10 - rightPaddle.width, rightPaddle.Ylocation, rightPaddle.width, rightPaddle.height);
            g.FillEllipse(myBrush, ball.Xlocation, ball.Ylocation, ball.size, ball.size);
        }

        public void Test(string direction)
        {
           
        }
    }
}
