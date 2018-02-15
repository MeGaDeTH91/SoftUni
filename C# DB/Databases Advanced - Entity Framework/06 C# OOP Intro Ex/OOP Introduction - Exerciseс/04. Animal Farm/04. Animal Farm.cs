using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            double products = chicken.ProductPerDay();
            Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {products} eggs per day.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}