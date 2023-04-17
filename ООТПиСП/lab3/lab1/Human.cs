﻿using System.Linq.Expressions;
using System.Security.Cryptography;

namespace lab1
{
    class Human
    {
        protected string _name;
        protected string _surename;
        protected DateTime _birthday;
        protected int _startYear;
        public Human()
        {
            _startYear = 0;
            _name = "пусто";
            _surename = "пусто";
            _birthday = DateTime.Now;
            Console.WriteLine("Вызван конструкотр без параметров");
        }

        public Human(int startYear, string name, DateTime birthday, string surename)
        {
            _startYear = startYear;
            _name = name;
            _surename = surename;
            _birthday = birthday;
            Console.WriteLine("Вызван конструкотр с параметрами");
        }
        public Human(Human human)
        {
            _startYear = human._startYear;
            _name = human._name;
            _surename = human._surename;
            _birthday = human._birthday;
            Console.WriteLine("Вызван конструкотр копирования");
        }
        ~Human()
        {
            Console.WriteLine("Вызван деструктор");
           
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime Getbirthday()
        {
            return _birthday;
        }
        public int GetStartYear()
        {
            return _startYear;
        }
        public string GetSurename()
        {
            return _surename;
        }


        public void SetName(string name)
        {
            _name = name;
        }

        public void Setbirthday(DateTime birthday)
        {
             _birthday = birthday;
        }
        public void SetStartYear(int startyear)
        {
           _startYear = startyear;
        }
        public void SetSurename(string surename)
        {
            _surename = surename;
        }
        public void AddHumanName()
        {
            Console.Write("Введите имя сотрудника: ");
            while (true)
            {
                string str = Console.ReadLine();
                
                if (CorrectImput.IsLatters(str))
                {
                    SetName(str);
                    break;
                }
            }
        }
        public void AddHumanSurename()
        {
            Console.Write("Введите фамилию сотрудника: ");
            while (true)
            {
                string str = Console.ReadLine();
                if (CorrectImput.IsLatters(str))
                {
                    SetSurename(str);
                    break;
                }
            }
        }
        public void AddHumanBirthday()
        {
            int day, month, year,years;
            Console.WriteLine("Ввод Данных дня рождения сотрудника\nВведите день(1 - 31): ");

            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out day) && CorrectImput.InRange(1, 31, day);
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                break;
            }
            Console.Write("Введите месяц(1 - 12): ");
            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out month) && CorrectImput.InRange(1, 12, month);
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                break;
            }
            Console.Write($"Введите год({DateTime.Now.Year - 60} - {DateTime.Now.Year - 18}): ");
            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out year) && CorrectImput.InRange(DateTime.Now.Year - 60, DateTime.Now.Year - 18, year);
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                break;
            }
            Setbirthday(new DateTime(year, month, day));
        }
        public void AddHumanStartYear()
        {
            Console.Write($"Введите год начала работы(2000 - {DateTime.Now.Year}): ");
            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out int year) && CorrectImput.InRange(2000, DateTime.Now.Year, year) && (year - 18) >= _birthday.Year;
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }

                SetStartYear(year);
                break;
            }
        }

        public void NewEployment()
        {
            AddHumanName();
            AddHumanSurename();
            AddHumanBirthday();
            AddHumanStartYear();
        }

        public virtual void Show()
        {
            Console.Write(
                "Имя и Фамилия - " + _name + " " + _surename + "\n" +
                $"День рождения - {_birthday.ToString("D")}\n" +
                "Год начала работы - " + _startYear + "\n");
        }

    }

}
