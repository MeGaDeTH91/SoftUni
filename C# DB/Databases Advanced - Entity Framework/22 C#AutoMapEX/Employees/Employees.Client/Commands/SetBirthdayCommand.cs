using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        //<employeeId> <date: "dd-MM-yyyy"> 
        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            var employeeName = employeeService.SetBirthday(employeeId, date);

            return $"{employeeName}'s birthday was set to {args[1]}.";
        }
    }
}
