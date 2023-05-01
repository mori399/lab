

namespace lab1
{
    class Department
    {
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
            int startyear;
            string name; 
            string surename;
            DateTime birthday;
            Console.Write("Введите имя сотрудника: ");
            while (true)
            {
                name = Console.ReadLine();
                if (CorrectImput.IsLatters(name)) break;
            }
            Console.Write("Введите фамилию сотрудника: ");
            while (true)
            {
                surename = Console.ReadLine();
                if (CorrectImput.IsLatters(surename)) break;
            }

                Console.WriteLine("Введите день рождения сотрудника: ");
                while (true)
                {
                    var chek = DateTime.TryParse(Console.ReadLine(), out birthday);
                    if (!chek)
                    {
                        Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        continue;
                    }
                    break;
                }

            Console.Write($"Введите год начала работы(2000 - {DateTime.Now.Year}): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out startyear) && CorrectImput.InRange(2000, DateTime.Now.Year, startyear) && (startyear - 18) >= birthday.Year)
                {
                    break;
                }
                else
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                }
            }
            Human hum = new Human(startyear, name, birthday, surename);

            depart[dep].Add(hum);
        }
        public void Copy(int dep, int number, int quantity)
        {
            if (depart[dep][number] is Workers wor)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Workers workers = new Workers(wor);
                    depart[dep].Add(workers);
                }
            }
            else if (depart[dep][number] is Dismissed dis)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Dismissed workers = new Dismissed(dis);
                    depart[dep].Add(workers);
                }
            }
            else
            {
                for (int i = 0; i < quantity; i++)
                {
                    Human human = new Human(depart[dep][number]);
                    depart[dep].Add(human);
                }
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

        public bool AddNewWorker(int dep,int number)
        {
            if (depart[dep].Count == 0)
            {
                Console.WriteLine("В этом отделе никого нет.");
                return false;
            }
            Workers worker = new Workers(depart[dep][number].GetStartYear(), depart[dep][number].GetName(), depart[dep][number].Getbirthday(), depart[dep][number].GetSurename(), Workers.AddWorkersProfes());
            depart[dep][number] = worker;
            return true;
        }
        public bool DismissEmployee(int dep,int number)
        {
            if (depart[dep].Count == 0)
            {
                Console.WriteLine("В этом отделе никого нет.");
                return false;
            }
            Dismissed dismiss = new Dismissed(depart[dep][number].GetStartYear(), depart[dep][number].GetName(), depart[dep][number].Getbirthday(), depart[dep][number].GetSurename(), Dismissed.AddDismissedProfes(depart[dep][number].GetStartYear()));
            depart[dep][number] = dismiss;
            return true;

        }
    }
}
