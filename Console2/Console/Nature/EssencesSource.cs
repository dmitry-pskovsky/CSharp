using System;
using System.Collections.Generic;
using Console.Statistics;
using Console.Utilities;
using OpenTK;

namespace Console.Nature
{
	public class EssencesSource
	{
		Random random;
			
		public EssencesSource()
		{
			random = new Random();
		}
		
		public List<Vector2> GenerateEssance()
		{
			int size = 7;
			
			List<Vector2> points = new List<Vector2>();
			
			GenerateNextPoints(size, points);
			
			return points;
		}
		
		public void GenerateNextPoints(int count, List<Vector2> points)
		{
			int pointsCount = points.Count;
			int index1, index2;
			
			if (pointsCount >= count)
				return;
				
			if (pointsCount >= 3)
			{
				for(int i = 0; i < 5; i++)
				{
					GetTwoPointsIndexes(points, out index1, out index2);
					if (GeneratePointBetweenTwoIndexes(points, index1, index2))
					{
						Statistics.Statistics.GetNode("GENERATE_NEXT_POINTS_" + i).incrementValue("sucsess");
						GenerateNextPoints(count, points);
						return;
					}
					Statistics.Statistics.GetNode("GENERATE_NEXT_POINTS_" + i).incrementValue("fail");
				}
			}
			else
			{
				points.Add(GenerateAleatoryPoint());
				GenerateNextPoints(count, points);
			}
		}
		
		public bool GeneratePointBetweenTwoIndexes(List<Vector2> points, int index1, int index2)
		{
			int attempts = 10;
			
			while (attempts > 0)
			{
				points.Insert(index1, GenerateAleatoryPoint());
				if (!GeometricalUtilities.CheckFigureIntersection(points))
				{
					Statistics.Statistics.GetNode("GENERATE_BETWEEN_INDEXES").incrementValue("sucsess");
					return true;
				}
				points.RemoveAt(index1);
				Statistics.Statistics.GetNode("GENERATE_BETWEEN_INDEXES").incrementValue("fail");
				attempts--;
			}	
			
			return false;
		}
		
		private void GetTwoPointsIndexes(List<Vector2> points, out int index1, out int index2)
		{
			int count = points.Count;
			int rand = random.Next(0, count + 1);
			
			if (rand == count)
			{
				index1 = rand;
				index2 = 0;
			}
			else
			{
				index1 = rand;
				index2 = rand + 1;
			}
		}
		
		public Vector2 GenerateAleatoryPoint()
		{
			int degrees = random.Next(0, 360);
			int radius = 50;
			double angle = Math.PI * degrees / 180.0;
			
			return new Vector2((float)Math.Cos(angle) * radius, (float)Math.Sin(angle) * radius);
		}
	}
}
