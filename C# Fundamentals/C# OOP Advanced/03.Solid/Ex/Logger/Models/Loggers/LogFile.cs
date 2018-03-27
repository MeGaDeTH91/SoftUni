namespace LoggerLibrary.Models.Loggers
{
    using LoggerLibrary.Interfaces;
    using System;
    using System.IO;

    public class LogFile : ILogFile
    {
        const string DefaultPath = "../data/";

        public string Path { get; }

        public int Size { get; private set; }

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            this.InitializeDirectory();
            this.Size = 0;
        }

        private void InitializeDirectory()
        {
            Directory.CreateDirectory(DefaultPath);
            File.AppendAllText(this.Path, string.Empty);
        }

        public void WriteLogToFile(string errorLog)
        {
            File.AppendAllText(this.Path, errorLog + Environment.NewLine);

            int addedSize = 0;

            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }
            this.Size += addedSize;
        }
    }
}
