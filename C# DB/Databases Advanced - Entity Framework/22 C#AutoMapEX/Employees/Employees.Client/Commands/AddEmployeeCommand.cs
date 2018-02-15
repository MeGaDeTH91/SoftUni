using Employees.Data;
using Employees.DtoModels;
using Employees.Models;
using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<firstName> <lastName> <salary>
        public string Execute(params string[] data)
        {
            string firstName = data[0];
            string lastName = data[1];
            decimal salary = decimal.Parse(data[2]);

            var employeeDto = new EmployeeDto(firstName, lastName, salary);

            employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} successfully added.";
        }
    }
}
