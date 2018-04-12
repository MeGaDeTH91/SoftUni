namespace P01_EventImplementation
{
    using P01_EventImplementation.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                dispatcher.Name = command;
            }
        }
    }
}
