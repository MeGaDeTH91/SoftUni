using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
           
            for (int currNum = 0; currNum < numArr.Length; currNum++)
            {
                int sumLeft = 0;
                int sumRight = 0;
                for (int j = 0; j < currNum; j++)
                {

                    sumLeft += numArr[j];
                }
                for (int j = currNum + 1; j < numArr.Length; j++)
                {
                    sumRight += numArr[j];
                }
                if(sumRight == sumLeft)
                {
                    Console.WriteLine(currNum);
                    return;
                }
            }
            
                Console.WriteLine("no");
           
        }
    }
}
