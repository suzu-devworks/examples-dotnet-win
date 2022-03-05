using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Examples.WinForms.Controls
{
    public partial class PaintPictureBox : UserControl
    {
        public PaintPictureBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (current == Point.Empty)
            {
                return;
            }

            var size = new Size(100, 100);

            var rectangle = new Rectangle(
                current.X - (size.Height / 2),
                current.Y - (size.Width / 2),
                size.Height,
                size.Width);

            var graphics = e.Graphics;
            //using var brush = new SolidBrush(Color.Blue);
            using var brush = new LinearGradientBrush(rectangle, Color.AliceBlue, Color.DarkSlateBlue, LinearGradientMode.BackwardDiagonal);
            brush.GammaCorrection = true;

            graphics.FillEllipse(brush, rectangle);
            return;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == Point.Empty)
            {
                current = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private Point current;

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            current = Point.Empty;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (current == Point.Empty)
            {
                return;
            }

            var size = new Size(50, 50);

            var rectangle = new Rectangle(
                current.X - (size.Height / 2),
                current.Y - (size.Width / 2),
                size.Height,
                size.Width);

            if (rectangle.Contains(e.Location))
            {
                return;
            }

            current = e.Location;
            pictureBox1.Invalidate();

        }
    }
}
