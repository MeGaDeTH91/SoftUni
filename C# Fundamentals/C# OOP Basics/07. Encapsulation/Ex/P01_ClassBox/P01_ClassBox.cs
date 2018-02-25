using System;

namespace P01_ClassBox
{
    class P01_ClassBox
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box myBox = new Box(length, width, height);

            double surfaceArea = myBox.SurfaceArea();
            double lateralSurfaceArea = myBox.LateralSurfaceArea();
            double volume = myBox.Volume();

            Console.WriteLine($"Surface Area - {surfaceArea:F2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
