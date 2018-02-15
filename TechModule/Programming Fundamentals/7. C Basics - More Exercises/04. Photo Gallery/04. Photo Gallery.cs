using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            var photoNum = int.Parse(Console.ReadLine());
            var day = int.Parse(Console.ReadLine());
            var month = int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hours = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var size = int.Parse(Console.ReadLine());
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            var byteToKb = 0.0;
            var kbtoMb = 0.0;
            if (size >= 1024)
            {
                 byteToKb = size / 1000;
            }
            if (byteToKb >= 1024)
            {
                 kbtoMb = byteToKb / 1000;
            }
            Console.WriteLine("Name: DSC_{0:D4}.jpg", photoNum);
            Console.WriteLine("Date Taken: {0:D2}/{1:D2}/{2} {3:D2}:{4:D2}", day, month, year, hours, minutes);
            if (kbtoMb >0)
            {
                Console.WriteLine("Size: {0}MB", kbtoMb);
            }
            else if (byteToKb > 0)
            {
                Console.WriteLine("Size: {0}KB", byteToKb);
            }
            else 
            {
                Console.WriteLine("Size: {0}B", size);
            }
           
            if(width > height)
            {
                Console.WriteLine("Resolution: {0}x{1} (landscape)", width, height);
            }
            else if (width < height)
            {
                Console.WriteLine("Resolution: {0}x{1} (portrait)", width, height);
            }
            else if (width == height)
            {
                Console.WriteLine("Resolution: {0}x{1} (square)", width, height);
            }
        }
    }
}
