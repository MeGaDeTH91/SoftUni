using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            var daytype = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());

            if (age >= 0 && age <= 18)
            {
                if (daytype == "weekday")
                {
                    Console.WriteLine("12$");
                } 
                else if(daytype == "weekend")
                {
                    Console.WriteLine("15$");
                }
                else if (daytype == "holiday")
                {
                    Console.WriteLine("5$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
           else if (age > 0 && age <= 64)
            {
                if (daytype == "weekday")
                {
                    Console.WriteLine("18$");
                }
                else if (daytype == "weekend")
                {
                    Console.WriteLine("20$");
                }
                else if (daytype == "holiday")
                {
                    Console.WriteLine("12$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (age > 0 && age <= 122)
            {
                if (daytype == "weekday")
                {
                    Console.WriteLine("12$");
                }
                else if (daytype == "weekend")
                {
                    Console.WriteLine("15$");
                }
                else if (daytype == "holiday")
                {
                    Console.WriteLine("10$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
