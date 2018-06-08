namespace P02_ValidateURL
{
    using System;
    using System.Net;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private const string defaultHttpPort = "80";
        private const string defaultHttpsPort = "443";
        private const string defaultPath = "/";

        public static void Main(string[] args)
        {
            string regexPattern = @"(?<protocol>http|https)(:\/\/)(?<host>[a-zA-Z0-9\.\-]+\.[a-zA-Z]+)(\:)*(?<port>[0-9]+)*(?<path>[a-zA-Z_\-\\\/\.]+)*(\?)*(?<query>[a-zA-Z0-9\=\ _\-\.\&]+)*(\#)*(?<fragment>[0-9a-zA-Z\/\\\.\&\-_\+]+)*";

            Regex regex = new Regex(regexPattern);

            string encodedUrl = Console.ReadLine();

            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            Match match = regex.Match(decodedUrl);

            string protocol = match.Groups["protocol"].Value;
            string host = match.Groups["host"].Value;
            string port = !string.IsNullOrWhiteSpace(match.Groups["port"].Value) ? match.Groups["port"].Value : protocol == "http" ? defaultHttpPort : defaultHttpsPort;

            bool portIsValid = protocol == "http" && port == "80" || protocol == "https" && port == "443";

            if (!match.Success || !portIsValid)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string path =  !string.IsNullOrWhiteSpace(match.Groups["path"].Value) ? match.Groups["path"].Value : defaultPath;
                string query = match.Groups["query"].Value;
                string fragment = match.Groups["fragment"].Value;

                Console.WriteLine($"Protocol: {protocol}");
                Console.WriteLine($"Host: {host}");
                Console.WriteLine($"Port: {port}");
                Console.WriteLine($"Path: {path}");

                if (!string.IsNullOrWhiteSpace(query))
                {
                    Console.WriteLine($"Query: {query}");
                }
                if (!string.IsNullOrWhiteSpace(fragment))
                {
                    Console.WriteLine($"Fragment: {fragment}");
                }
            }
        }
    }
}
