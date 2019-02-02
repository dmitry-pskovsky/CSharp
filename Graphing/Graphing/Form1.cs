using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Threading;

namespace Graphing
{
    public partial class Form1 : Form
    {
        private Graphics _graphics;
        private GraphicsObject _graphicsObject;

        private static int CELL_WIDTH = 200;
        private static int CELL_HEIGHT = 200;

        private List<Organism> _list;

        public Form1()
        {
            InitializeComponent();
            
            Settings.IterrationCount = 20;
            Settings.MutatePoints = true;
            Settings.SideSize = 20;
            
            Helper.Initialize();
            _list = new List<Organism>();

            int i = 0;
            for (i = 0; i < 20; i++)
            {
                _list.Add(Helper.GetRandomOrganizm(10));
            }


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _graphics = e.Graphics;
            DrawField();
            if (_list.Count == 2)
            {
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(100, 100), _list[0].Points);
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(300, 100), _list[1].Points);
            }
            else if (_list.Count == 1)
            {
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(100, 100), _list[0].Points);
            }
            else
            {
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(100, 100), _list[0].Points);
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(300, 100), _list[1].Points);
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(500, 100), _list[2].Points);
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(700, 100), _list[3].Points);
                _graphicsObject = new GraphicsObject(e.Graphics, new Point(900, 100), _list[4].Points); 
            }
            
        }

        private void DrawField()
        {
            Pen _pen = new Pen(Color.Purple);
            for (int i = 0; i < 2; i++)
            {
                _graphics.DrawLine(_pen, new Point(0, CELL_HEIGHT * i), new Point(CELL_WIDTH * 5, CELL_HEIGHT * i));
            }
            for (int i = 0; i < 5; i++)
            {
                _graphics.DrawLine(_pen, new Point(i * CELL_WIDTH, 0), new PointF(i * CELL_WIDTH, 1.3f * CELL_HEIGHT));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Organism> newList = new List<Organism>();
            for (int i = 0; i < Settings.IterrationCount; i++)
            {
                newList = Helper.GetNewGeneration(_list);
                _list = newList;
            }

            _list = newList;

            Console.WriteLine(_list[0].Viability + "via");
             /*
              * Add random 
            _list.Clear();
            int i = 0;
            for (i = 0; i < 20; i++)
            {
                _list.Add(Helper.GetRandomOrganizm(10));
            }
            */

            /*
            List<Point> points = _list[0].Points;

            Point g = Helper.GetRandomPointOnLine(points[0], points[1]);

            points.Insert(1, g);
            _list[0] = new Organism(new OrganismInfo(points));
             */

            /* -------------------------------------
            _list[0].Points = Helper.Crop(_list[0].Points);
            _list[1].Points = Helper.Crop(_list[1].Points);
             Organism organism = Helper.Interbreed(_list[0], _list[1]);

             _list.Clear();
             _list = new List<Organism>();
             _list.Add(organism);
             -------------------------------------*/
             /*
            _list.Clear();
            
            _list.Add(Helper.GetRandomOrganizm());
            _list.Add(Helper.GetRandomOrganizm());
            _list.Add(Helper.GetRandomOrganizm());
            _list.Add(Helper.GetRandomOrganizm());
            _list.Add(Helper.GetRandomOrganizm());
            */
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
