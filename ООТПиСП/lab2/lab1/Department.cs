using System.Runtime.Intrinsics.Arm;

namespace lab1
{
    class Department
    {
        List<Human>[] depart = new List<Human>[3];
        public void AddNewEployment(int num, Human hum)
        {
            depart[num].Add(new Human(hum));
        }
        public void Initializations()
        {
            depart[0] = new List<Human>();
            depart[1] = new List<Human>();
            depart[2] = new List<Human>();
        }

        public bool DeleteEployment(int num, string name)
        {
            int count = 0;
            bool flag = false, MoreOne = false;
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
                   if (int.TryParse(Console.ReadLine(), out int i) == true)
                    {
                        depart[num].RemoveAt(i);
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
                    return true;
                }
                else return false;
            }
        }
        public void ShowEployment()
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
        public void ShowEployment(int num)
        {
                for (int i = 0; i < depart[num].Count; i++)
                {
                Console.WriteLine(i + ".");
                depart[num][i].Show();
                }
            if (depart[num].Count == 0) Console.WriteLine("Тут пусто\n");
        }
        public bool EditingEployment(int num, string name)
        {
            int count = 0;
            bool flag = false, MoreOne = false;
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
                   // count = i;
                    //flag = false;
                }
            }
            if (MoreOne)
            {
                Console.Write("Сотрудника под каким номером нужно редактировать?\n");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int i) == true)
                    {
                        count = i;
                        break;
                    }
                    else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                }

            }
            else
            {
                if (flag)
                {
                }
                else return false;
            }
           // if (flag) return false;
            Console.WriteLine("Что нужно изменить?\n1 - Имя сотрудника\n2 - Фамилию сотрудника\n3 - День рождения сотрудника\n4 - Год начала работы сотрудника\n");
            int edit = Convert.ToInt32(Console.ReadLine());
            switch (edit)
            {
                case 1:
                    depart[num][count].AddHumanName();
                    return true;
                    break;
                case 2:
                    depart[num][count].AddHumanSurename();
                    return true;
                    break;
                case 3:
                    depart[num][count].AddHumanBirthday();
                    return true;
                    break;
                case 4:
                    depart[num][count].AddHumanStartYear();
                    return true;
                    break;
            }
            return false;
        }
        public void Constructor(int dep)
        {
            int startyear = 0, day = 0, year = 0, month = 0;
            string name = "", surename = "";
            Console.Write("Введите имя сотрудника: ");
            name = Console.ReadLine();
            Console.Write("Введите фамилию сотрудника: ");
            surename = Console.ReadLine();
            Console.WriteLine("Ввод Данных дня рождения сотрудника");
            Console.Write("Введите день(0 - 31): ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите месяц(0 - 12): ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите год(1960 - 2005): ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите год начала работы(2000 - 2023): ");
            startyear = Convert.ToInt32(Console.ReadLine());

            Human hum = new Human(startyear, name, surename, day, month, year);

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
    }
}
