namespace BashSoft
{
    using System.IO;

    /// <summary>
    /// Holds the data for the current session. 
    /// </summary>
    public static class SessionData
    {
        /// <summary>
        /// starts with a value of, the application’s directory in the file system.
        /// </summary>
        public static string currentPath = Directory.GetCurrentDirectory();
    }
}
