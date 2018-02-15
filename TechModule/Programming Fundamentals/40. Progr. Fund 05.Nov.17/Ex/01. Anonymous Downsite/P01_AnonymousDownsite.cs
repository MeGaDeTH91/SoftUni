using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01._Anonymous_Downsite
{


    public class P01_AnonymousDownsite
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int secKey = int.Parse(Console.ReadLine());

            decimal totalLoss = 0.0m;
            BigInteger securityToken = 0;

            List<string> sites = new List<string>();

            //List<string> affected = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string siteInput = Console.ReadLine();
                sites.Add(siteInput);
            }

            securityToken = (BigInteger)BigInteger.Pow(secKey, sites.Count());

            foreach (var site in sites)
            {
                string[] siteTokens = site
                    .Split(new[] { ' ', '\t', '\n', '\r' },StringSplitOptions.RemoveEmptyEntries).ToArray();


                string websiteName = siteTokens[0];

                long websiteVisits = long.Parse(siteTokens[1]);

                decimal pricePerVisit = decimal.Parse(siteTokens[2]);

                var siteLoss = websiteVisits * pricePerVisit;
                totalLoss += siteLoss;
            }

            foreach (var web in sites)
            {
                string site = web.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                Console.WriteLine(site);
            }

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}