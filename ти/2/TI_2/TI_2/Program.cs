﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace TI_2
{
    // AAF4C61DDCC5E8A2DABEDE0F3B482CD9AEA9434D
    class Program
    {
        static string ByteArrayToString(byte[] _by) 
        {
            string result = "";

            for (int c = 0; c < _by.Length; c++)
            {
                result += _by[c].ToString("X2");
            }

            return result;
        }
        static void Main(string[] args)
        {
            byte[] b = { 5, 6 };
            HashAlgorithm sha = SHA1.Create();

            byte[] result = sha.ComputeHash(File.ReadAllBytes(@"C:\Users\morim\Desktop\Для пугу\ти\2\TI_2\123.txt"));
            string results;
            Console.WriteLine(results = ByteArrayToString(result));


            Console.WriteLine("task 2");
            Console.ReadKey();

            PSA psa = new PSA();
            long p = 101, q = 103, d = 0, n = 0;
            psa.Start(p, q, ref d, ref n);
            psa.startD(d, n);

            

            
        }
    }

  
}
