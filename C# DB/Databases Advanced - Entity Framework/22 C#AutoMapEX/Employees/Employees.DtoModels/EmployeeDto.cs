using System;

namespace Employees.DtoModels
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {

        }

        public EmployeeDto(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
        }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }
}
