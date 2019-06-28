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

namespace Pong
{
    public partial class Pong : Form
    {
        public Pong()
        {
            InitializeComponent();
            leftPaddle = new Paddle(true);
            rightPaddle = new Paddle(false);
            ball = new Ball();
            leftScore = 0;
            rightScore = 0;
            GameStage = "Intro"; //start up screen
            PongBox.Invalidate();
        }

        Paddle leftPaddle;
        Paddle rightPaddle;
        Ball ball;
        System.Timers.Timer clock;
        int leftScore, rightScore;
        string GameStage;
        string winMessage;
        int countdown; //321 before ball launch
        int counter; //timing of countdown
        int WinScore = 11; //score needed to win
        int BoxWidth = 800;

        private void Start()
        {
            clock = new System.Timers.Timer();
            clock.Elapsed += new ElapsedEventHandler(TimerTick);
            clock.Interval = 10;                        
            leftScore = 0;
            rightScore = 0;
            ToCountdown();
            clock.Enabled = true;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            if (GameStage == "Countdown") //countdown to ball launch
            {
                counter++;
                if (counter == 50) //triggers every half second
                {
                    countdown--;
                    counter = 0;
                }
                if (countdown == -1)
                {
                    ball.Launch(BoxWidth);
                    GameStage = "Started";
                }              
            }
            if (GameStage == "Started") //round in play
            {
                leftPaddle.UpdatePosition();
                rightPaddle.UpdatePosition();
                ball.UpdatePosition();

                if (ball.Xlocation <= 0 - ball.size) //right scores
                {
                    rightScore++;
                    ToCountdown();
                }
                else if (ball.Xlocation <= 10 + leftPaddle.width && ball.Xlocation >= 10 && ball.Ylocation >= leftPaddle.Ylocation && ball.Ylocation <= leftPaddle.Ylocation + leftPaddle.height)
                {
                    ball.Hit(leftPaddle);
                }
                if (ball.Xlocation >= BoxWidth) //left scores
                {
                    leftScore++;
                    ToCountdown();
                }
                if (ball.Xlocation >= BoxWidth - 10 - rightPaddle.width - ball.size && ball.Xlocation <= BoxWidth - 10 - ball.size && ball.Ylocation >= rightPaddle.Ylocation && ball.Ylocation <= rightPaddle.Ylocation + rightPaddle.height)
                {
                    ball.Hit(rightPaddle);
                }

                if (rightScore == WinScore)
                {
                    clock.Enabled = false;
                    Gameover("RIGHT");
                }
                else if (leftScore == WinScore)
                {
                    clock.Enabled = false;
                    Gameover("LEFT");
                }
            }
            
            PongBox.Invalidate();
        }

        private void Pong_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(BoxWidth, 600);
        }

        private void PongBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush myBrush = new SolidBrush(Color.White);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            if (GameStage == "Intro")
            {
                g.DrawString("PRESS SPACE TO START", new Font("Lucida Sans Unicode", 15), Brushes.White, BoxWidth/2 - 1, 299, format);
            }
            else if (GameStage == "Started")
            {
                for (int i = 0; i <= PongBox.Height - 20; i += 20) //center line
                {
                    g.FillRectangle(myBrush, BoxWidth/2 - 2, i, 3, 10);
                }
                g.FillRectangle(myBrush, 10, leftPaddle.Ylocation, leftPaddle.width, leftPaddle.height);
                g.FillRectangle(myBrush, BoxWidth - 10 - rightPaddle.width, rightPaddle.Ylocation, rightPaddle.width, rightPaddle.height);
                g.FillEllipse(myBrush, ball.Xlocation, ball.Ylocation, ball.size, ball.size);
                g.DrawString(Convert.ToString(leftScore), new Font("Lucida Sans Unicode", 50), Brushes.White, BoxWidth/2 - 100, 100, format);
                g.DrawString(Convert.ToString(rightScore), new Font("Lucida Sans Unicode", 50), Brushes.White, BoxWidth / 2 + 100, 100, format);
            } 
            else if (GameStage == "Over") //game is over, displays winner
            {
                g.DrawString(winMessage, new Font("Lucida Sans Unicode", 15), Brushes.White, BoxWidth/2 - 1, 299, format);
                g.DrawString("PRESS SPACE TO PLAY AGAIN", new Font("Lucida Sans Unicode", 10), Brushes.White, BoxWidth / 2 - 1, 325, format);
            }
            else if (GameStage == "Countdown")
            {
                g.FillRectangle(myBrush, 10, 275, leftPaddle.width, leftPaddle.height);
                g.FillRectangle(myBrush, BoxWidth - 10 - rightPaddle.width, 275, rightPaddle.width, rightPaddle.height);
                g.FillEllipse(myBrush, BoxWidth/2 - 1 - ball.size / 2, 299 - ball.size / 2, ball.size, ball.size);
                g.DrawString(countdown.ToString(), new Font("Lucida Sans Unicode", 90), Brushes.White, BoxWidth/2 - 1, 400, format);
                for (int i = 0; i <= PongBox.Height - 20; i += 20)
                {
                    g.FillRectangle(myBrush, BoxWidth/2 -2, i, 3, 10);
                }
                g.DrawString(Convert.ToString(leftScore), new Font("Lucida Sans Unicode", 50), Brushes.White, BoxWidth / 2 - 100, 100, format);
                g.DrawString(Convert.ToString(rightScore), new Font("Lucida Sans Unicode", 50), Brushes.White, BoxWidth / 2 + 100, 100, format);
            }          
        }

        private void Pong_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameStage == "Started")
            {
                if (e.KeyCode == Keys.W)
                {
                    leftPaddle.direction = 1;
                }
                if (e.KeyCode == Keys.S)
                {
                    leftPaddle.direction = -1;
                }
                if (e.KeyCode == Keys.Up)
                {
                    rightPaddle.direction = 1;
                }
                if (e.KeyCode == Keys.Down)
                {
                    rightPaddle.direction = -1;
                }
            }         
        }

        private void Pong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                leftPaddle.direction = 0;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                rightPaddle.direction = 0;
            }
        }

        private void Pong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space && (GameStage == "Intro" || GameStage == "Over"))
            {
                Start();
            }
        }

        public void Gameover(string winner)
        {
            winMessage = "THE WINNER IS " + winner;
            GameStage = "Over";
            PongBox.Invalidate();
        }

        public void ToCountdown()
        {
            GameStage = "Countdown";
            countdown = 3;
            counter = 0;
            leftPaddle.Ylocation = 275;
            rightPaddle.Ylocation = 275;
        }
    }
}
