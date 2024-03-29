﻿namespace lab1;

class Program
{
    static void Main()
    {
        int dep = 0;
        bool flag;
        Department department = new Department();
        Human Eployment = new Human();
        while (true)
        {
            Console.WriteLine("Что делаем?\n" +
                "1 - Добавить сотрудника\n" +
                "2 - Удалить сотрудника\n" +
                "3 - Просмотреть сотрудников\n" +
                "4 - Редактировать сотрудника\n");
            int.TryParse(Console.ReadLine(), out int n);
            switch (n)
            {
                case 1:
                    Console.WriteLine("В какой отдел добавить сотрудника?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            Eployment.NewEployment();
                            department.AddNewEployee(dep, Eployment);
                            Console.WriteLine("Успешно");
                            // Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
                case 2:
                    Console.WriteLine("Из какого отдела удалить сотрудника?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && dep <= 3 && dep >= 1)
                        {
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
                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Какой отдел вывести?(1-3) / all - вывести всех");
                    while (true)
                    {
                        string tem = Console.ReadLine();
                        if (int.TryParse(tem, out dep))
                        {
                            if (dep <= 3 && dep >= 1)
                            {
                                dep--;
                                department.ShowEployee(dep);
                                break;
                            }
                            else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                        }
                        else
                        {
                          
                            if (tem == "all")
                            {
                                department.ShowEployee();
                                break;
                            }
                            else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                        }
                    }
                    //Console.ReadKey();
                    //Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("Из какого отдела редактируемый сотрудник?(1-3)");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) && dep <= 3 && dep >= 1)
                        {
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
                        else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}