using System;

namespace P04_Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            Smartphone phone = new Smartphone("Smartphone", phones, urls);

            Console.WriteLine(phone);
        }
    }
}
