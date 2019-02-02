using System;
using System.Collections.Generic;
using Console.Utilities;
using OpenTK;
using Console.DisplayObjects;

namespace Console
{
	public class GraphicShape : DisplayObject
	{
		List<Vector2> points = new List<Vector2>();
		
		public GraphicShape(List<Vector2> points)
			: base()
		{
			this.Position = Vector2.Zero;
			this.points = points;
		}
		
		public GraphicShape(List<Vector2> points, Vector2 position)
			: base()
		{
			this.Position = position;
			this.points = points;
		}
		
		private void Draw()
		{
			GraphicUtilities.DrawShape(points, PositionOnScreen, 0.5f);
		}
		
		override public void Update()
		{
			base.Update();
			
			Draw();
		}
	}
}
