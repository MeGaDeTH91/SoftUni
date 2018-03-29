using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        int[] numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Lake lake = new Lake(numbers);

        lake.Jump();
    }
}
