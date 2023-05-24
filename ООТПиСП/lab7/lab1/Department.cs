using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace lab1
{
    class Department
    {
        List<Human>[] depart = new List<Human>[3];
        public void AddNewEployee(int num, Workers hum)
        {
            depart[num].Add(new Workers(hum));
        }
        public Department()
        {
            depart[0] = new List<Human>();
            depart[1] = new List<Human>();
            depart[2] = new List<Human>();
        }
        public static Department operator +(Department department, Human human)
        {
            Console.WriteLine("В какой отдел добавить сотрудника?(1-3)");
            while (true)
            {
                if (!(int.TryParse(Console.ReadLine(), out int dep) && CorrectImput.InRange(1, 3, dep)))
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                dep--;
                department.depart[dep].Add(human);
                return department;
            }
        }
        public static Department operator ++(Department department)
        {
            Console.WriteLine("В какой отдел добавить сотрудника?(1-3)");
            while (true)
            {
                if (!(int.TryParse(Console.ReadLine(), out int dep) && CorrectImput.InRange(1, 3, dep)))
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    continue;
                }
                dep--;
                if (department.depart[dep].Count != 0) department.depart[dep].Add(department.depart[dep][0]);
                else Console.WriteLine("Лист пуст");
                return department;
            }
        }
        public bool DeleteEployee(int num)
        {
            int count = 0;
            string name = "";
            bool flag = false, MoreOne = false;

            if (depart[num].Count == 0)
            {
                EmptyListException error = new EmptyListException("В этом отделе никого нет.");
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
                EmptyListException error = new EmptyListException("В этом отделе никого нет.");
                Console.WriteLine($"случилась ошибка: {error.Message}");
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
        public bool CheckEmployee(int dep)
        {
            if (depart[dep].Count > 0)
            {
                return true;
            }
            else return false;
        }
        public bool AddNewWorker(int dep, int number)
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
        public bool DismissEmployee(int dep, int number)
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
        public void ShowOperators(Department department)
        {
            bool menu = true;
            int dep;
            while (menu)
            {
                Workers workers = new Workers();
                Console.WriteLine("Какой оператор используем?\n" +
                    "1 - оператор +\n" +
                    "2 - оператор ++\n" +
                    "3 - оператор ==\n" +
                    "4 - оператор !=\n" +
                    "5 - оператор <\n" +
                    "6 - оператор >\n" +
                    "7 - оператор <=\n" +
                    "8 - оператор >=\n" +
                    "9 - показать всё\n" +
                    "-1 - чтобы выйти\n");

                int.TryParse(Console.ReadLine(), out int n);
                switch (n)
                {

                    case 1:
                        workers.NewEployment();
                        department += new Workers(workers);
                        break;
                    case 2:
                        department++;
                        break;
                    case 3:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] == depart[dep][number2])
                                    {
                                        Console.WriteLine("Они равны ");
                                    }
                                    else Console.WriteLine("Они не равны ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] != depart[dep][number2])
                                    {
                                        Console.WriteLine("Они не равны ");
                                    }
                                    else Console.WriteLine("Они равны ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] < depart[dep][number2])
                                    {
                                        Console.WriteLine("Первый меньше второго ");
                                    }
                                    else Console.WriteLine("Первый не меньше второго ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] > depart[dep][number2])
                                    {
                                        Console.WriteLine("Первый больше второго ");
                                    }
                                    else Console.WriteLine("Первый не больше второго ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] <= depart[dep][number2])
                                    {
                                        Console.WriteLine("Первый меньше или равен второму ");
                                    }
                                    else Console.WriteLine("Первый не меньше или равен второму ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    if (depart[dep][number1] >= depart[dep][number2])
                                    {
                                        Console.WriteLine("Первый больше или равен второму");
                                    }
                                    else Console.WriteLine("Первый не больше или равен второму ");
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Из какого отдела сравниваемые сотрудники?(1-3)");
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                            {
                                dep--;
                                Console.WriteLine("Введите номер первого сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number1)) { break; }
                                Console.WriteLine("Введите номер второго сотрудника ");
                                if (!int.TryParse(Console.ReadLine(), out int number2)) { break; }
                                if (CorrectImput.InRange(0, depart[dep].Count() - 1, number1) && CorrectImput.InRange(0, depart[dep].Count() - 1, number2))
                                {
                                    bool check = depart[dep][number1] == depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} == human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                    check = depart[dep][number1] != depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} != human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                    check = depart[dep][number1] < depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} < human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                    check = depart[dep][number1] > depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} > human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                    check = depart[dep][number1] <= depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} <= human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                    check = depart[dep][number1] >= depart[dep][number2];
                                    Console.WriteLine($"human1 - {depart[dep][number1].GetStartYear()} >= human2 - {depart[dep][number2].GetStartYear()} :" + check);
                                }
                                else Console.WriteLine("Сотрудников с такими номерами нет ");
                                break;
                            }

                            else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                        }
                        break;
                    case -1:
                        menu = false;
                        break;
                }
            }
        }
    }
}
