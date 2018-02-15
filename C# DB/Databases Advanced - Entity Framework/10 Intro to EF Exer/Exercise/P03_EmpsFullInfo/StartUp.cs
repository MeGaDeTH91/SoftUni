using System;

using P02_DatabaseFirst;
using P02_DatabaseFirst.Data;
using System.Linq;

namespace P03_EmpsFullInfo
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .OrderBy(x => x.EmployeeId)
                    .Select(x => new
                    {
                        x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary
                    })
                    .ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
                }
            }
        }
    }
}
