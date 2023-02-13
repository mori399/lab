using System.Media;

namespace kki
{
    struct Table
    {
        public bool busy;
        public bool PlayerHave;
        public int LineHp;
        public int LineDmg;
        public Table()
        {
            busy = true;
            PlayerHave = false;
            LineHp = 0;
            LineDmg = 0;
        }
    }
    struct Deck
    {
        public bool Using;
        public Image PicterCard;
        public int HP;
        public int DMG;
        public int MANA;
        public Deck()
        {
            Using = true;
            PicterCard = Image.FromFile("../kki/Cards/test.jpg");
            HP = 0;
            DMG = 0;
            MANA = 0;
        }
    }

    internal static class Program
    {
       
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            SoundPlayer sound_main = new SoundPlayer("..\\kki\\songs\\Backgroundmusic.wav");
            sound_main.PlayLooping();
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());

        }
        
    }
}