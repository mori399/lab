string path = @"D:\OS\LAB\source.txt";

string str = "";
//str = File.ReadAllText(path);

double S;
S = Convert.ToDouble(args[0]);
//S = Convert.ToDouble(str);

File.Delete(path);

//S = double.Parse(Console.Read
//Line());

S = Math.Pow(S, 1.0 / 3.0);

string res = Convert.ToString(S);
File.WriteAllText(path, res);
//Console.WriteLine(S);