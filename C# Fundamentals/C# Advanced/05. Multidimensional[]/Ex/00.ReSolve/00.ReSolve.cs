using System;
using System.Collections.Generic;
using System.Linq;

namespace _00.ReSolve
{
    class Program
    {
        static void Main(string[] args)
        {
            double damage = double.Parse(Console.ReadLine());

            int playerHealth = 18500;
            double heiganHealth = 3000000;

            string lastSpell = string.Empty;

            int playerRowPos = 7;
            int playerColPos = 7;
            
            Queue<int> spellPlague = new Queue<int>();

            while (playerHealth > 0 && heiganHealth > 0)
            {
                heiganHealth -= damage;

                string[] heiganAttack = Console.ReadLine()
                                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                if(spellPlague.Count > 0)
                {
                    playerHealth -= spellPlague.Dequeue();
                    lastSpell = "Plague Cloud";
                }
                if(heiganHealth <=0 || playerHealth <= 0)
                {
                    break;
                }

                string attackSpell = heiganAttack[0];
                int attackRow = int.Parse(heiganAttack[1]);
                int attackCol = int.Parse(heiganAttack[2]);

                if(IsCellReached(playerRowPos, playerColPos, attackRow, attackCol) && IsPlayerDamaged(ref playerRowPos,ref playerColPos, attackRow, attackCol))
                {
                    if(attackSpell == "Eruption")
                    {
                        playerHealth -= 6000;
                        lastSpell = "Eruption";
                    }
                    else if (attackSpell == "Cloud")
                    {
                        playerHealth -= 3500;
                        spellPlague.Enqueue(3500);
                        lastSpell = "Plague Cloud";
                    }
                }
            }
            string heiganPrint = heiganHealth <= 0 ? $"Heigan: Defeated!" : $"Heigan: {heiganHealth:F2}";
            string playerPrint = playerHealth <= 0 ? $"Player: Killed by {lastSpell}" : $"Player: {playerHealth}";

            Console.WriteLine(heiganPrint);
            Console.WriteLine(playerPrint);
            Console.WriteLine($"Final position: {playerRowPos}, {playerColPos}");
        }

        private static bool IsPlayerDamaged(ref int playerRowPos,ref int playerColPos, int attackRow, int attackCol)
        {
            //Try Up
            if(playerRowPos - 1 >= 0 && playerRowPos - 1 < attackRow - 1)
            {
                playerRowPos -= 1;
                return false;
            }

            //Try Right
            else if(playerColPos + 1 < 15 && playerColPos + 1 > attackCol + 1)
            {
                playerColPos += 1;
                return false;
            }

            //Try Down
            else if(playerRowPos + 1 < 15 && playerRowPos + 1 > attackRow + 1)
            {
                playerRowPos += 1;
                return false;
            }

            //Try Left
            else if(playerColPos - 1 >= 0 && playerColPos - 1 < attackCol - 1)
            {
                playerColPos -= 1;
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsCellReached(int playerRowPos, int playerColPos, int attackRow, int attackCol)
        {
            return (playerRowPos >= attackRow - 1) && (playerRowPos <= attackRow + 1) && (playerColPos >= attackCol - 1) && (playerColPos <= attackCol + 1);
        }
    }
}
