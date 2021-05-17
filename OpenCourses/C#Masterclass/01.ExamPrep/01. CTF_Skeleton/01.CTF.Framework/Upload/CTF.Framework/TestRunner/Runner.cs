namespace CTF.Framework.TestRunner
{
    using CTF.Framework.Attributes;
    using CTF.Framework.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Runner
    {
        private readonly StringBuilder stringBuilder;

        public Runner()
        {
            this.stringBuilder = new StringBuilder();
        }

        public string Run(string assemblyPath)
        {
            var assembly = Assembly.LoadFrom(assemblyPath);
            var classes = assembly
                .GetTypes()
                .Where(x => x.GetCustomAttributes(typeof(CTFTestClassAttribute)).Any());

            foreach (var clazz in classes)
            {
                var methods = clazz.GetMethods()
                    .Where(x => x.GetCustomAttributes(typeof(CTFTestMethodAttribute)).Any());

                var instance = Activator.CreateInstance(clazz);

                foreach (var method in methods)
                {
                    try
                    {
                        var methodParams = method.GetParameters();

                        var paramsForInvocation = new List<object>();

                        foreach (var methodParam in methodParams)
                        {
                            paramsForInvocation.Add(methodParam);
                        }

                        try
                        {
                            try
                            {
                                method.Invoke(instance, paramsForInvocation.ToArray());
                                stringBuilder.AppendLine($"Class: {clazz.Name} Method: {method.Name} - passed!");
                            }
                            catch (Exception e)
                            {
                                throw e.InnerException;
                            }
                        }
                        catch (TestException)
                        {
                            stringBuilder.AppendLine($"Class: {clazz.Name} Method: {method.Name} - failed!");
                        }
                    }
                    catch (Exception)
                    {
                        stringBuilder.AppendLine($"Unexpected error occurred in {method.Name}!");
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
