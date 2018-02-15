using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01.Trainers
{
    class Top
    {
        public string TeamName { get; set; }
        public decimal Earned { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Top teamTechnical = new Top()
            {
                TeamName = "Technical",
                Earned = 0
            };
            Top teamTheoretical = new Top()
            {
                TeamName = "Theoretical",
                Earned = 0
            };
            Top teamPractical = new Top()
            {
                TeamName = "Practical",
                Earned = 0
            };
            for (int i = 0; i < n; i++)
            {
                Top currentWin = new Top();
                long distanceml = long.Parse(Console.ReadLine());
                decimal cargoTons = decimal.Parse(Console.ReadLine());
                string teamName = Console.ReadLine();
                decimal currentEarned = 0.0m;
                decimal cargoInKg = cargoTons * 1000m;
                long distanceMeters = distanceml * 1600;
                currentEarned = (cargoInKg * 1.5m) - (0.7m * distanceMeters * 2.5m);

                if(teamName == "Technical")
                {
                    teamTechnical.Earned += currentEarned;
                }
                else if (teamName == "Theoretical")
                {
                    teamTheoretical.Earned += currentEarned;
                }
                else if (teamName == "Practical")
                {
                    teamPractical.Earned += currentEarned;
                }
            }
            if(teamTechnical.Earned > teamPractical.Earned &&
                teamTechnical.Earned > teamTheoretical.Earned)
            {
                Console.WriteLine($"The {teamTechnical.TeamName} Trainers win with ${teamTechnical.Earned:F3}.");
            }
            else
            {
                if(teamPractical.Earned > teamTheoretical.Earned)
                {
                    Console.WriteLine($"The {teamPractical.TeamName} Trainers win with ${teamPractical.Earned:F3}.");
                }
                else
                {
                    Console.WriteLine($"The {teamTheoretical.TeamName} Trainers win with ${teamTheoretical.Earned:F3}.");
                }
            }
        }
    }
}
