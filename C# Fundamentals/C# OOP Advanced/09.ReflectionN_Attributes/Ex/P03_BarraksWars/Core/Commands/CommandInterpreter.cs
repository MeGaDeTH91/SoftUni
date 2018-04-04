namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Attributes;
    using _03BarracksFactory.Contracts;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string StringNamespace = "_03BarracksFactory.Core.Commands";
        private const string CommandSuffix = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string fullCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == fullCommandName);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            

            var command = (IExecutable)Activator.CreateInstance(type, new object[] { data });
            
            this.InjectDependencies(command, type);

            return (command);
        }

        private void InjectDependencies(IExecutable command, Type type)
        {
            Type injectionType = typeof(InjectAttribute);

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.GetCustomAttributes().Any(y => y.GetType() == injectionType)).ToArray();

            FieldInfo[] interpreterFields = this.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToArray();

            foreach (var field in fieldsToInject)
            {//NeedINFOABOUT This neededField
                var neededField = interpreterFields.FirstOrDefault(x => x.Name == field.Name).GetValue(this);

                field.SetValue(command, neededField);
            }
        }
    }
}
