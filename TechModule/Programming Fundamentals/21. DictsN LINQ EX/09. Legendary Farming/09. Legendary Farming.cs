using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _09.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> keyMaterials = new Dictionary<string, long>();
            keyMaterials["motes"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["shards"] = 0;

            SortedDictionary<string, long> junkMaterials = new SortedDictionary<string, long>();

            string input = Console.ReadLine();
            string pattern = @"((?<count>[0-9]+)([ ])(?<material>[A-Za-z0-9!.{}\[\](),]+))";
            Regex myRegex = new Regex(pattern);

            while (input != null)
            {
                MatchCollection matches = myRegex.Matches(input);
                foreach (Match currMatch in matches)
                {
                    long countMatch = long.Parse(currMatch.Groups["count"].Value);
                    string matMatch = currMatch.Groups["material"].Value.ToLower();

                    if(matMatch == "shards" || matMatch == "fragments" ||
                        matMatch == "motes")
                    {
                        keyMaterials[matMatch] += countMatch;
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(matMatch))
                        {
                            junkMaterials[matMatch] += countMatch;
                        }
                        else
                        {
                            junkMaterials[matMatch] = countMatch;
                        }
                    }

                    if (keyMaterials["motes"] >= 250)
                    {
                        Console.WriteLine($"Dragonwrath obtained!");
                        keyMaterials["motes"] -= 250;
                        foreach (var keyMats in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{keyMats.Key}: {keyMats.Value}");
                        }
                        foreach (var junk in junkMaterials.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{junk.Key}: {junk.Value}");
                        }
                        return;
                    }
                    if (keyMaterials["fragments"] >= 250)
                    {
                        Console.WriteLine($"Valanyr obtained!");
                        keyMaterials["fragments"] -= 250;
                        foreach (var keyMats in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{keyMats.Key}: {keyMats.Value}");
                        }
                        foreach (var junk in junkMaterials.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{junk.Key}: {junk.Value}");
                        }
                        return;
                    }
                    if (keyMaterials["shards"] >= 250)
                    {
                        Console.WriteLine($"Shadowmourne obtained!");
                        keyMaterials["shards"] -= 250;
                        foreach (var keyMats in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                        {
                            Console.WriteLine($"{keyMats.Key}: {keyMats.Value}");
                        }
                        foreach (var junk in junkMaterials.OrderBy(x => x.Key))
                        {
                            Console.WriteLine($"{junk.Key}: {junk.Value}");
                        }
                        return;
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
