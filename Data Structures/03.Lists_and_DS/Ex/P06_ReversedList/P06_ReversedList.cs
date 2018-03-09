using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06_ReversedList
{
    class P06_ReversedList
    {
        static void Main(string[] args)
        {
            ReversedList<int> list = new ReversedList<int>();

            list.Add(5);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(0);

            foreach (var num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
