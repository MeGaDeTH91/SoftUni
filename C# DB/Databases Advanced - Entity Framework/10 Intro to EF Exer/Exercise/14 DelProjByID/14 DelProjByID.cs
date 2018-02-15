using System;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System.Linq;

namespace _14_DelProjByID
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var project = db.Projects.Find(2);

                var deleteProjs = db.EmployeesProjects
                    .Where(x => x.ProjectId == 2)
                    .ToList();

                db.EmployeesProjects.RemoveRange(deleteProjs);

                db.Projects.Remove(project);
                db.SaveChanges();

                db.Projects
                        .Take(10)
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.Name));



            }
        }
    }
}
