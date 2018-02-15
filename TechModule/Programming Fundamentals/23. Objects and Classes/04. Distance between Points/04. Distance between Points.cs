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
            Point a = ReadPoint();
            Point b = ReadPoint();
            double result = CalculateDistance(a , b);
            Console.WriteLine($"{result:F3}"); 
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
        static double CalculateDistance(Point p1, Point p2)
        {
            int deltaX = p1.X - p2.X;
            int deltaY = p1.Y - p2.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
