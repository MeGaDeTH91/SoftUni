using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            Employee currEmp = new Employee(name, salary, position, department);

            if (input.Length == 4)
            {
                if(!employees.ContainsKey(department))
                {
                    employees[department] = new List<Employee>();
                }
                employees[department].Add(currEmp);
            }
            else if (input.Length == 5)
            {
                int age;
                bool isAge = int.TryParse(input[4], out age);

                if(isAge)
                {
                    currEmp.Age = age;
                }
                else
                {
                    string email = input[4];
                    currEmp.Email = email;
                }

                if (!employees.ContainsKey(department))
                {
                    employees[department] = new List<Employee>();
                }
                employees[department].Add(currEmp);
            }
            else
            {
                string mail = input[4];
                int age = int.Parse(input[5]);
                currEmp.Email = mail;
                currEmp.Age = age;
                if (!employees.ContainsKey(department))
                {
                    employees[department] = new List<Employee>();
                }
                employees[department].Add(currEmp);
            }
        }

        string highDep = string.Empty;
        decimal highestSalary = 0.0m;

        foreach (var emp in employees)
        {
            if(emp.Value.Average(x => x.Salary) > highestSalary)
            {
                highDep = emp.Key;
                highestSalary = emp.Value.Average(x => x.Salary);
            }
        }


        Console.WriteLine($"Highest Average Salary: {highDep}");
        foreach (var emp in employees[highDep].OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:F2} {emp.Email} {emp.Age}");
        }
    }
}
