namespace BashSoft
{
    using System;

    /// <summary>
    /// An interpreter that calls the functionalities. 
    /// </summary>
    public class InputReader
    {
        private const string endCommand = "quit";

        /// <summary>
        /// Starts to listen for commands and executes them if the syntax is correct. 
        /// </summary>
        public static void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
            string input = Console.ReadLine();
            input = input.Trim();

            // TODO: change with do-while ??? avoiding repetitions of code
            while (!input.Equals(endCommand))
            {
                CommandInterpreter.InterpredComman(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}
