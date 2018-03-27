namespace LoggerLibrary.Interfaces
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteLogToFile(string errorLog);
    }
}
