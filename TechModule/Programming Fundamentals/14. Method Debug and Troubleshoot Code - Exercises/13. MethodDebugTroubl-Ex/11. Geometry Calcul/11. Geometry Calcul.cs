using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calcul
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            switch (figure)
            {
                case "triangle":
                    double sideOrWidth = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{GetTriangleArea(sideOrWidth, height):F2}");
                    break;
                case "rectangle":
                     sideOrWidth = double.Parse(Console.ReadLine());
                     height = double.Parse(Console.ReadLine());
                     Console.WriteLine($"{GetRectangleArea(sideOrWidth, height):F2}");
                     break;
                case "square":
                    double sideOrRaduis = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{GetSquareArea(sideOrRaduis):F2}");
                    break;
                case "circle":
                    sideOrRaduis = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{GetCircleArea(sideOrRaduis):F2}");
                    break;
                default:
                    break;
            }
             
        }
        static double GetTriangleArea(double sideOrWidth, double height)
        {
            double area = (sideOrWidth * height) / 2;
            return area;
        }
        static double GetRectangleArea(double sideOrWidth, double height)
        {
            double area = (sideOrWidth * height);
            return area;
        }
        static double GetSquareArea(double sideOrRadius)
        {
            double area = Math.Pow(sideOrRadius, 2);
            return area;
        }
        static double GetCircleArea(double sideOrRadius)
        {
            double area = Math.PI *(Math.Pow(sideOrRadius, 2));
            return area;
        }
    }
}
