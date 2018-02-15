using System;
using System.IO;
using System.IO.Compression;

namespace _06._ZipSlicFiles
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            int slices = 5;
            string sourceFile = "../inputs/sliceMe.mp4";
            string destinationDirectory = "../outputs/";

            GzipIt(sourceFile, destinationDirectory, slices);
        }

        private static void GzipIt(string sourceFile, string destinationDirectory, int slices)
        {
            using (var streamFile = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                long sliceSize = (long)Math.Ceiling((double)streamFile.Length / slices);

                for (int index = 0; index < slices; index++)
                {
                    string currentDestinationDir = destinationDirectory + $"Part-{index}.{extension}.gz";

                    long currSliceSize = 0;

                    using (GZipStream writer = new GZipStream(new FileStream(currentDestinationDir, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];

                        while (streamFile.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currSliceSize += bufferSize;
                            if (currSliceSize >= sliceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
