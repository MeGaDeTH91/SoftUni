namespace HTTPServer.Server.Http.Response
{
    using HTTPServer.Server.Enums;
    using System.IO;

    public class FileResponse : HttpResponse
    {
        public FileResponse(string path)
        {
            this.StatusCode = HttpStatusCode.Ok;
            
            using(var streamReader = new StreamReader(@"GameStoreApplication" + path))
            {
                string fileContents = streamReader.ReadToEnd();

                this.Content = fileContents;
            }
        }

        public string Content { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Content}";
        }
    }
}
