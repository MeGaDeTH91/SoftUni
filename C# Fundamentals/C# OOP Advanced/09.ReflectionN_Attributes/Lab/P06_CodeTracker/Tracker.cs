﻿using P06_CodeTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            if(method.CustomAttributes.Any(x => x.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute att in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {att.Name}");
                }
            }

        }
    }
}
