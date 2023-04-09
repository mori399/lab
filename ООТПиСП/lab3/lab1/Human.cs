using System.Linq.Expressions;
using System.Security.Cryptography;

namespace lab1
{
    class Human
    {
        private string _name;
        private string _surename;
        private DateTime _birthday;
        private int _startYear;
        public Human()
        {
            _startYear = 0;
            _name = "пусто";
            _surename = "пусто";
            _birthday = DateTime.Now;
            Console.WriteLine("Вызван конструкотр без параметров");
        }

        public Human(int startYear, string name, DateTime birthday, string surename, int day, int month, int year)
        {
            _startYear = startYear;
            _name = name;
            _surename = surename;
            _birthday = birthday;
            Console.WriteLine("Вызван конструкотр с параметрами");
            Console.ReadKey();
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
            Console.ReadKey();
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
        public void AddHumanName()
        {
            Console.Write("Введите имя сотрудника: ");
            while (true)
            {
                bool flag = true;
                string str = Console.ReadLine();
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
                    _name = str;
                    break;
                }
            }
        }
        public void AddHumanSurename()
        {
            Console.Write("Введите фамилию сотрудника: ");
            while (true)
            {
                bool flag = true;
                string str = Console.ReadLine();
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
                    _surename = str;
                    break;
                }
            }
        }
        public void AddHumanBirthday()
        {
            int day, month, year;
            Console.WriteLine("Ввод Данных дня рождения сотрудника\nВведите день(1 - 31): ");

            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out day) && day <= 31 && day > 0;
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
                var chek = int.TryParse(Console.ReadLine(), out month) && month <= 12 && month > 0;
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
                var chek = int.TryParse(Console.ReadLine(), out year) && year <= DateTime.Now.Year - 18 && year >= DateTime.Now.Year - 60;
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                break;
            }
            _birthday = new DateTime(year, month, day);
        }
        public void AddHumanStartYear()
        {
            Console.Write($"Введите год начала работы(2000 - {DateTime.Now.Year}): ");
            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out int year) && year <= DateTime.Now.Year && year >= 2000 && (year - 18) >= _birthday.Year;
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }

                _startYear = year;
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

        public void Show()
        {
            Console.Write(
                "Имя и Фамилия - " + _name + " " + _surename + "\n" +
                $"День рождения - {_birthday.ToString("D")}\n" +
                "Год начала работы - " + _startYear + "\n");
        }

    }

}
