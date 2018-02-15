using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            long jump = long.Parse(Console.ReadLine());

            const char checkLetter = 'p';
            bool ifMatch = false;

            for (int i = 0; i < text.Length; i++)
            {
                if(text[i] == checkLetter)
                {
                    ifMatch = true;

                    long endIndex = jump;

                    if (endIndex + i >= text.Length)
                    {
                        endIndex = text.Length - i;

                    }
                    else
                    {
                        endIndex += 1;
                    }
                    
                    string matchedString = text.Substring(i, (int)endIndex);
                    Console.WriteLine(matchedString);
                    i = (int)(i + jump);
                }
            }

            if (!ifMatch)
            {
                Console.WriteLine("no");
            }

            //string[] checkArray = Console.ReadLine().Split(' ').ToArray();

            //string checkstring = Console.ReadLine();
            //int n = int.Parse(Console.ReadLine());

            //char[] checkArray = checkstring.ToCharArray();

            //int currIndex = Array.IndexOf(checkArray, 'p');
            //if()
            //if (currIndex + n < checkArray.Length)
            //{
            //    for (int j = currIndex; j <= n; j++)
            //    {
            //        Console.Write("{0}", checkArray[j]);
            //    }
            //    Console.WriteLine();
            //}
            //else
            //{
            //    int diff = checkArray.Length - currIndex;
            //    for (int k = checkArray.Length - diff; k < checkArray.Length; k++)
            //    {
            //        Console.WriteLine("{0}", checkArray[k]);
            //    }
            //    Console.WriteLine();         
        }
    }
}
