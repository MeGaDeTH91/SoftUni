using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);

        MethodInfo[] getters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.Name.StartsWith("get")).ToArray();

        MethodInfo[] setters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.Name.StartsWith("set")).ToArray();

        foreach (var getter in getters)
        {
            sb.AppendLine($"{getter.Name} will return {getter.ReturnType}");
        }

        foreach (var setter in setters)
        {
            sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().FirstOrDefault().ParameterType}");
        }

        return sb.ToString().Trim();
    }
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");

        Type type = Type.GetType(className);

        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        MethodInfo[] fields = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name}");
        }

        return sb.ToString().Trim();
    }
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo getter in classPrivateMethods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        foreach (MethodInfo setter in classPublicMethods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in classFields.Where(f => fieldNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}
