using System.Data.Common;

namespace lab1;

class Program
{
    static void Main()
    {
        int dep;
        bool flag;
        Department department = new Department();
        Workers workers = new Workers();
        while (true)
        {
            Console.WriteLine("Что делаем?\n" +
                "1 - Добавить сотрудника\n" +
                "2 - Удалить сотрудника\n" +
                "3 - Просмотреть сотрудников\n" +
                "4 - Редактировать сотрудника\n" +
                "5 - Выдать сотруднику работу\n" +
                "6 - Уволить сотрудника\n" +
                "7 - Демонстарция операторов\n" +
                "8 - Шаблоны\n");

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
                        workers.NewEployment();
                        department.AddNewEployee(dep, workers);
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
                    Console.WriteLine("Из какого отдела сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                        {
                            dep--;
                            Console.WriteLine("Введите номер сотрудника ");
                            if (!int.TryParse(Console.ReadLine(), out int number)) { break; }
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
                case 6:
                    Console.WriteLine("Из какого отдела сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && CorrectImput.InRange(1, 3, dep))
                        {
                            dep--;
                            Console.WriteLine("Введите номер сотрудника ");
                            if (!int.TryParse(Console.ReadLine(), out int number)) { break; }
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
                case 7:
                    Console.Clear();
                    department.ShowOperators(department);
                    break;
                case 8:
                    Template<int> intArr = new Template<int>(5);

                    Console.WriteLine("Введите числа");
                    for (int i = 0; i < intArr.GetArrayLength(); i++)
                    {
                        int.TryParse(Console.ReadLine(),out int number);
                        intArr.SetByIndex(i, number);
                    }

                    Template<char> charArr = new Template<char>(5);

                    Console.WriteLine("Введите символ");
                    for (int i = 0; i < charArr.GetArrayLength(); i++)
                    {
                        char.TryParse(Console.ReadLine(), out char symbol);
                        charArr.SetByIndex(i, symbol);
                    }

                    Template<Workers> workersArr = new Template<Workers>(5);

                    for (int i = 0; i < workersArr.GetArrayLength(); i++)
                    {
                        int startdate = 2000;
                        startdate += i;
                        DateTime birthday = new DateTime(1980, 1, 4);
                        Workers worker = new Workers(startdate, "Игорь", birthday, "Цискович", "работяга");
                        workersArr.SetByIndex(i, worker);
                    }

                    Template<Dismissed> dismissedArr = new Template<Dismissed>(5);

                    for (int i = 0; i < dismissedArr.GetArrayLength(); i++)
                    {
                        int startdate = 2000;
                        startdate += i;
                        DateTime birthday = new DateTime(1980, 1, 4);
                        DateTime dismissdate = new DateTime(2020, 12, 9);
                        Dismissed dismiss = new Dismissed(startdate, "Кирилл", birthday, "Беляцкий", dismissdate);
                        dismissedArr.SetByIndex(i, dismiss);
                    }

                    Template<int>.templateMenu(intArr, charArr, workersArr, dismissedArr);
                    break;

            }
        }
    }
}