using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MyFirstException : Exception
    {
        public MyFirstException()
        {
            Console.WriteLine("My first exception is awesome!!!");
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < 100; i++)
            {

                if (input >= 0)
                {
                    Console.WriteLine(input);

                }
                else
                {
                    MyFirstException exc = new MyFirstException();
                    return;
                }


                input = int.Parse(Console.ReadLine());
            }
        }
    }
}