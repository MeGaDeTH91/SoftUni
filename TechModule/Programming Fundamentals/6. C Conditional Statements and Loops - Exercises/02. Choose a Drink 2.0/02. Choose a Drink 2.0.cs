using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());

            if (profession == "Athlete")
            {
                var price = quantity * 0.7;
                Console.WriteLine("The {0} has to pay {1:F2}.", profession, price);
            }
            else if (profession == "Businessman" || profession == "Businesswoman")
            {
                var price = quantity * 1.0;
                Console.WriteLine("The {0} has to pay {1:F2}.", profession, price);
            }
            else if (profession == "SoftUni Student")
            {
                var price = quantity * 1.7;
                Console.WriteLine("The {0} has to pay {1:F2}.", profession, price);
            }
            else
            {
                var price = quantity * 1.2;
                Console.WriteLine("The {0} has to pay {1:F2}.", profession, price);
            }
        }
    }
}
