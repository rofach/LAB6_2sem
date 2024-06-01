using System.Drawing.Drawing2D;

namespace WinForms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = CreateGraphics();
			
			g.DrawPie(new Pen(Color.Black, 3), new Rectangle(0, 50, 200, 100), 0, 90);

			g.DrawRectangle(Pens.Black, new Rectangle(50, 300, 100, 100));
						
			Point p1 = new(300, 200);
			Point p2 = new(400, 100);
			Point p3 = new(500, 200);
			PointF[] points = new PointF[] { p1, p2, p3 };
			g.FillPolygon(Brushes.Black, points);


			Rectangle rect = new Rectangle(300, 200, 200, 200);
			GraphicsPath circleSegment = new GraphicsPath();
			circleSegment.AddArc(rect, 0, 120);
			PointF startPoint = GetPointOnCircle(rect, 0);
			PointF endPoint = GetPointOnCircle(rect, 120);
			circleSegment.AddLine(startPoint, endPoint);
			circleSegment.CloseFigure();

			g.DrawPath(Pens.Black, circleSegment);

		}
		private PointF GetPointOnCircle(Rectangle rect, float angle)
		{
			float radius = rect.Width / 2;
			float centerX = rect.X + radius;
			float centerY = rect.Y + radius;

			float x = centerX + radius * (float)Math.Cos(angle * (float)Math.PI / 180);
			float y = centerY + radius * (float)Math.Sin(angle * (float)Math.PI / 180);

			return new PointF(x, y);
		}
	}
}