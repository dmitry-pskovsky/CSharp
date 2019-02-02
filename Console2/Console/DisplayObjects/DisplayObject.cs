using System;
using OpenTK;
using System.Collections.Generic;

namespace Console.DisplayObjects
{
	public class DisplayObject
	{
		public Vector2 Position { get; set; }
		public Vector2 PositionOnScreen {get; set; }
		public Vector2 Width {get; set;}
		public Vector2 Height {get; set;}
		
		DisplayObject parent;
			
		public DisplayObject()
		{
			DisplayObjectContainer.RegisterDisplayObject(this);
		}
		
		public void AddChild(DisplayObject displayObject)
		{
			displayObject.parent = this;
		}
		
		public void removeChild(DisplayObject displayObject)
		{
			displayObject.parent = null;
		}
		
		public virtual void Update()
		{
			PositionOnScreen = GetThisPositionOnScreen();
		}
		
		public Vector2 GetThisPositionOnScreen()
		{
			if (parent != null)
				return parent.GetThisPositionOnScreen() + Position;
			else
				return Position;
		}
	}
}
