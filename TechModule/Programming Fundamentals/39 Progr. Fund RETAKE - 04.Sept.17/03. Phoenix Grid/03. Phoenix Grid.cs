using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Phoenix_Grid
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([^\s_]{3})((\.)([^\s_]{3}))*$";
            Regex myRegex = new Regex(pattern);

            string input = Console.ReadLine();

            while (input != "ReadMe")
            {
                StringBuilder sb = new StringBuilder();
                string result = string.Empty;

                Match match = myRegex.Match(input);
                if(match.Success)
                {
                    string tmpStr = match.ToString();
                    string[] arr = tmpStr.Split(new char[] { '.' },StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                        foreach (string str in arr)
                        {
                            sb.Append(str);
                        }

                        result = sb.ToString();

                        char[] tempReverse = result.ToCharArray();
                        tempReverse = tempReverse.Reverse().ToArray();
                        string compare = new string(tempReverse);
                        if (result == compare)
                        {
                            Console.WriteLine("YES");
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }
                }
                else
                {
                    Console.WriteLine("NO");
                }

                input = Console.ReadLine();
            }
        }
    }
}
