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
            private Point[] points; //массив точек

            public ArrPoints(int size)
            {
                points = new Point[size]; // новый массив точек
            }
            public void SetPoint(int x, int y) // ставит точку
            {
                if(index >= points.Length) // если индекс выходит за границы 
                {
                    index = 0;
                }
                points[index] = new Point(x, y); // присваивание точки
                index++;
            }
            public void ResetPoint()
            {
                index = 0; //сброс индекса 
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

        Bitmap map = new Bitmap(100, 100); // храненине изображения
        Graphics graphics;

        Pen pen = new Pen(Color.Red, 6f);

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds; // размер экрана
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
            arrpoints.ResetPoint(); // для новой линии
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!mouse) { return; }

            arrpoints.SetPoint(e.X, e.Y); // берёт координаты мыши
            if(arrpoints.GetCount() >= 2)
            {
                graphics.DrawLines(pen,arrpoints.GetPoints()); // заполнение точками
                pictureBox1.Image = map; // передача рисунка
                arrpoints.SetPoint(e.X,e.Y); // непрерывистая линия
            }
        }
    }
}