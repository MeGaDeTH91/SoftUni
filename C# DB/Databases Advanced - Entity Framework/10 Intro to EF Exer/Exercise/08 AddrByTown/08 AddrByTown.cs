using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _08_AddrByTown
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                var addresses = db.Addresses
                    .OrderByDescending(x => x.Employees.Count)
                    .ThenBy(x => x.Town.Name)
                    .ThenBy(x => x.AddressText)
                    .Take(10)
                    .Select( a => new { a.AddressText, TownName = a.Town.Name, EmpCount = a.Employees.Count})
                    .ToList();

                foreach (var ad in addresses)
                {
                    Console.WriteLine($"{ad.AddressText}, {ad.TownName} - {ad.EmpCount} employees");
                }
            }
        }
    }
}
