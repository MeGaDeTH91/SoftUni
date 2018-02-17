using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Output")
            {
                string[] commTokens = inputLine.Split();

                var currDepartment = commTokens[0];

                var docFirstName = commTokens[1];
                var docLastName = commTokens[2];
                StringBuilder sb = new StringBuilder();
                sb.Append(docFirstName);
                sb.Append(docLastName);
                var doctorFullName = sb.ToString();

                var patientName = commTokens[3];
                
                if (!doctors.ContainsKey(doctorFullName))
                {
                    doctors[doctorFullName] = new List<string>();
                }
                if (!departments.ContainsKey(currDepartment))
                {
                    departments[currDepartment] = new List<string>();
                }

                bool thereIsFreeBed = departments[currDepartment].Count < 60;
                if (thereIsFreeBed)
                {
                    doctors[doctorFullName].Add(patientName);

                    departments[currDepartment].Add(patientName);
                }
            }

            string printLine;
            while ((printLine = Console.ReadLine()) != "End")
            {
                string[] args = printLine.Split();

                if (args.Length == 1)
                {
                    string printDepartment = args[0];

                    Console.WriteLine(string.Join(Environment.NewLine, departments[printDepartment]));
                }
                else if (args.Length == 2)
                {
                    bool isItRoomNumber = int.TryParse(args[1], out int seekRoom);

                    if (isItRoomNumber)
                    {
                        string printDepartment = args[0];

                        int startIndex = seekRoom * 3 - 3;
                        int endIndex = startIndex + 3;
                        List<string> temp = new List<string>();

                        for (int room = startIndex; room < endIndex; room++)
                        {
                            temp.Add(departments[printDepartment][room]);
                        }
                        temp = temp.OrderBy(x => x).ToList();
                        Console.WriteLine(string.Join(Environment.NewLine, temp));
                    }
                    else
                    {
                        string currDoctor = $"{args[0]}{args[1]}";
                        Console.WriteLine(string.Join(Environment.NewLine, doctors[currDoctor].OrderBy(x => x)));
                    }
                }
            }
        }
    }
}
