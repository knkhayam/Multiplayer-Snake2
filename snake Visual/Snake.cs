using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_Visual
{
    class Snake:List<bodyDot>
    {
        public Panel panel1;

        public int snakeNumber = 1;
        public int formWidth = 0;

        public Color color;
        public static int SnakeSize = Form1.SnakeSize;
        public static Size snakeSizePoint = new Size(Form1.SnakeSize, Form1.SnakeSize);
        public int dirx;
        public int diry;
        public string playerName;
        public Timer timer;
        Label playerLabel;
        bool alive;

        public int score=0;
        public int first;
        public int last;

        Food food;

        public Snake(Panel area,int snakeNumber=1,int formWidth=50)
        {
            panel1 = area;
            this.snakeNumber = snakeNumber;
            this.formWidth = formWidth;
            initPlayerLabel();

            alive = true;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;

            bodyDot x = new bodyDot(new Point(30, 40 + ((snakeNumber-1) * 5 * Form1.SnakeSize)), snakeSizePoint);
            bodyDot y = new bodyDot(new Point(30 + Form1.SnakeSize, 40 + ((snakeNumber - 1) * 5 * Form1.SnakeSize)), snakeSizePoint);
            bodyDot z = new bodyDot(new Point(30 + (Form1.SnakeSize * 2), 40 + ((snakeNumber - 1) * 5 * Form1.SnakeSize)), snakeSizePoint);
            x.BackColor = color;
            y.BackColor = color;
            z.BackColor = color;
            this.Add(x);
            this.Add(y);
            this.Add(z);

            first = this.Count - 1;
            last = 0;

            dirx = 1;
            diry = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this[last].Left = this[first].Location.X + (dirx * Form1.SnakeSize);
            this[last].Top = this[first].Location.Y + (diry * Form1.SnakeSize);

            if (this[last].Left > (panel1.Width - Form1.SnakeSize * 3))
                this[last].Left = 0;
            if (this[last].Top > (panel1.Height - Form1.SnakeSize * 5))
                this[last].Top = 0;
            if (this[last].Top < 0)
                this[last].Top = panel1.Height - (panel1.Height % Form1.SnakeSize) - (Form1.SnakeSize * 5);
            if (this[last].Left < 0)
                this[last].Left = panel1.Width - (panel1.Width % Form1.SnakeSize) - (Form1.SnakeSize * 3);

            if (this[last].Location == food.Location)
            {
                score++;
                playerLabel.Text = playerName + "[" + color.Name + "] : " + score;
                //eatPlayer.Play();
                bodyDot addition = new bodyDot(new Point(-SnakeSize, -SnakeSize), snakeSizePoint);
                this.Add(addition);
                panel1.Controls.Add(addition);
                PlaceFood();
            }

            this[last].BackColor = Color.Green;

            int akhriSayPichla = last - 1;
            if (akhriSayPichla < 0)
                akhriSayPichla = this.Count - 1;
            this[akhriSayPichla].BackColor = color;
            first = last;

            last++;

            if (last >= this.Count)
                last = 0;


        }

        //private void PlaceFood()
        //{
        //reDo:
        //    int randX = new Random().Next(0, panel1.Width - (SnakeSize * 3));
        //    int randY = new Random().Next(0, panel1.Height - (SnakeSize * 5));

        //    randX -= (randX % SnakeSize);
        //    randY -= (randY % SnakeSize);
        //    Point newLocation = new Point(randX, randY);

        //    food.Location = newLocation;
        //    //for (int i = 0; i < snake.Length; i++)
        //      //  foreach (bodyDot b in snake[i])
        //        //    if (food.Location == b.Location)
        //          //      goto reDo;
        //}

        void initPlayerLabel()
        {
            playerLabel = new Label();
            playerLabel.Text = playerName + "[" + color.Name + "] : " + score;
            playerLabel.AutoSize = true;
            playerLabel.Font = new Font(new FontFamily("Verdana"), 14f);

            switch (snakeNumber)
            {
                case 1:
                    playerLabel.Left = 10;
                    playerLabel.Top = 10;
                    color = Color.Red;
                    break;
                case 2:
                    playerLabel.Left = 10;
                    playerLabel.Top = 30;
                    color = Color.Orange;
                    break;
                case 3:
                    playerLabel.Left = formWidth / 2;
                    playerLabel.Top = 10;
                    color = Color.Blue;
                    break;
                case 4:
                    playerLabel.Left = formWidth / 2;
                    playerLabel.Top = 30;
                    color = Color.White;
                    break;
            }

        }
    }
}
