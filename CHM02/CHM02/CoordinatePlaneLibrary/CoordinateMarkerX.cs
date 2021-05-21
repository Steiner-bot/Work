using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinateMarkerX : ICoordinatePlaneEntity
	{
		public float X;
		public float Position;

		public CoordinateMarkerX(float x, float pos = 1)
		{
			X = x;
			Position = pos;
		}

		public void Draw(CoordinatePlane cp, Graphics g)
		{
			var x = cp.GetScaledX(X);
			var y = cp.GetScaledY(0);
			g.DrawLine(Pens.Black, x, y - 5 * Position, x, y + 5 * Position);
			var strform = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
			g.DrawString(X.ToString("0.##"), new Font("Arial", 8), Brushes.Black, x, y - 15 * Position, strform);
		}

		public float GetMinX() => X;
		public float GetMaxX() => X;
		public float GetMinY() => 0;
		public float GetMaxY() => 0;

	}
}
