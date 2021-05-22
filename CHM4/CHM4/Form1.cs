using System;
using System.Windows.Forms;

namespace CHM4
{
	public delegate float Function(float x);
	public partial class Form1 : Form
	{
		private float Eps = 0.00001f;
		private float[] interval = { 0, (float)Math.PI/4 };
		private Function F =
			x => (float)Math.Log(Math.Cos(x), Math.E);
		public Form1()
		{
			InitializeComponent();
			lblT1.Text = TrapezoidMethodSolving.SolveWithEpsAndExtrapolate(F, interval, Eps, 1, out 
				var wT, out var nT).ToString("0.000000");
			lblS1.Text = SimpsonMethodSolving.SolveWithEpsAndExtrapolate(F, interval, Eps, 6, out 
				var wS, out var nS).ToString("0.000000");
			lblT2.Text = wT.ToString("0.000000");
			lblS2.Text = wS.ToString("0.000000");
			lblTN.Text = nT.ToString();
			lblSN.Text = nS.ToString();
		}
	}
}
