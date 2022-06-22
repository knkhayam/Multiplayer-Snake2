using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_Visual
{
    public partial class Form1 : Form
    {
        Snake[] snake;
        //Color[] colors;
        public static int SnakeSize = 10;
        //static Size snakeSizePoint = new Size(SnakeSize, SnakeSize);
        //int[] dirX, dirY;

        //Label[] playerLabel;
        //List<string> Players;

        //Timer[] timer;

        bool isPlaying = false;
        //void initPlayerLabels()
        //{
        //    playerLabel = new Label[Players.Count];
        //    for(int i=0;i<playerLabel.Length;i++)
        //    {
        //        playerLabel[i] = new Label();
        //        playerLabel[i].Text = Players[i] + "[" + colors[i].Name + "] : "+score[i];
        //        playerLabel[i].AutoSize = true;
        //        playerLabel[i].Font = new Font(new FontFamily("Tekton Pro Ext"), 14f);

        //        playerLabel[i].Left = 10;
        //        if(i<2)
        //            playerLabel[i].Top = i * 20 + 10;
        //        else
        //        {
        //            playerLabel[i].Left = Width/2;
        //            playerLabel[i].Top = (i - 2) * 20 + 10;
        //        }
        //        panel2.Controls.Add(playerLabel[i]);
        //    }

        //}
        public Form1(int x,int y,List<string> players)
        {
            InitializeComponent();
            /// added by me color wali line
            Color[] colors = new Color[4] { Color.Blue, Color.White, Color.Yellow, Color.Brown };
            int numOfPlayers = players.Count;
            //Players = players;
            //timer = new Timer[numOfPlayers];
            
            Width = x * SnakeSize;
            Height = y * SnakeSize + panel1.Top;
            snake = new Snake[numOfPlayers];

            //snake = new List<bodyDot>[numOfPlayers];
            //first = new int[numOfPlayers];
            //last = new int[numOfPlayers];
            
            //score = new int[numOfPlayers];

            //dirX = new int[4]; // no matters how much players// limiting this will cause exception during keys//
            //dirY = new int[4];

            //initPlayerLabels();

            for (int i = 0; i < snake.Length; i++)
            {
                //snake[i] = new List<bodyDot>();
                snake[i] = new Snake(this.panel1,i + 1, Width);
                //timer[i] = new Timer();
                //timer[i].Interval = 100;
                //timer[i].Tag = i;
                //timer[i].Tick += Form1_Tick;
            }

            init();
        }

        bool[] alive;
        void Form1_Tick(object sender, EventArgs e)
        {
            Timer temp = (Timer)sender;
            int i = Convert.ToInt16(temp.Tag);

            //snake[i][last[i]].Left = snake[i][first[i]].Location.X + (dirX[i] * SnakeSize);
            //snake[i][last[i]].Top = snake[i][first[i]].Location.Y + (dirY[i] * SnakeSize);

            //if (snake[i][last[i]].Left > (panel1.Width - SnakeSize * 3))
            //    snake[i][last[i]].Left = 0;
            //if (snake[i][last[i]].Top > (panel1.Height - SnakeSize * 5))
            //    snake[i][last[i]].Top = 0;
            //if (snake[i][last[i]].Top < 0)
            //    snake[i][last[i]].Top = panel1.Height - (panel1.Height % SnakeSize) - (SnakeSize * 5);
            //if (snake[i][last[i]].Left < 0)
            //    snake[i][last[i]].Left = panel1.Width - (panel1.Width % SnakeSize) - (SnakeSize * 3);

            //if (snake[i][last[i]].Location == food.Location)
            //{
            //    score[i]++;
            //    playerLabel[i].Text = Players[i] + "[" + colors[i].Name + "] : " + score[i];
            //    eatPlayer.Play();
            //    bodyDot addition = new bodyDot(new Point(-SnakeSize, -SnakeSize), snakeSizePoint);
            //    snake[i].Add(addition);
            //    panel1.Controls.Add(addition);
            //    PlaceFood();
            //}
            //snake[i][last[i]].BackColor = Color.Green;

            //int akhriSayPichla = last[i] - 1;
            //if (akhriSayPichla < 0)
            //    akhriSayPichla = snake[i].Count - 1;
            //snake[i][akhriSayPichla].BackColor = colors[i];
            //first[i] = last[i];

            //last[i]++;

            //if (last[i] >= snake[i].Count)
            //    last[i] = 0;
            //////
            // The Most Difficult Part ///
            for (int t = 0; t < snake.Length; t++)
            {
                for (int j = 0; j < snake[t].Count; j++)
                {
                    if (first[t] != j && snake[t][first[t]].Location == snake[t][j].Location)
                    {
                        deathPlayer.Play();
                        reset();
                        break;
                    }
                    for (int r = 0; r < snake.Length; r++)
                    {
                        if (r == t)
                            continue;
                        for (int k = 0; k < snake[r].Count; k++)
                        {
                            if (snake[t][first[t]].Location == snake[r][k].Location)
                            {
                                if (alive[t])
                                {
                                    deathPlayer.Play();
                                    timer[t].Stop();
                                    alive[t] = false;

                                    for (int q = 0; q < alive.Length; q++)
                                        if (!alive[q])
                                        {
                                            if (q == alive.Length - 1)
                                                reset();
                                        }
                                        else
                                            break;
                                }
                                break;
                            }
                        }
                    }

                }
            }
           
        }

        SoundPlayer eatPlayer = new SoundPlayer("Resources\\eat.wav");
        SoundPlayer speedPlayer = new SoundPlayer("Resources\\speed.wav");
        SoundPlayer brakePlayer = new SoundPlayer("Resources\\brake.wav");
        SoundPlayer deathPlayer = new SoundPlayer("Resources\\death.wav");
        private void init()
        {
            for (int i = 0; i < snake.Length; i++)
            {
                //alive = new bool[snake.Length];
                //for (int q = 0; q < alive.Length; q++)
                  //  alive[q] = true;

                snake[i].Clear();

                //bodyDot x = new bodyDot(new Point(30, 40 + (i * 5 * SnakeSize)), snakeSizePoint);
                //bodyDot y = new bodyDot(new Point(30 + SnakeSize, 40 + (i * 5 * SnakeSize)), snakeSizePoint);
                //bodyDot z = new bodyDot(new Point(30 + (SnakeSize * 2), 40 + (i * 5 * SnakeSize)), snakeSizePoint);
                //x.BackColor = colors[i];
                //y.BackColor = colors[i];
                //z.BackColor = colors[i];
                //snake[i].Add(x);
                //snake[i].Add(y);
                //snake[i].Add(z);

                //first[i] = snake[i].Count - 1;
                //last[i] = 0;

                //dirX[i] = 1;
                //dirY[i] = 0;

                //food.BackColor = Color.Yellow;
                //PlaceFood();
                panel1.Controls.Add(food);

                foreach (bodyDot b in snake[i])
                    panel1.Controls.Add(b);

            }
        }

        void TogglePlay(bool tog)
        {
            isPlaying = tog;
            for (int i = 0; i < snake.Length; i++)
                snake[i].timer.Enabled = tog;
        }

        //int[] last;
        //int[] first;
        //int[] score;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            for (int j = 0; j < snake[0].Count; j++)
            {
                if (first[0] != j && snake[0][first[0]].Location == snake[0][j].Location)
                {
                    deathPlayer.Play();
                    reset();
                    break;
                }
                for(int k=0;k<snake[1].Count;k++)
                {
                    if (snake[0][first[0]].Location == snake[1][k].Location)
                    {
                        deathPlayer.Play();
                        reset();
                        break;
                    }
                }
            }

            for (int j = 0; j < snake[1].Count; j++)
            {
                if (first[1] != j && snake[1][first[1]].Location == snake[1][j].Location)
                {
                    deathPlayer.Play();
                    reset();
                    break;
                }
                for (int k = 0; k < snake[0].Count; k++)
                {
                    if (snake[1][first[1]].Location == snake[0][k].Location)
                    {
                        deathPlayer.Play();
                        reset();
                        break;
                    }
                }
            }
        }

        private void reset()
        {
            TogglePlay(false);
            System.Threading.Thread.Sleep(3000);
            MessageBox.Show("Game Over!");
            for(int i=0;i<snake.Length;i++)
            {
                score[i] = 0;
                playerLabel[i].Text = Players[i] + "[" + colors[i].Name + "] : " + score[i];
            }
            
            for (int i = 0; i < snake.Length;i++ )
                foreach (bodyDot b in snake[i])
                    panel1.Controls.Remove(b);
            
            init();

        }

        //bodyDot food = new bodyDot(new Point(0, 0),new Size(SnakeSize,SnakeSize));
        //private void PlaceFood()
        //{
        //reDo:
        //    int randX = new Random().Next(0, panel1.Width - (SnakeSize * 3));
        //    int randY = new Random().Next(0, panel1.Height - (SnakeSize * 5));

        //    randX -= (randX % SnakeSize);
        //    randY -= (randY % SnakeSize);
        //    Point newLocation = new Point(randX, randY);

        //    food.Location = newLocation;
        //    for (int i = 0; i < snake.Length; i++)
        //        foreach (bodyDot b in snake[i])
        //            if (food.Location == b.Location)
        //                goto reDo;
        //}

        private void sUp(int i)
        {
            if (dirX[i] == 0)
                return;
            dirX[i] = 0;
            dirY[i] = -1;
                    
        }
        private void sLeft(int i)
        {
            if (dirY[i] == 0)
                return;
            dirX[i] = -1;
            dirY[i] = 0;
                    
        }
        private void sDown(int i)
        {
            if (dirX[i] == 0)
                return;
            dirX[i] = 0;
            dirY[i] = 1;
        }
        private void sRight(int i)
        {
            if (dirY[i] == 0)
                return;
            dirX[i] = 1;
            dirY[i] = 0;
        }
        private void toggleBoost(int i,int val)
        {
            if (timer.Length < i)
                return;
            timer[i].Interval = val;
            if (val >= 100)
            {
                speedPlayer.Stop();
                brakePlayer.Play();
            }
            else
                speedPlayer.PlayLooping();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (!isPlaying)
            {
                TogglePlay(true);
            }

            switch(e.KeyCode)
            {
                    // Boost Keys //
                case Keys.Space:
                    toggleBoost(0, 20);
                    break;
                case Keys.R:
                    toggleBoost(1, 20);
                    break;
                case Keys.U:
                    toggleBoost(2, 20);
                    break;
                case Keys.P:
                    toggleBoost(3, 20);
                    break;
                
                // End of Boost Keys //

                    // Control Keys //

                    // Player 1 Controls //
                case Keys.Up:
                    sUp(0);
                    break;
                case Keys.Left:
                    sLeft(0);
                    break;
                case Keys.Down:
                    sDown(0);
                    break;
                case Keys.Right:
                    sRight(0);
                    break;

                    // Player 2 Controls // W is not working on my laptop, so WSAD will not be used //

                case Keys.E:
                    sUp(1);
                    break;
                case Keys.S:
                    sLeft(1);
                    break;
                case Keys.D:
                    sDown(1);
                    break;
                case Keys.F:
                    sRight(1);
                    break;

                    // Player 3 Controls //

                case Keys.Y:
                    sUp(2);
                    break;
                case Keys.G:
                    sLeft(2);
                    break;
                case Keys.H:
                    sDown(2);
                    break;
                case Keys.J:
                    sRight(2);
                    break;
                // Player 4 Controls //

                case Keys.O:
                    sUp(3);
                    break;
                case Keys.K:
                    sLeft(3);
                    break;
                case Keys.L:
                    sDown(3);
                    break;
                case Keys.OemSemicolon:
                    sRight(3);
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Space:
                    toggleBoost(0, 100);
                    break;
                case Keys.R:
                    toggleBoost(1, 100);
                    break;
                case Keys.U:
                    toggleBoost(2, 100);
                    break;
                case Keys.P:
                    toggleBoost(3, 100);
                    break;
            }
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panel1.Width = Width;
            panel1.Height = Height - panel1.Top;

            panel2.Width = Width;
            //label2.Left = Width - label2.Width - 10;
        }
    }
}
