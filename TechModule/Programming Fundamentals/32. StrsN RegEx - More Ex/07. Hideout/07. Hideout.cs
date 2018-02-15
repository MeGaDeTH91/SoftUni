using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;


namespace _07.Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            long minimum = 0;
            string exactChar = string.Empty;
            string specialChars = @"/.*+?|(,)[]{}\";
            string strMap = Console.ReadLine();
            string searched = Console.ReadLine();
            int counter = 0;
            while (true)
            {
                string[] searchedParam = searched.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => x.Length > 0).ToArray();

                counter++;
                exactChar = searchedParam[0];
                if(specialChars.Contains(exactChar))
                {
                    exactChar = @"\" + exactChar;
                }
                minimum = long.Parse(searchedParam[1]);
                string pattern = $"([{exactChar}]){{{minimum},}}";
                Match currMatch = Regex.Match(strMap, pattern);
                if (currMatch.Success)
                {
                    counter = 0;
                    string theMatch = currMatch.ToString();
                    long index = strMap.IndexOf(theMatch);
                    long size = theMatch.Length;
                    Console.WriteLine($"Hideout found at index {index} and it is with size {size}!");
                    return;
                }
                if (counter == 3)
                {
                    return;
                }
                searched = Console.ReadLine();
            }
        }
    }
}
