using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Media;

namespace kki
{
    public partial class Form1 : Form
    {
        Table[] Line = new Table[5];
        Table[] EnemyLine = new Table[5];
        Deck[] HandCard = new Deck[8];
        Deck[] EnemyHandCard = new Deck[8];
        Deck[] Card = new Deck[39];
        Deck[] EnemyCard = new Deck[21];

        public Form1(int num)
        {
            DoubleBuffered = true;
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("..\\kki\\Cards\\kki2.png");
            //CardFromSave();
            initializ();
            string[] str = File.ReadAllLines("..\\kki\\Cards\\CountCard.txt");
            CountCard = Convert.ToInt32(str[0]);
            PlHand();

            start();//niggers

            EnemySkin();

            EnemyHand();

            EnemyTurn();
            mana = manatem;
            WMP.URL = @".\songs\PlayCard.mp3";
            WMP2.URL = @".\songs\TakeCard.mp3";
        }
        WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer WMP2 = new WMPLib.WindowsMediaPlayer();

        bool cardclick = false;
        int num = -1, mana = 1, manatem = 1, HeroPlayerHP = 30, HeroEnemyHp = 30, NumCard = 4,EnemyNumCard = 4, AmountEnemyCard = 4, EndGame = 0;
        int CountCard = 28;
        int[] deck = new int[39];
        int[] Enemydeck = new int[21];
        private void card_Click(object sender, EventArgs e)
        {

            cardclick = true;                                  // карта выбрана
            TempCard.BackgroundImage = card1.BackgroundImage;  // запоминание изображения в левую карту
            TempCard.Visible = true;                           // отобразить выбранную карту
            card1.Visible = false;                             // убрать карту из руки
            if (num != 0) PlayCard(num);                                     // отобразить все карты в руке и обновить ману
            num = 0;                                           // запомнить номер взятой карты
            MANAupdate();                                      // обновить ману
        }

        private void card2_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card2.BackgroundImage;
            TempCard.Visible = true;
            card2.Visible = false;
            if (num != 1) PlayCard(num);
            num = 1;
            MANAupdate();
        }

