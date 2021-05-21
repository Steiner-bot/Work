using System.Linq;
using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinatePolyline : ICoordinatePlaneEntity
	{
		public readonly CoordinatePoint[] Points;
		public float LineWidth;
		public Color Color;

		private bool drawPoints;

		#region Constructors
		public CoordinatePolyline(CoordinatePoint[] points, Color color, float lineWidth, bool drawPoints = false)
		{
			Points = points;
			Color = color;
			LineWidth = lineWidth;
			this.drawPoints = drawPoints;
		}
		public CoordinatePolyline(CoordinatePoint[] points, Color color, bool drawPoints = false)
		{
			Points = points;
			Color = color;
			LineWidth = 2;
			this.drawPoints = drawPoints;
		}
		public CoordinatePolyline(CoordinatePoint[] points, float lineWidth, bool drawPoints = false)
		{
			Points = points;
			LineWidth = lineWidth;
			Color = Color.Black;
			this.drawPoints = drawPoints;
		}
		public CoordinatePolyline(CoordinatePoint[] points, bool drawPoints = false)
		{
			Points = points;
			Color = Color.Black;
			LineWidth = 2;
			this.drawPoints = drawPoints;
		}
		#endregion

		public void Draw(CoordinatePlane cp, Graphics g)
		{
			if (drawPoints) Points.ToList().ForEach(p => p.Draw(cp, g));
			g.DrawLines(new Pen(Color, LineWidth), Points.Select(p => new PointF(cp.GetScaledX(p.X), cp.GetScaledY(p.Y))).ToArray());
		}

		public float GetMinX() => Points.Min(p => p.X);
		public float GetMaxX() => Points.Max(p => p.X);
		public float GetMinY() => Points.Min(p => p.Y);
		public float GetMaxY() => Points.Max(p => p.Y);
	}
}
