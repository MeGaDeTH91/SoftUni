using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;


namespace _12_IncrSalary
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                db.Employees
                    .Where(x => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                    .Contains(x.Department.Name))
                    .ToList()
                    .ForEach(x => x.Salary *= 1.12m);

                db.SaveChanges();

                var empIncrSalary = db.Employees
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .Where(x => new[] { "Engineering", "Tool Design", "Marketing", "Information Services" }
                    .Contains(x.Department.Name))
                    .ToList();

                foreach (var emp in empIncrSalary)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
                }

               
                
            }
        }
    }
}
