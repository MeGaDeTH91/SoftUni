using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PrintReceipt();
        }
        static void PrintReceptHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
                               
        }
        static void PrintReceiptBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void PrintReceiptFooter()
        {
            
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
        static void PrintReceipt()
        {
            PrintReceptHeader();
            PrintReceiptBody();
            PrintReceiptFooter();
        }
        
    }
}
