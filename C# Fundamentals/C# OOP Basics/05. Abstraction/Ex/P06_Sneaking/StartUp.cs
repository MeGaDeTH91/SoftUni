using System;
using System.Collections.Generic;

namespace P06_Sneaking
{
    class StartUp
    {
        static char[][] room;
        private const char dot = '.';
        private const char sam = 'S';
        private const char nikoladze = 'N';
        private const char xMarksTheSpot = 'X';
        private const char enemyFaceRight = 'b';
        private const char enemyFaceLeft = 'd';

        static void Main()
        {
            int rowCount = int.Parse(Console.ReadLine());

            room = new char[rowCount][];

            int[] samCurrentPosition = new int[2];
            FillRoomAndSamPosition(ref room, rowCount, ref samCurrentPosition);

            char[] samDirections = Console.ReadLine().ToCharArray();

            for (int moveNumber = 0; moveNumber < samDirections.Length; moveNumber++)
            {
                EnemiesMove(room, rowCount);

                int[] enemyOnSameRow = new int[2];
                CheckForEnemiesFacingSam(room, ref samCurrentPosition, ref enemyOnSameRow);

                SamMoves(ref samCurrentPosition, samDirections, moveNumber);

                CheckForNikoladzeOnSamRow(ref samCurrentPosition, ref enemyOnSameRow);
            }
        }

        private static void CheckForNikoladzeOnSamRow(ref int[] samCurrentPosition, ref int[] enemyOnSameRow)
        {
            CheckForEnemiesOnSamRow(samCurrentPosition, ref enemyOnSameRow);
            if (room[enemyOnSameRow[0]][enemyOnSameRow[1]] == nikoladze && samCurrentPosition[0] == enemyOnSameRow[0])
            {
                room[enemyOnSameRow[0]][enemyOnSameRow[1]] = xMarksTheSpot;
                Console.WriteLine("Nikoladze killed!");
                PrintRoom(room);
            }
        }

        private static void SamMoves(ref int[] samCurrentPosition, char[] samDirections, int moveNumber)
        {
            room[samCurrentPosition[0]][samCurrentPosition[1]] = dot;
            switch (samDirections[moveNumber])
            {
                case 'U':
                    samCurrentPosition[0]--;
                    break;
                case 'D':
                    samCurrentPosition[0]++;
                    break;
                case 'L':
                    samCurrentPosition[1]--;
                    break;
                case 'R':
                    samCurrentPosition[1]++;
                    break;
                default:
                    break;
            }
            room[samCurrentPosition[0]][samCurrentPosition[1]] = sam;
        }

        private static void CheckForEnemiesFacingSam(char[][] room,ref int[] samCurrentPosition, ref int[] enemyOnSameRow)
        {
            CheckForEnemiesOnSamRow(samCurrentPosition, ref enemyOnSameRow);

            if (samCurrentPosition[1] < enemyOnSameRow[1] && room[enemyOnSameRow[0]][enemyOnSameRow[1]] == 'd' && enemyOnSameRow[0] == samCurrentPosition[0])
            {
                room[samCurrentPosition[0]][samCurrentPosition[1]] = xMarksTheSpot;
                Console.WriteLine($"Sam died at {samCurrentPosition[0]}, {samCurrentPosition[1]}");
                PrintRoom(room);
            }
            else if (enemyOnSameRow[1] < samCurrentPosition[1] && room[enemyOnSameRow[0]][enemyOnSameRow[1]] == enemyFaceRight && enemyOnSameRow[0] == samCurrentPosition[0])
            {
                room[samCurrentPosition[0]][samCurrentPosition[1]] = xMarksTheSpot;
                Console.WriteLine($"Sam died at {samCurrentPosition[0]}, {samCurrentPosition[1]}");
                PrintRoom(room);
            }
        }

        private static void CheckForEnemiesOnSamRow(int[] samCurrentPosition, ref int[] enemyOnSameRow)
        {
            for (int j = 0; j < room[samCurrentPosition[0]].Length; j++)
            {
                if (room[samCurrentPosition[0]][j] != dot && room[samCurrentPosition[0]][j] != sam)
                {
                    enemyOnSameRow[0] = samCurrentPosition[0];
                    enemyOnSameRow[1] = j;
                }
            }
        }

        private static void PrintRoom(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void EnemiesMove(char[][] room, int rowCount)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    char currCell = room[row][col];
                    if (currCell == 'b')
                    {
                        if (IsDestinationCellValid(room, rowCount, row, col + 1))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                            break;
                        }
                        else
                        {
                            room[row][col] = 'd';
                            break;
                        }
                    }
                    else if (currCell == 'd')
                    {
                        if (IsDestinationCellValid(room, rowCount, row, col - 1))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                            break;
                        }
                        else
                        {
                            room[row][col] = 'b';
                            break;
                        }
                    }
                }
            }
        }

        private static bool IsDestinationCellValid(char[][] room, int rowCount, int row, int col)
        {
            return row >= 0 && row < rowCount && col >= 0 && col < room[row].Length;
        }

        private static void FillRoomAndSamPosition(ref char[][] room, int rowCount, ref int[] samPosition)
        {
            for (int row = 0; row < rowCount; row++)
            {
                var rowInputContent = Console.ReadLine().ToCharArray();
                room[row] = new char[rowInputContent.Length];
                for (int col = 0; col < rowInputContent.Length; col++)
                {
                    room[row][col] = rowInputContent[col];
                    if (rowInputContent[col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }
    }
}
