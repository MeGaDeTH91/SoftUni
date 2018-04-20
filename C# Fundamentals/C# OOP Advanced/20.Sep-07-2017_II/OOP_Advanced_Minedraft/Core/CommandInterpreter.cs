using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0].Trim();

        Assembly assembly = Assembly.GetCallingAssembly();

        Type commandType = Type.GetType(commandName + Constants.CommandSuffix);

        ConstructorInfo ctor = commandType.GetConstructors().First();

        ParameterInfo[] commandConstructorParametersInfos = ctor.GetParameters();

        object[] constructorParams = new object[commandConstructorParametersInfos.Length];

        for (int i = 0; i < constructorParams.Length; i++)
        {
            Type paramType = commandConstructorParametersInfos[i].ParameterType;

            if(paramType == typeof(IList<string>))
            {
                constructorParams[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(x => x.PropertyType == paramType);

                constructorParams[i] = paramInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, constructorParams);

        string result = command.Execute();

        return result;
    }
}
