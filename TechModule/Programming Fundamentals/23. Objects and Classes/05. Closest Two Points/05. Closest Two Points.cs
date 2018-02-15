using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Distance_between_Points
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = ReadPoints();
            Point[] closestPoints = FindClosestTwoPoints(points);

            PrintDistance(closestPoints);

            PrintPoint(closestPoints[0]);
            PrintPoint(closestPoints[1]);
        }
        static Point ReadPoint()
        {
            int[] input = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            Point point = new Point();
            point.X = input[0];
            point.Y = input[1];

            return point;
        }
        static Point[] ReadPoints()
        {
            var n = int.Parse(Console.ReadLine());
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = ReadPoint();
            }
            return points;
        }
        static double CalculateDistance(Point p1, Point p2)
        {
            int deltaX = p1.X - p2.X;
            int deltaY = p1.Y - p2.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        static Point[] FindClosestTwoPoints(Point[] points)
        {
            double minDistance = double.MaxValue;
            Point[] closestTwoPoints = null;
            for (int p1 = 0; p1 < points.Length; p1++)
                for (int p2 = p1 + 1; p2 < points.Length; p2++)
                {
                    double distance = CalculateDistance(points[p1], points[p2]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTwoPoints = new Point[] { points[p1], points[p2] };
                    }
                }
            return closestTwoPoints;
        }
        static void PrintPoint(Point point)
        {
            Console.WriteLine("({0}, {1})", point.X, point.Y);
        }
        static void PrintDistance(Point[] points)
        {
            double distance = CalculateDistance(points[0], points[1]);
            Console.WriteLine("{0:f3}", distance);
        }
    

    }
}
