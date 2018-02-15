using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Calories_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cheese = 0;
            var tomatosauce = 0;
            var salami = 0;
            var pepper = 0;

            for (int i = 1; i <= n; i++)
            {
                var ingr = Console.ReadLine().ToLower();

                if (ingr == "cheese")
                {
                    cheese++;
                }
                else if (ingr == "tomato sauce")
                {
                    tomatosauce++;
                }
                else if (ingr == "salami")
                {
                    salami++;
                }
                else if (ingr == "pepper")
                {
                    pepper++;
                }
            }
            var totalcal = (cheese * 500) + (tomatosauce * 150) + (salami * 600) + (pepper * 50);
            Console.WriteLine("Total calories: {0}", totalcal);
        }
    }
}
