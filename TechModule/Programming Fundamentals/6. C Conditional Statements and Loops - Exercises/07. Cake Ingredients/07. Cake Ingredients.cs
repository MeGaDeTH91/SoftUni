using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            for (int i = 0; i <= 20; i++)
            {
                var ingr = Console.ReadLine();
                
                if (ingr == "Bake!")
                {
                    Console.WriteLine("Preparing cake with {0} ingredients.", counter);
                    break;
                }
                else
                {
                    Console.WriteLine("Adding ingredient {0}.", ingr);
                }
                counter++;
            }
        }
    }
}
