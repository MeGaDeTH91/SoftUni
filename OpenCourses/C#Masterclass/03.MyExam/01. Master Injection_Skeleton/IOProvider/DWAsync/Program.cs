using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DWAsync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string dirPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            ProcessIOAsync(dirPath + "/Files").Wait();
        }

        public static async Task ProcessIOAsync(string dirPath)
        {
            foreach (string file in Directory.EnumerateFiles(dirPath))
            {
                string fileText = await IOProvider.ReadFileAsync(file);
                string filenameWithoutPath = Path.GetFileName(file);

                await IOProvider.WriteFileAsync(dirPath + "/Result", filenameWithoutPath, fileText);
            }
        }
    }
}
