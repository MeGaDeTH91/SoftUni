namespace _03._Crypto_Blockchain
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"((?<rect>\[)|\{)[^0-9\[\]\{\}]*(?<digits>[0-9]{3,})[^0-9\[\]\{\}]*(?(rect)\]|\})";
            Regex rgx = new Regex(pattern);

            StringBuilder sb = new StringBuilder();
            int rowNumber = int.Parse(Console.ReadLine());

            for (int row = 0; row < rowNumber; row++)
            {
                sb.Append(Console.ReadLine());
            }
            string ourInput = sb.ToString();

            MatchCollection matches = rgx.Matches(ourInput);

            StringBuilder result = new StringBuilder();

            foreach (Match m in matches)
            {
                string fullMatch = m.ToString();
                string currDigits = m.Groups["digits"].Value;

                int currCryptoMatch = fullMatch.Length;

                if(currDigits.Length % 3 == 0)
                {
                    for (int index = 0; index < currDigits.Length; index+=3)
                    {
                        string currString = $"{currDigits[index]}{currDigits[index + 1]}{currDigits[index + 2]}";
                        char currAppend = (char)(int.Parse(currString) - currCryptoMatch);
                        result.Append(currAppend);
                    }
                }
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
