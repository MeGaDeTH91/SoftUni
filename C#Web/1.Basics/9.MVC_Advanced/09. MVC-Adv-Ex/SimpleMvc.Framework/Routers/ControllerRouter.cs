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
        public IHttpResponse Handle(IHttpRequest request)
        {
            IDictionary<string, string> getParams = new Dictionary<string, string>(request.UrlParameters);
            IDictionary<string, string> postParams = new Dictionary<string, string>(request.FormData);

            string controllerName = RetrieveController(request);

            Controller controller = this.GetController(controllerName);

            if(controller != null)
            {
                controller.Request = request;

                controller.InitializeController();
            }

            string actionName = RetrieveActionName(request);

            string requestMethod = request.Method.ToString().ToUpper();
            
            MethodInfo method = this.GetMethod(controller, requestMethod, actionName);

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            object[] methodParams = this.PrepareMethodParams(parameters, getParams, postParams);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParams);

                return response;
            }
            catch (Exception e)
            {
                return new InternalServerErrorResponse(e);
            }
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParams)
        {
            object actionResult = method
                .Invoke(controller, methodParams);

            IHttpResponse response = null;

            if(actionResult is IViewable)
            {
                string content = ((IViewable)actionResult).Invoke();

                response = new ContentResponse(HttpStatusCode.Ok, content);
            }
            else if (actionResult is IRedirectable)
            {
                string redirectUrl = ((IRedirectable)actionResult).Invoke();

                response = new RedirectResponse(redirectUrl);
            }

            return response;
        }

        private object[] PrepareMethodParams(IEnumerable<ParameterInfo> parameters, IDictionary<string, string> getParams, IDictionary<string, string> postParams)
        {
            var methodParams =
                new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive ||
                    param.ParameterType == typeof(string))
                {
                    methodParams[index] = ProcessPrimitiveParameter(param, getParams);

                    index++;
                }
                else
                {
                    methodParams[index] = ProcessComplexParameter(param, postParams);
                    
                    index++;
                }
            }

            return methodParams;
        }

        private object ProcessComplexParameter(ParameterInfo param, IDictionary<string, string> postParams)
        {
            Type bindingModelType = param.ParameterType;

            object bindingModel = Activator.CreateInstance(bindingModelType);

            IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));
            }

           return Convert.ChangeType(
                bindingModel,
                bindingModelType);
        }

        private static object ProcessPrimitiveParameter(ParameterInfo param, IDictionary<string, string> getParams)
        {
            object value = getParams[param.Name];

            return Convert.ChangeType(
                                    value,
                                    param.ParameterType);
        }

        private Controller GetController(string controllerName)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return default(Controller);
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);
        }

        private MethodInfo GetMethod(Controller controller, string requestMethod, string actionName)
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods(controller, actionName))
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }
        
        private string RetrieveController(IHttpRequest request)
        {
            string[] pathTokens = request.Path
                .Split(new[] { '/', '?'}, StringSplitOptions.RemoveEmptyEntries);

            if(pathTokens.Length < 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var controllerFirstLetter = char.ToUpper(pathTokens[0].First());
            var controllerRestOfName = pathTokens[0].Substring(1);

            string controllerName = $"{controllerFirstLetter}{controllerRestOfName}{MvcContext.Get.ControllersSuffix}";

            return controllerName;
        }

        private string RetrieveActionName(IHttpRequest request)
        {
            string[] pathTokens = request.Path
                .Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

            if (pathTokens.Length < 2)
            {
                BadRequestException.ThrowFromInvalidRequest();
            }

            var actionFirstLetter = char.ToUpper(pathTokens[1].First());
            var actionRestOfName = pathTokens[1].Substring(1);

            string actionName = $"{actionFirstLetter}{actionRestOfName}";

            return actionName;
        }
    }
}
