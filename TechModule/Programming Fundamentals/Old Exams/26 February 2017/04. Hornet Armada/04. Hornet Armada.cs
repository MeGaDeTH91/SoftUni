using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.Hornet_Armada
{
    class Legion
    {
        public string LegionName { get; set; }
        public long LastActivity { get; set; }
    }
    class Soldier
    {
        public List<string> SoldierType { get; set; }
        public long SoldierCount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, long>> legionsWithSoldiers = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> legionsWithActs = new Dictionary<string, long>();

            for (int i = 0; i < n; i++)
            {
                    string[] currInput = Console.ReadLine()
                        .Split(new char[] { ' ', '=', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                long currActivity = long.Parse(currInput[0]);
                string currLegName = currInput[1];
                string currSold = currInput[2];
                long soldCount = long.Parse(currInput[3]);

                if(legionsWithSoldiers.ContainsKey(currLegName))
                {
                    if(legionsWithSoldiers[currLegName].ContainsKey(currSold))
                    {
                        legionsWithSoldiers[currLegName][currSold] += soldCount;
                        if(currActivity > legionsWithActs[currLegName])
                        {
                            legionsWithActs[currLegName] = currActivity;
                        }
                    }
                    else
                    {
                        
                        legionsWithSoldiers[currLegName][currSold] = soldCount;
                        legionsWithActs[currLegName] = currActivity;
                    }

                }
                else
                {
                    legionsWithSoldiers[currLegName] = new Dictionary<string, long>();
                    legionsWithSoldiers[currLegName][currSold] = soldCount;
                    legionsWithActs[currLegName] = currActivity;
                }

            }
            string[] lastComm = Console.ReadLine()
                .Split(new char[] {' ', '\\'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if(lastComm.Length == 2)
            {
                long srchSoldier = long.Parse(lastComm[0]);
                string solType = lastComm[1];

                foreach (var leg in legionsWithSoldiers)
                {
                    foreach (var inn in leg.Value)
                    {
                        foreach (var k in inn.Key)
                        {
                            if(k = srchSoldier)
                        }
                    }
                }
            }
            else
            {

            }
        }
    }
}
