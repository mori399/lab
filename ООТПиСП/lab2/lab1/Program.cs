using System.Security.Cryptography;

namespace lab1;

class Program
{
    static void Main()
    {
        int dep = 0;
        string surename;
        bool flag;
        Department department = new Department();
        Human Eployment = new Human();
        department.Initializations();
        while (true)
        {
            Console.WriteLine("Что делаем?\n1 - Добавить сотрудника\n2 - Удалить сотрудника\n3 - Просмотреть сотрудников\n4 - Редактировать сотрудника\n5 - Добавить сотрудника через конструктор с параметрами\n6 - Копировать сотрудника");
            int.TryParse(Console.ReadLine(), out int n);
            switch (n)
            {
                case 1:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) == true && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            Eployment.NewEployment();
                            department.AddNewEployment(dep, Eployment);
                            Console.WriteLine("Успешно");
                           // Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
                case 2:
                    Console.WriteLine("Из какого отдела удалить сотрудника?");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) == true && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            Console.WriteLine("Фамилия удаляемого сотрудника:");
                            surename = Console.ReadLine();
                            flag = department.DeleteEployment(dep, surename);
                            if (flag)
                            {
                                Console.WriteLine("Успешно");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверная фамилия, или такой нет");
                                break;
                            }
                        }
                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Какой отдел вывести? / all - вывести всех");
                    while (true)
                    {
                        string tem = Console.ReadLine();
                        if (int.TryParse(tem, out dep) == false)
                        {
                            if (tem == "all")
                            {
                                department.ShowEployment();
                                break;
                            }
                            else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                        }
                        else
                        {
                            if (dep <= 3 && dep >= 1)
                            {
                                dep--;
                                department.ShowEployment(dep);
                                break ;
                            }
                            else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                        }
                    }
                    //Console.ReadKey();
                    //Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("Из какого отдела редактируемый сотрудник?");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) == true && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            Console.Write("Фамилия редактируемого сотрудника:");
                            surename = Console.ReadLine();
                            flag = department.EditingEployment(dep, surename);
                            if (flag)
                            {
                                Console.WriteLine("Успешно");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Неверная фамилия, или такой нет");
                            }

                        }
                        else Console.WriteLine("Некоректный ввод, попробуй ещё раз: ");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) == true && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            department.Constructor(dep);
                            Console.WriteLine("Успешно");
                            // Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                    break;
                case 6:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out dep) == true && dep <= 3 && dep >= 1)
                        {
                            dep--;
                            Console.WriteLine("Введите номер копируемого сотрудника ");
                            if (int.TryParse(Console.ReadLine(), out int number) == true) { }
                            else break;

                            Console.WriteLine("Введите количество копий ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) == true) { }
                            else break;

                            department.Copy(dep, number, quantity);
                            Console.WriteLine("Успешно");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                        else Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    }
                        break;
                    break;
            }
        }
    }
}