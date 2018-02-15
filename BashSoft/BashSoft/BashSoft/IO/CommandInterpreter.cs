namespace BashSoft
{
    using System;
    using System.Diagnostics;
    using SimpleJudge;

    /// <summary>
    /// Class respossible for interpreting user commands
    /// </summary>
    public class CommandInterpreter
    {
        /// <summary>
        /// Interprets given input and executes the coresponding command. If the command or arguments are invalid, an user friendly exception message is given
        /// </summary>
        /// <param name="input">User input string with command and arguments (if any)</param>
        public static void InterpredComman(string input)
        {
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = data[0];

            switch (command.ToLower())
            {
                case "open":
                    TryOpenFile(input, data);
                    break;
                case "mkdir":
                    TryCreateDirectory(input, data);
                    break;
                case "ls":
                    TryTraverseFolders(input, data);
                    break;
                case "cmp":
                    TryCompareFiles(input, data);
                    break;
                case "cdrel":
                    TryChangePathRelatively(input, data);
                    break;
                case "cdabs":
                    TryChangePathAbsolute(input, data);
                    break;
                case "readdb":
                    TryReadDatabaseFromFile(input, data);
                    break;
                case "help":
                    TryGetHelp(input, data);
                    break;
                case "show":
                    TryShowWantedData(input, data);
                    break;
                case "filter":
                    TryFilterAndTake(input, data);
                    break;
                case "order":
                    TryOrderAndTake(input, data);
                    break;
                case "decorder":
                    // TODO: implement after functionality is implemented
                    break;
                case "download":
                    // TODO: implement after functionality is implemented
                    break;
                case "downloadasynch":
                    // TODO: implement after functionality is implemented
                    break;
                default:
                    DisplayInvalidCommandMessage(input);
                    break;
            }
        }

        /// <summary>
        /// Method that displays an invalid command message. 
        /// </summary>
        /// <param name="input">The invalid input commad</param>
        private static void DisplayInvalidCommandMessage(string input)
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }

        /// <summary>
        /// Tries to open a file in explorer.
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, file name</param>
        private static void TryOpenFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to make a directory at given place
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, folder name</param>
        private static void TryCreateDirectory(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string folderName = data[1];
                IOManager.CreateDirectoryInCurrentFolder(folderName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to traverse the folders with given depth. Default depth is 0 (current folder)
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, depth (0 if not given)</param>
        private static void TryTraverseFolders(string input, string[] data)
        {
            if (data.Length == 1)
            {
                IOManager.TraverseDirectory(0);
            }
            else if (data.Length == 2)
            {
                int depth = 0;
                if (int.TryParse(data[1], out depth))
                {
                    IOManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to compare 2 files
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, first file absolute path, second file absolute path</param>
        private static void TryCompareFiles(string input, string[] data)
        {
            if (data.Length == 3)
            {
                string firstFilePath = data[1];
                string secondFilePath = data[2];
                Tester.CompareContent(firstFilePath, secondFilePath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to change current path to the relative path given
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, new relative path</param>
        private static void TryChangePathRelatively(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string relPath = data[1];
                IOManager.ChangeCurrentDirectoryRelative(relPath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to change current path to the absolute path given
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, new absolute path</param>
        private static void TryChangePathAbsolute(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string absolutePath = data[1];
                IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Tries to read the database from a file
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command, input file name</param>
        private static void TryReadDatabaseFromFile(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string fileName = data[1];
                StudentsRepository.InitializeData(fileName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        /// <summary>
        /// Lists all available commands
        /// </summary>
        /// <param name="input">Current command</param>
        /// <param name="data">Parameters collection: command</param>
        private static void TryGetHelp(string input, string[] data)
        {
            if (data.Length == 1)
            {
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
                OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
                OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
                OutputWriter.WriteEmptyLine();
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryShowWantedData(string input, string[] data)
        {
            if (data.Length == 2)
            {
                string courseName = data[1];
                StudentsRepository.GetAllStudentsFromCourse(courseName);
            }
            else if (data.Length == 3)
            {
                string courseName = data[1];
                string userName = data[2];
                StudentsRepository.GetStudentScoresFromCourse(courseName, userName);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }
        private static void TryOrderAndTake(string input, string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string comparison = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForOrderAndTake(takeCommand, takeQuantity, courseName, comparison);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForOrderAndTake(string takeCommand, string takeQuantity, string courseName, string comparison)
        {
            if (takeCommand == "take")
            {
                if (takeQuantity == "all")
                {
                    StudentsRepository.OrderAndTake(courseName, comparison, null);
                }
                else
                {
                    int studentsToTake;
                    var hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }

        private static void TryFilterAndTake(string input, string[] data)
        {
            if(data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2].ToLower();
                string takeCommand = data[3].ToLower();
                string takeQuantity = data[4].ToLower();

                TryParseParametersForFilterAndTake(takeCommand, takeQuantity, courseName, filter);
            }
            else
            {
                DisplayInvalidCommandMessage(input);
            }
        }

        private static void TryParseParametersForFilterAndTake(string takeCommand, string takeQuantity, string courseName, string filter)
        {
            if(takeCommand == "take")
            {
                if(takeQuantity == "all")
                {
                    StudentsRepository.FilterAndTake(courseName, filter);
                }
                else
                {
                    int studentsToTake;
                    bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);
                    if (hasParsed)
                    {
                        StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                    }
                    else
                    {
                        OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                    }
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidTakeCommand);
            }
        }
    }
}
