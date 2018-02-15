using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string namesInput = Console.ReadLine();

            int tossNum = int.Parse(Console.ReadLine());

            string[] names = namesInput.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> queueWinner = new Queue<string>(names);

            int counter = tossNum - 1;



            while (queueWinner.Count > 1)
            {
                if (queueWinner.Count == 1)
                {
                    break;
                }
                for (int i = 0; i < queueWinner.Count; i++)
                {
                    if (counter == 0)
                    {
                        string losers = queueWinner.Dequeue();
                        Console.WriteLine($"Removed {losers}");
                        counter = tossNum - 1;
                    }
                    else
                    {
                        string currRemove = queueWinner.Dequeue();
                        queueWinner.Enqueue(currRemove);
                        counter--;
                    }
                }

            }                
            
            Console.WriteLine($"Last is {queueWinner.Dequeue()}");
            
        }
    }
}
