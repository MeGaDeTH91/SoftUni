using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var currhealth = int.Parse(Console.ReadLine());
            var maxhealth = int.Parse(Console.ReadLine());
            var currenergy = int.Parse(Console.ReadLine());
            var maxenergy = int.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("Health: |{0}{1}|", new string('|', currhealth), new string('.', maxhealth - currhealth));
            Console.WriteLine("Energy: |{0}{1}|", new string('|', currenergy), new string('.', maxenergy - currenergy));
        }
    }
}
