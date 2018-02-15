using System;
using System.Collections.Generic;
using System.Linq;

class Program

{
    static void Main()
    {
        var dict = new Dictionary<string, HashSet<string>>();
        string input = Console.ReadLine();

        while (input != "Blaze it!")
        {
            string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            string creature = tokens[0];
            string squadM = tokens[1];

            if (!dict.ContainsKey(creature))
                dict[creature] = new HashSet<string>();

            dict[creature].Add(squadM);

            input = Console.ReadLine();
        }

        List<string> keys = dict.Keys.ToList();
        var secDict = new Dictionary<string, int>();

        foreach (var kvp in dict)
        {
            string key = kvp.Key;
            var words = kvp.Value;
            int count = words.Count;

            foreach (var word in words)
            {
                bool IsThereSuchKey = keys.Contains(word);

                if (IsThereSuchKey)
                {
                    bool DoesKeyContainSuchMate = dict[word].Contains(key);

                    if (IsThereSuchKey && DoesKeyContainSuchMate)
                        count--;
                }
            }

            if (!secDict.ContainsKey(key))
                secDict[key] = 0;

            secDict[key] = count;
        }

        foreach (var kvp in secDict.OrderByDescending(n => n.Value))
            Console.WriteLine($"{kvp.Key} : {kvp.Value}");
    }
}