using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    static class CorrectImput
    {
        public static bool IsLatters(string str)
        {
            foreach (char c in str)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
                {
                    Console.Write("Некоректный ввод, попробуй ещё раз: ");
                    return false;
                }
            }
            return true;
        }
        public static bool InRange(int left, int right, int number)
        {
            if (number >= left && number <= right) return true;
            return false;
        }
    }
}
