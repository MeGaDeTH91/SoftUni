namespace P04_WorkForce.Models
{
    using System;

    public abstract class Employee
    {
        private int weekWorkHours;
        private string name;
        
        protected Employee(string name, int weekWorkHours)
        {
            this.Name = name;
            this.WeekWorkHours = weekWorkHours;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int WeekWorkHours
        {
            get { return this.weekWorkHours; }
            set { this.weekWorkHours = value; }
        }

    }
}
