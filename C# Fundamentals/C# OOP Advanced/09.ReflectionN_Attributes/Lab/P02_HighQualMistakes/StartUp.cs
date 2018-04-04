using System;

namespace P02_HighQualMistakes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
