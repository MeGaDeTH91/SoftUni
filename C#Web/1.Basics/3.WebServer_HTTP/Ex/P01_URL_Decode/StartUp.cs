namespace P01_URL_Decode
{
    using System;
    using System.Net;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string encodedUrl = Console.ReadLine();

            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            Console.WriteLine(decodedUrl);
        }
    }
}
