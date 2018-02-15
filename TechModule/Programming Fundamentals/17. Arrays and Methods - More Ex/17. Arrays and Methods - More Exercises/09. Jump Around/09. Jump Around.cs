using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int currentJump = numArray[0];
            long sum = 0;
            int i = 0;
            while (true)
            {
                if (currentJump + i >= numArray.Length)  ////ако излиза от масива надясно
                {
                    if (i - currentJump >= 0)     ////стъпка наляво
                    {
                        i = i - currentJump;
                        sum += numArray[i];
                        currentJump = numArray[i];
                    }
                    else                        // няма посока за движение, печати
                    {
                        sum = sum + numArray[0];
                        Console.WriteLine(sum);
                        break;
                    }
                }
                else if (currentJump - i < 0)       //ако излиза наляво
                {
                    if (currentJump + i < numArray.Length)  //може надясно
                    {
                        i = i + currentJump;
                        sum += numArray[i];
                        currentJump = numArray[i];
                    }
                   
                    else
                    {
                        sum = sum + numArray[0];
                        Console.WriteLine(sum);
                        break;
                    }
                }
                else                         //ако няма да излезе извън масива и в двете посоки
                {
                    if (i - currentJump < 0)
                    {
                        i = i + currentJump;
                        sum += numArray[i];
                        currentJump = numArray[i];
                    }
                    else
                    {
                        i = i - currentJump;
                        sum += numArray[i];
                        currentJump = numArray[i];
                    }
                }
            }
        }
    }
}
