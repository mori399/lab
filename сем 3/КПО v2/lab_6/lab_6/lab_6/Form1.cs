namespace lab_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize();
        }
        private class ArrPoints
        {
            private int index;
            private Point[] points; //������ �����

            public ArrPoints(int size)
            {
                points = new Point[size]; // ����� ������ �����
            }
            public void SetPoint(int x, int y) // ������ �����
            {
                if(index >= points.Length) // ���� ������ ������� �� ������� 
                {
                    index = 0;
                }
                points[index] = new Point(x, y); // ������������ �����
                index++;
            }
            public void ResetPoint()
            {
                index = 0; //����� ������� 
            }
            public int GetCount()
            {
                return index;
            }
            public Point[] GetPoints()
            {
                return points;
            }
        }
        private bool mouse = false;
        private ArrPoints arrpoints = new ArrPoints(2);

        Bitmap map = new Bitmap(100, 100); // ��������� �����������
        Graphics graphics;

        Pen pen = new Pen(Color.Red, 6f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds; // ������ ������
            map = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(map); 

           // pen.StartCap = System.Drawing.Drawing2D.LineCap.Round();
           // pen.EndCap = System.Drawing.Drawing2D.LineCap.Round();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
            arrpoints.ResetPoint(); // ��� ����� �����
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!mouse) { return; }

            arrpoints.SetPoint(e.X, e.Y); // ���� ���������� ����
            if(arrpoints.GetCount() >= 2)
            {
                graphics.DrawLines(pen,arrpoints.GetPoints()); // ���������� �������
                pictureBox1.Image = map; // �������� �������
                arrpoints.SetPoint(e.X,e.Y); // ������������� �����
            }
        }
    }
}