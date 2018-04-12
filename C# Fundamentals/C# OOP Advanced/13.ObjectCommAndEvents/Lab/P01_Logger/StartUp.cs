namespace P01_Logger
{
    using System;

    public class StartUp
    {
        public delegate void MyFirstDelegate(string someInput);
        public event MyFirstDelegate MyFirstEvent;
        public static void Main()
        {
            

        }

        public void SomeVoidMethodTakingString(string input)
        {
            Console.WriteLine("Batman1");
        }

        public void SomeVoidMethodTakingString2(string input)
        {
            Console.WriteLine("Batman2");
        }
    }
}
