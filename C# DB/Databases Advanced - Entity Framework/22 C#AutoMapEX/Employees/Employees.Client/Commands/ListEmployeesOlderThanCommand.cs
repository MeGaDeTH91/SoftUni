using Employees.DtoModels;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.Client.Commands
{
    class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int age = int.Parse(args[0]);

            List<EmployeeManagerDto> employees = employeeService.OlderThan(age);

            if (employees == null)
            {
                throw new ArgumentException($"No employees older than {age} age.");
            }

            var output = new StringBuilder();

            var orderedEmployees = employees
                .OrderByDescending(e => e.Salary);

            foreach (var emp in orderedEmployees)
            {
                output.Append($"{emp.FirstName} {emp.LastName} - ${emp.Salary:F2} - Manager: ");

                if (emp.Manager == null)
                {
                    output.Append("[no manager]");
                }
                else
                {
                    output.Append(emp.Manager.LastName);
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString().TrimEnd();
        }

    }
}
