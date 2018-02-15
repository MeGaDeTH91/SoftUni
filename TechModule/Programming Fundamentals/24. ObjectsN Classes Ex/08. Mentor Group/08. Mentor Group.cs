using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _08.Mentor_Group
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> Attendance { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Student> register = new SortedDictionary<string, Student>();
            string dateInput = Console.ReadLine();

            while (dateInput != "end of dates")
            {
                List<string> inputArr = dateInput.Split(' ', ',')
                    .ToList();
                Student currStudent = new Student()
                {
                    Attendance = new List<DateTime>()
                };
                string currName = inputArr[0];
                currStudent.Name = currName;
                inputArr.RemoveAt(0);
                
                List<DateTime> currDates = new List<DateTime>();
                for (int i = 0; i < inputArr.Count; i++)
                {
                    currDates.Add(DateTime.ParseExact(inputArr[i], "dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
                
                if(register.ContainsKey(currName))
                {
                    for (int i = 0; i < currDates.Count; i++)
                    {
                        register[currName].Attendance.Add(currDates[i]);
                    }
                }
                else
                {
                    register.Add(currName, currStudent);
                    for (int i = 0; i < currDates.Count; i++)
                    {
                        register[currName].Attendance.Add(currDates[i]);
                    }
                }
                dateInput = Console.ReadLine();
            }
            string commentsInput = Console.ReadLine();
            while (commentsInput != "end of comments")
            {
                List<string> comments = commentsInput.Split('-')
                    .ToList();
                string currName = comments[0];
                
                Student currStudent = new Student()
                {
                    Comments = new List<string>()
                };
                currStudent.Name = currName;
                
                string currComment = comments[1];
                if (register.ContainsKey(currName))
                {
                    if(register[currName].Comments == null)
                    {
                        register[currName].Comments = new List<string>();
                        register[currName].Comments.Add(currComment);
                    }
                    else
                    {
                        register[currName].Comments.Add(currComment);
                    }
                   
                }
                commentsInput = Console.ReadLine();
            }
            foreach (var item in register)
            {
                Console.WriteLine($"{item.Key}");
                Console.WriteLine("Comments: ");
                if(item.Value.Comments != null)
                {
                    foreach (var inner in item.Value.Comments)
                    {
                        Console.WriteLine($"- {inner}");
                    }
                }
                Console.WriteLine("Dates attended: ");
                if(item.Value.Attendance != null)
                {
                    foreach (var inner2 in item.Value.Attendance.OrderBy(x =>x))
                    {
                        Console.WriteLine($"-- {inner2.ToString("dd/MM/yyyy")}");
                    }
                }
            }
        }
    }
}
