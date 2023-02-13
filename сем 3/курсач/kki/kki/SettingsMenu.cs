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

namespace kki
{
    public partial class SettingsMenu : Form
    {
        public SettingsMenu()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }
        bool flag = false;
        private void Settings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            Settings.BackColor = Color.Gray;
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            Settings.BackColor = Color.Transparent;
        }

        private void Enemycard1_Click(object sender, EventArgs e)
        {
            Enemycard1.Location = new Point(634, 269);
            Enemycard2.Location = new Point(890, 284);
            Enemycard3.Location = new Point(1140, 284);
            File.Delete("..\\kki\\Cards\\settings.txt");
            File.AppendAllText("..\\kki\\Cards\\settings.txt", "0");
        }

        private void Enemycard2_Click(object sender, EventArgs e)
        {
            Enemycard1.Location = new Point(634, 284);
            Enemycard2.Location = new Point(890, 269);
            Enemycard3.Location = new Point(1140, 284);
            File.Delete("..\\kki\\Cards\\settings.txt");
            File.AppendAllText("..\\kki\\Cards\\settings.txt", "1");
        }

        private void Enemycard3_Click(object sender, EventArgs e)
        {
            Enemycard1.Location = new Point(634, 284);
            Enemycard2.Location = new Point(890, 284);
            Enemycard3.Location = new Point(1140, 269);
            File.Delete("..\\kki\\Cards\\settings.txt");
            File.AppendAllText("..\\kki\\Cards\\settings.txt", "2");
        }

        private void Song_Click(object sender, EventArgs e)
        {
            SoundPlayer sound_main = new SoundPlayer("..\\kki\\songs\\Backgroundmusic.wav");
            if (flag)
            {
                sound_main.PlayLooping();
                flag = false;
            } else
            {
                sound_main.Stop();
                flag = true;
            }
        }

        private void MenuSong_MouseEnter(object sender, EventArgs e)
        {
            MenuSong.BackColor = Color.Gray;
        }

        private void MenuSong_MouseLeave(object sender, EventArgs e)
        {
            MenuSong.BackColor = Color.Transparent;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            File.Delete("..\\kki\\Cards\\CountCard.txt");
            File.AppendAllText("..\\kki\\Cards\\CountCard.txt", "28");
        }

        private void Reset_MouseEnter(object sender, EventArgs e)
        {
            Reset.BackColor = Color.Gray;
        }

        private void Reset_MouseLeave(object sender, EventArgs e)
        {
            Reset.BackColor = Color.Transparent;
        }
    }
}
