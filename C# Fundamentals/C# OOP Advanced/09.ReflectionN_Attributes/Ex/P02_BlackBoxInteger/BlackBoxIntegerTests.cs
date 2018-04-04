namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        private static Type boxType = typeof(BlackBoxInteger);

        public static void Main()
        {
            BlackBoxInteger classInstance = Activator.CreateInstance(boxType, true) as BlackBoxInteger;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commTokens = command.Split(new[] { '_'});

                string currentCommand = commTokens[0];
                int currentNumber = int.Parse(commTokens[1]);

                var currentMethod = boxType.GetMethod(currentCommand, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                currentMethod.Invoke(classInstance, new object[] { currentNumber });

                FieldInfo field = boxType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                string currentValue = field.GetValue(classInstance).ToString();
                Console.WriteLine(currentValue);
            }
        }
    }
}
