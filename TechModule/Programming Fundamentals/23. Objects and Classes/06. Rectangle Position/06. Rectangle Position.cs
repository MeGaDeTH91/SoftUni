using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rectangle_Position
{
   public class Rectange
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Right { get { return Left + Width; } }
        public int Bottom { get { return Top + Height; } }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectange rect1 = ReadRectangle();
            Rectange rect2 = ReadRectangle();
            if(IsInside(rect1, rect2))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }
        static bool IsInside(Rectange r1, Rectange r2)
        {
            var isInLeft = r1.Left >= r2.Left;
            var isInRight = r1.Right <= r2.Right;
            var isInsideHorizontal = isInLeft && isInRight;
            var isInTop = r1.Top <= r2.Top;
            var isInBottom = r1.Bottom <= r2.Bottom;
            var isInsideVertical = isInTop && isInBottom;
            var final = isInsideHorizontal && isInsideVertical;
            return final;
        }
        public static Rectange ReadRectangle()
        {
            var size = Console.ReadLine().Split().Select(int.Parse);
            Rectange rectangle = new Rectange()
            {
                Left = size.First(),
                Top = size.Skip(1).First(),
                Width = size.Skip(2).First(),
                Height = size.Skip(3).First()
            };
            return rectangle;
        }
    }
    
}
