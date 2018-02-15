using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            //2-ри начин, по-кратък
        //    int roll = int.Parse(Console.ReadLine());
        //    Queue<string> queue = new Queue<string>();

        //    string commands = Console.ReadLine();

        //    int counter = 0;
        //    int totalCars = 0;

        //    while (commands != "end")
        //    {
        //        if (commands != "green")
        //        {
        //            queue.Enqueue(commands);
        //        }
        //        else
        //        {
        //            counter = 0;

        //            while (queue.Count > 0 && counter < roll)
        //            {
        //                Console.WriteLine($"{queue.Dequeue()} passed!");
        //                counter++;
        //                totalCars++;
        //            }

        //        }


        //        commands = Console.ReadLine();
        //    }

        //    Console.WriteLine($"{totalCars} cars passed the crossroads.");
        //}

            int carNum = int.Parse(Console.ReadLine());
            int greenNum = 0;

            Stack<string> commRaw = new Stack<string>();

            Stack<string> commStack = new Stack<string>();            

            Queue<string> carsJam = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                commRaw.Push(command);
            }
            int count = 0;
            foreach (var comm in commRaw)
            {
                if(comm != "green")
                {
                    count++;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        commRaw.Pop();
                    }
                    foreach (var com in commRaw)
                    {
                        if(com != "green")
                        {
                            carsJam.Enqueue(com);
                        }                        
                    }
                    break;
                }
            }
            while (commRaw.Count != 0)
            {
                string current = commRaw.Pop();
                if(current == "green")
                {
                    greenNum++;
                }
                commStack.Push(current);
            }
            carsJam = new Queue<string>(commStack);

            int carNumToPass = carsJam.Count() - greenNum;
            int greenPass = greenNum * carNum;
            int passedNum = Math.Min(carNumToPass, greenPass);

            int tempCount = passedNum;

            while (tempCount > 0)
            {
                string current = carsJam.Dequeue();

                if(current != "green")
                {
                    tempCount--;
                    Console.WriteLine($"{current} passed!");
                }
            }
            Console.WriteLine($"{passedNum} cars passed the crossroads.");
        }
    }
}
