using System;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace lab1
{
    class Human
    {
        public Human()
        {
            _startYear = 0;
            _name = "пусто";
            _surename = "пусто";
            _day = 0;
            _month = 0;
            _year = 1980;
        }
        public Human(Human human)
        {
            _startYear = human._startYear;
            _name = human._name;
            _surename = human._surename;
            _day = human._day;
            _month = human._month;
            _year = human._year;
        }
        ~Human()
        {
        }

        private string _name;
        private string _surename;
        private int _day;
        private int _month;
        private int _year;
        private int _startYear;

        public string GetName()
        {
            return _name;
        }
        public int GetDay()
        {
            return _day;
        }
        public int GetMonth()
        {
            return _month;
        }
        public int GetYear()
        {
            return _year;
        }
        public int GetStartYear()
        {
            return _startYear;
        }
        public string GetSurename()
        {
            return _surename;
        }

        public void AddHumanName()
        {
            Console.Write("Введите имя сотрудника: ");
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
                        break;
                    }
                }
                if (flag)
                {
                    _name = str;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
        }
        public void AddHumanSurename()
        {
            Console.Write("Введите фамилию сотрудника: ");
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
                        break;
                    }
                }
                if (flag)
                {
                    _surename = str;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
        }

        public void AddHumanBirthday()
        {
            Console.WriteLine("Ввод Данных дня рождения сотрудника");
            Console.Write("Введите день(1 - 31): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int day) && day <= 31 && day > 0)
                {
                    _day = day;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            Console.Write("Введите месяц(1 - 12): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int month) && month <= 12 && month > 0)
                {
                    _month = month;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            Console.Write("Введите год(1960 - 2005): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int year) && year <= 2005 && year >= 1960)
                {
                    _year = year;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
        }

        public void AddHumanStartYear()
        {
            Console.Write("Введите год начала работы(2000 - 2023): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int year) && year <= 2023 && year >= 2000 && (year - 18) >= _year)
                {
                    _startYear = year;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
        }

        public void NewEployment()
        {
            AddHumanName();
            AddHumanSurename();
            AddHumanBirthday();
            AddHumanStartYear();
        }

        public void Show()
        {
            Console.Write("Имя и Фамилия - " + _name + " " + _surename + "\n");
            Console.Write("День рождения - " + _day + "." + _month + "." + _year + "\n");
            Console.Write("Год начала работы - " + _startYear + "\n\n");
        }

    }

}
