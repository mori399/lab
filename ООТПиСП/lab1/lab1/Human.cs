using System.Linq.Expressions;

namespace lab1
{
 class Human
    {
        public Human()
        {

        }
        //конструктор копирования
        public Human(Human human)
        {
            StartYear = human.StartYear;
            Name = human.Name;
            Surename = human.Surename;
            Day = human.Day;
            Month = human.Month;
            Year = human.Year;
        }

        private string Name;
        private string Surename;
        private int Day;
        private int Month;
        private int Year;
        private int StartYear;

        public string GetName() 
        { 
            return Name; 
        }
        public int GetDay()
        {
            return Day;
        }
        public int GetMonth()
        {
            return Month;
        }
        public int GetYear()
        {
            return Year;
        }
        public int GetStartYear()
        {
            return StartYear;
        } 
        public string GetSurename()
        {
            return Surename;
        }

        public void AddHumanName()
        {
            Console.Write("Введите имя сотрудника: ");      
            bool flag = true;
            while (true) {
                string str = Console.ReadLine();
                flag = true;
                foreach (char c in str)
                {
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))
                    {
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Name = str;
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
                    if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))
                    {
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Surename = str;
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
            Console.Write("Введите день(0 - 31): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int day) == true && day <= 31 && day > 0)
                {
                    Day = day;
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            Console.Write("Введите месяц(0 - 12): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int month) == true && month <= 12 && month > 0)
                {
                    Month = month;
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
                if (int.TryParse(Console.ReadLine(), out int year) == true && year <= 2005 && year >= 1960)
                {
                    Year = year;
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
                if (int.TryParse(Console.ReadLine(), out int year) == true && year <= 2023 && year >= 2000 && (year - 18)>= Year)
                {
                    StartYear = year;
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
            Console.Write("Имя и Фамилия - " + Name + " " + Surename + "\n");
            Console.Write("День рождения - " + Day + "." + Month + "." + Year + "\n");
            Console.Write("Год начала работы - " + StartYear + "\n\n");
        }

    }

}
