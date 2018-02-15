using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace _03.Nether_Realms
{
    class Demon
    {
        public long Health { get; set; }
        public decimal Damage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] demonsList = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string pattern = @"(?<number>(([+-])*)(([0-9]+([.])*([0-9]+)*)))";
            SortedDictionary<string, Demon> participants = new SortedDictionary<string, Demon>();

            foreach (var demon in demonsList)
            {
                long health = 0;
                decimal dmg = 0.0m;
                MatchCollection match = Regex.Matches(demon, pattern);
                char[] currDem = demon.ToCharArray();
                for (int i = 0; i < currDem.Length; i++)
                {
                    if(!char.IsDigit(currDem[i]) &&
                        (currDem[i] != '.' &&
                        currDem[i] != '+' &&
                        currDem[i] != '-' &&
                        currDem[i] != '*' &&
                        currDem[i] != '/'))
                    {
                        health += currDem[i];
                    }
                    
                }
                string action = string.Empty;
                foreach (Match m in match)
                {
                    string currMatch = m.ToString();

                    decimal currNum = decimal.Parse(m.Groups["number"].Value.ToString());
                    dmg += currNum;
                    
                }
                for (int i = 0; i < demon.Length; i++)
                {
                    if (demon[i] == '*')
                    {
                        dmg *= 2;
                    }
                    else if (demon[i] == '/')
                    {
                        dmg /= 2;
                    }
                }
                if (!participants.ContainsKey(demon))
                {
                    participants[demon] = new Demon();
                    participants[demon].Health = health;
                    participants[demon].Damage = dmg;
                }
                
            }
            foreach (var currDemon in participants)
            {
                Console.WriteLine($"{currDemon.Key} - {currDemon.Value.Health} health, {currDemon.Value.Damage:F2} damage");
            }
        }
    }
}
