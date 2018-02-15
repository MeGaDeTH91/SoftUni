using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .ToList();
            

            for (int i = 0; i < input.Count; i++)
            {
                var currentStrWord = input[i];
                if (currentStrWord.Length != 2)
                {
                    input.Remove(currentStrWord);
                    i--;
                }
                else if((char.IsNumber(currentStrWord[0]) || (char.IsNumber(currentStrWord[1]))))
                {
                    var tempChar = currentStrWord.ToCharArray();
                    Array.Reverse(tempChar);
                    input[i] = new string(tempChar);
                }
            }
            char[] output = new char[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                
                var tempChar = System.Convert.ToChar(System.Convert.ToUInt32(input[i], 16));
                output[i] = tempChar;
            }
              
            Array.Reverse(output);
            var finaloutput = new string(output);
            Console.WriteLine(finaloutput);
        }
    }
}
