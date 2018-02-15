using System;
using System.IO;

namespace _04._CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../inputs/copyMe.png";
            string outputPath = "../outputs/copyMe.png";

            using (var source = new FileStream(inputPath, FileMode.Open))
            {
                using (var destinationFile = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readByCount = source.Read(buffer, 0, buffer.Length);
                        if(readByCount <= 0)
                        {
                            break;
                        }
                        destinationFile.Write(buffer, 0, buffer.Length);
                    }
                }
            }

            //2-ри начин
            //using (var stream = new FileStream(inputPath, FileMode.Open))
            //{
            //    using(var copyStream = new FileStream(outputPath, FileMode.CreateNew))
            //    {
            //        stream.CopyTo(copyStream);
            //    }
            //}
        }
    }
}
