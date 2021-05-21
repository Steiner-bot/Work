using System.Drawing;

namespace CoordinatePlaneLibrary
{
	public class CoordinateMarkerY : ICoordinatePlaneEntity
	{
		public float Y;
		public float Position;

		public CoordinateMarkerY(float y, float pos = 1)
		{
			Y = y;
			Position = pos;
		}

		public void Draw(CoordinatePlane cp, Graphics g)
		{
			var x = cp.GetScaledX(0);
			var y = cp.GetScaledY(Y);
			g.DrawLine(Pens.Black, x - 5 * Position, y, x + 5 * Position, y);
			var strform = new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
			if (Position < 0)
				strform.Alignment = StringAlignment.Far;
			g.DrawString(Y.ToString("0.##"), new Font("Arial", 8), Brushes.Black, x + 5 * Position + (Position > 0 ? 5 : -5), y, strform);
		}

		public float GetMinX() => 0;
		public float GetMaxX() => 0;
		public float GetMinY() => Y;
		public float GetMaxY() => Y;

	}
}
