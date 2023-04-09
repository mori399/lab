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
        public Workers()
        {
            //_human = null;
            _profession = "non";
            Console.WriteLine("Вызван конструкотр без параметров");
        }
        public Workers(Human hum,string profes) 
        {
            //_human = hum;
            _profession = profes;
            Console.WriteLine("Вызван конструкотр с параметрами");
        }
        public Workers(Workers workers)
        {
           // _human = workers._human;
            _profession = workers._profession;
            Console.WriteLine("Вызван конструкотр копирования");
        }

        List <Workers> workers = new List <Workers> ();
        private string _profession;
       // private Human _human;
        public string GetProfession()
        {
            return _profession;
        }

        public static string AddWorkersProfes()
        {
            Console.Write("Введите профессию сотрудника: ");
            bool flag = true;
            while (true)
            {
                string str = Console.ReadLine();
                flag = true;
                foreach (char c in str)
                {
                    if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
                    {
                        flag = false;
                        Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        break;
                    }
                }
                if (flag)
                {
                    return str;
                    break;
                }
            }
        }
        public void AddWorkers(Human hum)
        {
            //_human = hum;
            AddWorkersProfes();
        } 

        public new void Show()
        {
            //_human.Show();
            Console.Write(
                 "Имя и Фамилия - " + GetName() + " " + GetSurename() + "\n" +
                 $"День рождения - {Getbirthday().ToString("D")}\n" +
                 "Год начала работы - " + GetStartYear() + "\n"+
                 "Профессия - " + _profession + "\n\n" );
        }
    }
}
