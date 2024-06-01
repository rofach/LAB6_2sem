using System.Net.NetworkInformation;

namespace WinForms2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			BackColor = Color.LightBlue;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{

			Graphics g = CreateGraphics();


			int width = Size.Width;
			int height = Size.Height;

			Point leftBottom = new Point(0, height);
			Point rightBottom = new Point(width, height);

			// points for the front hill
			Point p1 = new Point(width, height - 10);
			Point p2 = new Point(width / 2, (int)(height * 0.8));
			Point p3 = new Point(0, height - 10);
			Point[] hillPoints = new Point[3] { p1, p2, p3 };

			// points for the first back hill
			Point p4 = new Point(width / 4, (int)(height * 0.7));
			Point[] hillPoints2 = new Point[3] { leftBottom, p4, rightBottom };

			// points for the second back hill
			Point p5 = new Point((int)(width * 0.8), (int)(height * 0.6));
			Point[] hillPoints3 = new Point[3] { leftBottom, p5, rightBottom };

			//mountain1 points
			Point apex1 = leftBottom;
			Point apex2 = new(width / 4, height / 4);
			Point apex3 = new(width / 2, height);
			PointF[] trianglePoints1 = new PointF[] { apex1, apex2, apex3 };

			//mountain2 points
			Point apex4 = new(width / 5, height);
			Point apex5 = new((width / 5 + width)/2, height / 5);
			Point apex6 = new(width, height);
			PointF[] trianglePoints2 = new PointF[] { apex4, apex5, apex6 };
			
			Point apex7 = new(width / 5 + 245, height - 300);
			Point apex8 = new(width - 245, height - 300);
			PointF[] trianglePoints3 = new PointF[] { apex7, apex5, apex8 };

			//tree leaves
			var tr1 = new Point(675, 260);
			var tr2 = new Point(705, 200);
			var tr3 = new Point(735, 260);
			PointF[] treeLeaves = new PointF[3] { tr1, tr2, tr3 };

			//cloud
			Point cp1 = new(120, 140);
			Point cp2 = new(140, 120);
			Point cp3 = new(160, 130);
			Point cp4 = new(180, 120);
			Point cp5 = new(200, 140);
			Point[] cloudPoints = new Point[5] { cp1,cp2,cp3,cp4,cp5};
			
			// draw objects in reverse order
			g.FillPolygon(Brushes.DarkSlateGray, trianglePoints2);
			g.FillPolygon(Brushes.Gray, trianglePoints1);
			g.FillPolygon(Brushes.White, trianglePoints3);
			g.FillClosedCurve(Brushes.DarkOliveGreen, hillPoints3);
			g.FillClosedCurve(Brushes.GreenYellow, hillPoints2);
			g.FillClosedCurve(Brushes.Green, hillPoints);
			g.FillEllipse(Brushes.Yellow, new Rectangle(width - 100, 0, 100, 100));
			g.FillClosedCurve(Brushes.White, cloudPoints);

			g.FillRectangle(Brushes.Brown, 700, 230, 10, 100);
			g.FillPolygon(Brushes.Green, treeLeaves);
			//g.FillPie(Brushes.Green, new Rectangle(0, height-100, width, height / 2), 180, 180);
		}
	}
}