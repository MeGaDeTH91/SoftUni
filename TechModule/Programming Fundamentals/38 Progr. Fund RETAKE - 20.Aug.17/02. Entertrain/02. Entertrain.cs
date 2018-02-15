using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Entertrain
{
    class Program
    {
        static void Main(string[] args)
        {
            int locoPw = int.Parse(Console.ReadLine());
            List<int> wagonList = new List<int>();
            List<int> averageList = new List<int>();
            int wagonAdd = default(int);
            int wagAverage = 0;

            string input = Console.ReadLine();

            while (input != "All ofboard!")
            {
                int currWag = int.Parse(input);
                wagonList.Add(currWag);
                averageList.Add(currWag);
                
                if (averageList.Sum()> locoPw)
                {
                    //wagonAdd = averageList.Sum();
                    foreach (var item in averageList)
                    {
                        wagonAdd += item;
                    }
                    wagAverage = wagonAdd / averageList.Count;
                    int closest = wagonList.Aggregate((x, y) => Math.Abs(x - wagAverage) < Math.Abs(y - wagAverage) ? x : y);
                    wagonList.Remove(closest);
                }

                input = Console.ReadLine();
            }
            
            wagonList.Reverse();
            wagonList.Add(locoPw);
            Console.WriteLine(string.Join(" ", wagonList));
        }
    }
}
