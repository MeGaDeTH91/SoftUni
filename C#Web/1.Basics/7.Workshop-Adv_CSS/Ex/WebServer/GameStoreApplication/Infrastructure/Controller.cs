namespace HTTPServer.GameStoreApplication.Infrastructure
{
    using Server.Enums;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Views.Home;

    public abstract class Controller 
    {
        public const string DefaultPath = @"GameStoreApplication\Resources\{0}.html";
        public const string ContentPlaceholder = "{{{content}}}";
        protected const string HomePath = "/";

        protected Controller()
        {
            this.ViewData = new Dictionary<string, string>
            {
                ["authDisplay"] = "block"
            };

            this.ViewDataErrors = new Dictionary<string, string>();
        }

        protected abstract string ApplicationDirectory { get; }

        protected IDictionary<string, string> ViewData { get; private set; }

        protected IDictionary<string, string> ViewDataErrors { get; private set; }

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            if (this.ViewDataErrors.Any())
            {
                foreach (var value in this.ViewDataErrors)
                {
                    result = result.Replace($"{{{{{{{value.Key}Display}}}}}}", "flex");
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            result = Regex.Replace(result, "{{{\\w+ErrorDisplay}}}", "none");

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        protected IHttpResponse RedirectResponse(string route)
        {
            return new RedirectResponse(route);
        }

        protected void AddError(string errorMessage)
        {
            this.ViewData["showError"] = "block";
            this.ViewData["error"] = errorMessage;
        }

        protected bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, context, results, true) == false)
            {
                foreach (var result in results)
                {
                    if (result != ValidationResult.Success)
                    {
                        this.AddError(result.ErrorMessage);

                        return false;
                    }
                }
            }

            return true;
        }

        private string ProcessFileHtml(string fileName)
        {
            var layoutHtml = File.ReadAllText(string.Format(DefaultPath, "layout"));

            var fileHtml = File
                .ReadAllText(string.Format(DefaultPath, fileName));

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }
    }
}
