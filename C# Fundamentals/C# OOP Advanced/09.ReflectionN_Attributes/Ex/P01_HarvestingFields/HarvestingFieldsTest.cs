 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        private static Type harvestType = typeof(HarvestingFields);

        public static void Main()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                fields.AddRange(FieldFactory(harvestType, command));
            }
            foreach (var field in fields)
            {
                string accessModifier = field.IsPrivate ? "private" : field.IsPublic ? "public" : "protected";
                Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }
        }

        private static List<FieldInfo> FieldFactory(Type harvestType, string fieldType)
        {

            switch (fieldType)
            {
                case "private":
                    return harvestType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).Where(x => x.IsPrivate).ToList();
                case "protected":
                    return harvestType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).Where(x => x.IsFamily).ToList();
                case "public":
                    return harvestType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).ToList();
                case "all":
                    return harvestType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).ToList();
                default:
                    return new List<FieldInfo>();
            }
        }
    }
}
