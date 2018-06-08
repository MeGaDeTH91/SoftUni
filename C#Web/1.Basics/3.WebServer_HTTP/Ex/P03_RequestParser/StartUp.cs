namespace P03_RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        private const string errorNotFoundCode = "{0} 404 NotFound";
        private const string okCode = "{0} 200 OK";
        private static string httpVersion = string.Empty;

        private const string contentLengthOk = "Content-Length: 2";
        private const string contentLengthNotFound = "Content-Length: 9";

        private const string contentType = "Content-Type: text/plain";

        private const string statusNotFound = "NotFound";
        private const string statusOk = "OK";

        private static Dictionary<string, HashSet<string>> paths = new Dictionary<string, HashSet<string>>();

        public static void Main(string[] args)
        {
            ReadPathsAndMethods();

            bool readValidHttpRequest = ReadHttpRequest();

            StringBuilder sb = new StringBuilder();

            if (readValidHttpRequest)
            {
                sb.AppendLine(string.Format(okCode, httpVersion));
                sb.AppendLine(contentLengthOk);
                sb.AppendLine(contentType);
                sb.AppendLine();
                sb.AppendLine(statusOk);
            }
            else
            {
                sb.AppendLine(string.Format(errorNotFoundCode, httpVersion));
                sb.AppendLine(contentLengthNotFound);
                sb.AppendLine(contentType);
                sb.AppendLine();
                sb.AppendLine(statusNotFound);
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static bool ReadHttpRequest()
        {
            string[] httpRequestTokens = Console.ReadLine().Split(new[] { " /", " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            string requestMethod = httpRequestTokens[0].ToLower();
            string requestPath = httpRequestTokens[1].ToLower();
            httpVersion = httpRequestTokens[2];

            bool requestValidity = CheckIfRequestIsValid(requestMethod, requestPath);
            
            return requestValidity;
        }

        private static bool CheckIfRequestIsValid(string requestMethod, string requestPath)
        {
            bool validMethod = paths.ContainsKey(requestMethod);
            bool validPath = validMethod && paths[requestMethod].Contains(requestPath);

            return validPath;
        }

        private static void ReadPathsAndMethods()
        {
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                string[] lineTokens = line.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string path = lineTokens[0];
                string method = lineTokens[1];

                if (!paths.ContainsKey(method))
                {
                    paths[method] = new HashSet<string>();
                }
                paths[method].Add(path);
            }
        }
    }
}
