using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> tour = new Queue<int>();
            

            for (int i = 0; i < n; i++)
            {
                string inputComm = Console.ReadLine();

                int[] nums = inputComm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int difference = nums[0] - nums[1];

                tour.Enqueue(difference);
            }

            Queue<int> originalTour = new Queue<int>(tour);

            while (true)
            {
                int checker = 0;
                int fuel = 0;

                foreach (var t in tour)
                {
                    if (fuel + t < 0)
                    {
                        tour.Enqueue(tour.Dequeue());
                        break;
                    }
                    else
                    {
                        fuel += t;
                        checker++;
                    }
                }
                if (checker == originalTour.Count)
                {
                    break;
                }
            }

            int seekElement = tour.Dequeue();

            int counter = 0;
            foreach (var ot in originalTour)
            {
                if(ot == seekElement)
                {
                    Console.WriteLine(counter);
                    return;
                }
                else
                {
                    counter++;
                }
            }
        }
    }
}
