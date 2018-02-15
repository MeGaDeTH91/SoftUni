using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string paramType = Console.ReadLine();

            switch (paramType)
            {
                case "volume":
                    Console.WriteLine($"{GetVolume(side):F2}");
                    break;
                case "face":
                    Console.WriteLine($"{GetFaceDiag(side):F2}");
                    break;
                case "space":
                    Console.WriteLine($"{GetSpaceDiag(side):F2}");
                    break;
                case "area":
                    Console.WriteLine($"{GetArea(side):F2}");
                    break;
                default:
                    break;
            }
        }
        static double GetVolume(double side)
        {
           
            double volume = Math.Pow(side, 3);
            return volume;
        }
        static double GetArea(double side)
        {

            double area = 6 * (Math.Pow(side, 2));
            return area;
        }
        static double GetSpaceDiag(double side)
        {
            double space = Math.Sqrt(3 * (Math.Pow(side, 2)));
            return space;
        }
        static double GetFaceDiag(double side)
        {
            double face = Math.Sqrt(2 * (Math.Pow(side, 2)));
            return face;
        }
    }
}
