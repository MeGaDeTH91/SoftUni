using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _6._AddAddrNUpdEmp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                Employee employee = db.Employees
                    .FirstOrDefault(x => x.LastName == "Nakov");

                employee.Address = address;
                db.SaveChanges();

                var adds = db.Employees
                    .OrderByDescending(x => x.AddressId)
                    .Select(x => new { AddressText = x.Address.AddressText })
                    .ToList();

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{adds[i].AddressText}");
                }
            }
        }
    }
}
