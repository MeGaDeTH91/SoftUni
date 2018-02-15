using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<employeeId>
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employeeInfo = employeeService.ById(employeeId);

            return $"ID: {employeeId} - {employeeInfo.FirstName} {employeeInfo.LastName} - ${employeeInfo.Salary:f2}";
        }
    }
}
