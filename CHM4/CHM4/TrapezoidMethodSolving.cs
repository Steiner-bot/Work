using System;

namespace CHM4
{
	public static class TrapezoidMethodSolving
	{
		public static float Solve(Function f, float[] interval, int n)
		{
			if (n < 1) return 0;
			var a = interval[0];
			var b = interval[1];

			var sum = 0f;
			var h = (b - a) / n;
			var x = a;
			for (var i = 1; i < n; i++)
			{
				x += h;
				sum += f(x);
			}
			return h * ((f(a) + f(b)) / 2 + sum);
		}
		public static float SolveWithEps(Function f, float[] interval, float eps, int startN, out int n)
		{
			n = startN;
			var f1 = Solve(f, interval, n);
			while (true)
			{
				n *= 2;
				var f2 = Solve(f, interval, n);
				if (Math.Abs(f2 - f1) < eps) return f2;
				f1 = f2;
			}
		}
		public static float SolveWithEpsAndExtrapolate(Function f, float[] interval, float eps, int startN, out float withoutExtrapolation, out int n)
		{
			n = startN;
			var f1 = Solve(f, interval, n);
			var h1 = (interval[1] - interval[0]) / n; 
			while (true)
			{
				n *= 2;
				var f2 = Solve(f, interval, n);
				var h2 = (interval[1] - interval[0]) / n;
				if (Math.Abs(f2 - f1) < eps)
				{
					withoutExtrapolation = f2;
					return (f2 * (h1 / h2).Pow(2) - f1) / ((h1 / h2).Pow(2) - 1);
				}
				f1 = f2;
				h1 = h2;
			}
		}
	}
}
