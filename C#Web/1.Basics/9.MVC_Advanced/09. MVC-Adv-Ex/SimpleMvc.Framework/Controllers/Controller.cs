namespace SimpleMvc.Framework.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using SimpleMvc.Framework.Interfaces;
    using SimpleMvc.Framework.Models;
    using SimpleMvc.Framework.Views;
    using SimpleMvc.Framework.ActionResults;
    using SimpleMvc.Framework.Attributes.Property;
    using System.Reflection;
    using WebServer.Http.Contracts;
    using SimpleMvc.Framework.Security;
    using WebServer.Http;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }

        protected ViewModel Model { get; }

        protected internal IHttpRequest Request { get; internal set; }

        protected internal Authentication User { get; private set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();

            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            IRenderable view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected internal void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if(user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected bool IsValidModel(object bindingModel)
        {
            foreach (var property in bindingModel.GetType().GetProperties())
            {
                IEnumerable<Attribute> attributes =
                    property.GetCustomAttributes()
                    .Where(x => x is PropertyAttribute);

                if (!attributes.Any())
                {
                    continue;
                }

                foreach (PropertyAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(bindingModel)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected void SignIn(string name)
        {
            this.Request.Session.Add(SessionStore.CurrentUserKey, name);
        }

        protected void SignOut()
        {
            this.Request.Session.Clear();
        }

        private void InitializeViewModelData()
        {
            this.Model["displayType"] = this.User.IsAuthenticated ? "block": "none";
        }
    }
}
