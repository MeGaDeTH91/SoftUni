using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.Email_Statistics
{
    class Domains
    {
        public string Name { get; set; }
        public List<string> User { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<username>([A-Za-z]{5,100}))@(?<server>([a-z]){3,100}.)(?<topLVL>(([com]{3})|([bg]{2})|([org]{3})))\b";
            List<Domains> registry = new List<Domains>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                Domains simpleDomain = new Domains()
                {
                    User = new List<string>()
                };
                string inputMail = Console.ReadLine();
                Match currMatch = Regex.Match(inputMail, pattern);
                if(currMatch.Success)
                {
                    string currDomain = currMatch.Groups["server"].Value + currMatch.Groups["topLVL"].Value.ToString();
                    string currUser = currMatch.Groups["username"].Value.ToString();
                    if(registry.Select(x => x.Name).Any(x => x.Contains(currDomain)))
                    {
                        int findMeIndex = registry.FindIndex(x => x.Name == currDomain);
                        if(!registry[findMeIndex].User.Contains(currUser))
                        {
                            registry[findMeIndex].User.Add(currUser);
                        }
                    }
                    else
                    {
                        simpleDomain.Name = currDomain;
                        simpleDomain.User.Add(currUser);
                        registry.Add(simpleDomain);
                    }
                }
            }
            foreach (var domain in registry.OrderByDescending(x => x.User.Count))
            {
                Console.WriteLine($"{domain.Name}:");
                foreach (var user in domain.User)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}
