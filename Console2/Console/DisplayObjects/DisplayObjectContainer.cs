using System;
using System.Collections.Generic;

namespace Console.DisplayObjects
{

	public class DisplayObjectContainer
	{
		private static List<DisplayObject> children  = new List<DisplayObject>();
		private static int numChildren = 0;
		
		public DisplayObjectContainer()
		{
			
		}
		
		public static void RegisterDisplayObject(DisplayObject displayObject)
		{
			children.Add(displayObject);
			numChildren = children.Count;
		}
		
		public static void UnRegisterDisplayObject(DisplayObject displayObject)
		{
			children.Remove(displayObject);
			numChildren = children.Count;
		}
		
		public static void Update()
		{
			for (int i = 0; i < numChildren; i++)
			{
				children[i].Update();
			}
		}
	}
}
