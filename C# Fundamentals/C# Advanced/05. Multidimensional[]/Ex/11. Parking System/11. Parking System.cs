using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                                     .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            int rows = matrixDimensions[0];
            int cols = matrixDimensions[1];

            Dictionary<int, HashSet<int>> parking = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < rows; i++)
            {
                parking[i] = new HashSet<int>();
            }
                
                        
            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                int[] parkingDetails = command
                                       .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToArray();

                int entryRow = parkingDetails[0];
                int desiredRow = parkingDetails[1];
                int desiredCol = parkingDetails[2];

                int parkIndex = 0;

                if (IsFree(parking, desiredRow, desiredCol))
                    parkIndex = desiredCol;

                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        int previous = desiredCol - i;
                        int next = desiredCol + i;

                        if (previous > 0 &&    // First col is unreachable by condition!
                             IsFree(parking, desiredRow, (previous))
                           )
                        {
                            parkIndex = previous;
                            break;
                        }

                        else if (next < cols &&
                                  IsFree(parking, desiredRow, (next))
                                )
                        {
                            parkIndex = next;
                            break;
                        }
                    }
                }

                if (parkIndex == 0)     // Not valid!
                    Console.WriteLine($"Row {desiredRow} full");

                else
                {
                    parking[desiredRow].Add(parkIndex);
                    int steps = Math.Abs(entryRow - desiredRow) + 1 + parkIndex;
                    Console.WriteLine(steps);
                }
            }
        }

        private static bool IsFree(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (!parking.ContainsKey(row) ||
                 !parking[row].Contains(col)
               )
            {
                return true;
            }
            return false;
        }
    }
}