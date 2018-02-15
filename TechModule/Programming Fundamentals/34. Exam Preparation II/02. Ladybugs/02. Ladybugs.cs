using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _02.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] field = new long[long.Parse(Console.ReadLine())];
            long[] bugs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            for (int i = 0; i < bugs.Length; i++)
            {
                if(bugs[i] >= 0 && bugs[i] < field.Length)
                {
                    long bugIndex = bugs[i];
                    field[bugIndex] = 1;
                }
                
            }
            string commands = Console.ReadLine();

            while (commands != "end")
            {
                string[] commandArr = commands.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                long startIndex = long.Parse(commandArr[0]);
                string direction = commandArr[1];
                long flyLength = long.Parse(commandArr[2]);
                long nextIndex = 0;
                if (checkValidIndex(startIndex, field) && field[startIndex] == 1) // Ако началния индекс е в рамките на полето и има калинка там
                {
                    field[startIndex] = 0;  //полето става празно
                    while (true)   //докато калинката излезе от полето или стъпи на празно поле
                    {
                        if ((direction == "left" && flyLength < 0) || ((direction == "right" && flyLength >= 0)))
                        {
                            // right -->>
                            if (checkValidIndex(startIndex + Math.Abs(flyLength), field))
                            {
                                nextIndex = startIndex + Math.Abs(flyLength);
                            }
                            else
                            {
                                break;
                            }
                        }
                        // <<-- Left
                        else if ((direction == "right" && flyLength < 0) || ((direction == "left" && flyLength >= 0)))
                        {
                            if (checkValidIndex(startIndex - Math.Abs(flyLength), field))
                            {
                                nextIndex = startIndex - Math.Abs(flyLength);
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (field[nextIndex] == 0)
                        {
                            field[nextIndex] = 1;
                            break;
                        }        
                     startIndex = nextIndex;     
                    }
                } 
                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
        private static bool checkValidIndex(long index, long[] field)
        {
            return index >= 0 && index < field.Length;
        }
    }
}
