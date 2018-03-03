using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_MordorPlan
{
    class P05_MordorPlan
    {
        static void Main(string[] args)
        {
            string[] foodList = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            long moodPoints = 0;

            foreach (var food in foodList)
            {
                switch (food.ToLower())
                {
                    case "cram":
                        moodPoints += 2;
                        break;
                    case "lembas":
                        moodPoints += 3;
                        break;
                    case "apple":
                        moodPoints += 1;
                        break;
                    case "melon":
                        moodPoints += 1;
                        break;
                    case "honeycake":
                        moodPoints += 5;
                        break;
                    case "mushrooms":
                        moodPoints -= 10;
                        break;
                    default:
                        moodPoints -= 1;
                        break;
                }
            }

            Console.WriteLine(moodPoints);
            if(moodPoints < -5)
            {
                Console.WriteLine("Angry");
            }
            else if(moodPoints >= -5 && moodPoints <= 0)
            {
                Console.WriteLine("Sad");
            }
            else if (moodPoints >= 1 && moodPoints <= 15)
            {
                Console.WriteLine("Happy");
            }
            else
            {
                Console.WriteLine("JavaScript");
            }
        }
    }
}
