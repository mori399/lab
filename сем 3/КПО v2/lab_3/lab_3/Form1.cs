namespace lab_3
{
    public partial class Form1 : Form
    {
        WORKER[] TABL = new WORKER[10];

        public Form1()
        {
            InitializeComponent();

            TABL[0].NAME = "Матвиенко С.В.";
            TABL[0].POS = "Импровизатор";
            int a = 2010;
            TABL[0].YEAR = a;
            //
            TABL[1].NAME = "Попов А.С.";
            TABL[1].POS = "Актёр";
            int g = 2005;
            TABL[1].YEAR = g;
            //
            TABL[2].NAME = "Позов Д.Т.";
            TABL[2].POS = "Комик";
            int c = 2015;
            TABL[2].YEAR = c;
            //
            TABL[3].NAME = "Шастун А.А.";
            TABL[3].POS = "Юморист";
            int d = 2020;
            TABL[3].YEAR = d;

            button1.Click += button1_Click;
        }
        string str2;
        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object? sender, EventArgs e)
        {
            int number = Convert.ToInt32(comboBox2.SelectedItem);
            label2.Text = " ";
            str2 = " ";
            bool flag = true;
            switch (comboBox1.SelectedItem)
            {
                case "Ввести фамилию и инициалы":
                    TABL[number] = AddNAME(TABL[number], Input.Text);
                    break;
                case "Ввести должность":
                    TABL[number] = AddPOS(TABL[number], Input.Text);
                    break;
                case "Ввести год поступления на работу":
                    TABL[number] = AddBDay(TABL[number], Input.Text);
                    WORKER temp;
                    while (flag)
                    {
                        flag = false;
                        for (int i = 0; i < 9; i++)
                        {
                            if (TABL[i].NAME == null)
                            {
                                break;
                            }
                            if (TABL[i].NAME.CompareTo(TABL[i + 1].NAME) > 0)
                            {
                                temp = TABL[i];
                                TABL[i] = TABL[i + 1];
                                TABL[i + 1] = temp;
                                flag = true;
                            }
                        }
                    }
                    break;
                case "Вывести превышающий стаж работы":
                    int num = int.Parse(Input.Text);
                    flag = true;
                    for (int i = 0; i < TABL.Length; i++)
                    {
                        if (num > TABL[i].YEAR && TABL[i].YEAR != 0)
                        {
                            str2 += TABL[i].NAME + " | " + TABL[i].POS + " | " + TABL[i].YEAR + " №" + i + "\n";
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        str2 += "Таких нет";
                    }
                    label2.Text = str2;
                    break;
                case "Вывести всех":
                    for (int i = 0; i < TABL.Length; i++)
                    {
                        if (TABL[i].NAME != null)
                        {
                            str2 += TABL[i].NAME + " | " + TABL[i].POS + " | " + TABL[i].YEAR + " №" + i + "\n";
                        }
                    }
                    label2.Text = str2;
                    break;
            }
        }

        WORKER AddNAME(WORKER znk, string str)
        {
            znk.NAME = str;
            return znk;
        }

        WORKER AddPOS(WORKER znk, string str)
        {
            znk.POS = str;
            return znk;
        }

        WORKER AddBDay(WORKER znk, string str)
        {
            int num = int.Parse(str);
            znk.YEAR = num;
            return znk;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}