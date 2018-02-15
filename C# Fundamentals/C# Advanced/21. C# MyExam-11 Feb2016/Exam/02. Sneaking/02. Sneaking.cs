namespace _02._Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int rowNumber = int.Parse(Console.ReadLine());

            char[][] room = new char[rowNumber][];

            int samRow = 0;
            int samCol = 0;

            int nikiRow = 0;
            int nikiCol = 0;

            List<Enemy> enemies = new List<Enemy>();

            for (int row = 0; row < rowNumber; row++)
            {
                string currRowInput = Console.ReadLine().Trim();
                room[row] = new char[currRowInput.Length];
                for (int col = 0; col < currRowInput.Length; col++)
                {
                    char currElement = currRowInput[col];
                    if(currElement == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                    else if(currElement == 'N')
                    {
                        nikiRow = row;
                        nikiCol = col;
                    }
                    else if(currElement == 'd' ||
                            currElement == 'b')
                    {
                        Enemy currEnemy = new Enemy
                        {
                            Type = currElement.ToString(),
                            CurrentRow = row,
                            CurrentCol = col
                        };
                        enemies.Add(currEnemy);
                    }
                    room[row][col] = currElement;
                }
            }

            string instructions = Console.ReadLine().Trim();
            int commStartIndex = 0;

            while (true)
            {
                foreach (var enemy in enemies)
                {
                    string currEnemyType = enemy.Type.ToString();
                    int currEnemyRow = enemy.CurrentRow;
                    int currEnemyCol = enemy.CurrentCol;
                    if(currEnemyType == "d")
                    { 
                        if (currEnemyCol == 0) // Flip
                        {
                            enemy.Type = "b";
                            room[enemy.CurrentRow][enemy.CurrentCol] = 'b';
                        }
                        else
                        {
                            room[enemy.CurrentRow][enemy.CurrentCol] = '.';
                            enemy.CurrentCol--;
                            room[enemy.CurrentRow][enemy.CurrentCol] = 'd';
                        }
                    }
                    else if(currEnemyType == "b")
                    {
                        
                        if(currEnemyCol == room[currEnemyRow].Length - 1) // Flip
                        {
                            enemy.Type = "d";
                            room[enemy.CurrentRow][enemy.CurrentCol] = 'd';
                        }
                        else
                        {
                            room[enemy.CurrentRow][enemy.CurrentCol] = '.';
                            enemy.CurrentCol++;
                            room[enemy.CurrentRow][enemy.CurrentCol] = 'b';
                        }
                    }
                }

                if (enemies.Any(x => x.Type == "b" && x.CurrentRow == samRow && x.CurrentCol < samCol) ||
                    enemies.Any(x => x.Type == "d" && x.CurrentRow == samRow && x.CurrentCol > samCol))
                {
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");
                    room[samRow][samCol] = 'X';
                    PrintCurrentRoomStatus(room, rowNumber);
                    return;
                }

                string directionToGo = instructions[commStartIndex].ToString();
                if (samRow == nikiRow)
                {
                    Console.WriteLine("Nikoladze killed!");
                    room[nikiRow][nikiCol] = 'X';
                    PrintCurrentRoomStatus(room, rowNumber);
                    return;
                }
                if (directionToGo == "U")
                {
                    bool isThereEnemy = CheckForEnemy(room, samRow - 1, samCol);
                    if (isThereEnemy)
                    {
                        var enemyToDelete = enemies.FirstOrDefault(x => x.CurrentRow == samRow - 1 && x.CurrentCol == samCol);
                        enemies.Remove(enemyToDelete);
                    }
                    room[samRow][samCol] = '.';
                    samRow--;
                    room[samRow][samCol] = 'S';
                }
                else if (directionToGo == "D")
                {
                    bool isThereEnemy = CheckForEnemy(room, samRow + 1, samCol);
                    if (isThereEnemy)
                    {
                        var enemyToDelete = enemies.FirstOrDefault(x => x.CurrentRow == samRow + 1 && x.CurrentCol == samCol);
                        enemies.Remove(enemyToDelete);
                    }
                    room[samRow][samCol] = '.';
                    samRow++;
                    room[samRow][samCol] = 'S';
                }
                else if (directionToGo == "L")
                {
                    bool isThereEnemy = CheckForEnemy(room, samRow, samCol - 1);
                    if (isThereEnemy)
                    {
                        var enemyToDelete = enemies.FirstOrDefault(x => x.CurrentRow == samRow && x.CurrentCol == samCol - 1);
                        enemies.Remove(enemyToDelete);
                    }
                    room[samRow][samCol] = '.';
                    samCol--;
                    room[samRow][samCol] = 'S';
                }
                else if (directionToGo == "R")
                {
                    bool isThereEnemy = CheckForEnemy(room, samRow, samCol + 1);
                    if (isThereEnemy)
                    {
                        var enemyToDelete = enemies.FirstOrDefault(x => x.CurrentRow == samRow && x.CurrentCol == samCol + 1);
                        enemies.Remove(enemyToDelete);
                    }
                    room[samRow][samCol] = '.';
                    samCol++;
                    room[samRow][samCol] = 'S';
                }
                if (samRow == nikiRow)
                {
                    Console.WriteLine("Nikoladze killed!");
                    room[nikiRow][nikiCol] = 'X';
                    PrintCurrentRoomStatus(room, rowNumber);
                    return;
                }
                commStartIndex++;
            }
        }
        private static bool CheckForEnemy(char[][] room, int targetRow, int targetCol)
        {
            if(room[targetRow][targetCol] == 'd' || room[targetRow][targetCol] == 'b')
            {
                return true;
            }
            return false;
        }
        private static void PrintCurrentRoomStatus(char[][] room, int rowNumber)
        {
            for (int row = 0; row < rowNumber; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
        }
        public class Enemy
        {
            public string Type { get; set; }
            public int CurrentRow { get; set; }
            public int CurrentCol { get; set; }
        }
    }
}
