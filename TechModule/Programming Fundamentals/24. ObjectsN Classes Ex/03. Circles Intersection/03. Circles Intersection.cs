using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Circles_Intersection
{
    class Circle
    {
        public Point Center { get; set; }
        public decimal Radius { get; set; }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var circle1 = ReadCircle();
            var circle2 = ReadCircle();
            if(TheyIntersect(circle1, circle2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
           
        }
        private static Circle ReadCircle()
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Point center = new Point();
            center.X = input[0];
            center.Y = input[1];
            Circle currCircle = new Circle();
            currCircle.Center = center;
            currCircle.Radius = input[2];
            return currCircle;
        }
        static bool TheyIntersect(Circle circle1, Circle circle2)
        {
            bool result = false;
            double distance = CalculateDistance(circle1.Center, circle2.Center);
            if(distance <= (double)(circle1.Radius + circle2.Radius))
            {
                result = true;
            }
            return result;
        }

        private static double CalculateDistance(Point center1, Point center2)
        {
            var result = 0.0d;
            int sideA = Math.Abs(center1.X - center2.X);
            int sideB = Math.Abs(center1.Y - center2.Y);
            result = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            return result;
        }
    }
}
