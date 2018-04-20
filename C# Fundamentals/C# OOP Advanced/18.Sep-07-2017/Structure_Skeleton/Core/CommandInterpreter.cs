using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string harvestercontroller = "harvesterController";
    private const string providercontroller = "providerController";
    private const string CommandSuffix = "Command";
    
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Type.GetType(commandName + CommandSuffix);

        ConstructorInfo ctor = commandType.GetConstructors().First();

        ParameterInfo[] parametersInfos = ctor.GetParameters();

        object[] ctorParams = new object[parametersInfos.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            Type parameterType = parametersInfos[i].ParameterType;

            if (parameterType == typeof(IList<string>))
            {
                ctorParams[i] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo paramInfo = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == parameterType);

                ctorParams[i] = paramInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorParams);

        string outputResult = command.Execute();

        return outputResult;
    }
}
