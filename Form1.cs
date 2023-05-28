namespace Rectangle
{
    public partial class Form1 : Form
    {
        Point start;
        Point end;
        Size size = new Size(10, 10);
        int count = 0;
        //private Label label1;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            end.X = e.X;
            end.Y = e.Y;
            if (start.X > end.X || start.Y > end.Y)
            {
                Point temp = start;
                start = end;
                end = temp;
            }
            Label rectangle = new Label();
            rectangle.Location = new Point(Math.Abs(start.X), Math.Abs(start.Y));
            rectangle.Width = Math.Abs(start.X - end.X);
            rectangle.Height = Math.Abs(start.Y - end.Y);
            rectangle.Name = $"{count++}";
            if (rectangle.Size.Width<size.Width || rectangle.Size.Height<size.Height)
            {
                MessageBox.Show("Minimum 10x10 olcude ola biler!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Controls.Add(rectangle);
                rectangle.BorderStyle = BorderStyle.Fixed3D;
                rectangle.BackColor = Color.Yellow;
                rectangle.MouseClick += Label_MouseClick;
                rectangle.MouseDoubleClick += Label_MouseDoubleClick;

            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start.X = e.X;
                start.Y = e.Y;
            }


        }
        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            Label clickedLabel = (Label)sender;
            string labelInfo = $"Text: {clickedLabel.Text}   Name: {clickedLabel.Name}  Location: {clickedLabel.Location} Size: {clickedLabel.Size}";
            Text = labelInfo;
        }
        private void Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label clickedLabel = (Label)sender;
            clickedLabel.Dispose();
            Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}