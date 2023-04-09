using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace lab1
{
    class Department
    {
       // List<Workers> workers = new List<Workers>();
        List<Human>[] depart = new List<Human>[3];
        public void AddNewEployee(int num, Human hum)
        {
            depart[num].Add(new Human(hum));
        }
        public Department()
        {
            depart[0] = new List<Human>();
            depart[1] = new List<Human>();
            depart[2] = new List<Human>();
        }

        public bool DeleteEployee(int num)
        {
            int count = 0;
            string name = "";
            bool flag = false, MoreOne = false;

            if (depart[num].Count == 0)
            {
                Console.WriteLine("В этом отделе никого нет.");
                return false;
            }
            Console.WriteLine("Фамилия удаляемого сотрудника:");
            name = Console.ReadLine();
            for (int i = 0; i < depart[num].Count; i++)
            {
                if (depart[num][i].GetSurename().IndexOf(name) != -1)
                {
                    Console.Write(i + ".");
                    depart[num][i].Show();
                    count = i;
                    if (flag)
                    {
                        MoreOne = true;
                    }
                    flag = true;
                }
            }
            if (MoreOne)
            {
                Console.Write("Сотрудника под каким номером нужно удалить?\n");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int i))
                    {
                        depart[num].RemoveAt(i);
                        GC.Collect();
                        return true;
                    }
                    else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                }

            }
            else
            {
                if (flag)
                {
                    depart[num].RemoveAt(count);
                    GC.Collect();
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверная фамилия, или такой нет");
                    return false;
                }
            }

        }
        public void ShowEployee()
        {
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(++num + "-------------------------------");
                for (int j = 0; j < depart[i].Count; j++)
                {
                    Console.WriteLine(j + ".");
                    depart[i][j].Show();
                }
                if (depart[i].Count == 0) Console.WriteLine("Тут пусто\n");
            }
        }
        public void ShowEployee(int num)
        {
            for (int i = 0; i < depart[num].Count; i++)
            {
                Console.WriteLine(i + ".");
                depart[num][i].Show();
            }
            if (depart[num].Count == 0) Console.WriteLine("Тут пусто\n");
        }

        //public void ShowWorker()
        //{
        //    for (int i = 0; i < workers.Count; i++)
        //    {
        //        Console.WriteLine(i + ".");
        //        workers[i].ShowWorkers();
        //    }
        //    if (workers.Count == 0) Console.WriteLine("Тут пусто\n");
        //}
        public bool EditingEployee(int num)
        {
            int count = 0;
            string name = "";
            bool flag = false, MoreOne = false;
            if (depart[num].Count == 0)
            {
                Console.WriteLine("В этом отделе никого нет.");
                return false;
            }
            Console.Write("Фамилия редактируемого сотрудника:");
            name = Console.ReadLine();
            for (int i = 0; i < depart[num].Count; i++)
            {
                if (depart[num][i].GetSurename() == name)
                {
                    if (depart[num][i].GetSurename().IndexOf(name) != -1)
                    {
                        Console.Write(i + ".");
                        depart[num][i].Show();
                        count = i;
                        if (flag)
                        {
                            MoreOne = true;
                        }
                        flag = true;
                    }
                }
            }
            if (MoreOne)
            {
                Console.Write("Сотрудника под каким номером нужно редактировать?\n");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int i))
                    {
                        count = i;
                        break;
                    }
                    else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                }

            }
            else
            {
                if (!flag)
                {
                    Console.WriteLine("Неверная фамилия, или такой нет");
                    return false;
                }

            }
            Console.WriteLine("Что нужно изменить?\n" +
                "1 - Имя сотрудника\n" +
                "2 - Фамилию сотрудника\n" +
                "3 - День рождения сотрудника\n" +
                "4 - Год начала работы сотрудника\n");
            int edit = Convert.ToInt32(Console.ReadLine());
            switch (edit)
            {
                case 1:
                    depart[num][count].AddHumanName();
                    return true;
                case 2:
                    depart[num][count].AddHumanSurename();
                    return true;
                case 3:
                    depart[num][count].AddHumanBirthday();
                    return true;
                case 4:
                    depart[num][count].AddHumanStartYear();
                    return true;
            }
            return false;
        }
        public void AddEmployeeByConstructor(int dep)
        {
            int startyear = 0, day = 0, year = 0, month = 0;
            string name = "", surename = "";
            DateTime birthday;
            bool flag = true;
            Console.Write("Введите имя сотрудника: ");
            while (true)
            {
                name = Console.ReadLine();
                flag = true;
                foreach (char c in name)
                {
                    if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
                    {
                        Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        flag = false;
                        break;
                    }

                }
                if (flag) break;
            }
            Console.Write("Введите фамилию сотрудника: ");
            while (true)
            {
                surename = Console.ReadLine();
                flag = true;
                foreach (char c in surename)
                {
                    if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
                    {
                        Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        flag = false;
                        break;
                    }

                }
                if (flag) break;
            }
            Console.WriteLine("Ввод Данных дня рождения сотрудника");
            Console.Write("Введите день(1 - 31): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out day) && day <= 12 && day > 0)
                {
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
                if (int.TryParse(Console.ReadLine(), out month) && day <= 31 && day > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }

            Console.Write($"Введите год({DateTime.Now.Year - 60} - {DateTime.Now.Year - 18}): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out year) && year <= DateTime.Now.Year - 18 && year >= DateTime.Now.Year - 60)
                {
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            birthday = new DateTime(year, month, day);
            Console.Write("Введите год начала работы(2000 - 2023): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out startyear) && startyear <= 2023 && startyear >= 2000 && (startyear - 18) >= year)
                {
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            Human hum = new Human(startyear, name, birthday, surename, day, month, year);

            depart[dep].Add(hum);
        }
        public void Copy(int dep, int number, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Human human = new Human(depart[dep][number]);
                depart[dep].Add(human);
            }
        }
        public bool CheckEmployee(int dep)
        {
            if (depart[dep].Count > 0)
            {
                return true;
            }
            else return false;
        }

        public void AddNewWorker(int dep,int number)
        {
            Workers worker = new Workers(depart[dep][number],Workers.AddWorkersProfes());
            //Workers workers = depart[dep][number];
            depart[dep][number] = worker;          
        }

        public Human GetHuman(int dep, int number)
        {
            Human hum = depart[dep][number];
            //depart[dep].RemoveAt(number);
            return hum;
        }


    }
}
