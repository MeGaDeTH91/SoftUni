namespace P04_WorkForce.Models
{
    using System;

    public delegate void PassWeekDelegate(Job job);

    public class Job
    {
        public event PassWeekDelegate PassWeekEvent;

        private string name;

        private int workHoursNeeded;

        private Employee jobEmployee;

        public Job(string name, int workHoursNeeded, Employee jobEmployee)
        {
            this.name = name;
            this.workHoursNeeded = workHoursNeeded;
            this.jobEmployee = jobEmployee;
        }

        public void Update()
        {
            this.workHoursNeeded -= this.jobEmployee.WeekWorkHours;

            if(this.workHoursNeeded <= 0)
            {
                Console.WriteLine($"Job {this.name} done!");
                this.PassWeekEvent.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.workHoursNeeded}";
        }
    }
}
