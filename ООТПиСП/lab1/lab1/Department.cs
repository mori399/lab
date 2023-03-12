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
            bool flag = true;
            for (int i = 0; i < depart[num].Count; i++)
            {
                if (depart[num][i].GetName() == name)
                {
                    count = i;
                    flag = false;
                }
            }
            if (flag) return false;

            depart[num].RemoveAt(count);
            return true;
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
            }
        }
        public void ShowEployment(int num)
        {
                for (int i = 0; i < depart[num].Count; i++)
                {
                    depart[num][i].Show();
                }
        }
        public bool EditingEployment(int num, string name)
        {
            int count = 0;
            bool flag = true;
            for (int i = 0; i < depart[num].Count; i++)
            {
                if (depart[num][i].GetName() == name)
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
