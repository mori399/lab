using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1
{
    internal class Workers : Human
    {
        private string _profession;

        public Workers()
        {
            _profession = "non";
            Console.WriteLine("Вызван конструкотр без параметров наследовательного класса Workers");
            
        }
        public Workers(int startYear, string name, DateTime birthday, string surename, string profes) : base (startYear, name, birthday, surename)
        {
            _profession = profes;
            Console.WriteLine("Вызван конструкотр с параметрами наследовательного класса Workers");
            Console.ReadKey();
        }
        public Workers(Workers workers): base(workers)
        {
            _profession = workers._profession;
            Console.WriteLine("Вызван конструкотр копирования наследовательного класса Workers");
        }
        ~Workers()
        {
            Console.WriteLine("Вызван деструктор наследовательного класса Workers");
            //Console.ReadKey();
        }

        public string GetProfession()
        {
            return _profession;
        }

        public static string AddWorkersProfes()
        {
            Console.Write("Введите профессию сотрудника: ");
            while (true)
            {
                string str = Console.ReadLine();
                if (CorrectImput.IsLatters(str))
                {
                    return str;
                }
            }
        }
        public override void Show()
        {
            Console.Write(
                 "Имя и Фамилия - " + GetName() + " " + GetSurename() + "\n" +
                 $"День рождения - {Getbirthday().ToString("D")}\n" +
                 "Год начала работы - " + GetStartYear() + "\n"+
                 "Профессия - " + _profession + "\n" );
        }
    }
}
