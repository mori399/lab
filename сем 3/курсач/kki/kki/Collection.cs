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
 
    public partial class Collection : Form
    {
        Deck[] Card = new Deck[39];
        int i = 1;
        public Collection()
        {
            DoubleBuffered = true;
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("..\\kki\\Cards\\menu.png");
            initializ();
            ShowCard();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            MainMenu.BackColor = Color.Gray;
        }
        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            MainMenu.BackColor = Color.Transparent;
        }

        private void back_Click(object sender, EventArgs e)
        {
            i -= 14;
            ShowCard();
        }

        private void next_Click(object sender, EventArgs e)
        {
            i += 14;
            ShowCard();
        }
        void ShowCard()
        {
            pic1.BackgroundImage = Card[i].PicterCard;
            Dmg1.Text = Card[i].DMG.ToString();
            Mana1.Text = Card[i].MANA.ToString();
            Hp1.Text = Card[i].HP.ToString();

            pic2.BackgroundImage = Card[i + 1].PicterCard;
            Dmg2.Text = Card[i + 1].DMG.ToString();
            Mana2.Text = Card[i + 1].MANA.ToString();
            Hp2.Text = Card[i + 1].HP.ToString();

            pic3.BackgroundImage = Card[i + 2].PicterCard;
            Dmg3.Text = Card[i + 2].DMG.ToString();
            Mana3.Text = Card[i + 2].MANA.ToString();
            Hp3.Text = Card[i + 2].HP.ToString();

            pic4.BackgroundImage = Card[i + 3].PicterCard;
            Dmg4.Text = Card[i + 3].DMG.ToString();
            Mana4.Text = Card[i + 3].MANA.ToString();
            Hp4.Text = Card[i + 3].HP.ToString();

            pic5.BackgroundImage = Card[i + 4].PicterCard;
            Dmg5.Text = Card[i + 4].DMG.ToString();
            Mana5.Text = Card[i + 4].MANA.ToString();
            Hp5.Text = Card[i + 4].HP.ToString();

            pic6.BackgroundImage = Card[i + 5].PicterCard;
            Dmg6.Text = Card[i + 5].DMG.ToString();
            Mana6.Text = Card[i + 5].MANA.ToString();
            Hp6.Text = Card[i + 5].HP.ToString();

            pic7.BackgroundImage = Card[i + 6].PicterCard;
            Dmg7.Text = Card[i + 6].DMG.ToString();
            Mana7.Text = Card[i + 6].MANA.ToString();
            Hp7.Text = Card[i + 6].HP.ToString();

            pic8.BackgroundImage = Card[i + 7].PicterCard;
            Dmg8.Text = Card[i + 7].DMG.ToString();
            Mana8.Text = Card[i + 7].MANA.ToString();
            Hp8.Text = Card[i + 7].HP.ToString();

            pic9.BackgroundImage = Card[i + 8].PicterCard;
            Dmg9.Text = Card[i + 8].DMG.ToString();
            Mana9.Text = Card[i + 8].MANA.ToString();
            Hp9.Text = Card[i + 8].HP.ToString();

            if (i < 28)
            {
                pic10.BackgroundImage = Card[i + 9].PicterCard;
                Dmg10.Text = Card[i + 9].DMG.ToString();
                Mana10.Text = Card[i + 9].MANA.ToString();
                Hp10.Text = Card[i + 9].HP.ToString();

                pic11.BackgroundImage = Card[i + 10].PicterCard;
                Dmg11.Text = Card[i + 10].DMG.ToString();
                Mana11.Text = Card[i + 10].MANA.ToString();
                Hp11.Text = Card[i + 10].HP.ToString();

                pic12.BackgroundImage = Card[i + 11].PicterCard;
                Dmg12.Text = Card[i + 11].DMG.ToString();
                Mana12.Text = Card[i + 11].MANA.ToString();
                Hp12.Text = Card[i + 11].HP.ToString();

                pic13.BackgroundImage = Card[i + 12].PicterCard;
                Dmg13.Text = Card[i + 12].DMG.ToString();
                Mana13.Text = Card[i + 12].MANA.ToString();
                Hp13.Text = Card[i + 12].HP.ToString();

                pic14.BackgroundImage = Card[i + 13].PicterCard;
                Dmg14.Text = Card[i + 13].DMG.ToString();
                Mana14.Text = Card[i + 13].MANA.ToString();
                Hp14.Text = Card[i + 13].HP.ToString();
            } else
            {
                pic10.BackgroundImage = null;
                Dmg10.Text = null;
                Mana10.Text = null;
                Hp10.Text = null;

                pic11.BackgroundImage = null;
                Dmg11.Text = null;
                Mana11.Text = null;
                Hp11.Text = null;

                pic12.BackgroundImage = null;
                Dmg12.Text = null;
                Mana12.Text = null;
                Hp12.Text = null;

                pic13.BackgroundImage = null;
                Dmg13.Text = null;
                Mana13.Text = null;
                Hp13.Text = null;

                pic14.BackgroundImage = null;
                Dmg14.Text = null;
                Mana14.Text = null;
                Hp14.Text = null;
            }
        }
        void initializ()                      // инициализация карт
        {

            Card[1].Using = true;
            Card[1].PicterCard = Image.FromFile("../kki/Cards/Ilya.jpg");
            Card[1].HP = 9;
            Card[1].DMG = 9;
            Card[1].MANA = 9;

            Card[2].Using = true;
            Card[2].PicterCard = Image.FromFile("../kki/Cards/рыцарь3.jpg");
            Card[2].HP = 8;
            Card[2].DMG = 4;
            Card[2].MANA = 6;

            Card[3].Using = true;
            Card[3].PicterCard = Image.FromFile("../kki/Cards/рыцарь2.jpg");
            Card[3].HP = 5;
            Card[3].DMG = 4;
            Card[3].MANA = 4;

            Card[4].Using = true;
            Card[4].PicterCard = Image.FromFile("../kki/Cards/лучник.jpg");
            Card[4].HP = 1;
            Card[4].DMG = 2;
            Card[4].MANA = 1;

            Card[5].Using = true;
            Card[5].HP = 4;
            Card[5].DMG = 7;
            Card[5].MANA = 5;
            Card[5].PicterCard = Image.FromFile("../kki/Cards/шаман.jpg");

            Card[6].Using = true;
            Card[6].PicterCard = Image.FromFile("../kki/Cards/Жрец4.jpg");
            Card[6].HP = 2;
            Card[6].DMG = 2;
            Card[6].MANA = 1;

            Card[7].Using = true;
            Card[7].PicterCard = Image.FromFile("../kki/Cards/Жрец.jpg");
            Card[7].HP = 1;
            Card[7].DMG = 3;
            Card[7].MANA = 2;

            Card[8].Using = true;
            Card[8].PicterCard = Image.FromFile("../kki/Cards/fire.png");
            Card[8].HP = 4;                                               
            Card[8].DMG = 4;
            Card[8].MANA = 3;

            Card[9].Using = true;
            Card[9].PicterCard = Image.FromFile("../kki/Cards/Girl.jpg");
            Card[9].HP = 1;
            Card[9].DMG = 1;
            Card[9].MANA = 0;

            Card[10].Using = true;
            Card[10].PicterCard = Image.FromFile("../kki/Cards/ведьма2.jpg");
            Card[10].HP = 3;
            Card[10].DMG = 1;
            Card[10].MANA = 1;

            Card[11].Using = true;
            Card[11].PicterCard = Image.FromFile("../kki/Cards/воин.jpg");
            Card[11].HP = 4;
            Card[11].DMG = 3;
            Card[11].MANA = 3;

            Card[12].Using = true;
            Card[12].PicterCard = Image.FromFile("../kki/Cards/воин2.jpg");
            Card[12].HP = 6;
            Card[12].DMG = 6;
            Card[12].MANA = 5;

            Card[13].Using = true;
            Card[13].PicterCard = Image.FromFile("../kki/Cards/жрец2.jpg");
            Card[13].HP = 8;
            Card[13].DMG = 7;
            Card[13].MANA = 7;

            Card[14].Using = true;
            Card[14].PicterCard = Image.FromFile("../kki/Cards/жрец3.jpg");
            Card[14].HP = 3;
            Card[14].DMG = 3;
            Card[14].MANA = 3;

            Card[15].Using = true;
            Card[15].PicterCard = Image.FromFile("../kki/Cards/Кицуне.jpg");
            Card[15].HP = 2;
            Card[15].DMG = 1;
            Card[15].MANA = 1;

            Card[16].Using = true;
            Card[16].PicterCard = Image.FromFile("../kki/Cards/лиса.jpg");
            Card[16].HP = 5;
            Card[16].DMG = 5;
            Card[16].MANA = 5;

            Card[17].Using = true;
            Card[17].PicterCard = Image.FromFile("../kki/Cards/маг.jpg");
            Card[17].HP = 4;
            Card[17].DMG = 4;
            Card[17].MANA = 4;

            Card[18].Using = true;
            Card[18].PicterCard = Image.FromFile("../kki/Cards/охотник.jpg");
            Card[18].HP = 3;
            Card[18].DMG = 2;
            Card[18].MANA = 2;

            Card[19].Using = true;
            Card[19].PicterCard = Image.FromFile("../kki/Cards/охотник2.jpg");
            Card[19].HP = 5;
            Card[19].DMG = 7;
            Card[19].MANA = 6;

            Card[20].Using = true;
            Card[20].PicterCard = Image.FromFile("../kki/Cards/рыцарь.jpg");
            Card[20].HP = 2;
            Card[20].DMG = 1;
            Card[20].MANA = 1;

            Card[20].Using = true;
            Card[20].PicterCard = Image.FromFile("../kki/Cards/шаман2.jpg");
            Card[20].HP = 2;
            Card[20].DMG = 4;
            Card[20].MANA = 3;

            Card[21].Using = true;
            Card[21].PicterCard = Image.FromFile("../kki/Cards/шаман3.jpg");
            Card[21].HP = 5;
            Card[21].DMG = 1;
            Card[21].MANA = 2;

            Card[22].Using = true;
            Card[22].PicterCard = Image.FromFile("../kki/Cards/герой - охотник.jpg");
            Card[22].HP = 7;
            Card[22].DMG = 8;
            Card[22].MANA = 7;

            Card[23].Using = true;
            Card[23].PicterCard = Image.FromFile("../kki/Cards/маг2.jpg");
            Card[23].HP = 2;
            Card[23].DMG = 6;
            Card[23].MANA = 4;

            Card[24].Using = true;
            Card[24].PicterCard = Image.FromFile("../kki/Cards/герой.jpg");
            Card[24].HP = 8;
            Card[24].DMG = 5;
            Card[24].MANA = 6;

            Card[25].Using = true;
            Card[25].PicterCard = Image.FromFile("../kki/Cards/герой2.jpg");
            Card[25].HP = 5;
            Card[25].DMG = 9;
            Card[25].MANA = 7;

            Card[26].Using = true;
            Card[26].PicterCard = Image.FromFile("../kki/Cards/герой3.jpg");
            Card[26].HP = 8;
            Card[26].DMG = 6;
            Card[26].MANA = 6;

            Card[27].Using = true;
            Card[27].PicterCard = Image.FromFile("../kki/Cards/герой-лучник.jpg");
            Card[27].HP = 1;
            Card[27].DMG = 9;
            Card[27].MANA = 5;

            Card[28].Using = true;
            Card[28].PicterCard = Image.FromFile("../kki/Cards/судья.jpg");
            Card[28].HP = 7;
            Card[28].DMG = 7;
            Card[28].MANA = 7;
            ////////////////////
            Card[29].Using = true;
            Card[29].PicterCard = Image.FromFile("../kki/Cards/вороны.jpg");
            Card[29].HP = 2;
            Card[29].DMG = 2;
            Card[29].MANA = 1;

            Card[30].Using = true;
            Card[30].PicterCard = Image.FromFile("../kki/Cards/зомбэ.jpg");
            Card[30].HP = 4;
            Card[30].DMG = 4;
            Card[30].MANA = 3;

            Card[31].Using = true;
            Card[31].PicterCard = Image.FromFile("../kki/Cards/зомби.jpg");
            Card[31].HP = 3;
            Card[31].DMG = 3;
            Card[31].MANA = 2;

            Card[32].Using = true;
            Card[32].PicterCard = Image.FromFile("../kki/Cards/огр.jpg");
            Card[32].HP = 8;
            Card[32].DMG = 6;
            Card[32].MANA = 5;

            Card[33].Using = true;
            Card[33].PicterCard = Image.FromFile("../kki/Cards/огр2.jpg");
            Card[33].HP = 8;
            Card[33].DMG = 7;
            Card[33].MANA = 8;

            Card[34].Using = true;
            Card[34].PicterCard = Image.FromFile("../kki/Cards/демон.jpg");
            Card[34].HP = 9;
            Card[34].DMG = 9;
            Card[34].MANA = 8;

            Card[35].Using = true;
            Card[35].PicterCard = Image.FromFile("../kki/Cards/бес.jpg");
            Card[35].HP = 2;
            Card[35].DMG = 4;
            Card[35].MANA = 2;

            Card[36].Using = true;
            Card[36].PicterCard = Image.FromFile("../kki/Cards/бес2.jpg");
            Card[36].HP = 6;
            Card[36].DMG = 4;
            Card[36].MANA = 4;

            Card[37].Using = true;
            Card[37].PicterCard = Image.FromFile("../kki/Cards/орк.jpg");
            Card[37].HP = 5;
            Card[37].DMG = 5;
            Card[37].MANA = 4;

            Card[38].Using = true;
            Card[38].PicterCard = Image.FromFile("../kki/Cards/орк2.jpg");
            Card[38].HP = 6;
            Card[38].DMG = 7;
            Card[38].MANA = 6;

        }

        private void back_MouseEnter(object sender, EventArgs e)
        {
            back.BackColor = Color.Gray;
        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            back.BackColor = Color.Transparent;
        }

        private void next_MouseEnter(object sender, EventArgs e)
        {
            next.BackColor = Color.Gray;
        }

        private void next_MouseLeave(object sender, EventArgs e)
        {
            next.BackColor = Color.Transparent;
        }
    }
}
