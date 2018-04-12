namespace P04_WorkForce
{
    using P04_WorkForce.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string TypeNamespace = "P04_WorkForce.Models";
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            ListOfJobs listOfJobs = new ListOfJobs();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                string currentCommand = commTokens[0];

                switch (currentCommand)
                {
                    case "Job":
                        Type jobType = typeof(Job);

                        string jobName = commTokens[1];
                        int workHoursNeeded = int.Parse(commTokens[2]);
                        string employeeName = commTokens[3];

                        Employee assignEmployee = employees.FirstOrDefault(x => x.Name.Equals(employeeName));

                        object[] constructorParameters = new object[] { jobName, workHoursNeeded, assignEmployee };

                        Job newJob = (Job)Activator.CreateInstance(jobType, constructorParameters);

                        listOfJobs.AddJob(newJob);

                        break;
                    case "Pass":
                        listOfJobs.Jobs.ToList().ForEach(x => x.Update());
                        break;
                    case "Status":
                        Console.WriteLine(string.Join(Environment.NewLine, listOfJobs.Jobs));
                        break;
                    default:
                        string empName = commTokens[1];

                        Type empType = Type.GetType($"{TypeNamespace}.{currentCommand}");
                        
                        Employee classInstance = (Employee)Activator.CreateInstance(empType, new object[] { empName });

                        employees.Add(classInstance);
                        break;
                }
            }
        }
    }
}
