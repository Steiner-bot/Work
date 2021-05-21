using System;
using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinateVector : ICoordinatePlaneEntity
	{
		public readonly CoordinatePoint From, To;
		public string Name;
		public float LineWidth;
		public Color Color;

		#region Constructors
		public CoordinateVector(CoordinatePoint from, CoordinatePoint to, Color color, float lineWidth, string name = "")
		{
			From = from;
			To = to;
			Color = color;
			LineWidth = lineWidth;
			Name = name;
		}
		public CoordinateVector(CoordinatePoint from, CoordinatePoint to, Color color, string name = "")
		{
			From = from;
			To = to;
			Color = color;
			LineWidth = 2;
			Name = name;
		}
		public CoordinateVector(CoordinatePoint from, CoordinatePoint to, float lineWidth, string name = "")
		{
			From = from;
			To = to;
			LineWidth = lineWidth;
			Color = Color.Black;
			Name = name;
		}
		public CoordinateVector(CoordinatePoint from, CoordinatePoint to, string name = "")
		{
			From = from;
			To = to;
			Color = Color.Black;
			LineWidth = 2;
			Name = name;
		}
		#endregion

		public void Draw(CoordinatePlane cp, Graphics g)
		{
			var fromScaled = new PointF(cp.GetScaledX(From.X), cp.GetScaledY(From.Y));
			var toScaled = new PointF(cp.GetScaledX(To.X), cp.GetScaledY(To.Y));
			var pen = new Pen(Color, LineWidth);

			g.DrawLine(pen, fromScaled.X, fromScaled.Y, toScaled.X, toScaled.Y);

			var v0 = new PointF(toScaled.X - fromScaled.X, toScaled.Y - fromScaled.Y);
			var c = (float)Math.Sqrt(Math.Pow(v0.X, 2) + Math.Pow(v0.Y, 2));
			var normalized = new PointF(v0.Y / c, v0.X / c);
			var a1 = new PointF((float)Math.Sin(Math.Asin(normalized.Y) + Math.PI / 8), (float)Math.Cos(Math.Acos(normalized.X) + Math.PI / 8));
			var a2 = new PointF((float)Math.Sin(Math.Asin(normalized.Y) - Math.PI / 8), (float)Math.Cos(Math.Acos(normalized.X) - Math.PI / 8));
			g.DrawLines(pen,
				new[]
				{
					new PointF(toScaled.X - a1.X * 10, toScaled.Y - a1.Y * 10),
					new PointF(toScaled.X, toScaled.Y),
					new PointF(toScaled.X - a2.X * 10, toScaled.Y - a2.Y * 10)
				});
			if (Name != "")
				g.DrawString(Name, new Font("Arial", 8), Brushes.Black, new RectangleF(toScaled.X, toScaled.Y - 20, 20, 20));
		}

		public float GetMinX() => Math.Min(From.X, To.X);
		public float GetMaxX() => Math.Max(From.X, To.X);
		public float GetMinY() => Math.Min(From.Y, To.Y);
		public float GetMaxY() => Math.Max(From.Y, To.Y);
	}
}
