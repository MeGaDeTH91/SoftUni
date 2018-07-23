using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Extensions
{
    public static class StringExtensions
    {
        public static string SurroundWithTag(this string input, string search, string tag, object htmlAttributes = null)
        {
            string lowerInput = input.ToLower();
            int indexOfSearch = lowerInput.IndexOf(search.ToLower());

            if (indexOfSearch == -1)
            {
                return input;
            }

            string attributes = string.Empty;
            if (htmlAttributes != null)
            {
                var htmlAttrs = new RouteValueDictionary(htmlAttributes);
                attributes = string.Join(" ", htmlAttrs.Select(GetAttribute));
            }

            string result = string.Format("{0}<{1} {4}>{2}</{1}>{3}",
               input.Substring(0, indexOfSearch),
               tag,
               input.Substring(indexOfSearch, search.Length),
               input.Substring(indexOfSearch + search.Length),
               attributes);

            return result;
        }

        private static string GetAttribute(KeyValuePair<string, object> item)
        {
            return string.Format("{0}=\"{1}\"", item.Key, System.Net.WebUtility.HtmlEncode(item.Value.ToString()));
        }
    }
}
