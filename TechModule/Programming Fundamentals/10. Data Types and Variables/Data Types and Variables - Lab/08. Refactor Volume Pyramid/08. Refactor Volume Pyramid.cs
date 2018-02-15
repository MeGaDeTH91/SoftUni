using System;



    class Program
    {
        static void Main()
        {
            Console.Write("Length: ");
            var length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            var width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            var height = double.Parse(Console.ReadLine());

            double result = (length * width * height) /3  ;
            Console.WriteLine("Pyramid Volume: {0:F2}", result);
            //my code
        }
    }

