using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Decrypt_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte n = byte.Parse(Console.ReadLine());

            char intMessage = '\0';
            char intLetter = '\0';
            string decrMessage = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                intMessage = (char)(intMessage + (letter + key));
                intLetter = (char)(intLetter + Convert.ToChar(intMessage));
                decrMessage = decrMessage + $"{intLetter}";
                intMessage = '\0';
                intLetter = '\0';
            }
            
            Console.WriteLine(decrMessage);
        }
    }
}
