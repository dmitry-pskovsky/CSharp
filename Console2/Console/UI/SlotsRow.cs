using System;
using System.Collections.Generic;
using Console.DisplayObjects;
using OpenTK;

namespace Console.UI
{
	public class SlotsRow : DisplayObject
	{
		const int SIZE = 5;
		
		internal static int RADIUS = 95;
		
		List<ShapeSlot> slots = new List<ShapeSlot>();
		int busySlots = 0;
		float radius;
		
		public SlotsRow(int row = 5, int colum = 1, float scale = 1.0f) 
			: base()
		{
			radius = RADIUS * scale;
			
			ShapeSlot shapeSlot;
			for (int j = 1; j < colum + 1; j++)
			{
				for (int i = 0; i < row; i++)
				{
					 
					shapeSlot = new ShapeSlot(radius, scale);
					slots.Add(shapeSlot);
					if (j%2 == 0)
						shapeSlot.Position = new Vector2(i * (radius - 5) * 2 + radius * 2f,  -(radius * j) - radius);
					else 
						shapeSlot.Position = new Vector2(i * (radius - 5) * 2 + radius, -(radius * j));
					AddChild(shapeSlot);
				}
			}
		}
		
		public void AddShape(DisplayObject displayObject) 
		{
			//if (slots.Count >= SIZE)
				//return;
			
			slots[busySlots].AddContent(displayObject);
			busySlots++;
		}
	}
}
