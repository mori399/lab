
using System.Diagnostics;
using System.Linq.Expressions;

namespace Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\OS\LAB\source.txt";

            double A, B, S = 0;

            //string[] cou = args[0].Split('.');
            A = double.Parse(args[0]);
            B = double.Parse(args[1]);

            //File.Delete(path);

            for (int i = 1; i <= B; i++)
            {
                S += Math.Log(A * i, 2);
            }

            string res = Convert.ToString(S);
            Console.WriteLine(res);
            Process.Start(@"D:\OS\lab1.2\lab1.2\bin\Debug\net6.0\lab1.2.exe", res);
            
        }
    }
}