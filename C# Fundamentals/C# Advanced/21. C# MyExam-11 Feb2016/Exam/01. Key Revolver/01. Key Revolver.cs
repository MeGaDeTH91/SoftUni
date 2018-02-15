namespace _01._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
                                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            long resultIntelligence = 0;
            int reloadTime = gunBarrelSize;
            bool weAreOutOfSomething = false;
            int bulletsUsed = 0;
            
            while (!weAreOutOfSomething)
            {
                if(bullets.Count > 0 && locks.Count > 0)
                {
                    int currBullet = bullets.Pop();
                    int currLock = locks.Peek();

                    if(currBullet <= currLock)
                    {
                        Console.WriteLine($"Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine($"Ping!");
                    }

                    bulletsUsed++;
                    reloadTime--;
                    if(reloadTime == 0 && bullets.Count > 0)
                    {
                        reloadTime = gunBarrelSize;
                        Console.WriteLine($"Reloading!");
                    }
                }
                else
                {
                    weAreOutOfSomething = true;
                }
            }
            resultIntelligence = bulletsUsed * bulletPrice;
            long earned = intelligenceValue - resultIntelligence;
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }

            else if(bullets.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
