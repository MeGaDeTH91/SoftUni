namespace _04._Cubic_Assault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const int Border = 1000000;
        static void Main(string[] args)
        {
            List<Region> regions = new List<Region>();

            string command;
            while ((command = Console.ReadLine()) != "Count em all")
            {
                string[] currInput = command
                                     .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();

                string currentRegion = currInput[0];
                string colorType = currInput[1];
                long typeCount = long.Parse(currInput[2]);

                if (!regions.Any(x => x.Name == currentRegion))
                {
                    Region newReg = new Region()
                    {
                        Name = currentRegion,
                        Colors = new List<Color>(),
                        BlackCount = 0
                    };
                    Color black = new Color()
                    {
                        ColorType = "Black",
                        ColorCount = 0
                    };
                    Color red = new Color()
                    {
                        ColorType = "Red",
                        ColorCount = 0
                    };
                    Color green = new Color()
                    {
                        ColorType = "Green",
                        ColorCount = 0
                    };
                    newReg.Colors.Add(black);
                    newReg.Colors.Add(red);
                    newReg.Colors.Add(green);
                    regions.Add(newReg);
                }
                var reg = regions.FirstOrDefault(x => x.Name == currentRegion);
                switch (colorType)
                {
                    case "Black":
                        reg.BlackCount += typeCount;
                        reg.Colors.FirstOrDefault(x => x.ColorType == "Black").ColorCount += typeCount;
                        break;
                    case "Red":
                        reg.Colors.FirstOrDefault(x => x.ColorType == "Red").ColorCount += typeCount;
                        break;
                    case "Green":
                        reg.Colors.FirstOrDefault(x => x.ColorType == "Green").ColorCount += typeCount;
                        break;
                    default:
                        break;
                }
                var redUpdate = reg.Colors.FirstOrDefault(x => x.ColorType == "Red");
                var greenUpdate = reg.Colors.FirstOrDefault(x => x.ColorType == "Green");
                var blackUpdate = reg.Colors.FirstOrDefault(x => x.ColorType == "Black");

                while (redUpdate.ColorCount >= Border || greenUpdate.ColorCount >= Border)
                {
                    if (greenUpdate.ColorCount >= Border)
                    {
                        redUpdate.ColorCount += greenUpdate.ColorCount / Border;
                        greenUpdate.ColorCount %= Border;
                    }
                    if (redUpdate.ColorCount >= Border)
                    {
                        blackUpdate.ColorCount += redUpdate.ColorCount / Border;
                        reg.BlackCount += redUpdate.ColorCount / Border;
                        redUpdate.ColorCount %= Border;
                    }
                }
            }

            foreach (var region in regions.OrderByDescending(x => x.BlackCount).ThenBy(x => x.Name.Length).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{region.Name}");
                foreach (var color in region.Colors.OrderByDescending(x => x.ColorCount).ThenBy(x => x.ColorType))
                {
                    Console.WriteLine($"-> {color.ColorType} : {color.ColorCount}");
                }
            }
        }
        public class Region
        {
            public string Name { get; set; }

            public long BlackCount { get; set; }

            public List<Color> Colors { get; set; }
        }
        public class Color
        {
            public string ColorType { get; set; }
            public long ColorCount { get; set; }
        }
    }
}
