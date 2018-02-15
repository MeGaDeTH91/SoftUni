using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Magic_exchangeable_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split()
                .ToArray();
            Dictionary<string, string> registry = new Dictionary<string, string>();
            List<char> leftWord = new List<char>();
            List<char> rightWord = new List<char>();
            if (strings[0].Length > strings[1].Length)
            {
                leftWord = strings[1].ToList();
                rightWord = strings[0].ToList();
            }
            else
            {
                leftWord = strings[0].ToList();
                rightWord = strings[1].ToList();
            }
            bool exchangable = true;
            if (leftWord.Count == rightWord.Count)
            {
                
                for (int i = 0; i < rightWord.Count; i++)
                {
                    if (registry.ContainsKey(leftWord[i].ToString()) )
                    {
                        if (registry[leftWord[i].ToString()] != rightWord[i].ToString())
                        {
                            exchangable = false;
                            Console.WriteLine("false");
                            return;
                        }
                    }
                    else if(registry.ContainsValue(rightWord[i].ToString()))
                    {
                        exchangable = false;
                        Console.WriteLine("false");
                        return;
                    }
                    else
                    {
                        registry[leftWord[i].ToString()] = rightWord[i].ToString();
                    }
                }
            }
            else if (leftWord.Count < rightWord.Count)
            {
                for (int i = 0; i < leftWord.Count; i++)
                {
                    if (registry.ContainsKey(leftWord[i].ToString()))
                    {
                        if (registry[leftWord[i].ToString()] != rightWord[i].ToString())
                        {
                            exchangable = false;
                            Console.WriteLine("false");
                            return;
                        }
                    }
                    else if (registry.ContainsValue(rightWord[i].ToString()))
                    {
                        exchangable = false;
                        Console.WriteLine("false");
                        return;
                    }
                    else
                    {
                        registry[leftWord[i].ToString()] = rightWord[i].ToString();
                    }
                }
                if(!exchangable)
                {
                    Console.WriteLine("false");
                    return;
                }
                if (exchangable == true)
                {
                    for (int i = leftWord.Count; i < rightWord.Count; i++)
                    {
                        if (!registry.ContainsValue(rightWord[i].ToString()))
                        {
                            exchangable = false;
                        }
                    }
                }
            }
            var result = exchangable.ToString().ToLower();
            Console.WriteLine(result);
        }
    }
}
