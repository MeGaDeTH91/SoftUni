using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            var peshdmg = int.Parse(Console.ReadLine());
            var goshdmg = int.Parse(Console.ReadLine());
            
            //var zero = 1000;
            var peshhlt = 100;
            var goshhlt = 100;
            var counter = 0;
            for (int i = 1; i <= 1000; i++)
            {
                counter++;
                
                if (i % 2 == 0)
                {
                    peshhlt = peshhlt - goshdmg;
                    if (peshhlt <= 0)
                    {
                        Console.WriteLine("Gosho won in {0}th round.", counter);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Gosho used Thunderous fist and reduced Pesho to {0} health.", peshhlt);
                    }
                    
                }
                if (i % 2 != 0)
                {
                    goshhlt = goshhlt - peshdmg;
                    if (goshhlt <= 0)
                    {
                        Console.WriteLine("Pesho won in {0}th round.", counter);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Pesho used Roundhouse kick and reduced Gosho to {0} health.", goshhlt);
                    }
                    
                }
                if (i % 3 == 0)
                {
                    peshhlt = peshhlt + 10;
                    goshhlt = goshhlt + 10;
                }
            }
        }
    }
}
