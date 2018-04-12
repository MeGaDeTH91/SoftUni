namespace P04_WorkForce.Models
{
    using System;

    public class StandardEmployee : Employee
    {
        private const int DefaultWorkHours = 40;

        public StandardEmployee(string name) : base(name, DefaultWorkHours)
        {
        }
    }
}
