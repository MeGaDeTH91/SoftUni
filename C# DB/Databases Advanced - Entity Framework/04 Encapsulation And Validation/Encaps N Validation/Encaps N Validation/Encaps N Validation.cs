using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        decimal length = decimal.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);

            decimal surfArea = box.SurfArea(length, width, height);
            decimal latArea = box.LatSurfArea(length, width, height);
            decimal volume = box.Volume(length, width, height);

            Console.WriteLine($"Surface Area - {surfArea:F2}");
            Console.WriteLine($"Lateral Surface Area - {latArea:F2}");
            Console.WriteLine($"Volume - {volume:F2}");
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
        
    }
}