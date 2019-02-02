using System;
using System.Collections.Generic;
using System.Drawing;
using Console.DisplayObjects;
using Console.Utilities;
using OpenTK;

namespace Console.UI
{
	public class ShapeSlot : DisplayObject
	{
		List<Vector2> points = new List<Vector2>();
		DisplayObject content;
		
		float size = 150f;
		float shift = 1f;
		float scale;
		
		public ShapeSlot(float radius, float scale = 1.0f) 
			:base()
		{
			for (int i = 90; i <= 450; i+=60)
			{
				double degInRad = i * 3.1416/180;
				float t = (float)(Math.Cos(degInRad) * radius);
				points.Add(new Vector2((float)(Math.Cos(degInRad) * radius), (float)(Math.Sin(degInRad) * radius)));
			}
			
			for (int i = 90; i <= 450; i+=60)
			{
				double degInRad = i * 3.1416/180;
				float t = (float)(Math.Cos(degInRad) * (radius + 3));
				points.Add(new Vector2((float)(Math.Cos(degInRad) * (radius + 3)), (float)(Math.Sin(degInRad) * (radius + 3))));
			}
		}
		
		public void AddContent(DisplayObject content)
		{
			this.content = content;
			content.Position = PositionOnScreen;
		}
		
		private void Draw()
		{
			Color color = GraphicUtilities.GetColorFromHEX("#a7a7a7");
			GraphicUtilities.DrawLine(points[0], points[1], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[1], points[2], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[2], points[3], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[3], points[4], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[4], points[5], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[5], points[6], PositionOnScreen, color);
			GraphicUtilities.DrawLine(points[6], points[0], PositionOnScreen, color);
			
			color = GraphicUtilities.GetColorFromHEX("#00b40d");
			GraphicUtilities.DrawLine(points[7], points[8], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[8], points[9], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[9], points[10], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[10], points[11], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[11], points[12], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[12], points[13], PositionOnScreen, color, 0.2f);
			GraphicUtilities.DrawLine(points[13], points[0], PositionOnScreen, color, 0.2f);
		}
		
		override public void Update()
		{
			base.Update();
			
			Draw();
			
			if (content != null)
				content.Position = PositionOnScreen;
		}
	}
}
