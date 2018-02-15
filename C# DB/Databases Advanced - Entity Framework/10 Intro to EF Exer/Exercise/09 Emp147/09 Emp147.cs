using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _09_Emp147
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var empl147 = db.Employees
                    .Where(x => x.EmployeeId == 147)
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle,
                        Projects = x.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(p => p)
                    .ToList()
                    })
                    .FirstOrDefault();

                Console.WriteLine($"{empl147.FirstName} {empl147.LastName} - {empl147.JobTitle}{Environment.NewLine}{string.Join(Environment.NewLine, empl147.Projects)}");
            }
        }
    }
}
