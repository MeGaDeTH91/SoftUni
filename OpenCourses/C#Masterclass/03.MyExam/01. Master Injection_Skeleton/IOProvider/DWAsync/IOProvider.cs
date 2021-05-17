namespace DWAsync
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class IOProvider
    {
        public static async Task<string> ReadFileAsync(string file)
        {
            return await File.ReadAllTextAsync(file);
        }
        public static async Task WriteFileAsync(string dir, string file, string content)
        {
            Directory.CreateDirectory(dir);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dir, file)))
            {
                await outputFile.WriteAsync(content);
            }
        }
    }
}
