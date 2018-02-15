using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital_II
{
    class Program
    {
        private const int DepartmentCapacity = 60;
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] currentTokens = input
                                         .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                         .ToArray();

                string currDepartment = currentTokens[0];
                string currDoctor = $"{currentTokens[1]} {currentTokens[2]}";
                string currPatient = currentTokens[3];

                if(!departments.ContainsKey(currDepartment))
                {
                    departments[currDepartment] = new List<string>();
                }
                if(!doctors.ContainsKey(currDoctor))
                {
                    doctors[currDoctor] = new List<string>();
                }
                if(departments[currDepartment].Count + 1 <= DepartmentCapacity)
                {
                    departments[currDepartment].Add(currPatient);
                    doctors[currDoctor].Add(currPatient);
                }
            }

            string print;
            while ((print = Console.ReadLine()) != "End")
            {
                string[] printTokens = print
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();

                if(printTokens.Length == 1)
                {
                    string printDep = printTokens[0];

                    if(departments.ContainsKey(printDep))
                    {
                        foreach (var patient in departments[printDep])
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else
                {
                    string printDep = printTokens[0];
                    int roomNum;
                    bool isItDepRoom = int.TryParse(printTokens[1], out roomNum);

                    if (isItDepRoom)
                    {
                        if(departments.ContainsKey(printDep))
                        {
                            int startIndex = roomNum * 3 - 3;
                            int endIndex = startIndex + 2;
                            List<string> printList = new List<string>();

                            for (int index = startIndex; index <= endIndex; index++)
                            {
                                printList.Add(departments[printDep][index]);
                            }
                            Console.WriteLine(string.Join(Environment.NewLine, printList.OrderBy(x => x)));
                        }
                    }
                    else
                    {
                        string printDoc = $"{printTokens[0]} {printTokens[1]}";

                        if (doctors.ContainsKey(printDoc))
                        {
                            foreach (var patient in doctors[printDoc].OrderBy(x => x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
        }
    }
}
