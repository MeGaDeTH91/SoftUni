namespace P04_WorkForce.Models
{
    using System;
    using System.Collections.Generic;

    public class ListOfJobs : List<Job>
    {
        public List<Job> Jobs { get; private set; }
        
        public ListOfJobs()
        {
            this.Jobs = new List<Job>();
        }

        public void AddJob(Job job)
        {
            this.Jobs.Add(job);
            job.PassWeekEvent += this.WhenJobIsCompleted;
        }

        public void WhenJobIsCompleted(Job job)
        {
            this.Jobs.Remove(job);
        }
    }
}
