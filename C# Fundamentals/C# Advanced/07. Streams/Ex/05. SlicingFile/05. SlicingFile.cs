using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _05._SlicingFile
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            int slices = 5;
            string sourceFile = "../inputs/sliceMe.mp4";
            string destinationDirectory = "../outputs/";
            List<string> files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Slice(sourceFile, destinationDirectory, slices);
            Assemble(files, destinationDirectory);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int slices)
        {
            using (var streamFile = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long sliceSize = (long)Math.Ceiling((double)streamFile.Length / slices);
                
                for (int index = 0; index < slices; index++)
                {
                    string currentDestinationDir = destinationDirectory + $"Part-{index}." + extension;

                    long currSliceSize = 0;

                    using (var writer = new FileStream(currentDestinationDir, FileMode.Create))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (streamFile.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currSliceSize += bufferSize;
                            if(currSliceSize >= sliceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            string assembledFile = $"{destinationDirectory}Assembled.{extension}";

            using (var writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];
                string sourceDir = "../outputs/";

                foreach (var file in files)
                {
                    string currentSourceDir = sourceDir +file;

                    using (var reader = new FileStream(currentSourceDir, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, bufferSize) > 0)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }        
    }
}
