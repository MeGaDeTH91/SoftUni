using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char[] charArr = word.ToCharArray();
            
           
            for (int i = 0; i < charArr.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", charArr[i], '\0' + charArr[i] - 97);
            }
        }
    }
}
