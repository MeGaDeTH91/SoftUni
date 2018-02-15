using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _13_EmpStartWithSa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                db.Employees
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .Where(x => x.FirstName.Substring(0, 2) == "Sa")
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle,
                        x.Salary
                    })
                    .ToList()
                    .ForEach(x => Console.WriteLine(string.Join(Environment.NewLine, $"{x.FirstName} {x.LastName} - {x.JobTitle} - (${x.Salary:F2})")));
            }
        }
    }
}
