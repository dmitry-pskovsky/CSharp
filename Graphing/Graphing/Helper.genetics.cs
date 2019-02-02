using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

static partial class Helper
{
    public static List<Nucleotide> SeparateGenom(List<Point> points)
    {
        List<Nucleotide> nucleotides = new List<Nucleotide>();
        const int SIDES = 4;
        int pointsPerNucleotide = (int)Math.Round((double)points.Count / SIDES);
        int temp = SIDES - 1;
        int rest = points.Count - (temp * pointsPerNucleotide);
        int i;
        int j;
        int l = 0;
        if (points.Count != 2)
        {
            for (i = 0; i < temp; i++)
            {
                nucleotides.Add(new Nucleotide());
                for (j = 0; j < pointsPerNucleotide; j++)
                {
                    nucleotides[nucleotides.Count - 1].Add(new Point(points[l].X, points[l].Y));
                    l++;
                }
            }
            nucleotides.Add(new Nucleotide());
            for (j = 0; j < rest; j++)
            {
                nucleotides[nucleotides.Count - 1].Add(new Point(points[l].X, points[l].Y));
            }
        }
        else
        {
            nucleotides.Add(new Nucleotide());
            nucleotides.Add(new Nucleotide());
            nucleotides.Add(new Nucleotide());
            nucleotides.Add(new Nucleotide());
            nucleotides[1].Add(new Point(points[0].X, points[0].Y));
            nucleotides[3].Add(new Point(points[1].X, points[1].Y));
        }
        return nucleotides;
    }

    public static Organism Interbreed(Organism organism1, Organism organism2)
    {
        List<Nucleotide> genome1 = SeparateGenom(organism1.Points);
        List<Nucleotide> genome2 = SeparateGenom(organism2.Points);
        List<Point> interbreeded = new List<Point>();

        interbreeded.AddRange(genome1[0].Points);
        interbreeded.AddRange(genome1[1].Points);
        interbreeded.AddRange(genome2[2].Points);
        interbreeded.AddRange(genome2[3].Points);

        return new Organism(new OrganismInfo(interbreeded));
    }

    public static Organism GetRandomOrganizm(int pointsCount = 0)
    {
        if(pointsCount <= 0)
            pointsCount = Random.Next(3, 11);

        List<Point> points = new List<Point>();
        Point point;
        int i = 0;
        int j = 0;
        int e = 0;
        while (i < pointsCount)
        {
            if (j > 10)
            {
                j = 0;
                return ReturnAnyNotIntersected(points);
            }
            else
            {
                point = GetRandomPoint();
                points.Add(point);
            }

            i++;
            if (points.Count > 2)
            {
                if (CheckFigureIntersection(points, false))
                {
                    points.RemoveAt(points.Count - 1);
                    j++;
                    i--;
                    continue;
                }
            }
            if (i == pointsCount)
            {
                if (CheckFigureIntersection(points))
                {
                    points.RemoveAt(points.Count - 1);
                    e++;
                    i--;
                    if (e > 20)
                    {
                        return ReturnAnyNotIntersected(points);
                    }
                }
            }
        }

        return new Organism(new OrganismInfo(points));
    }

    private static Organism ReturnAnyNotIntersected(List<Point> points)
    {
        if (CheckFigureIntersection(points))
        {
            points.RemoveAt(points.Count - 1);
            return ReturnAnyNotIntersected(points);
        }
        return new Organism(new OrganismInfo(points));
    }

    public static List<Organism> GetNewGeneration(List<Organism> individuals)
    {
        List<Organism> childs = new List<Organism>();
        List<Organism> viable = new List<Organism>();
        List<Action> actions = new List<Action>();
        int i;


        //-------------------------------------
        GetBestPreviousIndividuals(individuals, childs);
        //-------------------------------------

        // Add 20 * 4 + 20 = 100 
        //-------------------------------------
        //GetIssues(individuals, childs);
        //-------------------------------------
        //actions.Add(GetIssues);

        // Add 10 * 20 = 200
        //-------------------------------------
        //GetInterbreedIssues(individuals, childs);
        //-------------------------------------
        //actions.Add(GetInterbreedIssues);

        // Add 200
        i = 0;
        for (i = 0; i < 200; i++) // 110
        {
            childs.Add(GetRandomOrganizm(10));
        }

        //AllocateTasks(actions);
        
       // actions[0]();
       // actions[1]();
       // actions[2]();

        childs.Sort(delegate(Organism organism1, Organism organism2)
        {
            return organism2.Viability.CompareTo(organism1.Viability);
        });

        for (i = 0; i < childs.Count; i += 2)
        {
            if (viable.Count >= 20)
                return viable;
            viable.Add(childs[i]);
        }
        return viable;
    }

    private static void GetBestPreviousIndividuals(List<Organism> individuals, List<Organism> childs)
    {
        int i = 0;
        foreach (var individual in individuals)
        {
            childs.Add(individual);
        }
    }

    private static void GetInterbreedIssues(List<Organism> individuals, List<Organism> childs)
    {
        int i = 0;
        int j = 0;
        int u = 0;
        Organism organism;
        for (i = 0; i < 20; i++)
        {
            for (j = 0; j < individuals.Count; j++)
            {
                if (i == j)
                {
                    u++;
                    continue;
                }
                organism = Helper.Interbreed(individuals[i], individuals[j]);
                childs.Add(organism);
            }
        }
    }

    private static void GetIssues(List<Organism> individuals, List<Organism> childs)
    {
        int i = 0;
        foreach (var individual in individuals)
        {
            for (i = 0; i < 4; i++)
            {
                childs.Add(individual.GetIssue());
            }
        }
    }

    public static int Mutate(int value)
    {
        switch (_random.Next(0, 3))
        {
            case 0:
                return value;
            case 1:
                return ++value;
            case 2:
                return --value;
            default:
                return value;
        }

    }
}

