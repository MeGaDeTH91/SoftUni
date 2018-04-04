using System;

namespace P03_MissionPrivateImpossible
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.RevealPrivateMethods("Hacker");

            Console.WriteLine(result);
        }
    }
}
