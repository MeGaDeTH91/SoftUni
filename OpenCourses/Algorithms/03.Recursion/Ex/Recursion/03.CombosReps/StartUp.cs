namespace _03.CombosReps
{
    using System;

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
            GenCombos(0, 0);
        }

        private static void InitializeSet()
        {
            for (int i = 0; i < set.Length; i++)
            {
                set[i] = i + 1;
            }
        }

        private static void GenCombos(int index, int border)
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
                    GenCombos(index + 1, i);
                }
            }
        }
    }
}
