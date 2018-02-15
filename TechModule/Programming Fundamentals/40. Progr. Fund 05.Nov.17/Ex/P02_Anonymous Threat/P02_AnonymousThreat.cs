using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_Anonymous_Threat
{
    class P02_AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> inputStrings = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] commandArgs = command.Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentCommand = commandArgs[0];

                if(currentCommand == "merge")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);
                    startIndex = ValidateIndex(startIndex, inputStrings);
                    endIndex = ValidateIndex(endIndex, inputStrings);


                }
                else if(currentCommand == "divide")
                {

                }
            }

            Console.WriteLine(string.Join(" ", inputStrings));
        }

        private static int ValidateIndex(int index, List<string> inputStrings)
        {
            if(index < 0)
            {
                index = 0;
            }
            else if(index >= inputStrings.Count)
            {
                index = inputStrings.Count - 1;
            }
            return index;
        }
    }
}
