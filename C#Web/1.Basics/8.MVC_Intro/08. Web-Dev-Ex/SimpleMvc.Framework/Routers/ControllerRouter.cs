namespace SimpleMvc.Framework.Routers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Exceptions;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParams = new Dictionary<string, string>(request.UrlParameters);
            this.postParams = new Dictionary<string, string>(request.FormData);

            this.requestMethod = request.Method.ToString().ToUpper();

            this.RetrieveControllerAndActionNames(request);

            MethodInfo method = this.GetMethod();
            
            if(method == null)
            {
                return new NotFoundResponse();
            }

            this.PrepareMethodParams(method);

            var actionResult = (IInvocable)method.Invoke(
                this.GetController(),
                this.methodParams);

            var content = actionResult.Invoke();

            return new ContentResponse(HttpStatusCode.Ok, content);
            
        }

        private void RetrieveControllerAndActionNames(IHttpRequest request)
        {
            string[] pathTokens = request.Path
                .Split(new[] { '/', '?'}, StringSplitOptions.RemoveEmptyEntries);

            if(pathTokens.Length < 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var controllerFirstLetter = char.ToUpper(pathTokens[0].First());
            var controllerRestOfName = pathTokens[0].Substring(1);

            this.controllerName = $"{controllerFirstLetter}{controllerRestOfName}{MvcContext.Get.ControllersSuffix}";

            var actionFirstLetter = char.ToUpper(pathTokens[1].First());
            var actionRestOfName = pathTokens[1].Substring(1);

            this.actionName = $"{actionFirstLetter}{actionRestOfName}";
        }

        private void PrepareMethodParams(MethodInfo method)
        {
            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams =
                new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive ||
                    param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];

                    this.methodParams[index] = Convert.ChangeType(
                        value,
                        param.ParameterType);

                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;

                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(
                            bindingModel,
                            Convert.ChangeType(
                                postParams[property.Name],
                                property.PropertyType));
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType);

                    index++;
                }
            }
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetController();

            if(controller == null)
            {
                return new MethodInfo[0];
            }

            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if(type == null)
            {
                return default(Controller);
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}
