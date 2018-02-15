using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string inpLine = Console.ReadLine();
            string scorePattern = @"[0-9]+[:][0-9]+";
            Dictionary<string, int> results = new Dictionary<string, int>();
            Dictionary<string,int> topScorers = new Dictionary<string, int>();
            
            while (inpLine != "final")
            {
                int index = inpLine.IndexOf(key) + key.Length;
                string firstSeparation = inpLine.Substring(index, inpLine.Length - 1 - index);
                int secondIndex = firstSeparation.IndexOf(key) + key.Length;
                string team1 = firstSeparation.Substring(0, secondIndex - key.Length);
                string SecondSepar = firstSeparation.Substring(secondIndex, firstSeparation.Length - 1 - secondIndex);
                int thirdIndex = SecondSepar.IndexOf(key) + key.Length;
                string thirdSep = SecondSepar.Substring(thirdIndex, SecondSepar.Length - thirdIndex);
                int fourthIndex = thirdSep.IndexOf(key);
                string team2 = thirdSep.Substring(0, fourthIndex);
                string score = string.Empty;
                Match scoreMatch = Regex.Match(inpLine, scorePattern);
                StringBuilder buildMeTeams = new StringBuilder();
                StringBuilder buildMeScore = new StringBuilder();
                buildMeScore.Append(scoreMatch.ToString());
                score = buildMeScore.ToString();
                string[] scoreArr = score.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                char[] temp1 = team1.ToCharArray();
                temp1 = temp1.Reverse().ToArray();
                char[] temp2 = team2.ToCharArray();
                temp2 = temp2.Reverse().ToArray();
                team1 = new string(temp1).ToUpper();
                if(!results.ContainsKey(team1))
                {
                    results[team1] = 0;
                }
                team2 = new string(temp2).ToUpper();
                if (!results.ContainsKey(team2))
                {
                    results[team2] = 0;
                }
                int scoreTeam1 = int.Parse(scoreArr[0]);
                if(scoreTeam1 > 0)
                {
                    if(topScorers.ContainsKey(team1))
                    {
                        topScorers[team1] += scoreTeam1;
                    }
                    else
                    {
                        topScorers[team1] = scoreTeam1;
                    }
                }
                int scoreTeam2 = int.Parse(scoreArr[1]);
                if (scoreTeam2 > 0)
                {
                    if (topScorers.ContainsKey(team2))
                    {
                        topScorers[team2] += scoreTeam2;
                    }
                    else
                    {
                        topScorers[team2] = scoreTeam2;
                    }
                }
                string winner = string.Empty;
                if(scoreTeam1 > scoreTeam2)
                {
                    winner = team1;

                        results[winner]+=3;
                    
                }
                else if(scoreTeam2 > scoreTeam1)
                {
                    winner = team2;

                        results[winner]+=3;   
                    
                }
                else if (scoreTeam1==scoreTeam2)
                {
                    
                    results[team1]++;
                    results[team2]++;
                }
                
                inpLine = Console.ReadLine();
            }
            int counter = 1;
            Console.WriteLine("League standings:");
            foreach (var team in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter}. {team.Key} {team.Value}");
                counter++;
            }
            Console.WriteLine("Top 3 scored goals:");
            counter = 0;
            foreach (var sco in topScorers.OrderByDescending(x=> x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"- {sco.Key} -> {sco.Value}");
                if(counter == 2)
                {
                    break;
                }
                counter++;
            }
        }
    }
}
