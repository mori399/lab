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

            //for (int i = 0; i < filmList.Count; i++)
            //{
            //    if (filmList[i].GetName().IndexOf(Name) != -1)
            //    {
            //        Console.Write(i + ".");
            //        filmList[i].SeeInfo();
            //    }
            //}

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
                     depart[i][j].Show();
                }
                if (depart[i].Count == 0) Console.WriteLine("Тут пусто\n");
            }
        }
        public void ShowEployment(int num)
        {
                for (int i = 0; i < depart[num].Count; i++)
                {
                  depart[num][i].Show();
                }
            if (depart[num].Count == 0) Console.WriteLine("Тут пусто\n");
        }
        public bool EditingEployment(int num, string name)
        {
            int count = 0;
            bool flag = true;
            for (int i = 0; i < depart[num].Count; i++)
            {
                if (depart[num][i].GetSurename() == name)
                {
                    count = i;
                    flag = false;
                }
            }
            if (flag) return false;
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
    }
}
