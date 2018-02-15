using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var package = Console.ReadLine().ToLower();
            var hallprice = 0.0;
            var disctype = 0.0;
            var total = 0.0;
            var overallprice = 0.0;
            if (num <= 50)
            {
                hallprice = 2500;

                if (package == "normal")
                {
                    total = hallprice + 500;
                    disctype = total * 5 / 100;
                    overallprice = total - disctype;

                }
               else if (package == "gold")
                {
                    total = hallprice + 750;
                    disctype = total * 10/100;
                    overallprice = total -  disctype;
                }
                else if (package == "platinum")
                {
                    total = hallprice + 1000;
                    disctype = total * 15 / 100;
                    overallprice = total - disctype;
                }
                var priceper = overallprice / num;
                Console.WriteLine("We can offer you the Small Hall");
                Console.WriteLine("The price per person is {0:F2}$", priceper);
            }
            else if (num <= 100)
            {
                hallprice = 5000;

                if (package == "normal")
                {
                    total = hallprice + 500;
                    disctype = total * 5 / 100;
                    overallprice = total - disctype;

                }
                else if (package == "gold")
                {
                    total = hallprice + 750;
                    disctype = total * 10 / 100;
                    overallprice = total - disctype;
                }
                else if (package == "platinum")
                {
                    total = hallprice + 1000;
                    disctype = total * 15 / 100;
                    overallprice = total - disctype;
                }
                var priceper = overallprice / num;
                Console.WriteLine("We can offer you the Terrace");
                Console.WriteLine("The price per person is {0:F2}$", priceper);
            }
            else if (num <= 120)
            {
                hallprice = 7500;

                if (package == "normal")
                {
                    total = hallprice + 500;
                    disctype = total * 5 / 100;
                    overallprice = total - disctype;

                }
                else if (package == "gold")
                {
                    total = hallprice + 750;
                    disctype = total * 10 / 100;
                    overallprice = total - disctype;
                }
                else if (package == "platinum")
                {
                    total = hallprice + 1000;
                    disctype = total * 15 / 100;
                    overallprice = total - disctype;
                }
                var priceper = overallprice / num;
                Console.WriteLine("We can offer you the Great Hall");
                Console.WriteLine("The price per person is {0:F2}$", priceper);
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
