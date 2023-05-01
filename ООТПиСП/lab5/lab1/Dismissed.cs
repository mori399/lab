using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Dismissed : Human
    {
        private DateTime _dismissedDate;
        public Dismissed()
        {
            _dismissedDate = new DateTime();
            Console.WriteLine("Вызван конструкотр без параметров наследовательного класса Dismissed");

        }
        public Dismissed(int startYear, string name, DateTime birthday, string surename, DateTime date) : base(startYear, name, birthday, surename)
        {
            _dismissedDate = date;
            Console.WriteLine("Вызван конструкотр с параметрами наследовательного класса Dismissed");
        }
        public Dismissed(Dismissed dismissed) : base(dismissed)
        {
            _dismissedDate = dismissed._dismissedDate;
            Console.WriteLine("Вызван конструкотр копирования наследовательного класса Dismissed");
        }
        ~Dismissed()
        {
            Console.WriteLine("Вызван деструктор наследовательного класса Dismissed");
        }

        public DateTime GetDismissedDate()
        {
            return _dismissedDate;
        }

        public static DateTime AddDismissedProfes(int startyear)
        {
            int day, month, year;
            Console.WriteLine("Ввод Данных дня увольнения сотрудника\nВведите день(1 - 31): ");

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
            Console.Write($"Введите год({startyear} - {DateTime.Now.Year}): ");
            while (true)
            {
                var chek = int.TryParse(Console.ReadLine(), out year) && CorrectImput.InRange(startyear, DateTime.Now.Year, year);
                if (!chek)
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                break;
            }
            return new DateTime(year, month, day);
        }

        public override void Show()
        {
            Console.Write(
                 "Имя и Фамилия - " + GetName() + " " + GetSurename() + "\n" +
                 $"День рождения - {Getbirthday().ToString("D")}\n" +
                 "Год начала работы - " + GetStartYear() + "\n" +
                 "Дата увольнения - " + _dismissedDate.ToString("D") + "\n");
        }
    }
}

