using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            char[] initialChar = input.Where(a => !char.IsDigit(a)).ToArray();
            int[] numList = input.Where(a => char.IsDigit(a))
                .Select(a => int.Parse(a.ToString())).ToArray();

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < numList.Length; i++)
            {
                if(i % 2 > 0)
                {
                    skipList.Add(numList[i]);
                }
                else
                {
                    takeList.Add(numList[i]);
                }
            }
            int totalSkip = 0;
            string finalMessage = string.Empty;
            for (int i = 0; i < takeList.Count; i++)
            {
                int skipCount = skipList[i];
                int takeCount = takeList[i];
                finalMessage += new string(initialChar.Skip(totalSkip).Take(takeCount).ToArray());
                totalSkip += skipCount + takeCount;
            }
            Console.WriteLine(finalMessage);
        }
    }
}
