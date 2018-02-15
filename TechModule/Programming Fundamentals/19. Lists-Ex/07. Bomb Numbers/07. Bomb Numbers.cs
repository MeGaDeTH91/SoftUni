using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var bombInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bombNum = bombInput[0];
            int powerNum = bombInput[1];
            int indexOfBomb = numList.IndexOf(bombNum);
            while (numList.IndexOf(bombNum) >= 0)
            {
                indexOfBomb = numList.IndexOf(bombNum);
                var leftSide = indexOfBomb - powerNum;
                var rightSide = indexOfBomb + powerNum;
                var diff = rightSide - leftSide;
                var topBorderdiff = numList.Count - leftSide;
                var botBorderdiff = rightSide;
                if ((rightSide < numList.Count) && (leftSide >= 0))
                {
                    for (int i = 0; i <= diff; i++)
                    {
                        numList.RemoveAt(leftSide);
                    }

                }
                else if ((rightSide >= numList.Count) && (leftSide < 0))
                {
                    for (int i = 0; i <= numList.Count + 1; i++)
                    {
                        numList.RemoveAt(0);
                    }
                }
                else if ((rightSide >= numList.Count) && (leftSide >= 0))
                {
                    for (int i = 0; i < topBorderdiff; i++)
                    {
                        numList.RemoveAt(leftSide);
                    }
                }
                else if ((rightSide < numList.Count) && (leftSide < 0))
                {
                    for (int i = 0; i <= botBorderdiff; i++)
                    {
                        numList.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine(numList.Sum());
        }
    }
}