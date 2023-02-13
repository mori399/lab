using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kki
{
    public partial class Menu : Form
    {
        public Menu()
        {
            DoubleBuffered = true;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
        }
        int NumCard = 0;
        private void Play_Click(object sender, EventArgs e)
        {
            //SettingsMenu coll = new SettingsMenu();
            //int NumCard = coll.SkinCard();
            Form1 game = new Form1(NumCard);
            game.ShowDialog(); 
        }

        private void Play_MouseEnter(object sender, EventArgs e)
        {
            Play.BackColor = Color.Gray;
        }

        private void Play_MouseLeave(object sender, EventArgs e)
        {
            Play.BackColor = Color.Transparent;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsMenu settings = new SettingsMenu();
            settings.ShowDialog();
        }

        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            Settings.BackColor = Color.Gray;
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            Settings.BackColor = Color.Transparent;
        }

        private void Collection_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection();
            collection.ShowDialog();
        }

        private void Collection_MouseEnter(object sender, EventArgs e)
        {
            Collection.BackColor = Color.Gray;
        }

        private void Collection_MouseLeave(object sender, EventArgs e)
        {
            Collection.BackColor = Color.Transparent;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.BackColor = Color.Gray;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = Color.Transparent;
        }
    }
}
