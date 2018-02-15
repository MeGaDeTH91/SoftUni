using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Test
{
    class PokemonEvo
    {
        public string EvolutionType { get; set; }
        public long EvolutionIndex { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, List<PokemonEvo>> pokemons = new Dictionary<string, List<PokemonEvo>>();

            while (input != "wubbalubbadubdub")
            {
                string[] arr = input.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if(arr.Length == 1)
                {
                    string pokeName = arr[0];
                    if(pokemons.ContainsKey(pokeName))
                    {
                        Console.WriteLine($"# {pokeName}");
                        foreach (var poke in pokemons)
                        {
                            if(poke.Key == pokeName)
                            {
                                foreach (var searched in poke.Value)
                                {
                                    Console.WriteLine($"{searched.EvolutionType} <-> {searched.EvolutionIndex}");
                                }
                            }
                            
                        }
                    }

                }
                else if(arr.Length == 3)
                {
                    string pokeName = arr[0];
                    string evoType = arr[1];
                    long evoIndex = long.Parse(arr[2]);
                    PokemonEvo currPokeEvo = new PokemonEvo()
                    {
                        EvolutionType = evoType,
                        EvolutionIndex = evoIndex
                    };
                    if(!pokemons.ContainsKey(pokeName))
                    {
                        pokemons[pokeName] = new List<PokemonEvo>();
                        pokemons[pokeName].Add(currPokeEvo);
                    }
                    else
                    {
                        pokemons[pokeName].Add(currPokeEvo);
                    }
                }

                input = Console.ReadLine();
            }
            
            foreach (var poke in pokemons)
            {
                Console.WriteLine($"# {poke.Key}");
               
                    foreach (var searched in poke.Value.OrderByDescending(x => x.EvolutionIndex))
                    {
                        Console.WriteLine($"{searched.EvolutionType} <-> {searched.EvolutionIndex}");
                    }
            }
        }
    }
}
