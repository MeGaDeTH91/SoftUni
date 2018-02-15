using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var volume = double.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var sugar = int.Parse(Console.ReadLine());

            double variable = volume / 100;
            double kcal = variable * energy;
            double sugars = variable * sugar;

            Console.WriteLine("{0}ml {1}:", volume, name);
            Console.WriteLine("{0}kcal, {1}g sugars", kcal, sugars);
        }
    }
}
