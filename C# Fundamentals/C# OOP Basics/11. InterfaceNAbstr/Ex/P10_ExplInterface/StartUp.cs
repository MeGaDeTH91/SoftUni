using System;
using System.Text;

namespace P10_ExplInterface
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commTokens = command.Split();

                string name = commTokens[0];
                string country = commTokens[1];
                int age = int.Parse(commTokens[2]);

                Citizen newCitizen = new Citizen(name, country, age);
                sb.AppendLine(newCitizen.ToString());
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }
    }
}
