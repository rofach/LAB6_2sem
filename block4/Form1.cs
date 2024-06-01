using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace block4
{
	public partial class Form1 : Form
	{
		int x = -160;
		public Form1()
		{
			InitializeComponent();
			timer1.Start();
		}
		

		private void timer1_Tick(object sender, EventArgs e)
		{
			x += 5;
			if(x-250 > ClientSize.Width)
			{
				x = -200;
			}
			Invalidate();
			
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Random rand = new Random();
			base.OnPaint(e);
			Graphics g = CreateGraphics();
			Point railBegin = new Point(0, ClientSize.Height / 2);
			Point railEnd = new Point(Width, ClientSize.Height / 2);

			
			// rails
			g.DrawLine(new Pen(Color.Gray, 5), railBegin, railEnd);		
			for(int i = 0; i < ClientSize.Width/20; i++)
				g.FillRectangle(Brushes.DarkGray, i * 40, ClientSize.Height / 2, 10, 10);

			// train
			g.FillRectangle(Brushes.Gray, x - 55, ClientSize.Height / 2 - 22, 50, 10);
			g.FillRectangle(Brushes.DarkRed, x - 15, ClientSize.Height / 2 - 60, 200, 50);
			g.FillRectangle(Brushes.DarkRed, x - 250, ClientSize.Height / 2 - 60, 200, 50);

			//wheels
			for (int i = 0; i < 4; i++)
				g.FillEllipse(Brushes.Black, x - 235 + 50 * i, ClientSize.Height / 2 - 20, 20, 20);
			
			for (int i = 0; i < 4; i++)
				g.FillEllipse(Brushes.Black, x + 50 * i, ClientSize.Height/2 - 20, 20, 20);

			// windows
			for (int i = 0; i < 4; i++)
				g.FillRectangle(Brushes.White, x - 235 + 50 * i, ClientSize.Height / 2 - 50, 20, 20);
			for (int i = 0; i < 4; i++)
				g.FillRectangle(Brushes.White, x + 50 * i, ClientSize.Height / 2 - 50, 20, 20);

			// tube
			g.FillRectangle(Brushes.Blue, x + 170, ClientSize.Height / 2 - 90, 10, 30);

			// smoke
			for(int i = 0, xt = x, yt = ClientSize.Height / 2 - 100; i < 30;
				i++, xt -= 5, yt -= 3 - (i/10))
			{
				g.FillEllipse(Brushes.Black, xt + 170 + rand.Next(-10, 10), yt - rand.Next(-10*(i/10), 5*(i/10)),6, 6);		
			}
		}
	}
}
