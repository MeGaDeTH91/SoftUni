using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var empPersonalDto = employeeService.SetManager(employeeId, managerId);

            return $"{empPersonalDto.Manager.FirstName} {empPersonalDto.Manager.LastName} is successfuly added as a manager to {empPersonalDto.FirstName} {empPersonalDto.LastName}";
        }
    }
}
