using Employees.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees.Client.Commands
{
    class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<employeeId> <address>
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            string address = string.Join(" ", args.Skip(1).ToArray());

            var employeeName = employeeService.SetAddress(employeeId, address);

            return $"{employeeName}'s address was set to {address}.";
        }
    }
}
