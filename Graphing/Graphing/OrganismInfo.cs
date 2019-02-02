using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OrganismInfo
{
    private List<Point> _points;

    public OrganismInfo()
    {
        Create();
    }

    public OrganismInfo(List<Point> points)
    {
        _points = new List<Point>();
        foreach (var point in points)
        {
            _points.Add(new Point(point.X, point.Y));
        }
    }

    public List<Point> Points()
    {
        List<Point> points = new List<Point>();
        foreach (var point in _points)
        {
            points.Add(new Point(point.X, point.Y));
        }
        return points;
    }

    private void Create()
    {
        /*
        _points = new List<Point>();
        for (int i = 0; i < 5; i++)
        {
            _points.Add(new Point(0, 0));
        }
         */
        _points = new List<Point>();
        _points.Add(new Point(0, 0));
        _points.Add(new Point(50, 0));
        _points.Add(new Point(50, 50));
        _points.Add(new Point(0, 50));
         
    }
}

