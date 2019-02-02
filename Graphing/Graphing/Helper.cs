using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


static partial class Helper
{
    private static Random _random;
    private static Stopwatch _stopWatch;

    public static Random Random
    {
        get { return _random; }
        private set { _random = value; }
    }

    public static int RandomSignNumber(int a, int b)
    {
        int number = Random.Next(a, b);
        if (Random.Next(0, 2) == 0)
            return number;
        else
            return -number;
    }

    public static Point GetRandomPointOnLine(Point a, Point b)
    {
        Point point;
        if (a.X == b.X && a.Y == b.Y)
        {
            point = new Point(a.X, a.Y);
            return point;
        }

        double shiftX = b.X - a.X;
        double shiftY = b.Y - a.Y;
        double length = Math.Sqrt((shiftX)*(shiftX) + (shiftY)*(shiftY));

        int random = Random.Next(0, (int)length + 1);
        double lambda = random/length;

        int newX = (int)(shiftX * lambda);
        int newY = (int)(shiftY * lambda);
        point = new Point(a.X + newX, a.Y + newY);
        return point;
    }

    public static List<Point> AddRandomPoint(List<Point> points)
    {
        List<Point> _points = points;
        Point point;

        int random = Random.Next(0, points.Count);

        if (random == points.Count - 1)
        {
             point = GetRandomPointOnLine(points[points.Count - 1], points[0]);
            _points.Insert(0, point);
        }
        else
        {
             point = GetRandomPointOnLine(points[random], points[random + 1]);
             _points.Insert(random + 1, point);
        }

        return _points;
    }

    public static Point GetRandomPoint(int xInterval = 150, int yInterval = 150)
    {
        return new Point(Random.Next(0, xInterval + 1), Random.Next(0, yInterval + 1));
    }

    public static Point GetLocalRandomPoint(Point location)
    {
       int shiftX = Random.Next(0, 10);
       int shiftY = Random.Next(0, 10);

        if (Random.Next(0, 2) > 0)
            shiftX = shiftX *= -1;
        else
            shiftX = shiftX;

        if (Random.Next(0, 2) > 0)
            shiftY = shiftY *= -1;
        else
            shiftY = shiftY;

        return new Point(location.X + shiftX, location.Y + shiftY);
    }

    public static void WritePerformanceTime(Action action, string name)
    {
        _stopWatch.Start();
        action.Invoke();
        _stopWatch.Stop();
        Console.WriteLine("TIME: " + _stopWatch.Elapsed.TotalMilliseconds);
    }

    public static List<Point> Crop(List<Point> originalPoints)
    {
        List<Point> points = new List<Point>();
        Point extremeLeft;
        Point extremeTop;
        int i;

        for (i = 0; i < originalPoints.Count; i++)
        {
            points.Add(new Point(originalPoints[i].X, originalPoints[i].Y));
        }

        points.Sort(delegate(Point point1, Point point2)
        {
            return point2.X.CompareTo(point1.X);
        });

        extremeLeft = points[points.Count - 1];

        points.Sort(delegate(Point point1, Point point2)
        {
            return point2.Y.CompareTo(point1.Y);
        });

        extremeTop = points[points.Count - 1];
        
        
        for (i = 0; i < originalPoints.Count; i++)
        {
            originalPoints[i] = new Point(originalPoints[i].X - extremeLeft.X, originalPoints[i].Y);
        }

        for (i = 0; i < originalPoints.Count; i++)
        {
            originalPoints[i] = new Point(originalPoints[i].X, originalPoints[i].Y - extremeTop.Y);
        }

        return originalPoints;
    }

    public static void AllocateTasks(List<Action> actions)
    {
        int i;
        Task[] tasks = new Task[actions.Count];
        for (i = 0; i < actions.Count; i++)
        {
            tasks[i] = new Task(actions[i]);
        }

        for (int j = 0; j < tasks.Length; j++)
        {
            tasks[j].Start();
        }
        Task.WaitAll(tasks);
    }

    public static void Initialize()
    {
        _random = new Random();
        _stopWatch = new Stopwatch();
    }
}

