using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.Files
{
    class File
    {
        public string Root { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public BigInteger Size { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<File> allFiles = new List<File>();
            for (int i = 0; i < n; i++)
            {
                
                string currInput = Console.ReadLine();   // Current Input Command
                string[] rootSplit = currInput.Split('\\').ToArray();  // Split For The Root
                string root = rootSplit[0];   // Now we have the Root
                string[] sizeSplit = currInput.Split(';').ToArray(); // Split For Size
                string pathPlusFile = sizeSplit[0]; // Now we have Path and File
                BigInteger size = BigInteger.Parse(sizeSplit[1]); // Now we have Current Size
                string[] fileSplit = rootSplit.Last().Split(';').ToArray();  //Split For Filename
                string currFileName = fileSplit[0];              // Now we have the filename
                string[] extSplit = currFileName.Split('.').ToArray(); // Split for extension
                string currExtension = extSplit.Last();  // now we have the extension of the current file

                File currFile = new File()
                {
                    Root = root,
                    FileName = currFileName,
                    Extension = currExtension,
                    Size = size
                };
                var fileNamematch = allFiles.FirstOrDefault(x => x.FileName == currFileName && x.Root == root);
                if (fileNamematch != null)
                {
                    fileNamematch.Size = size;
                }
                else
                {
                    allFiles.Add(currFile);
                }
            }
            string[] searchInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string neededExt = searchInput[0];
            string neededRoot = searchInput[2];
            var result = allFiles.
                Where(f => f.Root == neededRoot).
                Where(f => f.Extension == neededExt).
                OrderByDescending(x => x.Size).
                ThenBy(x => x.FileName);
            if(result.Any())
            {
                foreach (var r in result)
                {
                    Console.WriteLine($"{r.FileName} - {r.Size} KB");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
