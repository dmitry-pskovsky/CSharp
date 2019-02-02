using System;
using System.Collections.Generic;
using OpenTK;

namespace Console.Nature
{
	public class OrganismParameters
	{
		public List<Vector2> Points { get; set; }
		
		public OrganismParameters(List<Vector2> points)
		{
			Points = points;
		}
	}
}
