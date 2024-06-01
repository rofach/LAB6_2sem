using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace WinForms3
{
	public partial class Form1 : Form
	{
		int x, y, recWidth = 100, recHeight = 50;
		short rotateAngle = 0;
		Rectangle rect = new Rectangle();
		int moveX = 3;
		public Form1()
		{
			InitializeComponent();
			InitRectangle();
			timer1.Start();
		}

		void InitRectangle()
		{			
			y = ClientSize.Height / 2 - recHeight / 2; 
			x = -recWidth;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{		
			rotateAngle += 10;
			if (rotateAngle < 0) rotateAngle = 0;
			x += moveX;
			y += (int)(Math.Sin(x/(moveX/0.2)) * 10); //( (x+100) / 50) * 10);
			if (x > ClientSize.Width)
				InitRectangle();
			Invalidate();
		}

		void RotateRectangle(Graphics g, Rectangle rect, float angle)
		{
			Matrix m = new Matrix();
			m.RotateAt(angle, new PointF(rect.Left + (rect.Width / 2),
											 rect.Top + (rect.Height / 2)));
			g.Transform = m;

		}
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = CreateGraphics();		
			rect.X = x;
			rect.Y = y;
			rect.Width = recWidth;
			rect.Height = recHeight;
			Point p1 = new Point(100, 100);
			Point p2 = new Point(100, 200);
			Point p3 = new Point(200, 100);
			PointF[] p = new PointF[3] { p1, p2, p3 };
			
			RotateRectangle(g, rect, rotateAngle);			
			g.FillRectangle(Brushes.Blue, rect);
			g.ResetTransform();
			g.FillPolygon(Brushes.Black, p);
		}
	}
}
