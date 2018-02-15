using System;
using System.Text.RegularExpressions;

namespace P03_Anonymous_Vox
{
    class P03_AnonymousVox
    {
        static void Main(string[] args)
        {
            Regex myRegex = new Regex(@"(?<start>{[^{}]+})(?<placeholder>{[^{}]+})(?<end>{[^{}]+})");


        }
    }
}
