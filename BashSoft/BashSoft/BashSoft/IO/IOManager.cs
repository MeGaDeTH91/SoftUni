using System;

namespace BashSoft
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    ///     Functionality for traversing the folders and other behaviors.
    /// </summary>
    public static class IOManager
    {
        /// <summary>
        ///     Traverse the folder of the project using a queue with BFS.
        /// </summary>
        /// <param name="path">Folders to traverse</param>
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            var subFoldersQueue = new Queue<string>();
            subFoldersQueue.Enqueue(SessionData.currentPath);

            while (subFoldersQueue.Count != 0)
            {
                // Dequeue the folder at the start of the queue
                string currentPath = subFoldersQueue.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                // stop when we reached the wanted depth
                if (depth - identation < 0)
                {
                    break;
                }

                // Print the folder path
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

                try
                {
                    foreach (string file in Directory.GetFiles(currentPath))
                    {
                        // get file name and replace the full path with dashes
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', indexOfLastSlash), fileName));
                    }

                    // Add all it's subfolders to the end of the queue
                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFoldersQueue.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        /// <summary>
        /// Method for making a directory.
        /// </summary>
        /// <param name="name">Name of the folder to create</param>
        public static void CreateDirectoryInCurrentFolder(string name)
        {
            // TODO: GetCurrentDirectoryPath()
            string path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        /// <summary>
        /// Moves forwards and backwards in the folders 
        /// </summary>
        /// <param name="relativePath">New relative path</param>
        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        /// <summary>
        /// Gets an absolute path and goes directly there
        /// </summary>
        /// <param name="absolutePath">Absolute path to go to</param>
        public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            SessionData.currentPath = absolutePath;
        }
    }
}