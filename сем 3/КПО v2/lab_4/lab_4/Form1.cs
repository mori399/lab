using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            label2.Text = "Введите путь к файлу";
            button1.Click += button1_Click;
        }
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object? sender, EventArgs e)
        {
            label2.Text = " ";

            string path = Path.Text;
            switch (comboBox1.SelectedItem)
            {
                case "1":
                    N1(path);
                    break;
                case "2":
                    N2(path);
                    break;
            }
        }
        //C:\Users\morim\Desktop\Для пугу\КПО v2\lab_4\a.txt
        void N1(string path)
        {

            string[] str = File.ReadAllLines(path);
            string result = "";
            int[] a;
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                a = str[i].Split(' ').Select(Int32.Parse).ToArray();
                for (int j = 0; j < a.Length; j++)
                {
                    for (int n = 0; n < a.Length - 1; n++)
                    {
                        if (a[n] > a[n + 1])
                        {
                            int tem = a[n];
                            a[n] = a[n + 1];
                            a[n + 1] = tem;
                        }
                    }
                }
                for (int check = 0; check < a.Length - 2; check++)
                {
                    if (a[check] - a[check + 1] == a[check + 1] - a[check + 2]) { }
                    else flag = false;
                }
                if (flag)
                {
                    for (int b = 0; b < a.Length; b++)
                    {
                        result += a[b] + " ";
                    }
                    result += "\n";
                } 
                flag = true;
            }
            string path2 = path.Substring(0, path.Length - 4);
            path2 += "2.txt";
            File.AppendAllText(path2, result);
            label2.Text = result;
        }
        //C:\Users\morim\Desktop\Для пугу\КПО v2\lab_4\b.txt
        void N2(string path)
        {
            string[] str = File.ReadAllLines(path);
            int index;
            string result = "";

            label2.Text = Convert.ToString(str[0][0]);
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i][0] == 'К' || str[i][0] == 'С')
                {
                    index = str[i].IndexOf(' ') + 1;
                    result += str[i].Substring(index);
                    result += "\n";
                }
            }
            string path2 = path.Substring(0, path.Length - 4);
            path2 += "2.txt";
            File.AppendAllText(path2, result);
            label2.Text = result;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}