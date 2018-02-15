using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            double damage = double.Parse(Console.ReadLine());

            double heiganHealth = 3000000;
            int playerHealth = 18500;

            int rowPosition = 7;
            int colPosition = 7;

            Queue<int> cloudQueue = new Queue<int>();

            string lastSpell = string.Empty;

            while (heiganHealth > 0 && playerHealth > 0)
            {
                string[] inputLine = Console.ReadLine()
                                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                string currSpell = inputLine[0];
                int impactRow = int.Parse(inputLine[1]);
                int impactCol = int.Parse(inputLine[2]);

                heiganHealth -= damage;
                
                if(cloudQueue.Count > 0)
                {
                    playerHealth -= cloudQueue.Dequeue();
                    if(playerHealth <= 0 || heiganHealth <= 0)
                    {
                        continue;
                    }
                }

                if (heiganHealth <= 0)
                {
                    continue;
                }

                if (IsCellReached(rowPosition, colPosition, impactRow, impactCol) &&
                    IsPlayerDamaged(ref rowPosition, ref colPosition, impactRow, impactCol))
                {
                    if (currSpell == "Cloud")
                    {
                        lastSpell = "Plague Cloud";
                        playerHealth -= 3500;
                        cloudQueue.Enqueue(3500);
                    }
                    else if (currSpell == "Eruption")
                    {
                        lastSpell = "Eruption";
                        playerHealth -= 6000;
                    }
                }

            }

            string heiganPrint = heiganHealth <= 0 ? $"Heigan: Defeated!" : $"Heigan: {heiganHealth:F2}";

            string playerPrint = playerHealth <= 0 ? $"Player: Killed by {lastSpell}" : $"Player: {playerHealth}";

            string positionPrint = $"Final position: {rowPosition}, {colPosition}";

            Console.WriteLine(heiganPrint);
            Console.WriteLine(playerPrint);
            Console.WriteLine(positionPrint);
        }

        private static bool IsPlayerDamaged(ref int rowPos, ref int colPos, int hitRow, int hitCol)
        {
            if (rowPos > 0 &&
                !IsCellReached(rowPos - 1, colPos, hitRow, hitCol)) // Try move Up
            {
                rowPos--;
                return false;
            }

            if (colPos + 1 < 15 && // Dancing area is 15 by 15 matrix
                !IsCellReached(rowPos, colPos + 1, hitRow, hitCol)) // Try move Right
            {
                colPos++;
                return false;
            }

            if (rowPos + 1 < 15 && // Dancing area is 15 by 15 matrix
                !IsCellReached(rowPos + 1, colPos, hitRow, hitCol)) // Try move Down
            {
                rowPos++;
                return false;
            }

            if (colPos > 0 &&
                !IsCellReached(rowPos, colPos - 1, hitRow, hitCol)) // Try move Left
            {
                colPos--;
                return false;
            }

            return true;
        }

        private static bool IsCellReached(int cellRow, int cellCol, int hitRow, int hitCol)
        {
            return (cellRow >= hitRow - 1) && (cellRow <= hitRow + 1) && (cellCol >= hitCol - 1) && (cellCol <= hitCol + 1);
        }
    }
}
