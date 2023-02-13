namespace lab_3
{
    struct WORKER
    {
        public string NAME;
        public string POS;
        public int YEAR;

        public WORKER()
        {
            NAME = "";
            POS = "";
            YEAR = 0;
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
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}