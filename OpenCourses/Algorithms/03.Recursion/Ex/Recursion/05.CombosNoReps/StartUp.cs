namespace _05.CombosNoReps
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] set;
        private static int[] comboVec;

        public static void Main()
        {
            int setCount = int.Parse(Console.ReadLine());
            int vecCount = int.Parse(Console.ReadLine());

            set = new int[setCount];
            comboVec = new int[vecCount];

            InitializeSet();
            GenerateCombos(0, 0);
        }

        private static void GenerateCombos(int index, int border)
        {
            if(index == comboVec.Length)
            {
                Console.WriteLine(string.Join(" ", comboVec));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    comboVec[index] = set[i]; 
                    GenerateCombos(index + 1, i + 1);
                }
            }
        }

        private static void InitializeSet()
        {
            for (int i = 0; i < set.Length; i++)
            {
                set[i] = i + 1;
            }
        }
    }
}
