using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Average_Grades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade
        {
            get {return Grades.Average();}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();
                string currName = input[0];
                List<double> currGrades = new List<double>();
                for (int grades = 1; grades < input.Length; grades++)
                {
                    var currentValue = double.Parse(input[grades]);
                    currGrades.Add(currentValue);
                }
                
                Student currStudent = new Student();

                    currStudent.Grades = new List<double>(currGrades);
                currStudent.Name = currName;
                list.Add(currStudent);
            }
            foreach (var item in list.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade))
            {
                Console.WriteLine($"{item.Name} -> {item.AverageGrade:F2}");
            }
        }
    }
}
