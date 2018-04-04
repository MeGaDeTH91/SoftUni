using System;

namespace P06_CodeTracker
{
    [SoftUni("Ventsi")]
    public class StartUp
    {
        [SoftUni("Gosho")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
