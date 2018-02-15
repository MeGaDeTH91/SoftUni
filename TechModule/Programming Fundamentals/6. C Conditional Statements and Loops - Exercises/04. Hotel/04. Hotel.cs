using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine().ToLower();
            var nights = int.Parse(Console.ReadLine());
            double studioprice = 0;
            double doubleprice = 0;
            double suiteprice = 0;
            if (month == "may" || month == "october")
            {
                if (nights > 7)
                {
                    studioprice = 47.5;
                }
                else
                {
                    studioprice = 50;
                }

                
                doubleprice = 65;
                suiteprice = 75;
                
            }
            
            
            else if (month == "june" || month == "september")
            {

                if (nights > 14)
                {
                    doubleprice = 64.8;
                }
                else
                {
                    doubleprice = 72;
                }
                studioprice = 60;
                
                suiteprice = 82;

            }
            else if (month == "july" || month == "august" || month == "december")
            {

                if (nights > 14)
                {
                    suiteprice = 75.65;
                }
                else
                {
                    suiteprice = 89;
                }
                studioprice = 68;
                doubleprice = 77;
                

            }
            
            double totalstudioprice = nights * studioprice;
            double totaldoubleprice = nights * doubleprice;
            double totalsuiteprice = nights * suiteprice;
            if ((month == "october" || month == "september") && nights > 7)
            {
                totalstudioprice = totalstudioprice - studioprice;
            }
            Console.WriteLine("Studio: {0:F2} lv.", totalstudioprice);
            Console.WriteLine("Double: {0:F2} lv.", totaldoubleprice);
            Console.WriteLine("Suite: {0:F2} lv.", totalsuiteprice);
          
        }
    }
}
