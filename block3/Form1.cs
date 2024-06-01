using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace block3
{
	public partial class Form1 : Form
	{
		PointF[] rectPoints = new PointF[4];
		PointF[] transformedPoints = new PointF[4];
		int recWidth = 50, recHeight = 50;
		int x0, y0;
		int moveX = 3;
		int moveY;
		double angle = 10;	
		public Form1()
		{
			InitializeComponent();
			InitRectangle();
			timer1.Start();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			angle += 10;
			x0 += moveX;
			moveY = (int)(Math.Sin(x0/(moveX/0.2))*10);
			y0 += moveY;
			for (int i = 0; i < rectPoints.Length; i++)
			{
				rectPoints[i].X += moveX;
				rectPoints[i].Y += moveY;
			}
			if(x0 - Math.Max(recWidth/2, recHeight/2) > ClientSize.Width)
			{
				InitRectangle();
			}
			Invalidate();
		}
		private PointF RotatePoint(PointF point, double angle)
		{
			angle = angle * Math.PI / 180;
			double ssin = Math.Sin(angle);
			double scos = Math.Cos(angle);
			return new PointF(
				(float)(x0 + (point.X - x0) * scos - (point.Y - y0) * ssin),
				(float)(y0 + (point.X - x0) * ssin + (point.Y - y0) * scos)
			); 
		}
		void InitRectangle()
		{
			rectPoints[0] = new Point(-recWidth, ClientSize.Height / 2 - recHeight+ recHeight/2);
			rectPoints[1] = new Point(-recWidth, ClientSize.Height / 2 + recHeight/2);
			rectPoints[2] = new Point(0, ClientSize.Height / 2 + recHeight/2);
			rectPoints[3] = new Point(0, ClientSize.Height / 2 - recHeight + recHeight/2);
			x0 = (int)((rectPoints[0].X + rectPoints[3].X) / 2);
			y0 = (int)((rectPoints[0].Y + rectPoints[1].Y) / 2);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			
			Graphics g = CreateGraphics();
			
			for (int i = 0; i < rectPoints.Length; i++)
			{
				transformedPoints[i] = RotatePoint(rectPoints[i], angle);
			}
			g.FillPolygon(Brushes.Red, transformedPoints);
			//g.FillPolygon(Brushes.Green, rectPoints);
			//g.DrawLine(Pens.Blue, transformedPoints[0], transformedPoints[2]);
			//g.FillEllipse(Brushes.Black, x0-5, y0-5,10, 10);
		}
	}
}
