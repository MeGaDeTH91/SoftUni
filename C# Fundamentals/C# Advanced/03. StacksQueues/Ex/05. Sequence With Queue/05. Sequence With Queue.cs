namespace _05._Sequence_With_Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long s = n;

            Queue<long> nums = new Queue<long>();

            nums.Enqueue(s);

            int skipCounter = 0;

            for (int i = 0; i < 49; i++)
            {
                switch (i % 3) 
                {
                    case 0:
                        s = nums.ToArray().Skip(skipCounter).Take(1).ToArray()[0];
                        nums.Enqueue(s + 1);
                        skipCounter++;
                        break;
                    case 1:
                        nums.Enqueue(2 * s + 1);
                        break;
                    case 2:
                        nums.Enqueue(s + 2);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
