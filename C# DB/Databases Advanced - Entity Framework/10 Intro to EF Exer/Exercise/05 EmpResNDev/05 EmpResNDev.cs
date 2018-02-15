using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _05_EmpResNDev
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var emps = db.Employees
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(x => x.FirstName)
                    .Where(x => x.Department.Name == "Research and Development")
                    .Select(x => new { x.FirstName, x.LastName, DepartmentName = x.Department.Name, x.Salary })
                    .ToList();

                foreach (var e in emps)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
                }
            }
        }
    }
}
