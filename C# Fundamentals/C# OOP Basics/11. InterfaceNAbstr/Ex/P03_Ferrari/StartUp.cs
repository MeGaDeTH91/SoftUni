using System;

namespace P03_Ferrari
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            IFerrari ferrari = new Ferrari("488-Spider", driver);

            Console.WriteLine(ferrari);
        }
    }
}
