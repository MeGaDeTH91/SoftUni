using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numArr = Console.ReadLine()
                .Split(' ')
                .ToArray();
            int skip = int.Parse(numArr[0]);
            int take = int.Parse(numArr[1]);
            string text = Console.ReadLine();
            List<string> result = new List<string>();
            string pattern = @"\|<(\w{" + skip + "})(\\w{0," + take + "})";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match m in matches)
            {
                result.Add(m.Groups[2].Value);
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
