namespace Employees.Client
{
    using Employees.Client.Commands;
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;

    internal class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {

            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            var commandType = commandTypes.SingleOrDefault(t => t.Name.ToLower() == $"{commandName.ToLower()}command");

            if(commandType == null)
            {
                throw new InvalidOperationException("Invalid command.");
            }

            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            //За всеки Constructo параметър от Service Provider-а ми намери този Service
            var constructorArgs = constructorParams
                .Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constructor.Invoke(constructorArgs);

            return command;
        }
    }
}
