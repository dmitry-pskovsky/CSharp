using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

static partial class Helper
{
    public static double GetSideLength(Point point1, Point point2)
    {
        double result;
        result = Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        return result;
    }

    public static double GetPerimeter(List<double> SideList)
    {
        double perimeter = 0;
        int i;
        for (i = 0; i < SideList.Count; i++)
        {
            perimeter += SideList[i];
        }
        return perimeter;
    }

    public static bool Intersection(Point a1, Point a2, Point b1, Point b2)
    {
        double v1, v2, v3, v4;
        v1 = (b2.X - b1.X) * (a1.Y - b1.Y) - (b2.Y - b1.Y) * (a1.X - b1.X);
        v2 = (b2.X - b1.X) * (a2.Y - b1.Y) - (b2.Y - b1.Y) * (a2.X - b1.X);
        v3 = (a2.X - a1.X) * (b1.Y - a1.Y) - (a2.Y - a1.Y) * (b1.X - a1.X);
        v4 = (a2.X - a1.X) * (b2.Y - a1.Y) - (a2.Y - a1.Y) * (b2.X - a1.X);
        return (v1 * v2 < 0) && (v3 * v4 < 0);

    }

    public static double GetSideDisparity(double optimal, List<double> sideList)
    {
        double disparity = 0;

        int i;
        if (optimal == Double.NaN)
        {
            for (i = 0; i < sideList.Count; i++)
            {
                optimal += sideList[i];
            }
            optimal = optimal / sideList.Count;
        }

        for (i = 0; i < sideList.Count; i++)
        {
            disparity += Math.Abs(sideList[i] - optimal);
        }

        return disparity;
    }

    public static double GetSquare(OrganismInfo organismInfo)
    {
        double square = 0;
        float value1 = 0;
        float value2 = 0;
        int i = 0;
        for (i = 0; i < organismInfo.Points().Count - 1; i++)
        {
            value1 += organismInfo.Points()[i].X * organismInfo.Points()[i + 1].Y;
            value2 += organismInfo.Points()[i].Y * organismInfo.Points()[i + 1].X;
        }
        value1 += organismInfo.Points()[i].X * organismInfo.Points()[0].Y;
        value2 += organismInfo.Points()[i].Y * organismInfo.Points()[0].X;
        square = (value1 - value2) / 2;
        square = Math.Abs(square);
        return square;
    }

    public static bool CheckFigureIntersection(List<Point> points, bool closed = true)
    {
        int j;
        for (int i = 0; i < points.Count - 1; i++)
        {
            for (j = 0; j < points.Count - 1; j++)
            {
                if (i == j)
                    continue;

                if (Helper.Intersection(points[i], points[i + 1], points[j], points[j + 1]))
                    return true;
            }
            if (closed)
            {
                if (Helper.Intersection(points[i], points[i + 1], points[j], points[0]))
                    return true;
            }
        }

        return false;
    }
}

