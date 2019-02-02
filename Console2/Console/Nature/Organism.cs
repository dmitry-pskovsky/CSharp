using System;
using Console.DisplayObjects;
using Console.Utilities;

namespace Console.Nature
{
	public class Organism
	{
		double square = Double.NaN;
		OrganismParameters parameters;
		
		public double Square 
		{
			get 
			{
				if (Double.IsNaN(square))
				{
					return GeometricalUtilities.GetSquare(parameters.Points);
				}
				else
				{
					return square;
				}
			}
		}
			
		public Organism(OrganismParameters parameters)
		{
			this.parameters = parameters;
		}
		
		public DisplayObject GetDisplayObject()
		{
			GraphicShape graphicShape = new GraphicShape(parameters.Points);
			
			return graphicShape;
		}
		
		
	}
}
