using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CoordinatePlaneLibrary
{
	public class CoordinatePlane : PictureBox
	{
		public RectangleF ScaledBounds { get; private set; }
		public RectangleF PixelBounds { get; private set; }
		public PointF ScalePoint { get; private set; }

		private BindingList<ICoordinatePlaneEntity> entities = new BindingList<ICoordinatePlaneEntity>();

		private float stepX, stepY;
		private bool withIntervalLinesX, withIntervalLinesY;
		private bool locked;

		private string oxName = "X";
		private string oyName = "Y";

		public CoordinatePlane()
		{
			SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
			DoubleBuffered = true;
			PixelBounds = new RectangleF(30, 30, Width - 60, Height - 60);
			locked = false;
			entities.ListChanged += Entities_ListChanged;
			base.Paint += Update;
			base.SizeChanged += ControlSizeChanged;
		}

		#region Add Elements
		#region Points Adding
		public void AddPoint(CoordinatePoint p) =>
			entities.Add(p);
		public void AddPoint(float x, float y) =>
			entities.Add(new CoordinatePoint(x, y));
		public void AddPoint(float x, float y, Color color) =>
			entities.Add(new CoordinatePoint(x, y, color));
		public void AddPoint(float x, float y, float size, Color color) =>
			entities.Add(new CoordinatePoint(x, y, size, color));
		public void AddPoint(float x, float y, float size) =>
			entities.Add(new CoordinatePoint(x, y, size));
		public void AddPoint(CoordinateNamedPoint p) =>
			entities.Add(p);
		public void AddPoint(float x, float y, string name, int namePos = 1) =>
			entities.Add(new CoordinateNamedPoint(x, y, name, namePos));
		public void AddPoint(float x, float y, Color color, string name, int namePos = 1) =>
			entities.Add(new CoordinateNamedPoint(x, y, color, name, namePos));
		public void AddPoint(float x, float y, float size, Color color, string name, int namePos = 1) =>
			entities.Add(new CoordinateNamedPoint(x, y, size, color, name, namePos));
		public void AddPoint(float x, float y, float size, string name, int namePos = 1) =>
			entities.Add(new CoordinateNamedPoint(x, y, size, name, namePos));
		#endregion
		#region Lines Adding
		public void AddLine(CoordinateLine l) =>
			entities.Add(l);
		public void AddLine(CoordinatePoint p1, CoordinatePoint p2, bool drawPoints = false) =>
			entities.Add(new CoordinateLine(p1, p2, drawPoints));
		public void AddLine(CoordinatePoint p1, CoordinatePoint p2, Color color, bool drawPoints = false) =>
			entities.Add(new CoordinateLine(p1, p2, color, drawPoints));
		public void AddLine(CoordinatePoint p1, CoordinatePoint p2, Color color, float lineWidth, bool drawPoints = false) =>
			entities.Add(new CoordinateLine(p1, p2, color, lineWidth, drawPoints));
		public void AddLine(CoordinatePoint p1, CoordinatePoint p2, float lineWidth, bool drawPoints = false) =>
			entities.Add(new CoordinateLine(p1, p2, lineWidth, drawPoints));

		public void AddPolyLine(CoordinatePolyline l) =>
			entities.Add(l);
		public void AddPolyLine(CoordinatePoint[] points, bool drawPoints = false) =>
			entities.Add(new CoordinatePolyline(points, drawPoints));
		public void AddPolyLine(CoordinatePoint[] points, Color color, bool drawPoints = false) =>
			entities.Add(new CoordinatePolyline(points, color, drawPoints));
		public void AddPolyLine(CoordinatePoint[] points, Color color, float lineWidth, bool drawPoints = false) =>
			entities.Add(new CoordinatePolyline(points, color, lineWidth, drawPoints));
		public void AddPolyLine(CoordinatePoint[] points, float lineWidth, bool drawPoints = false) =>
			entities.Add(new CoordinatePolyline(points, lineWidth, drawPoints));
		#endregion
		#region Vectors Adding
		public void AddVector(CoordinateVector v) =>
			entities.Add(v);
		public void AddVector(CoordinatePoint p1, CoordinatePoint p2, string name = "") =>
			entities.Add(new CoordinateVector(p1, p2, name));
		public void AddVector(CoordinatePoint p1, CoordinatePoint p2, Color color, string name = "") =>
			entities.Add(new CoordinateVector(p1, p2, color, name));
		public void AddVector(CoordinatePoint p1, CoordinatePoint p2, Color color, float lineWidth, string name = "") =>
			entities.Add(new CoordinateVector(p1, p2, color, lineWidth, name));
		public void AddVector(CoordinatePoint p1, CoordinatePoint p2, float lineWidth, string name = "") =>
			entities.Add(new CoordinateVector(p1, p2, lineWidth, name));
		#endregion
		#region Markers Adding
		public void AddMarkerX(CoordinateMarkerX m) =>
			entities.Add(m);
		public void AddMarkerX(float x, float pos = 1) =>
			entities.Add(new CoordinateMarkerX(x, pos));
		public void AddMarkerY(CoordinateMarkerY m) =>
			entities.Add(m);
		public void AddMarkerY(float y, float pos = 1) =>
			entities.Add(new CoordinateMarkerY(y, pos));
		public void AddMarker(CoordinateMarkerX mx, CoordinateMarkerY my)
		{
			entities.Add(mx);
			entities.Add(my);
		}
		public void AddMarker(float x, float y, float posX = 1, float posY = 1)
		{
			entities.Add(new CoordinateMarkerX(x, posX));
			entities.Add(new CoordinateMarkerY(y, posY));
		}
		#endregion
		#endregion

		#region Interval Markers & Lines
		public void EnableIntervalMarkers(int xStep, int yStep, bool withLinesX, bool withLinesY)
		{
			EnableIntervalMarkersX(xStep, withLinesX);
			EnableIntervalMarkersY(yStep, withLinesY);
		}
		public void EnableIntervalMarkersX(int xStep, bool withLines)
		{
			if (xStep > 0) { stepX = xStep; withIntervalLinesX = withLines; }
		}
		public void EnableIntervalMarkersY(int yStep, bool withLines)
		{
			if (yStep > 0) { stepY = yStep; withIntervalLinesY = withLines; }
		}
		public void DisableIntervalMarkers() => stepX = stepY = 0;
		#endregion

		public void LockUpdate() => locked = true;
		public void UnlockUpdate() => locked = false;

		public void SetOxName(string name)
		{
			if (name != "")
			{
				oxName = name;
				Refresh();
			}
		}
		public void SetOyName(string name)
		{
			if (name != "")
			{
				oyName = name;
				Refresh();
			}
		}

		public void Clear() => entities.Clear();

		public float GetScaledX(float x) => PixelBounds.Left + ScalePoint.X * (x - ScaledBounds.Left);
		public float GetScaledY(float y) => PixelBounds.Top + ScalePoint.Y * (ScaledBounds.Bottom - y);

		private void Update(object sender, PaintEventArgs args)
		{
			if (entities.Count <= 0 || locked) return;

			var g = args.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

			var minX = Math.Min(0, entities.Min(e => e.GetMinX()));
			var maxX = Math.Max(0, entities.Max(e => e.GetMaxX()));
			var minY = Math.Min(0, entities.Min(e => e.GetMinY()));
			var maxY = Math.Max(0, entities.Max(e => e.GetMaxY()));

			var width = maxX - minX;
			var height = maxY - minY;

			ScaledBounds = new RectangleF(minX - width / 10, minY - height / 10, width + width / 5, height + height / 5);
			ScalePoint = new PointF(PixelBounds.Width / ScaledBounds.Width, PixelBounds.Height / ScaledBounds.Height);

			DrawIntervals(g);

			new CoordinateNamedPoint(0, 0, "0").Draw(this, g);
			new CoordinateVector(new CoordinatePoint(ScaledBounds.Left, 0), new CoordinatePoint(ScaledBounds.Right, 0), oxName).Draw(this, g);
			new CoordinateVector(new CoordinatePoint(0, ScaledBounds.Top), new CoordinatePoint(0, ScaledBounds.Bottom), oyName).Draw(this, g);

			entities.ToList().ForEach(e => e.Draw(this, g));
		}

		private void DrawIntervals(Graphics g)
		{
			DrawIntervalsX(g);
			DrawIntervalsY(g);
		}
		private void DrawIntervalsX(Graphics g)
		{
			if (stepX <= 0) return;
			for (var x = stepX; x < ScaledBounds.Right; x += stepX)
			{
				new CoordinateMarkerX(x, 1).Draw(this, g);
				if (withIntervalLinesX)
					new CoordinateLine(
						new CoordinatePoint(x, ScaledBounds.Top),
						new CoordinatePoint(x, ScaledBounds.Bottom),
						Color.FromArgb(40, 0, 0, 0), 1).Draw(this, g);
			}
			for (var x = -stepX; x > ScaledBounds.Left; x -= stepX)
			{
				new CoordinateMarkerX(x, -1).Draw(this, g);
				if (withIntervalLinesX)
					new CoordinateLine(
						new CoordinatePoint(x, ScaledBounds.Top),
						new CoordinatePoint(x, ScaledBounds.Bottom),
						Color.FromArgb(40, 0, 0, 0), 1).Draw(this, g);
			}
		}
		private void DrawIntervalsY(Graphics g)
		{
			if (stepY <= 0) return;

			for (var y = stepY; y < ScaledBounds.Bottom; y += stepY)
			{ 
				new CoordinateMarkerY(y, 1).Draw(this, g);
				if (withIntervalLinesY)
					new CoordinateLine(
						new CoordinatePoint(ScaledBounds.Left, y),
						new CoordinatePoint(ScaledBounds.Right, y),
						Color.FromArgb(40, 0, 0, 0), 1).Draw(this, g);
			}
			for (var y = -stepY; y > ScaledBounds.Top; y -= stepY)
			{
				new CoordinateMarkerY(y, -1).Draw(this, g);
				if (withIntervalLinesY)
					new CoordinateLine(
						new CoordinatePoint(ScaledBounds.Left, y),
						new CoordinatePoint(ScaledBounds.Right, y),
						Color.FromArgb(40, 0, 0, 0), 1).Draw(this, g);
			}
		}
		private void ControlSizeChanged(object sender, EventArgs e)
		{
			PixelBounds = new RectangleF(20, 20, Width - 40, Height - 40);
			Refresh();
		}
		private void Entities_ListChanged(object sender, ListChangedEventArgs e) =>
			Refresh();
	}
}