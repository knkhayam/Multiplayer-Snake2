using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake_Visual
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Resources/bg music.wav");
        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt16(numericUpDown1.Value);
            int y = Convert.ToInt16(numericUpDown2.Value);
            
            List<string> players = new List<string>();
            for (int i = 0; i < numericUpDown3.Value; i++)
                players.Add(playerText[i].Text);
            Form1 game = new Form1(x, y, players); 
            game.FormClosed += game_FormClosed;
            Hide();
            sp.Stop();
            game.ShowDialog();
        }

        void game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            sp.PlayLooping();

            for(int i = 0,placer = 0; i < playerLabel.Length; i++,placer += 25)
            {
                playerLabel[i] = new Label();
                playerText[i] = new TextBox();

                playerLabel[i].Text = "Player " + (i + 1) + " :";
                playerLabel[i].AutoSize = true;
                playerLabel[i].Location = new Point(5, placer);
                playerText[i].Location = new Point(5, placer += 15);
            }
            panel1.Controls.Add(playerText[0]);
            panel1.Controls.Add(playerLabel[0]);
        }

        Label[] playerLabel = new Label[4];
        TextBox[] playerText = new TextBox[4];
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            while (panel1.Controls.Count > 0)
                foreach (Control c in panel1.Controls)
                    panel1.Controls.Remove(c);
            for (int i = 0; i < numericUpDown3.Value; i++)
            {
                panel1.Controls.Add(playerLabel[i]);
                panel1.Controls.Add(playerText[i]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string info = "Player 1\n" +
                "ARROW KEYS FOR UP/DOWN/LEFT/RIGHT  SPACE TO BOOST\n" +
                "Player 2\n" +
                "E/D/S/F  FOR UP/DOWN/LEFT/RIGHT    R TO BOOST\n" +
                "Player 3\n" +
                "Y/H/G/J  FOR UP/DOWN/LEFT/RIGHT    U TO BOOST\n" +
                "Player 4\n" +
                "O/L/K/;  FOR UP/DOWN/LEFT/RIGHT    P TO BOOST\n" +
                "\n Enjoy Playing!";

            MessageBox.Show(info, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
