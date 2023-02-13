using System.Diagnostics;

string path = @"D:\OS\LAB\source.txt";

string str;
str = File.ReadAllText(path);
var str2 = str.Split(' ');

double A, B, S = 0;

//A = Convert.ToDouble(str2[0]);
//B = Convert.ToDouble(str2[1]);

File.Delete(path);

string[] cou = str.Split(' ');
A = double.Parse(cou[0]);
B = double.Parse(cou[1]);

for (int i = 1; i <= B; i++)
{
    S += Math.Log(A * i, 2);
}

string res = Convert.ToString(S);

File.WriteAllText(path, res);
//Process.Start(@"D:\OS\lab1.2\lab1.2\bin\Debug\net6.0\lab1.2.exe", res);
