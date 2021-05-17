namespace ConsoleApp
{
    using System;
    using CTF.Framework.TestRunner;

    public class Program
    {
        public static void Main(string[] args)
        {
            string assemblyPath = @"D:\SoftUni\OpenCourses\C#Masterclass\01.ExamPrep\01. CTF_Skeleton\01.CTF.Framework\Calculator.Tests\bin\Debug\netcoreapp3.0\Calculator.Tests.dll";
            Runner runner = new Runner();
            string result = runner.Run(assemblyPath);
            Console.WriteLine(result);
        }
    }
}
