using System;
using System.Linq;

namespace P03_Mankind
{
    class P03_Mankind
    {
        static void Main(string[] args)
        {
            try
            {
                string[] firstLine = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();
                string firstName = firstLine[0];
                string lastName = firstLine[1];
                string facultyNum = firstLine[2];

                Student newStudent = new Student(firstName, lastName, facultyNum);

                string[] secondLine = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                firstName = secondLine[0];
                lastName = secondLine[1];
                decimal weekSalary = decimal.Parse(secondLine[2]);
                double workHours = double.Parse(secondLine[3]);
                Worker newWorker = new Worker(firstName, lastName, weekSalary, workHours);

                Console.WriteLine(newStudent + Environment.NewLine);
                Console.WriteLine(newWorker);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
