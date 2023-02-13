namespace lab_5
{

    public partial class Form1 : Form
    {
        Queue<stud> queue = new Queue<stud>();
        stud[] TABL = new stud[10];
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;
        string res = "";
        private void button1_Click(object sender, EventArgs e)
        {
            string str = Input.Text, result = "";
            var st = new Stack<string>();
            var qe = new Queue<string>();
            bool flag = false;
            stud temp;
            switch (comboBox1.SelectedItem)
            {
                case "1":
                    for(int i = 0; i != str.Length; i++)
                    {
                        if (str[i] >= 'A' && str[i] <= 'Z')
                        {
                            qe.Enqueue(str[i].ToString());
                        }
                        else
                        {
                            st.Push(str[i].ToString());
     
                        }
                    }
                    while (true)
                    {
                        if (st.Count == 0) break;
                        if (qe.Count == 0) flag = true;
                        else result += qe.Dequeue();
                        if (flag) { 
                            result += st.Pop(); 
                            flag = false; 
                        }
                        else flag = true;

                    }
                    label2.Text = result;
                    break;

                case "¬вести фамилию и группу":
                    string[] cou = str.Split(' ');
                    TABL[count].NAME = cou[0];
                    TABL[count].NUM = int.Parse(cou[1]);
                    queue.Enqueue(TABL[count]);
                    count++;
                    break;

                case "»звлечь из очереди":
                    temp = queue.Dequeue();
                    res += temp.NAME + " ";
                    res += temp.NUM + "\n";
                    label2.Text = res;
                    break;
            }
        }
         
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}