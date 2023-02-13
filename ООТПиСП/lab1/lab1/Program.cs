using System.ComponentModel;


class Human
{
    public string Name { get; set; }
    public int num { get; set; }
    public int Year { get; set; }
    protected void addName()
    {
        Console.Write("Введите имя сотрудника: ");
        Name = Console.ReadLine();
    }

    protected void addnum()
    {
        Console.Write("Введите номер сотрудника: ");
        num = Convert.ToInt32(Console.ReadLine());
    }

    protected void addYear()
    {
        Console.Write("Введите год начала работы: ");
        Year = Convert.ToInt32(Console.ReadLine());
    }

   
}

class Department : Human
{
    public void NewEployment()
    {
        addName();
        addnum();
        addYear();

    }
    public void Show(int i)
    {
        Console.Write(++i + ".");
        Console.Write("Имя - " + Name + "\n");
        Console.Write("Номер - " + num + "\n");
        Console.Write("год старта - " + Year + "\n");
        Console.Write("--------------------\n");
    }
    public void Show()
    {
        Console.Write("Имя - " + Name + "\n");
        Console.Write("Номер - " + num + "\n");
        Console.Write("год старта - " + Year + "\n");
    }

}
class Program
{
    static void Main()
    {
        Department[,] Depart = new Department[3, 10];
        int n, number = 0, dep;
        Human[] Eployment = new Human[3];
        Console.WriteLine("Что делаем?\n1 - Добавить сотрудника\n2 - Просмотреть всех сотрудников\n");
        while (true)
        {
            n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    Depart[dep,number] = new Department();
                    Depart[dep,number].NewEployment();
                    number++;
                    break;
                case 2:
                    Console.WriteLine("В какой отдел добавить сотрудника?");
                    dep = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < number; i++)
                        Depart[dep,i].Show(i);                          //как проверить количество сотрудников во разных отделах?
                    break;
                case 3:
                    Console.WriteLine("Введите номер удаляемого сотрудника");
                    int del;
                    bool StartDel = false;
                    del = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; 0 < number; i++)
                    {
                        if(Eployment[i].num == del) { StartDel = true; }
                    }
                    break;
                case 4:

                    break;
                case 5:

                    break;
            }
        }
    }
}