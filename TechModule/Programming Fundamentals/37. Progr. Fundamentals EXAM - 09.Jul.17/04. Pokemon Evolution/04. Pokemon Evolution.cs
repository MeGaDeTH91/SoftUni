using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Pokemon_Evolution
{
    class Pokemon
    {
        public string Evo { get; set; }
        public int Index { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<Pokemon>> pokemonReg = new Dictionary<string, List<Pokemon>>();
            while (input != "wubbalubbadubdub")
            {
                string[] splitedInput = input
                    .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (splitedInput.Length == 1)
                {
                    string pokemName = splitedInput[0];
                    if (pokemonReg.ContainsKey(pokemName))
                    {
                        foreach (var currPoke in pokemonReg)
                        {
                            if (currPoke.Key == pokemName)
                            {
                                Console.WriteLine($"# {currPoke.Key}");
                                foreach (var it in currPoke.Value)
                                {
                                    Console.WriteLine($"{it.Evo} <-> {it.Index}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    string currPokem = splitedInput[0];
                    string currEvo = splitedInput[1];
                    int currIndex = int.Parse(splitedInput[2]);

                    if (!pokemonReg.ContainsKey(currPokem))
                    {
                        List<Pokemon> currList = new List<Pokemon>();
                        currList.Add(new Pokemon());
                        currList[0].Evo = currEvo;
                        currList[0].Index = currIndex;
                        pokemonReg[currPokem] = new List<Pokemon>(currList);
                    }
                    else
                    {
                        List<Pokemon> currPokemon = new List<Pokemon>();
                        currPokemon.Add(new Pokemon());
                        currPokemon[0].Evo = currEvo;
                        currPokemon[0].Index = currIndex;
                        pokemonReg[currPokem].Add(currPokemon[0]);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var pok in pokemonReg)
            {
                Console.WriteLine($"# {pok.Key}");
                foreach (var i in pok.Value.OrderByDescending(x => x.Index))
                {
                    Console.WriteLine($"{i.Evo} <-> {i.Index}");
                }
            }
        }
    }
}
