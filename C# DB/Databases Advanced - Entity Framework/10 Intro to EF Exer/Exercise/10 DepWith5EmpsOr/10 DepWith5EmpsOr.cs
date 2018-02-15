using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _10_DepWith5EmpsOr
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                var departments = db.Departments
                    .OrderBy(x => x.Employees.Count)
                    .ThenBy(x => x.Name)
                    .Where(x => x.Employees.Count > 5)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        d.Employees
                    })
                    .ToList();

                foreach (var d in departments)
                {
                    Console.WriteLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                    foreach (var e in d.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                    {
                        Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                    }
                    Console.WriteLine("----------");
                }
            }
        }
    }
}
