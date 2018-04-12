namespace P04_WorkForce.Models
{
    using System;

    public class PartTimeEmployee : Employee
    {
        private const int DefaultWorkHours = 20;

        public PartTimeEmployee(string name) : base(name, DefaultWorkHours)
        {
        }
    }
}
