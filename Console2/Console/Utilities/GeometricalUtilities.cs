using System;
using System.Collections.Generic;
using OpenTK;

namespace Console.Utilities
{
	public class GeometricalUtilities
	{
		public GeometricalUtilities()
		{
			
		}
		
		
		static public double GetSquare(List<Vector2> points)
	    {
	        double square = 0;
	        float value1 = 0;
	        float value2 = 0;
	        int i = 0;
	        int count = points.Count;
	        
	        for (i = 0; i < count - 1; i++)
	        {
	            value1 += points[i].X * points[i + 1].Y;
	            value2 += points[i].Y * points[i + 1].X;
	        }
	        value1 += points[i].X * points[0].Y;
	        value2 += points[i].Y * points[0].X;
	        square = (value1 - value2) / 2;
	        square = Math.Abs(square);
	        return square;
		}
		
		static public bool Intersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
    	{
	        double v1, v2, v3, v4;
	        v1 = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
	        v2 = (b2.X - b1.X) * (a2.Y - b1.Y) - (b2.Y - b1.Y) * (a2.X - b1.X);
	        v3 = (a2.X - a1.X) * (b1.Y - a1.Y) - (a2.Y - a1.Y) * (b1.X - a1.X);
	        v4 = (a2.X - a1.X) * (b2.Y - a1.Y) - (a2.Y - a1.Y) * (b2.X - a1.X);
	        return (v1 * v2 < 0) && (v3 * v4 < 0);
		}
		
		static public double GetPerimeter(List<double> sideLengthes)
    	{
	        double perimeter = 0;
	        int i;
	        int count = sideLengthes.Count;
	        for (i = 0; i < count; i++)
	        {
	            perimeter += sideLengthes[i];
	        }
	        return perimeter;
		}
		
		static public bool CheckFigureIntersection(List<Vector2> points, bool closed = true)
		{
	        int j;
	        for (int i = 0; i < points.Count - 1; i++)
	        {
	            for (j = 0; j < points.Count - 1; j++)
	            {
	                if (i == j)
	                    continue;
	
	                if (Intersection(points[i], points[i + 1], points[j], points[j + 1]))
	                    return true;
	            }
	            if (closed)
	            {
	                if (Intersection(points[i], points[i + 1], points[j], points[0]))
	                    return true;
	            }
	        }
	
	        return false;
		}
		
		static public List<double> GetSideLengthes(List<Vector2> points)
	    {
			List<double> _sideLengthes = new List<double>();
			int count = points.Count;
			int i;
			for (i = 0; i < count - 1; i++)
			{
				_sideLengthes.Add(GetSideLength(points[i], points[i + 1]));
			}
			_sideLengthes.Add(GetSideLength(points[i], points[0]));
			return _sideLengthes;
		}
		
    	static double GetSideLength(Vector2 point1, Vector2 point2)
		{
			double result;
			result = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
			return result;
		}
	}
}
