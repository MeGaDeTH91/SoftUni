using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] field = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long startIndex = long.Parse(Console.ReadLine());
            long icarusDMG = 1;

            string commands = Console.ReadLine();

            while (commands != "Supernova")
            {
                string[] commandArr = commands.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string direction = commandArr[0];
                long steps = long.Parse(commandArr[1]);
                long nextIndex = 0;

                while (true)
                {
                    if (direction == "right")
                    {
                        // right -->>
                        if (checkUpperIndex(startIndex + steps, field))
                        {
                            nextIndex = startIndex + steps;
                            for (long i = startIndex + 1; i <= nextIndex; i++)
                            {
                                field[i] -= icarusDMG;
                            }
                            startIndex = nextIndex;
                            break;
                        }
                        else
                        {
                            for (long i = startIndex + 1; i < field.Length; i++)
                            {
                                field[i] -= icarusDMG;
                            }
                            icarusDMG += 1;
                            field[0] -= icarusDMG;
                            steps = steps - (field.Length - startIndex);
                            
                            startIndex = 0;
                            continue;
                        }
                    }
                    //<< --Left
                    else if (direction == "left")
                    {
                        if (checkLowerIndex(startIndex - steps, field))
                        {
                            nextIndex = startIndex - steps + 1;
                            for (long i = startIndex - 1; i >= nextIndex - 1; i--)
                            {
                                field[i] -= icarusDMG;
                            }
                            startIndex = nextIndex - 1;
                            break;
                        }
                        else
                        {
                            for (long i = startIndex - 1; i >= 0; i--)
                            {
                                field[i] -= icarusDMG;
                            }
                            icarusDMG += 1;
                            field[field.Length - 1] -= icarusDMG;
                            
                            steps = steps - (startIndex) - 1;
                            
                            startIndex = field.Length - 1;

                            continue;
                        }
                    }
                }
                
                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", field));
        }
        private static bool checkLowerIndex(long index, long[] field)
        {
            return index >= 0;
        }
        private static bool checkUpperIndex(long index, long[] field)
        {
            return index < field.Length;
        }
    }
}
