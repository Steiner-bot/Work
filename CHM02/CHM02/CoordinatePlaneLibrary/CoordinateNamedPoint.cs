using System.Drawing;
namespace CoordinatePlaneLibrary
{
	public class CoordinateNamedPoint : CoordinatePoint
	{
		public string Name;
		private int namePos;
		public CoordinateNamedPoint(float x, float y, string name, int namePos = 1) : base(x, y) 
		{ Name = name; this.namePos = namePos; }
		public CoordinateNamedPoint(float x, float y, Color color, string name, int namePos = 1) : base(x, y, color)
		{ Name = name; this.namePos = namePos; }
		public CoordinateNamedPoint(float x, float y, float size, string name, int namePos = 1) : base(x, y, size)
		{ Name = name; this.namePos = namePos; }
		public CoordinateNamedPoint(float x, float y, float size, Color color, string name, int namePos = 1) : base(x, y, size, color) 
		{ Name = name; this.namePos = namePos; }

		public override void Draw(CoordinatePlane cp, Graphics g)
		{
			base.Draw(cp, g);
			if (Name == "") return;
			var strform = new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
			if (namePos == 1 || namePos == 2)
				strform.Alignment = StringAlignment.Near;
			g.DrawString(Name, new Font("Arial", 10), Brushes.Black,
				cp.GetScaledX(X) + (namePos == 1 || namePos == 2 ? 10 : -10),
				cp.GetScaledY(Y) + (namePos == 2 || namePos == 3 ? 10 : -10), strform);
		}
	}
}
