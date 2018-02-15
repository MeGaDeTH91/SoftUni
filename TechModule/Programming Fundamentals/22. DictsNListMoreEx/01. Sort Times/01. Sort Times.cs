using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sort_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .ToList();
            List<TimeSpan> spans = input.Select(TimeSpan.Parse)
                .ToList();
            spans.Sort((a, b) => a.CompareTo(b));
            List<string> formated = new List<string>();
            foreach (var item in spans)
            {
                formated.Add(item.ToString("hh\\:mm"));
            }
            Console.WriteLine(string.Join(", ", formated));
        }
    }
}
