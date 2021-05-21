using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHM02
{
	public partial class Form1 : Form
	{
		private const float epsilun = 1e-5f;
		private const float h = 1e-3f;

		private Func<float, float, float> f1 = new Func<float, float, float>((x, y) => (float)Math.Sin(x + y) - x*15f);
		private Func<float, float, float> f2 = new Func<float, float, float>((x, y) => (x*x+y*y-1f));

		private Func<float, float, float> f1x = new Func<float, float, float>((x, y) => (float)Math.Cos(x+y)-15f);
		private Func<float, float, float> f1y = new Func<float, float, float>((x, y) => ((float)Math.Cos(x+y)));
		private Func<float, float, float> f2x = new Func<float, float, float>((x, y) => 2f*x);
		private Func<float, float, float> f2y = new Func<float, float, float>((x, y) => 2f*y);

		public Form1()
		{
			InitializeComponent();
			//cp1.SetOxName("Iter");
			//cp1.SetOyName("X");
			//cp2.SetOxName("Iter");
			//cp2.SetOyName("Y");
			//cp1.EnableIntervalMarkersX(1, false);
			//cp2.EnableIntervalMarkersX(1, false);
		}

		public void Calcult(float x1, float y1, out float x, out float y, out PointF[] iters)
		{
			var xn = x1;
			var yn = y1;
			var Iter = new List<PointF>();
			do
			{
				x = xn;
				y = yn;
				Iter.Add(new PointF(x, y));
				var a = GetA(x, y);
				var b = GetB(x, y);
				var c = GetC(x, y);
				var d = GetD(x, y);
				var f = this.f1(x, y);
				var g = this.f2(x, y);
				xn = x - (d * f - b * g) / (a * d - b * c);
				yn = y - (a * g - c * f) / (a * d - b * c);
			} 
			while (Math.Pow(xn - x, 2) + Math.Pow(yn - y, 2) >= epsilun ||
					Math.Sqrt(Math.Pow(f1(xn, yn), 2) + Math.Pow(f2(xn, yn), 2)) >= epsilun);
			x = xn;
			y = yn;
			Iter.Add(new PointF(x, y));
			iters = Iter.ToArray();
		}
		public void CalcultNum(float x1, float y1, out float x, out float y, out PointF[] iters)
		{
			var x0 = x1;
			var y0 = y1;
			var Iter = new List<PointF>();
			do
			{
				x = x0;
				y = y0;
				Iter.Add(new PointF(x, y));
				var a = GetAByNums(x, y);
				var b = GetBByNums(x, y);
				var c = GetCByNums(x, y);
				var d = GetDByNums(x, y);
				var f = this.f1(x, y);
				var g = this.f2(x, y);
				x0 = x - (d * f - b * g) / (a * d - b * c);
				y0 = y - (a * g - c * f) / (a * d - b * c);
			}
			while (Math.Pow(x0 - x, 2) + Math.Pow(y0 - y, 2) >= epsilun ||
					Math.Sqrt(Math.Pow(f1(x0, y0), 2) + Math.Pow(f2(x0, y0), 2)) >= epsilun);
			x = x0;
			y = y0;
			Iter.Add(new PointF(x, y));
			iters = Iter.ToArray();
		}

		public float GetA(float x, float y) => f1x(x, y);
		public float GetB(float x, float y) => f1y(x, y);
		public float GetC(float x, float y) => f2x(x, y);
		public float GetD(float x, float y) => f2y(x, y);
		public float GetAByNums(float x, float y) => (f1(x + h, y) - f1(x, y)) / h;
		public float GetBByNums(float x, float y) => (f1(x, y + h) - f1(x, y)) / h;
		public float GetCByNums(float x, float y) => (f2(x + h, y) - f2(x, y)) / h;
		public float GetDByNums(float x, float y) => (f2(x, y + h) - f2(x, y)) / h;

		private void preEnd(int method)
		{
			float x, y;
			PointF[] points;
			lbLog.Items.Clear();
			//cp1.Clear();
			//cp2.Clear();
			if (method == 1)
			{
				Calcult((float)nudX.Value, (float)nudY.Value, out x, out y, out points);
				lbLog.Items.Add("Производные вычислены вручную");
			}
			else
			{
				CalcultNum((float)nudX.Value, (float)nudY.Value, out x, out y, out points);
				lbLog.Items.Add("Производные вычислены численно");
			}
			var listX = new List<CoordinatePlaneLibrary.CoordinatePoint>();
			var listY = new List<CoordinatePlaneLibrary.CoordinatePoint>();
			for (var i = 0; i < points.Length; i++)
			{
				lbLog.Items.Add("Iteration " + i + ": x = " + points[i].X.ToString("0.######") + "; y = " + points[i].Y.ToString("0.######"));
				listX.Add(new CoordinatePlaneLibrary.CoordinatePoint(i, points[i].X, 10, Color.Green));
				listY.Add(new CoordinatePlaneLibrary.CoordinatePoint(i, points[i].Y, 10, Color.Red));
			}

			//cp1.AddPolyLine(listX.ToArray(), Color.Black, true);
			//cp2.AddPolyLine(listY.ToArray(), Color.Black, true);
			//cp1.AddMarkerY(x);
			//cp2.AddMarkerY(y);
			lbLog.Items.Add("Solve: x = " + x.ToString("0.######") + "; y = " + y.ToString("0.######"));
			lbLog.Items.Add("Iterations Count: " + (points.Length - 1));
		}

		private void btnSolve1_Click(object sender, EventArgs e) => preEnd(1);
		private void btnSolve2_Click(object sender, EventArgs e) =>	preEnd(2);

		private void nudX_ValueChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
