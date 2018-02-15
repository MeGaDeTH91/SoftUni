using Employees.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employeeInfo = employeeService.PersonalById(employeeId);

            string birthday = "[no birthday specified]";

            if(employeeInfo.BirthDay != null)
            {
                birthday = employeeInfo.BirthDay.Value.ToString("dd-MM-yyyy");
            }

            string address = address = employeeInfo.Address ?? "[no address specified]";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {employeeId} - {employeeInfo.FirstName} {employeeInfo.LastName} - ${employeeInfo.Salary:f2}");
            sb.AppendLine($"Birthday: {birthday}");
            sb.AppendLine($"Address: {address}");
            
            return $"{sb.ToString().Trim()}";
        }
    }
}
