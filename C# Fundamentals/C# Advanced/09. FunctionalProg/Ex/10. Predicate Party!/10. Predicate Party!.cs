using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .ToList();

            Predicate<string> doublePredicate = stringCmm => stringCmm.ToLower() == "double";
            Predicate<string> removePredicate = stringCmm => stringCmm.ToLower() == "remove";
            Predicate<string> startsWithPredicate = stringCmm => stringCmm.ToLower() == "startswith";
            Predicate<string> endsWithPredicate = stringCmm => stringCmm.ToLower() == "endswith";
            Predicate<string> lengthPredicate = stringCmm => stringCmm.ToLower() == "length";

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] commTokens = command
                                      .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                string commType = commTokens[0];
                string commCriteria = commTokens[1];
                string commParams = commTokens[2];

                List<string> tempList = new List<string>();

                if (doublePredicate(commType))
                {
                    if (startsWithPredicate(commCriteria))
                    {
                        int startLength = commParams.Length;
                        string pesh = "Pesho";
                        pesh = pesh.Substring(0, startLength );
                        tempList = names.Where(x => x.Substring(0, startLength) == commParams).ToList();

                    }
                    else if (endsWithPredicate(commCriteria))
                    {
                        int startLength = commParams.Length;
                        tempList = names.Where(x => x.Substring(x.Length - startLength, x.Length - 1) == commParams).ToList();

                    }
                    else if (lengthPredicate(commCriteria))
                    {
                        int currLength = int.Parse(commParams);
                        tempList = names.Where(x => x.Length == currLength).ToList();
                    }
                    if(tempList.Count > 0)
                    {
                        names.AddRange(tempList);
                    }
                }
                else if(removePredicate(commType))
                {
                    if (startsWithPredicate(commCriteria))
                    {
                        int startLength = commParams.Length;
                        tempList = names.Where(x => x.Substring(0, startLength) == commParams).ToList();

                    }
                    else if (endsWithPredicate(commCriteria))
                    {
                        int startLength = commParams.Length;
                        tempList = names.Where(x => x.Substring(x.Length - startLength , x.Length - 1) == commParams).ToList();

                    }
                    else if (lengthPredicate(commCriteria))
                    {
                        int currLength = int.Parse(commParams);
                        tempList = names.Where(x => x.Length == currLength).ToList();
                    }
                    if (tempList.Count > 0)
                    {
                        foreach (var tempName in tempList)
                        {
                            int indexOf = names.IndexOf(tempName);
                            while (indexOf >= 0)
                            {
                                names.RemoveAt(indexOf);

                                indexOf = names.IndexOf(tempName);
                            }
                        }
                    }
                }
            }

            if(names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.Write(string.Join(" ", names));
                Console.WriteLine(" are going to the party!");
            }
        }
    }
}
