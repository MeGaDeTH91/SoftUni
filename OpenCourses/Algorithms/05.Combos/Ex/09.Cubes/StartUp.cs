namespace _09.Cubes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private static char[] cube;
        private static HashSet<string> allPossibleCubes = new HashSet<string>();
        private static HashSet<string> resultCubes = new HashSet<string>();

        public static void Main()
        {
            cube = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

            CountCubes(0);

            Console.WriteLine(resultCubes.Count);
        }

        private static void CountCubes(int index)
        {
            if (index >= cube.Length)
            {
                string currentCube = string.Join("", cube);

                if (!allPossibleCubes.Contains(currentCube))
                {
                    MarkCube(currentCube);
                }
            }
            else
            {
                HashSet<int> swapped = new HashSet<int>();

                for (int i = index; i < cube.Length; i++)
                {
                    if (!swapped.Contains(cube[i]))
                    {
                        Swap(index, i);
                        CountCubes(index + 1);
                        Swap(index, i);
                        swapped.Add(cube[i]);
                    }
                }
            }
        }

        private static void MarkCube(string currentCube)
        {
            resultCubes.Add(currentCube);

            string rotatedX = RotateX(currentCube);
            string rotatedY = RotateY(currentCube);
            string rotatedZ = RotateZ(currentCube);

            for (int i = 0; i < 4; i++)
            {
                string mirrorX = RotateX(rotatedY);
                string mirrorY = RotateY(rotatedZ);
                string mirrorZ = RotateZ(rotatedX);

                allPossibleCubes.Add(rotatedX);
                rotatedX = RotateX(rotatedX);

                allPossibleCubes.Add(rotatedY);
                rotatedY = RotateY(rotatedY);

                allPossibleCubes.Add(rotatedZ);
                rotatedZ = RotateZ(rotatedZ);

                for (int j = 0; j < 4; j++)
                {
                    allPossibleCubes.Add(mirrorX);
                    mirrorX = RotateX(mirrorY);

                    allPossibleCubes.Add(mirrorY);
                    mirrorY = RotateX(mirrorZ);

                    allPossibleCubes.Add(mirrorZ);
                    mirrorZ = RotateX(mirrorX);
                }
            }
        }

        private static string RotateX(string currentCube)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(currentCube[3]);
            sb.Append(currentCube[1]);
            sb.Append(currentCube[2]);
            sb.Append(currentCube[0]);
            sb.Append(currentCube[7]);
            sb.Append(currentCube[4]);
            sb.Append(currentCube[5]);
            sb.Append(currentCube[6]);
            sb.Append(currentCube[11]);
            sb.Append(currentCube[8]);
            sb.Append(currentCube[9]);
            sb.Append(currentCube[10]);

            return sb.ToString().Trim();
        }

        private static string RotateY(string currentCube)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(currentCube[7]);
            sb.Append(currentCube[5]);
            sb.Append(currentCube[9]);
            sb.Append(currentCube[11]);
            sb.Append(currentCube[6]);
            sb.Append(currentCube[2]);
            sb.Append(currentCube[3]);
            sb.Append(currentCube[10]);
            sb.Append(currentCube[4]);
            sb.Append(currentCube[1]);
            sb.Append(currentCube[8]);
            sb.Append(currentCube[0]);

            return sb.ToString().Trim();
        }

        private static string RotateZ(string currentCube)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(currentCube[8]);
            sb.Append(currentCube[4]);
            sb.Append(currentCube[6]);
            sb.Append(currentCube[10]);
            sb.Append(currentCube[0]);
            sb.Append(currentCube[7]);
            sb.Append(currentCube[3]);
            sb.Append(currentCube[11]);
            sb.Append(currentCube[1]);
            sb.Append(currentCube[5]);
            sb.Append(currentCube[2]);
            sb.Append(currentCube[9]);

            return sb.ToString().Trim();
        }

        private static void Swap(int index, int i)
        {
            char element = cube[index];
            cube[index] = cube[i];
            cube[i] = element;
        }
    }
}
