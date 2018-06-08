namespace WebServer.Server.Routing
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Enums;
    using Server.Handlers;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ServerRouteConfig : IServerRouteConfig
    {
        private Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> routes;

        public Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes => this.routes;

        public ServerRouteConfig(IAppRouteConfig appRouteConfig)
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>>();

            foreach (HttpRequestMethod request in Enum.GetValues(typeof(HttpRequestMethod)))
            {
                this.routes[request] = new Dictionary<string, IRoutingContext>();
            }

            this.InitializeServerConfig(appRouteConfig);
        }

        private void InitializeServerConfig(IAppRouteConfig appRouteConfig)
        {
            foreach (KeyValuePair<HttpRequestMethod, Dictionary<string, RequestHandler>> kvp in appRouteConfig.Routes)
            {
                foreach (KeyValuePair<string, RequestHandler> requestHandler in kvp.Value)
                {
                    List<string> args = new List<string>();

                    string parsedRegex = this.ParseRoute(requestHandler.Key, args);

                    IRoutingContext routingContext = new RoutingContext(args, requestHandler.Value);

                    this.routes[kvp.Key].Add(parsedRegex, routingContext);
                }
            }
        }

        private string ParseRoute(string requestHandlerKey, List<string> args)
        {
            StringBuilder parsedRegex = new StringBuilder();

            parsedRegex.Append("^");

            if(requestHandlerKey == "/")
            {
                parsedRegex.Append("/$");
                return parsedRegex.ToString();
            }

            string[] tokens = requestHandlerKey.Split(new[] { '/' },StringSplitOptions.None);

            this.ParseTokens(args, tokens, parsedRegex);

            return parsedRegex.ToString();
        }

        private void ParseTokens(List<string> args, string[] tokens, StringBuilder parsedRegex)
        {
            for (int idx = 0; idx < tokens.Length; idx++)
            {
                string end = idx == tokens.Length - 1 ? "$" : "/";

                if (!tokens[idx].StartsWith("{") && !tokens[idx].EndsWith("}"))
                {
                    parsedRegex.Append($"{tokens[idx]}{end}");
                    continue;
                }

                string pattern = "<\\w+>";
                Regex regex = new Regex(pattern);

                Match match = regex.Match(tokens[idx]);

                if (!match.Success)
                {
                    continue;
                }

                string paramName = match.Groups[0].ToString().Substring(1, match.Groups[0].Length - 2);

                args.Add(paramName);

                parsedRegex.Append($"{tokens[idx].ToString().Substring(1, tokens[idx].Length - 2)}{end}");
            }
        }
    }
}
