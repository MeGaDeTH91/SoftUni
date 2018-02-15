using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;
using System.Globalization;

namespace _11_Latest10Projs
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                var projects = db.Projects
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .ToList();

                foreach (var p in projects.OrderBy(x => x.Name))
                {
                    string format = "M/d/yyyy h:mm:ss tt";

                    Console.WriteLine($"{p.Name}");
                    Console.WriteLine($"{p.Description}");
                    Console.WriteLine($"{p.StartDate.ToString(format, CultureInfo.InvariantCulture)}");
                }
            }
        }
    }
}
