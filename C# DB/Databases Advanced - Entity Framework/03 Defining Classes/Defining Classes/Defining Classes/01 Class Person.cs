using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            PropertyInfo[] properties = personType.GetProperties
                (BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(properties.Length);
        }
    }
}
