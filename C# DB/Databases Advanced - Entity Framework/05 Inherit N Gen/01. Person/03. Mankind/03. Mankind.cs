using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string[] studentInput = Console.ReadLine()
            .Split().ToArray();
            string stFirstName = studentInput[0];
            string stLastName = studentInput[1];
            string stFaculty = studentInput[2];
            Student student = new Student(stFirstName, stLastName, stFaculty);

            string[] workerInput = Console.ReadLine()
            .Split().ToArray();
            string wkFirstName = workerInput[0];
            string wkLastName = workerInput[1];
            decimal wkWeekSalary = decimal.Parse(workerInput[2]);
            decimal wkWorkinHours = decimal.Parse(workerInput[3]);
            Worker worker = new Worker(wkFirstName, wkLastName, wkWeekSalary, wkWorkinHours);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        
    }
}