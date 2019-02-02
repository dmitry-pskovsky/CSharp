using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GraphicsObject
{
    private Graphics _graphics;
    private List<Point> _points;
    private Pen _pen;
    private Brush _brush;
    private Point _position;
    private static int POINT_WIDTH = 4;
    private static int POINT_HEIGHT = 4;
    Point _alignValue;
    Point _alignValue2;
    Point _extremeLeft;
    Point _extremeTop;

    public GraphicsObject(Graphics graphics, Point position, List<Point> points)
    {
        _graphics = graphics;
        _points = points;
        _position = position;

        _pen = new Pen(Color.Blue);

        Initialize();
    }

    private void Initialize()
    {
        DrawRect(_points);

        int i;
        for (i = _points.Count-1; i > 0 ; i--)
        {
           // DrawPoint(_points[i]);
            DrawLine(_points[i], _points[i - 1]);
        }
       // DrawPoint(_points[0]);
        DrawLine(_points[0], _points[_points.Count  -1]);
    }

    private void DrawRect(List<Point> _points)
    {
        List<Point> points = new List<Point>();
        Point extremeRight;
        Point extremeBottom;

        for (int i = 0; i < _points.Count; i++)
        {
            points.Add(new Point(_points[i].X, _points[i].Y));
        }

        points.Sort(delegate(Point point1, Point point2)
        {
            return point2.X.CompareTo(point1.X);
        });

        extremeRight = points[0];
        _extremeLeft = points[points.Count - 1];

        points.Sort(delegate(Point point1, Point point2)
        {
            return point2.Y.CompareTo(point1.Y);
        });

        extremeBottom = points[0];
        _extremeTop = points[points.Count - 1];


        int width = extremeRight.X - _extremeLeft.X;
        int height = extremeBottom.Y - _extremeTop.Y;
        _alignValue2 = new Point(-width/2, -height/2);
        _alignValue.X = _alignValue2.X + _position.X;
        _alignValue.Y = _alignValue2.Y + _position.Y;

        //Pen pen = new Pen(Color.Red);
        //_graphics.DrawRectangle(pen, _alignValue.X, _alignValue.Y, width, height);


    }
    
    private void DrawLine(Point point1, Point point2)
    {
        _pen = new Pen(Color.Blue);
        _graphics.DrawLine(_pen, new Point(_alignValue.X + point1.X - _extremeLeft.X, _alignValue.Y + point1.Y - _extremeTop.Y), new Point(_alignValue.X + point2.X - _extremeLeft.X, _alignValue.Y + point2.Y - _extremeTop.Y));
    }
    
    /*
    private void DrawLine(Point point1, Point point2)
    {
        _pen = new Pen(Color.Blue);
        _graphics.DrawLine(_pen, new Point(point1.X, point1.Y), new Point(point2.X, point2.Y));
    }
    */
    public void Clear()
    {
        _graphics.Clear(Color.White);
    }

    private void DrawPoint(Point point)
    {
        _brush = new SolidBrush(Color.Blue);
        _graphics.DrawEllipse(_pen, _alignValue.X + (point.X - POINT_WIDTH / 2) - _extremeLeft.X, _alignValue.Y + (point.Y - POINT_HEIGHT / 2) - _extremeTop.Y, POINT_WIDTH, POINT_HEIGHT);
    }
}

