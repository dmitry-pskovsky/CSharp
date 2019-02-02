using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing;

class Organism
{
    private double _perimeter;
    private double _viability;
    private double _disparity;
    private OrganismInfo _organismInfo;
    private double _square;
    private List<double> _sideList;

    public List<double> SideList
    {
        get
        {
            if (_sideList == null)
            {
                _sideList = new List<double>();
                int i;
                for (i = 0; i < _organismInfo.Points().Count - 1; i++)
                {
                    _sideList.Add(Helper.GetSideLength(_organismInfo.Points()[i], _organismInfo.Points()[i + 1]));
                }
                _sideList.Add(Helper.GetSideLength(_organismInfo.Points()[i], _organismInfo.Points()[0]));
                return _sideList;
            }
            else
            {
                return _sideList;
            }
        }
    }

    public double Square
    {
        get { return _square; }
        private set { _square = value; }
    }

    public double Disparity
    {
        get { return _disparity; }
        private set { _disparity = value; }
    }

    public double Perimeter
    {
        get { return _perimeter; }
        private set { _perimeter = value; }
    }

    public double Viability
    {
        get { return _viability; }
        private set { _viability = value; }
    }

    public List<Point> Points
    {
        get { return _organismInfo.Points(); }
        set { _organismInfo =  new OrganismInfo(value); }
    }

    public Organism()
    {
        Create();
        InitializeViability();
    }

    public Organism(OrganismInfo organismInfo)
    {
        _organismInfo = new OrganismInfo(organismInfo.Points());
        InitializeViability();
    }
    
    public double InitializeViability()
    {
        /*
        _square = Helper.GetSquare(_organismInfo);
        _perimeter = Helper.GetPerimeter(SideList);
        _disparity = Helper.GetSideDisparity(Settings.SideSize, SideList);
        _viability = _perimeter - _square - _disparity + _organismInfo.Points().Count * 30;
        //_viability = square - perimeter - _disparity + _organismInfo.Points().Count;
        //if (_square < 10000)
         // _viability = Double.NegativeInfinity;

        if (Helper.CheckFigureIntersection(_organismInfo.Points()))
            _viability = Double.NegativeInfinity;

        */
        if (Helper.CheckFigureIntersection(_organismInfo.Points()))
        {
            _viability = Double.NegativeInfinity;
            return _viability;
        }

        _square = Helper.GetSquare(_organismInfo);

        if (_square <= 0)
        {
            _viability = Double.NegativeInfinity;
            return _viability;
        }

        _disparity = Helper.GetSideDisparity(Settings.SideSize, SideList);

        _perimeter = Helper.GetPerimeter(SideList);
        _viability = _disparity * (-1) + _organismInfo.Points().Count;
       // _disparity = Helper.GetSideDisparity(Settings.SideSize, SideList);
        //_viability = (_organismInfo.Points().Count * 10) - _disparity;



        return _viability;
    }
     

    public OrganismInfo GetOrganismInfo()
    {
        return _organismInfo;
    }

    private void Create()
    {
        _organismInfo = new OrganismInfo();
    }

    public Organism GetIssue()
    {
        return new Organism(Mutate());
    }

    private List<Point> Mutate(List<Point> points)
    {
        int pointsCount;
        Point point;
        int index;

        if (points.Count <= 1)
            pointsCount = Helper.Mutate(points.Count + 1);
        else
            pointsCount = Helper.Mutate(points.Count);

        if (pointsCount < points.Count)
        {
            points.RemoveAt(Helper.Random.Next(0, points.Count));
            return points;
        }
        else if (pointsCount > points.Count)
        {
            points = Helper.AddRandomPoint(points);
            return points;
        }
        else
        {
            return points;
        }
    }

    private OrganismInfo Mutate()
    {
        List<Point> points = _organismInfo.Points();
        if (Settings.MutatePoints)
            points = Mutate(points);

        for (int i = 0; i < points.Count; i++)
        {
            points[i] = new Point(Helper.Mutate(points[i].X), Helper.Mutate(points[i].Y));
        }

        return new OrganismInfo(points);

    }
}

