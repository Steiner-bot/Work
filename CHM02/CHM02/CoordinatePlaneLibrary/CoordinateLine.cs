using System;
using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinateLine : ICoordinatePlaneEntity
	{
		public readonly CoordinatePoint P1, P2;
		public float LineWidth;
		public Color Color;

		private bool drawPoints;

		#region Constructors
		public CoordinateLine(CoordinatePoint p1, CoordinatePoint p2, Color color, float lineWidth, bool drawPoints = false)
		{
			P1 = p1;
			P2 = p2;
			Color = color;
			LineWidth = lineWidth;
			this.drawPoints = drawPoints;
		}
		public CoordinateLine(CoordinatePoint p1, CoordinatePoint p2, Color color, bool drawPoints = false)
		{
			P1 = p1;
			P2 = p2;
			Color = color;
			LineWidth = 2;
			this.drawPoints = drawPoints;
		}
		public CoordinateLine(CoordinatePoint p1, CoordinatePoint p2, float lineWidth, bool drawPoints = false)
		{
			P1 = p1;
			P2 = p2;
			LineWidth = lineWidth;
			Color = Color.Black;
			this.drawPoints = drawPoints;
		}
		public CoordinateLine(CoordinatePoint p1, CoordinatePoint p2, bool drawPoints = false)
		{
			P1 = p1;
			P2 = p2;
			Color = Color.Black;
			LineWidth = 2;
			this.drawPoints = drawPoints;
		}
		#endregion

		public void Draw(CoordinatePlane cp, Graphics g)
		{
			if (drawPoints) { P1.Draw(cp, g); P2.Draw(cp, g); }
			g.DrawLine(new Pen(Color, LineWidth), cp.GetScaledX(P1.X), cp.GetScaledY(P1.Y), cp.GetScaledX(P2.X), cp.GetScaledY(P2.Y));
		}

		public float GetMinX() => Math.Min(P1.X, P2.X);
		public float GetMaxX() => Math.Max(P1.X, P2.X);
		public float GetMinY() => Math.Min(P1.Y, P2.Y);
		public float GetMaxY() => Math.Max(P1.Y, P2.Y);

	}
}
