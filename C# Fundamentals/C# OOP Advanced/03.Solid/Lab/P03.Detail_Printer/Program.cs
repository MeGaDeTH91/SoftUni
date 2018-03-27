using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> docs = new List<string>() { "Doc1", "Doc2", "Doc3"};
            Manager man1 = new Manager("Johny", docs);
            Manager man2 = new Manager("Batman", docs);
            Employee emp1 = new Employee("Bruce");
            Employee emp2 = new Employee("Wayne");

            List<Employee> emps = new List<Employee>() { man1, man2, emp1, emp2};

            DetailsPrinter dp = new DetailsPrinter(emps);

            dp.PrintDetails();
        }
    }
}