        private void card3_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card3.BackgroundImage;
            TempCard.Visible = true;
            card3.Visible = false;
            if (num != 2) PlayCard(num);
            num = 2;
            MANAupdate();
        }

        private void card4_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card4.BackgroundImage;
            TempCard.Visible = true;
            card4.Visible = false;
            if (num != 3) PlayCard(num);
            num = 3;
            MANAupdate();
        }

        private void card5_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card5.BackgroundImage;
            TempCard.Visible = true;
            card5.Visible = false;
            if (num != 4) PlayCard(num);
            num = 4;
            MANAupdate();
        }

        private void card6_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card6.BackgroundImage;
            TempCard.Visible = true;
            card6.Visible = false;
            if (num != 5) PlayCard(num);
            num = 5;
            MANAupdate();
        }

        private void card7_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card7.BackgroundImage;
            TempCard.Visible = true;
            card7.Visible = false;
            if (num != 6) PlayCard(num);
            num = 6;
            MANAupdate();
        }
        private void card8_Click(object sender, EventArgs e)
        {
            cardclick = true;
            TempCard.BackgroundImage = card8.BackgroundImage;
            TempCard.Visible = true;
            card8.Visible = false;
            if (num != 7) PlayCard(num);
            num = 7;
            MANAupdate();
        }
        private void line1_Click(object sender, EventArgs e)
        {
            if (cardclick)
            {
                if (Line[0].busy)
                {
                    if (mana >= HandCard[num].MANA)
                    {
                        WMP.controls.play();
                        HandCard[num].Using = false;                       // пропажа карты в руке
                        line1.Cursor = DefaultCursor;                      // курсор
                        line1.BackgroundImage = TempCard.BackgroundImage;  // картинка
                        TempCard.Visible = false;                          // исчезает карата из выбора
                        Line[0].busy = false;                              // линия занята
                        cardclick = false;                                 // карата больше не выбрана 
                        Line[0].LineDmg = HandCard[num].DMG;               // вписать урон на стол
                        Line[0].LineHp = HandCard[num].HP;                 // вписать хп на стол
                        LineDmg1.Text = Line[0].LineDmg.ToString();        // отобразить урон
                        LineHp1.Text = Line[0].LineHp.ToString();          // отобразить хп
                        LineDmg1.Visible = true;                           // делает ячеку видимой 
                        LineHp1.Visible = true;
                        mana -= HandCard[num].MANA;                        // отнимает потраченную ману
                        MANAupdate();                                      // отображает ману
                    }
                    else
                    {
                        Mana.Text = "No";                                  // если маны не хватает
                        Mana.Location = new Point(109, 344);
                    }                             
                }
            }
        }
        private void line2_Click(object sender, EventArgs e)
        {
            if (cardclick)
            {
                if (Line[1].busy)
                {
                    if (mana >= HandCard[num].MANA)
                    {
                        WMP.controls.play();
                        HandCard[num].Using = false;
                        line2.Cursor = DefaultCursor;
                        line2.BackgroundImage = TempCard.BackgroundImage;
                        TempCard.Visible = false;
                        Line[1].busy = false;
                        cardclick = false;
                        Line[1].LineDmg = HandCard[num].DMG;
                        Line[1].LineHp = HandCard[num].HP;
                        LineDmg2.Text = Line[1].LineDmg.ToString();
                        LineHp2.Text = Line[1].LineHp.ToString();
                        LineDmg2.Visible = true;
                        LineHp2.Visible = true;
                        mana -= HandCard[num].MANA;
                        MANAupdate();
                    }
                    else
                    {
                        Mana.Text = "No";
                        Mana.Location = new Point(109, 344);
                    }
                }
            }
        }

        private void line3_Click(object sender, EventArgs e)
        {
            if (cardclick)
            {
                if (Line[2].busy)
                {
                    if (mana >= HandCard[num].MANA)
                    {
                        WMP.controls.play();
                        HandCard[num].Using = false;
                        line3.Cursor = DefaultCursor;
                        line3.BackgroundImage = TempCard.BackgroundImage;
                        TempCard.Visible = false;
                        Line[2].busy = false;
                        cardclick = false;
                        Line[2].LineDmg = HandCard[num].DMG;
                        Line[2].LineHp = HandCard[num].HP;
                        LineDmg3.Text = Line[2].LineDmg.ToString();
                        LineHp3.Text = Line[2].LineHp.ToString();
                        LineDmg3.Visible = true;
                        LineHp3.Visible = true;
                        mana -= HandCard[num].MANA;
                        MANAupdate();
                    }
                    else
                    {
                        Mana.Text = "No";
                        Mana.Location = new Point(109, 344);
                    }
                }
            }
        }

        private void line4_Click(object sender, EventArgs e)
        {
            if (cardclick)
            {
                if (Line[3].busy)
                {
                    if (mana >= HandCard[num].MANA)
                    {
                        WMP.controls.play();
                        HandCard[num].Using = false;
                        line4.Cursor = DefaultCursor;
                        line4.BackgroundImage = TempCard.BackgroundImage;
                        TempCard.Visible = false;
                        Line[3].busy = false;
                        cardclick = false;
                        Line[3].LineDmg = HandCard[num].DMG;
                        Line[3].LineHp = HandCard[num].HP;
                        LineDmg4.Text = Line[3].LineDmg.ToString();
                        LineHp4.Text = Line[3].LineHp.ToString();
                        LineDmg4.Visible = true;
                        LineHp4.Visible = true;
                        mana -= HandCard[num].MANA;
                        MANAupdate();
                    }
                    else
                    {
                        Mana.Text = "No";
                        Mana.Location = new Point(109, 344);
                    }
                }
            }
        }

        private void line5_Click(object sender, EventArgs e)
        {
            if (cardclick)
            {
                if (Line[4].busy)
                {   if (mana >= HandCard[num].MANA)
                    {
                        WMP.controls.play();
                        HandCard[num].Using = false;
                        line5.Cursor = DefaultCursor;
                        line5.BackgroundImage = TempCard.BackgroundImage;
                        TempCard.Visible = false;
                        Line[4].busy = false;
                        cardclick = false;
                        Line[4].LineDmg = HandCard[num].DMG;
                        Line[4].LineHp = HandCard[num].HP;
                        LineDmg5.Text = Line[4].LineDmg.ToString();
                        LineHp5.Text = Line[4].LineHp.ToString();
                        LineDmg5.Visible = true;
                        LineHp5.Visible = true;
                        mana -= HandCard[num].MANA;
                        MANAupdate();
                    }
                    else { 
                        Mana.Text = "No";
                        Mana.Location = new Point(109, 344);
                    }
                }
            }
        }

        private void Tempbox_Click(object sender, EventArgs e)   //возвращает все карты в руку
        {
            cardclick = false;
            card1.Visible = HandCard[0].Using;
            card2.Visible = HandCard[1].Using;
            card3.Visible = HandCard[2].Using;
            card4.Visible = HandCard[3].Using;
            card5.Visible = HandCard[4].Using;
            card6.Visible = HandCard[5].Using;
            card7.Visible = HandCard[6].Using;
            card8.Visible = HandCard[7].Using;
            TempCard.Visible = false;
        }
        void PlayCard(int numr)
        {
            if (numr == 0) card1.Visible = HandCard[0].Using;
            if (numr == 1) card2.Visible = HandCard[1].Using;
            if (numr == 2) card3.Visible = HandCard[2].Using;
            if (numr == 3) card4.Visible = HandCard[3].Using;
            if (numr == 4) card5.Visible = HandCard[4].Using;
            if (numr == 5) card6.Visible = HandCard[5].Using;
            if (numr == 6) card7.Visible = HandCard[6].Using;
            if (numr == 7) card8.Visible = HandCard[7].Using;
            MANAupdate();
        }

        void PlHand()                         // заполняет колоду картами в "случайном" порядке
        {
            Random rnd = new Random();
            int check = 0;
            bool flag = true;
            for (int i = 0; i < CountCard + 1; i++) //29
            {
                check = rnd.Next(1, CountCard); //28
                for (int j = 0; j != CountCard; j++)
                {
                    if (deck[j] == check && flag)
                    {
                        check = 1;
                        j = 0;
                        flag = false;
                    }
                    if (deck[j] == check && !flag)
                    {
                        check++;
                        j = -1;
                    }
                }
                flag = true;
                deck[i] = check;
            }
            for (int i = 0; i < 4; i++)
            {
                HandCard[i] = Card[deck[i]];
            }
        }
        void EnemyHand()                      // заполняет колоду противник "случайными" картами
        {
            Random rnd = new Random();
            
            int check = 0;
            bool flag = true;
            for (int i = 0; i < 21; i++) 
            {
                check = rnd.Next(1, 20);
                for (int j = 0; j != 20; j++)
                {
                    if (Enemydeck[j] == check && flag)
                    {
                        check = 1;
                        j = 0;
                        flag = false;
                    }
                    if (Enemydeck[j] == check && !flag)
                    {
                        check++;
                        j = -1;
                    }
                }
                flag = true;
                Enemydeck[i] = check;
            }
            for (int i = 0; i < 4; i++) 
            {
                EnemyHandCard[i] = EnemyCard[Enemydeck[i]];
            }
        } 
        void GiveCard()                       // алгоритм даёт каждый ход одну карту в руку
        {
            int mem = 0;
            for (int i = 0; i < 8; i++)
            {
                if (HandCard[mem].Using == false)
                {
                    break;
                }
                mem++;
            }
            if (mem < 8)
            {
                HandCard[mem] = Card[deck[NumCard]];
                fixPic(mem);
                NumCard++;
            }
            WMP2.controls.play();
            mem = 0;
        }
        void GiveCardEnemy()                  // карат противнику
        {
            int mem = 0;
            for (int i = 0; i < 8; i++)
            {
                if (EnemyHandCard[mem].MANA == 99 || EnemyHandCard[mem].MANA == 0)
                {
                    break;
                }
                mem++;
            }
            if (mem < 8)
            {
                EnemyHandCard[mem] = EnemyCard[Enemydeck[EnemyNumCard]];
                EnemyNumCard++;
            }
            mem = 0;
        }
        void fixPic(int num)                  // отображение картинки выданной карты
        {
            switch (num)
            {
                case 0:
                    card1.BackgroundImage = HandCard[num].PicterCard;
                    card1.Visible = true;
                    break;
                case 1:
                    card2.BackgroundImage = HandCard[num].PicterCard;
                    card2.Visible = true;
                    break;
                case 2:
                    card3.BackgroundImage = HandCard[num].PicterCard;
                    card3.Visible = true;
                    break;
                case 3:
                    card4.BackgroundImage = HandCard[num].PicterCard;
                    card4.Visible = true;
                    break;
                case 4:
                    card5.BackgroundImage = HandCard[num].PicterCard;
                    card5.Visible = true;
                    break;
                case 5:
                    card6.BackgroundImage = HandCard[num].PicterCard;
                    card6.Visible = true;
                    break;
                case 6:
                    card7.BackgroundImage = HandCard[num].PicterCard;
                    card7.Visible = true;
                    break;
                case 7:
                    card8.BackgroundImage = HandCard[num].PicterCard;
                    card8.Visible = true;
                    break;
                default:
                    break;
            }
        } 
        void start()                          // подготовка к игре
        {
            card1.BackgroundImage = HandCard[0].PicterCard;
            card2.BackgroundImage = HandCard[1].PicterCard;
            card3.BackgroundImage = HandCard[2].PicterCard;
            card4.BackgroundImage = HandCard[3].PicterCard;
            card5.BackgroundImage = HandCard[4].PicterCard;
            card6.BackgroundImage = HandCard[5].PicterCard;
            card7.BackgroundImage = HandCard[6].PicterCard;
            card8.BackgroundImage = HandCard[7].PicterCard;
            Mana.Text = mana.ToString();
            Playerhp.Text = HeroPlayerHP.ToString();
            EnemyHp.Text = HeroEnemyHp.ToString();
        }
        void initializ()                      // инициализация карт
        {
            Line[0].busy = true;
            Line[1].busy = true;
            Line[2].busy = true;
            Line[3].busy = true;
            Line[4].busy = true;
            EnemyLine[0].busy = true;
            EnemyLine[1].busy = true;
            EnemyLine[2].busy = true;
            EnemyLine[3].busy = true;
            EnemyLine[4].busy = true;

            Card[0].Using = true;
            Card[0].PicterCard = Image.FromFile("../kki/Cards/test.jpg");

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
            Card[8].HP = 4;                                                      //додумать
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
            ////////////////////
            EnemyCard[1].Using = true;
            EnemyCard[1].PicterCard = Image.FromFile("../kki/Cards/вороны.jpg");
            EnemyCard[1].HP = 2;
            EnemyCard[1].DMG = 2;
            EnemyCard[1].MANA = 1;
            EnemyCard[2] = EnemyCard[1];

            EnemyCard[3].Using = true;
            EnemyCard[3].PicterCard = Image.FromFile("../kki/Cards/зомбэ.jpg");
            EnemyCard[3].HP = 4;
            EnemyCard[3].DMG = 4;
            EnemyCard[3].MANA = 3;
            EnemyCard[4] = EnemyCard[3];

            EnemyCard[5].Using = true;
            EnemyCard[5].PicterCard = Image.FromFile("../kki/Cards/зомби.jpg");
            EnemyCard[5].HP = 3;
            EnemyCard[5].DMG = 3;
            EnemyCard[5].MANA = 2;
            EnemyCard[6] = EnemyCard[5];

            EnemyCard[7].Using = true;
            EnemyCard[7].PicterCard = Image.FromFile("../kki/Cards/огр.jpg");
            EnemyCard[7].HP = 8;
            EnemyCard[7].DMG = 6;
            EnemyCard[7].MANA = 5;
            EnemyCard[8] = EnemyCard[7];

            EnemyCard[9].Using = true;
            EnemyCard[9].PicterCard = Image.FromFile("../kki/Cards/огр2.jpg");
            EnemyCard[9].HP = 8;
            EnemyCard[9].DMG = 7;
            EnemyCard[9].MANA = 8;
            EnemyCard[10] = EnemyCard[9];

            EnemyCard[11].Using = true;
            EnemyCard[11].PicterCard = Image.FromFile("../kki/Cards/демон.jpg");
            EnemyCard[11].HP = 9;
            EnemyCard[11].DMG = 9;
            EnemyCard[11].MANA = 8;
            EnemyCard[12] = EnemyCard[11];

            EnemyCard[13].Using = true;
            EnemyCard[13].PicterCard = Image.FromFile("../kki/Cards/бес.jpg");
            EnemyCard[13].HP = 2;
            EnemyCard[13].DMG = 4;
            EnemyCard[13].MANA = 2;
            EnemyCard[14] = EnemyCard[13];

            EnemyCard[15].Using = true;
            EnemyCard[15].PicterCard = Image.FromFile("../kki/Cards/бес2.jpg");
            EnemyCard[15].HP = 6;
            EnemyCard[15].DMG = 4;
            EnemyCard[15].MANA = 4;
            EnemyCard[16] = EnemyCard[15];

            EnemyCard[17].Using = true;
            EnemyCard[17].PicterCard = Image.FromFile("../kki/Cards/орк.jpg");
            EnemyCard[17].HP = 5;
            EnemyCard[17].DMG = 5;
            EnemyCard[17].MANA = 4;
            EnemyCard[18] = EnemyCard[17];

            EnemyCard[19].Using = true;
            EnemyCard[19].PicterCard = Image.FromFile("../kki/Cards/орк2.jpg");
            EnemyCard[19].HP = 6;
            EnemyCard[19].DMG = 7;
            EnemyCard[19].MANA = 6;
            EnemyCard[20] = EnemyCard[19];

        }

        private void card1_MouseEnter(object sender, EventArgs e) //отображение карт при наводке
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[0].DMG.ToString();
                TempMana.Text = HandCard[0].MANA.ToString();
                TempHp.Text = HandCard[0].HP.ToString();
                TempCard.BackgroundImage = HandCard[0].PicterCard;
                ShowAll();
            }
        }

        private void card2_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[1].DMG.ToString();
                TempMana.Text = HandCard[1].MANA.ToString();
                TempHp.Text = HandCard[1].HP.ToString();
                TempCard.BackgroundImage = HandCard[1].PicterCard;
                ShowAll();
            }
        }


        private void card3_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[2].DMG.ToString();
                TempMana.Text = HandCard[2].MANA.ToString();
                TempHp.Text = HandCard[2].HP.ToString();
                TempCard.BackgroundImage = HandCard[2].PicterCard;
                ShowAll();
            }
        }

        private void card4_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[3].DMG.ToString();
                TempMana.Text = HandCard[3].MANA.ToString();
                TempHp.Text = HandCard[3].HP.ToString();
                TempCard.BackgroundImage = HandCard[3].PicterCard;
                ShowAll();
            }
        }

        private void card5_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[4].DMG.ToString();
                TempMana.Text = HandCard[4].MANA.ToString();
                TempHp.Text = HandCard[4].HP.ToString();
                TempCard.BackgroundImage = HandCard[4].PicterCard;
                ShowAll();
            }
        }

        private void card6_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[5].DMG.ToString();
                TempMana.Text = HandCard[5].MANA.ToString();
                TempHp.Text = HandCard[5].HP.ToString();
                TempCard.BackgroundImage = HandCard[5].PicterCard;
                ShowAll();
            }
        }


        private void card7_MouseEnter(object sender, EventArgs e)
        {
            if (!cardclick)
            {
                TempDmg.Text = HandCard[6].DMG.ToString();
                TempMana.Text = HandCard[6].MANA.ToString();
                TempHp.Text = HandCard[6].HP.ToString();
                TempCard.BackgroundImage = HandCard[6].PicterCard;
                ShowAll();
            }
        }

        private void card8_MouseEnter(object sender, EventArgs e)
        {
            TempDmg.Text = HandCard[7].DMG.ToString();
            TempMana.Text = HandCard[7].MANA.ToString();
            TempHp.Text = HandCard[7].HP.ToString();
            TempCard.BackgroundImage = HandCard[7].PicterCard;
            ShowAll();
        }

        private void pictureBox6_Click(object sender, EventArgs e)  // кнопка следующего раунда
        {
            mana = manatem++;
            Fight();
            if (NumCard < 28) GiveCard();
            if (NumCard < 20) GiveCardEnemy();
            EnemyTurn();
            ShowEnemyCard(AmountEnemyCard);
            AmountEnemyCard++;
            mana = manatem;
            MANAupdate();
        }
        void Fight()                                                // битва на линиях
        {
            for (int i = 0; i < 5; i++)
            {
                if (!Line[i].busy)
                {
                    if (!EnemyLine[i].busy){
                        EnemyLine[i].LineHp -= Line[i].LineDmg;
                        Line[i].LineHp -= EnemyLine[i].LineDmg;
                        updat(i); 
                    }
                    else
                    {
                        HeroEnemyHp -= Line[i].LineDmg;
                        if (HeroEnemyHp <= 0)
                        {
                            EnemyHp.Location = new Point(1623, 115);
                            EnemyHp.Text = "Dead";
                            EndGame = 1;
                            PauseMenu pause = new PauseMenu(this, EndGame);
                            pause.ShowDialog();
                            AddCard();
                            break;
                        }
                        else
                        {
                            if (HeroEnemyHp >= 10)
                            {
                                EnemyHp.Location = new Point (1685, 118);
                                EnemyHp.Text = HeroEnemyHp.ToString();
                            }
                            else if (HeroEnemyHp < 10)
                            {
                                EnemyHp.Location = new Point(1701, 115);
                                EnemyHp.Text = HeroEnemyHp.ToString();
                            }
                        }
                    }
                }
                else if (!EnemyLine[i].busy)
                {
                    HeroPlayerHP -= EnemyLine[i].LineDmg;
                    if (HeroPlayerHP <= 0)
                    {
                        Playerhp.Location = new Point(1623, 858);
                        Playerhp.Text = "Dead";
                        EndGame = 2;
                        PauseMenu pause = new PauseMenu(this, EndGame);
                        pause.ShowDialog();
                        break;
                    }
                    else
                    { if (HeroPlayerHP >= 10)
                        {
                            Playerhp.Location = new Point(1685, 859);
                            Playerhp.Text = HeroPlayerHP.ToString();
                        }
                        else if (HeroEnemyHp < 10)
                        {
                            Playerhp.Location = new Point(1698, 858);
                            Playerhp.Text = HeroPlayerHP.ToString();
                        }
                    }
                }
            }
        }

        void MANAupdate()
        {
            if (mana < 10)
            {
                Mana.Location = new Point(137, 343);
                Mana.Text = mana.ToString();
            }
            if (mana >= 10)
            {
                Mana.Location = new Point(123, 343);
                Mana.Text = mana.ToString();
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            PauseMenu pause = new PauseMenu(this, EndGame);
            pause.ShowDialog();
        }

        private void Pause_MouseEnter(object sender, EventArgs e)
        {
            Pause.BackColor = Color.Gray;
        }

        private void Pause_MouseLeave(object sender, EventArgs e)
        {
            Pause.BackColor = Color.Transparent;
        }

        void updat(int num)                                         // обновление значений если какая-то карта повержена
        {
            switch (num)
            {
                case 0:
                    if (EnemyLine[num].LineHp <= 0)
                    {
                        EnemyLine[num].busy = true;
                        EnemyLine[num].LineDmg = 0;
                        ENLineHp1.Visible = false;
                        ENLineDmg1.Visible = false;
                        ENLine1.BackgroundImage = null;
                    }
                    if (Line[num].LineHp <= 0)
                    {
                        Line[num].busy = true;
                        Line[num].LineDmg = 0;
                        LineHp1.Visible = false;
                        LineDmg1.Visible = false;
                        line1.BackgroundImage = null;
                    }
                    LineHp1.Text = Line[num].LineHp.ToString();
                    ENLineHp1.Text = EnemyLine[num].LineHp.ToString();
                    break;
                case 1:
                    if (EnemyLine[num].LineHp <= 0)
                    {
                        EnemyLine[num].busy = true;
                        EnemyLine[num].LineDmg = 0;
                        ENLineHp2.Visible = false;
                        ENLineDmg2.Visible = false;
                        ENLine2.BackgroundImage = null;
                    }
                    if (Line[num].LineHp <= 0)
                    {
                        Line[num].busy = true;
                        Line[num].LineDmg = 0;
                        LineHp2.Visible = false;
                        LineDmg2.Visible = false;
                        line2.BackgroundImage = null;
                    }
                    LineHp2.Text = Line[num].LineHp.ToString();
                    ENLineHp2.Text = EnemyLine[num].LineHp.ToString();
                    break;
                case 2:
                    if (EnemyLine[num].LineHp <= 0)
                    {
                        EnemyLine[num].busy = true;
                        EnemyLine[num].LineDmg = 0;
                        ENLineHp3.Visible = false;
                        ENLineDmg3.Visible = false;
                        ENLine3.BackgroundImage = null;
                    }
                    if (Line[num].LineHp <= 0)
                    {
                        Line[num].busy = true;
                        Line[num].LineDmg = 0;
                        LineHp3.Visible = false;
                        LineDmg3.Visible = false;
                        line3.BackgroundImage = null;
                    }
                    LineHp3.Text = Line[num].LineHp.ToString();
                    ENLineHp3.Text = EnemyLine[num].LineHp.ToString();
                    break;
                case 3:
                    if (EnemyLine[num].LineHp <= 0)
                    {
                        EnemyLine[num].busy = true;
                        EnemyLine[num].LineDmg = 0;
                        ENLineHp4.Visible = false;
                        ENLineDmg4.Visible = false;
                        ENLine4.BackgroundImage = null;
                    }
                    if (Line[num].LineHp <= 0)
                    {
                        Line[num].busy = true;
                        Line[num].LineDmg = 0;
                        LineHp4.Visible = false;
                        LineDmg4.Visible = false;
                        line4.BackgroundImage = null;
                    }
                    LineHp4.Text = Line[num].LineHp.ToString();
                    ENLineHp4.Text = EnemyLine[num].LineHp.ToString();
                    break;
                case 4:
                    if (EnemyLine[num].LineHp <= 0)
                    {
                        EnemyLine[num].busy = true;
                        EnemyLine[num].LineDmg = 0;
                        ENLineHp5.Visible = false;
                        ENLineDmg5.Visible = false;
                        ENLine5.BackgroundImage = null;
                    }
                    if (Line[num].LineHp <= 0)
                    {
                        Line[num].busy = true;
                        Line[num].LineDmg = 0;
                        LineHp5.Visible = false;
                        LineDmg5.Visible = false;
                        line5.BackgroundImage = null;
                    }
                    LineHp5.Text = Line[num].LineHp.ToString();
                    ENLineHp5.Text = EnemyLine[num].LineHp.ToString();
                    break;
                default:
                    break;
            }
        }


        void EnemyTurn(){                                           // интеллект противника
            int mem = 0, temp = -1, EnemyMem = 0;
            int[] HaveUnit = new int[5];
            int[] EnemyNoHaveUnits = new int[5];
            for (int i = 0, j = 0, k = 0; i < 5; i++)
            {
                if (!Line[i].busy && EnemyLine[i].busy)
                {
                    mem++;
                    HaveUnit[j] = i;               //подсчёт уязвимых мест
                    j++;
                }
                else if(EnemyLine[i].busy)
                {
                    EnemyMem++;
                    EnemyNoHaveUnits[k] = i;      //подсчёт свободных мест у противника 
                    k++;
                }

            }
            if (EnemyMem == 0) { }
            else
            {
                if (mem == 0)
                {
                    temp = FoundPower();           // если у игрока нет карт, противник ищет самую сильную карту и играет её
                    if (temp == -1) { }
                    else
                    {
                        if (EnemyMem > 0)
                        {
                            EnemyLine[EnemyNoHaveUnits[0]].LineDmg = EnemyHandCard[temp].DMG;
                            EnemyLine[EnemyNoHaveUnits[0]].LineHp = EnemyHandCard[temp].HP;
                            EnemyLine[EnemyNoHaveUnits[0]].busy = false;
                            mana -= EnemyHandCard[temp].MANA;
                            FindPlace(EnemyNoHaveUnits[0], temp);
                            AmountEnemyCard--;
                            EnemyMem--;
                        }
                    }

                }
                else if (mem == 1)                     //если у игрока одна карта, противник ищет самую слабую
                {                                      //карту и играет её перед, картой игрока, если мана позволяет
                    if (EnemyMem > 0)                  //ищет самую сильную карту на доступную ману
                    {
                        temp = FoundWeakness();
                        if (temp == -1) { }
                        else
                        {
                            EnemyLine[HaveUnit[0]].LineDmg = EnemyHandCard[temp].DMG;
                            EnemyLine[HaveUnit[0]].LineHp = EnemyHandCard[temp].HP;
                            EnemyLine[HaveUnit[0]].busy = false;
                            mana -= EnemyHandCard[temp].MANA;
                            FindPlace(HaveUnit[0], temp);
                            AmountEnemyCard--;
                            EnemyMem--;


                            if (EnemyMem > 0)
                            {
                                temp = FoundPower();
                                if (temp == -1) { }
                                else
                                {
                                    EnemyLine[EnemyNoHaveUnits[0]].LineDmg = EnemyHandCard[temp].DMG;
                                    EnemyLine[EnemyNoHaveUnits[0]].LineHp = EnemyHandCard[temp].HP;
                                    EnemyLine[EnemyNoHaveUnits[0]].busy = false;
                                    mana -= EnemyHandCard[temp].MANA;
                                    FindPlace(EnemyNoHaveUnits[0], temp);
                                    AmountEnemyCard--;
                                    EnemyMem--;
                                }
                            }
                        }
                    }

                }
                else if (mem >= 2)
                {
                    for (int i = 0; i < mem; i++)
                    {
                        if (EnemyMem > 0)
                        {
                            temp = FoundWeakness();
                            if (temp == -1) { }
                            else
                            {
                                EnemyLine[HaveUnit[i]].LineDmg = EnemyHandCard[temp].DMG;
                                EnemyLine[HaveUnit[i]].LineHp = EnemyHandCard[temp].HP;
                                EnemyLine[HaveUnit[i]].busy = false;
                                mana -= EnemyHandCard[temp].MANA;
                                FindPlace(HaveUnit[i], temp);
                                AmountEnemyCard--;
                                EnemyMem--;
                            }
                        }
                    }
                    if (EnemyMem > 0)
                    {
                        temp = FoundPower();
                        if (temp == -1) { }
                        else
                        {
                            EnemyLine[EnemyNoHaveUnits[0]].LineDmg = EnemyHandCard[temp].DMG;
                            EnemyLine[EnemyNoHaveUnits[0]].LineHp = EnemyHandCard[temp].HP;
                            EnemyLine[EnemyNoHaveUnits[0]].busy = false;
                            mana -= EnemyHandCard[temp].MANA;
                            AmountEnemyCard--;
                            FindPlace(EnemyNoHaveUnits[0], temp);
                        }
                    }
                }
            }
        }
        void ShowEnemyCard(int num)
        {
            switch (num)
            {
                case 0:
                    Enemycard1.Visible = true;
                    break;
                case 1:
                    Enemycard2.Visible = true;
                    break;
                case 2:
                    Enemycard3.Visible = true;
                    break;
                case 3:
                    Enemycard4.Visible = true;
                    break;
                case 4:
                    Enemycard5.Visible = true;
                    break;
                case 5:
                    Enemycard6.Visible = true;
                    break;
                case 6:
                    Enemycard7.Visible = true;
                    break;
                case 7:
                    Enemycard8.Visible = true;
                    break;
                default:
                    break;
            }
        }
        int FoundPower()                           // поиск самой сильной карты
        {
            int powerful = -1, memory = -1;
            for (int i = 0; i < 8; i++)
            {
                if (EnemyHandCard[i].MANA <= mana)
                {
                    if (EnemyHandCard[i].DMG > powerful && EnemyHandCard[i].DMG > 0)
                    {
                        powerful = EnemyHandCard[i].DMG;
                        memory = i;
                    }
                }
            }
             return memory;

        }
        int FoundWeakness()                        // поиск самой слабой 
        {
            int powerful = 99, memory = -1;
            for (int i = 0; i < 8; i++)
            {
                if (EnemyHandCard[i].MANA <= mana)
                {
                    if (EnemyHandCard[i].DMG < powerful && EnemyHandCard[i].DMG > 0)
                    {
                        powerful = EnemyHandCard[i].DMG;
                        memory = i;
                    }
                }
            }
         return memory;
        }
        void FindPlace(int num, int temp)          // отображение карты которую выбрал протвник 
        {
            switch(num)
            {
                case 0:
                    ENLine1.BackgroundImage = EnemyHandCard[temp].PicterCard;
                    ENLineDmg1.Text = EnemyLine[num].LineDmg.ToString();
                    ENLineDmg1.Visible = true;
                    ENLineHp1.Text = EnemyLine[num].LineHp.ToString();
                    ENLineHp1.Visible = true;
                    EnemyHandCard[temp].MANA = 99; // ломаем карту
                    break;
                case 1:
                    ENLine2.BackgroundImage = EnemyHandCard[temp].PicterCard;
                    ENLineDmg2.Text = EnemyLine[num].LineDmg.ToString();
                    ENLineDmg2.Visible = true;
                    ENLineHp2.Text = EnemyLine[num].LineHp.ToString();
                    ENLineHp2.Visible = true;
                    EnemyHandCard[temp].MANA = 99;
                    break;
                case 2:
                    ENLine3.BackgroundImage = EnemyHandCard[temp].PicterCard;
                    ENLineDmg3.Text = EnemyLine[num].LineDmg.ToString();
                    ENLineDmg3.Visible = true;
                    ENLineHp3.Text = EnemyLine[num].LineHp.ToString();
                    ENLineHp3.Visible = true;
                    EnemyHandCard[temp].MANA = 99;
                    break;
                case 3:
                    ENLine4.BackgroundImage = EnemyHandCard[temp].PicterCard;
                    ENLineDmg4.Text = EnemyLine[num].LineDmg.ToString();
                    ENLineDmg4.Visible = true;
                    ENLineHp4.Text = EnemyLine[num].LineHp.ToString();
                    ENLineHp4.Visible = true;
                    EnemyHandCard[temp].MANA = 99;
                    break;
                case 4:
                    ENLine5.BackgroundImage = EnemyHandCard[temp].PicterCard;
                    ENLineDmg5.Text = EnemyLine[num].LineDmg.ToString();
                    ENLineDmg5.Visible = true;
                    ENLineHp5.Text = EnemyLine[num].LineHp.ToString();
                    ENLineHp5.Visible = true;
                    EnemyHandCard[temp].MANA = 99;
                    break;
                default:
                    break;
            }
        }
        void AddCard()
        {
            if (CountCard < 39)
            {
                CountCard++;
                File.Delete("..\\kki\\Cards\\CountCard.txt");
                File.AppendAllText("..\\kki\\Cards\\CountCard.txt", CountCard.ToString());
            }
        }
        void ShowAll()                             // показывает все знчения карты
        {
            TempCard.Visible = true;
            TempDmg.Visible = true;
            TempHp.Visible = true;
            TempMana.Visible = true;
        }
        void EnemySkin()
        {
            string[] str = File.ReadAllLines("..\\kki\\Cards\\settings.txt");
            int Skin = Convert.ToInt32(str[0]);
            Image temp = Image.FromFile("..\\kki\\Cards\\shirt.png");
            if (Skin == 0)
            {
                temp = Image.FromFile("..\\kki\\Cards\\shirt.png");
            } else if (Skin == 1)
            {
                temp = Image.FromFile("..\\kki\\Cards\\31.png");
            }
            else if (Skin == 2)
            {
                temp = Image.FromFile("..\\kki\\Cards\\51.png");
            }
            Enemycard1.BackgroundImage = temp;
            Enemycard2.BackgroundImage = temp;
            Enemycard3.BackgroundImage = temp;
            Enemycard4.BackgroundImage = temp;
            Enemycard5.BackgroundImage = temp;
            Enemycard6.BackgroundImage = temp;
            Enemycard7.BackgroundImage = temp;
            Enemycard8.BackgroundImage = temp;
        }
       //void CardFromSave()
       // {
       //     string[] str = File.ReadAllLines("..\\kki\\Cards\\PlayerCollection.txt");
       //     for (int i = 0; i < CountCard; i++)
       //     {
       //        // int frgfghgh = Convert.ToInt32(str[0]);
       //     }
       // }

    }
}