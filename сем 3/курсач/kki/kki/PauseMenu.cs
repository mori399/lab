using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kki
{
    public partial class PauseMenu : Form
    {
        Form1 form1;
        public PauseMenu(Form1 owner, int EndGame)
        {
            DoubleBuffered = true;
            form1 = owner;
            InitializeComponent();
            if (EndGame == 1)
            {
                BackGame.Visible = false;
                MenuSong.Visible = false;
                Result.Visible = true;
                Result.ForeColor = Color.Lime;
                Result.Location = new Point(272, 50);
                Result.Text = "Победа";
            }
            if (EndGame == 2)
            {
                MenuSong.Visible = false;
                BackGame.Visible = false;
                Result.Visible = true;
                Result.ForeColor = Color.Red;
                Result.Location = new Point(190, 53);
                Result.Text = "Поражение";
            }
        }
        bool flag = false;
        private void BackGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            form1.Close();
            this.Close();
        }

        private void BackGame_MouseEnter(object sender, EventArgs e)
        {
            BackGame.BackColor = Color.Orange; 
        }

        private void BackGame_MouseLeave(object sender, EventArgs e)
        {
            BackGame.BackColor = Color.Transparent;
        }

        private void MainMenu_MouseEnter(object sender, EventArgs e)
        {
            MainMenu.BackColor = Color.Orange;
        }

        private void MainMenu_MouseLeave(object sender, EventArgs e)
        {
            MainMenu.BackColor = Color.Transparent;
        }

        private void MenuSong_Click(object sender, EventArgs e)
        {
            SoundPlayer sound_main = new SoundPlayer("..\\kki\\songs\\Backgroundmusic.wav");
            if (flag)
            {
                sound_main.PlayLooping();
                flag = false;
            }
            else
            {
                sound_main.Stop();
                flag = true;
            }
        }

        private void MenuSong_MouseEnter(object sender, EventArgs e)
        {
            MenuSong.BackColor = Color.Orange;
        }

        private void MenuSong_MouseLeave(object sender, EventArgs e)
        {
            MenuSong.BackColor = Color.Transparent;
        }
    }
}
