using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_ReverseNums
{
    class P01_ReverseNums
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split(new[] { ' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
