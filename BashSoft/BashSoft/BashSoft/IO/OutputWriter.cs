namespace BashSoft
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Class that give us base functionality for communication with a user.
    /// </summary>
    public static class OutputWriter
    {
        /// <summary>
        ///     Method that give us the ability to write a message.
        /// </summary>
        /// <param name="message">Message to be writen</param>
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }
        
        /// <summary>
        ///     Method for writing a message on a new line.
        /// </summary>
        /// <param name="message">Message to be writen</param>
        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        ///     Method for writing a new empty line.
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        ///     Method for writing a different kind of message which is an error/exception
        /// </summary>
        /// <param name="message">Message to be writen</param>
        public static void DisplayException(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void PrintStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }
    }
}