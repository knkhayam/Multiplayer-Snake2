using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_Visual
{
    class Food:bodyDot
    {
        Panel panel1;
        public static int SnakeSize = Form1.SnakeSize;
        public Snake[] snake;
        public Food(Panel area,Snake[] snake)
        {
            panel1 = area;
            this.snake = snake;
        }

        public void PlaceFood()
        {
        reDo:
            int randX = new Random().Next(0, panel1.Width - (SnakeSize * 3));
            int randY = new Random().Next(0, panel1.Height - (SnakeSize * 5));

            randX -= (randX % SnakeSize);
            randY -= (randY % SnakeSize);
            Point newLocation = new Point(randX, randY);

            this.Location = newLocation;
            for (int i = 0; i < snake.Length; i++)
              foreach (bodyDot b in snake[i])
                if (this.Location == b.Location)
                  goto reDo;
        }
    }
}
