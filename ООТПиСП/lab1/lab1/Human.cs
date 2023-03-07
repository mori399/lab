using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
 class Human
    {
        public Human()
        {

        }
        public Human(Human human)
        {
            this.Year = human.Year;
            this.Name = human.Name;
            this.Num = human.Num;
        }
        public string Name { get; set; }
        public int Num { get; set; }
        public int Year { get; set; }
        public void AddHumanName()
        {
            Console.Write("Введите имя сотрудника: ");
            Name = Console.ReadLine();
        }

        public void AddHumanNum()
        {
            Console.Write("Введите номер сотрудника: ");
            Num = Convert.ToInt32(Console.ReadLine());
        }

        public void AddHumanYear()
        {
            Console.Write("Введите год начала работы: ");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        public void NewEployment()
        {
            AddHumanName();
            AddHumanNum();
            AddHumanYear();

        }

        public void Show()
        {
            Console.Write("Имя - " + Name + "\n");
            Console.Write("Номер - " + Num + "\n");
            Console.Write("год старта - " + Year + "\n");
        }

    }

}
