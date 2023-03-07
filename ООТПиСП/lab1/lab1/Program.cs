using System;
using System.ComponentModel;

namespace lab1;

class Program
{
    static void Main()
    {
        int n, number = 0;
        var dep = 0;
        string name;
        bool flag;
        Department department = new Department();
        Human Eployment = new Human();
        department.Initializations();
        Console.WriteLine("Что делаем?\n1 - Добавить сотрудника\n2 - Удалить сотрудника\n3 - Просмотреть сотрудников\n");
        while (true)
        {
            n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    Eployment.NewEployment();
                    department.AddNewEployment(dep,Eployment);
                    number++;
                    break;
                case 2:
                    Console.WriteLine("Из какого отдела удалить сотрудника?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Имя удаляемого сотрудника:\n");
                    name = Console.ReadLine();
                    flag = department.DeleteEployment(dep, name);
                    if (flag)
                    {
                        Console.WriteLine("Успешно"); 
                    }else
                    {
                        Console.WriteLine("Неверное имя");
                    }
                    break;
                case 3:
                    Console.WriteLine("Какой отдел вывести?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    department.ShowEployment(dep);
                    break;
                case 4:
                    Console.WriteLine("Из какого отдела редактируемый сотрудник?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Имя редактируемого сотрудника:\n");
                    name = Console.ReadLine();
                    flag = department.EditingEployment(dep, name);
                    if (flag)
                    {
                        Console.WriteLine("Успешно");
                    }
                    else
                    {
                        Console.WriteLine("Неверное имя");
                    }
                    break;
                case 5:

                    break;
            }
        }
    }
}