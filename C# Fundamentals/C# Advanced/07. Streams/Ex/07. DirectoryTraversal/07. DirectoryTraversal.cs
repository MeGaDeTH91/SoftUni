using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._DirectoryTraversal
{
    class Program
    {
        private static Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            MakeDirectoryTraversal(path);
        }

        public static void MakeDirectoryTraversal(string path)
        {
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;
                long fileSize = info.Length;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }
                filesDictionary[extension].Add(info);
            }

            filesDictionary = filesDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktopPath + "/report.txt";

            using (var streamWriter = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value;

                    streamWriter.WriteLine(extension);

                    foreach (var fileInfo in fileInfos.OrderByDescending(x => x.Length))
                    {
                        double size = (double)fileInfo.Length / 1024;

                        streamWriter.WriteLine($"--{fileInfo.Name} - {size}kb");
                    }
                }
            }
        }
    }
}
