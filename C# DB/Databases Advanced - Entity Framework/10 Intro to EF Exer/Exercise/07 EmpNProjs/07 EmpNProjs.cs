using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;
using System.Globalization;

namespace _07_EmpNProjs
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var emps = db.Employees
                    .Where(x => x.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(x => new { x.FirstName, x.LastName, ManagerFirstName = x.Manager.FirstName, ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(epp => epp.Project)})
                    .ToList();

                foreach (var emp in emps)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                    foreach (var p in emp.Projects)
                    {
                        string format = "M/d/yyyy h:mm:ss tt";
                        
                        Console.WriteLine($"--{p.Name} - {p.StartDate.ToString(format, CultureInfo.InvariantCulture)} - {(p.EndDate == null ? "not finished":(p.EndDate.Value.ToString(format,CultureInfo.InvariantCulture)))} ");
                    }
                }
            }
        }
    }
}
