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
        public Workers(Human hum) 
        {
            _human = hum;
            AddWorkersProfes();
        }

        List <Workers> workers = new List <Workers> ();
        private string _profession;
        private Human _human;
        public string GetProfession()
        {
            return _profession;
        }

        public void AddWorkersProfes()
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
                    _profession = str;
                    break;
                }
            }
        }
        public void AddWorkers(Human hum)
        {
            workers.Add(new Workers(hum));
        } 
    }
}
