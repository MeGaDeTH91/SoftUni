using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _04_EmpSalaryOv50000
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var emps = db.Employees
                    .OrderBy(x => x.FirstName)
                    .Where(x => x.Salary > 50000)
                    .Select(x => new { x.FirstName })
                    .ToList();

                foreach (var e in emps)
                {
                    Console.WriteLine(e.FirstName);
                }
                    
            }
        }
    }
}
