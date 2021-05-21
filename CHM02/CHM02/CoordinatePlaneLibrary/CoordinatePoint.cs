using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinatePoint : ICoordinatePlaneEntity
	{
		public readonly float X, Y;
		public readonly float Size;
		public Color Color;

		#region Constructors
		public CoordinatePoint(float x, float y, float size, Color color)
		{
			X = x;
			Y = y;
			Size = size;
			Color = color;
		}
		public CoordinatePoint(float x, float y, Color color)
		{
			X = x;
			Y = y;
			Size = 5;
			Color = color;
		}
		public CoordinatePoint(float x, float y, float size)
		{
			X = x;
			Y = y;
			Size = size;
			Color = Color.Black;
		}
		public CoordinatePoint(float x, float y)
		{
			X = x;
			Y = y;
			Size = 5;
			Color = Color.Black;
		}
		#endregion

		public virtual void Draw(CoordinatePlane cp, Graphics g) =>
			g.FillEllipse(new SolidBrush(Color), cp.GetScaledX(X) - Size / 2, cp.GetScaledY(Y) - Size / 2, Size, Size);

		public float GetMinX() => X;
		public float GetMaxX() => X;
		public float GetMinY() => Y;
		public float GetMaxY() => Y;
	}
}
