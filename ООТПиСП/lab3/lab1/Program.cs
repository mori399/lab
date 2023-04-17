namespace lab1;

class Program
{
    static void Main()
    {
        int dep;
        bool flag;
        Department department = new Department();
        Human eployment = new Human();
        while (true)
        {
            Console.WriteLine("Что делаем?\n" +
                "1 - Добавить сотрудника\n" +
                "2 - Удалить сотрудника\n" +
                "3 - Просмотреть сотрудников\n" +
                "4 - Редактировать сотрудника\n" +
                "5 - Добавить сотрудника через конструктор с параметрами\n" +
                "6 - Копировать сотрудника\n" +
                "7 - Выдать сотруднику работу\n" +
                "8 - Уволить сотрудника\n");
            int.TryParse(Console.ReadLine(), out int n);
            switch (n)
            {
                case 1:
                    Console.WriteLine("В какой отдел добавить сотрудника?(1-3)");
                    while (true)
                    {
                        if (!(int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep)))
                        {
                            Console.Write("Некоректный ввод, попробуй ещё раз: ");
                            continue;
                        }
                        dep--;
                        eployment.NewEployment();
                        department.AddNewEployee(dep, eployment);
                        Console.WriteLine("Успешно");
                        // Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Из какого отдела удалить сотрудника?(1-3)");
                    while (true)
                    {
                        if (!(int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep)))
                        {
                            Console.Write("Некоректный ввод, попробуй ещё раз: ");
                            continue;
                        }
                        dep--;
                        flag = department.DeleteEployee(dep);
                        if (flag)
                        {
                            Console.WriteLine("Успешно");
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                   // Console.ReadKey();
                    //Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Какой отдел вывести?(1-3) / all - вывести всех");
                    while (true)
                    {
                        string tem = Console.ReadLine();
                        if (int.TryParse(tem, out dep))
                        {
                            if (!CorrectImput.InRange(1, 3, dep))
                            {
                                Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                                continue;
                            }
                            dep--;
                            department.ShowEployee(dep);
                            break;
                        }
                        else
                        {
                            if (tem == "all")
                            {
                                department.ShowEployee();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                                continue;
                            }
                        }
                    }
                    //Console.ReadKey();
                    //Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("Из какого отдела редактируемый сотрудник?(1-3)");
                    while (true)
                    {
                        if (!(int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep)))
                        {
                            Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                            continue;
                        }
                        dep--;
                        flag = department.EditingEployee(dep);
                        if (flag)
                        {
                            Console.WriteLine("Успешно");
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("В какой отдел добавить сотрудника?(1-3)");
                    while (true)
                    {
                        if (!(int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1,3,dep)))
                        {
                            Console.Write("Некоректный ввод, попробуй ещё раз: ");
                            continue;
                        }
                        dep--;
                        department.AddEmployeeByConstructor(dep);
                        Console.WriteLine("Успешно");
                        // Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    break;
                case 6:
                    Console.WriteLine("Из какого отдела копируемый сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                        {
                            dep--;
                            if (department.CheckEmployee(dep))
                            {
                                Console.WriteLine("Введите номер копируемого сотрудника ");
                                if (int.TryParse(Console.ReadLine(), out int number)) { }
                                else break;

                                Console.WriteLine("Введите количество копий ");
                                if (!int.TryParse(Console.ReadLine(), out int quantity))
                                    break;

                                department.Copy(dep, number, quantity);
                                Console.WriteLine("Успешно");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("В этом отделе никого нет.");
                                break;
                            }
                        }

                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
                case 7:
                    Console.WriteLine("Из какого отдела сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                        {
                            dep--;
                            Console.WriteLine("Введите номер сотрудника ");
                            if (int.TryParse(Console.ReadLine(), out int number)) { }
                            else break;
                            flag = department.AddNewWorker(dep, number);
                            if (flag)
                            {
                                Console.WriteLine("Успешно");
                                break;
                            }
                            else
                            {
                                break;
                            }
                            Console.Clear();
                            break;
                        }

                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
                case 8:
                    Console.WriteLine("Из какого отдела сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                        {
                            dep--;
                            Console.WriteLine("Введите номер сотрудника ");
                            if (int.TryParse(Console.ReadLine(), out int number)) { }
                            else break;
                            flag = department.DismissEmployee(dep, number);
                            if (flag)
                            {
                                Console.WriteLine("Успешно");
                                break;
                            }
                            else
                            {
                                break;
                            }
                            Console.Clear();
                            break;
                        }

                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
            }
        }
    }
}