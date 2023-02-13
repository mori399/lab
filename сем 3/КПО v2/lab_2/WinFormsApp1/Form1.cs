using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            str = textBox1.Text;
           RES.Text = N3(str);
        }


        // List<string> lst

        string N1(string str2)
        {
            char ch = 'w';
            char cv = 'x';
            int indexOfChar = str2.IndexOf(ch); //IndexOf: находит индекс первого вхождения символа или подстроки в строке
            int indexOfChar2 = str2.IndexOf(cv);
            if (indexOfChar < indexOfChar2)
            {

                str2 = "w ranshe";
            }
            else if (indexOfChar > indexOfChar2)
            {

                str2 = "x ranshe";
            }
            else
            {
                str2 = "net takih bykav";
            }
            return str2;
        }

        string N2(string str2)
        {
            StringBuilder sb = new StringBuilder(str2);
            for (int i = 0; i < str2.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    if (str2[i] == 'a' || str2[i] == 'b')
                    {
                        sb[i] = 'c';
                        str2 = sb.ToString();
                    }
                    else {
                        sb[i] = 'a';
                        str2 = sb.ToString();
                    }
                }
            }
            RES.Text = str2;
            return str2;
        }
        string N3(string str2)
        {
            string[] words = str2.Split(new char[] { ' ' }); //Split: разделяет одну строку на массив строк
            int indexOfChar = str2.IndexOf(words[1]); //IndexOf: находит индекс первого вхождения символа или подстроки в строке
            str2 = str2.Substring(indexOfChar + words[1].Length); //Substring: извлекает из строки подстроку, начиная с указанной позиции
            return str2;
        }

        string N4(string str2)
        {
            char tmp = ' ';
            bool flag = true;
            for (int i = 0; i < str2.Length; i++)
            {
                    if (tmp <= str2[i])
                    {
                        tmp = str2[i];
                    }
                    else
                    {
                    str2 = "no";
                    flag = false;   
                        break;
                    }
            }

            if (flag == true)
            {
                str2 = "yes";
            }
            return str2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}