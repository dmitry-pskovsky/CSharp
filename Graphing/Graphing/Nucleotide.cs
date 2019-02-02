using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

class Nucleotide
{
    List<Point> _points;

    public Nucleotide(List<Point> points) 
    {
        _points = points;
    }

    public Nucleotide() 
    {
        _points = new List<Point>();
    }

    public void Add(Point point)
    {
        _points.Add(point);
    }

    public List<Point> Points
    {
        get { return _points; }
        private set { _points = value; }
    }
}
