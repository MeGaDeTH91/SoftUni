﻿using System;

namespace P04_Collector
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
