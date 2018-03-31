using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enterprise : IEnterprise
{
    public Dictionary<Guid, Employee> employees;

    public Enterprise()
    {
        this.employees = new Dictionary<Guid, Employee>();
    }

    public int Count => this.employees.Count;

    public void Add(Employee employee)
    {
        if (!this.employees.ContainsKey(employee.Id))
        {
            this.employees.Add(employee.Id, employee);
        }
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        return this.employees.Values.Where(x => x.Position == position && x.Salary >= minSalary).ToList();
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (this.employees.ContainsKey(guid))
        {
            this.employees[guid].FirstName = employee.FirstName;
            this.employees[guid].LastName = employee.LastName;
            this.employees[guid].Salary = employee.Salary;
            this.employees[guid].Position = employee.Position;
            this.employees[guid].HireDate = employee.HireDate;
            return true;
        }
        return false;
    }

    public bool Contains(Guid guid)
    {
        return this.employees.ContainsKey(guid);
    }

    public bool Contains(Employee employee)
    {
        return this.employees.ContainsKey(employee.Id);
    }

    public bool Fire(Guid guid)
    {
        if (this.employees.ContainsKey(guid))
        {
            this.employees.Remove(guid);
            return true;
        }
        return false;
    }

    public Employee GetByGuid(Guid guid)
    {
        if (!this.employees.ContainsKey(guid))
        {
            throw new ArgumentException();
        }
        return this.employees[guid];
    }

    public IEnumerable<Employee> GetByPosition(Position position)
    {
        var temp = this.employees.Values.Where(x => x.Position.Equals(position));
        if(!temp.Any())
        {
            throw new ArgumentException();
        }
        return temp;
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var temp = this.employees.Values.Where(x => x.Salary >= minSalary).ToList();
        if(temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;
    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        var temp = this.employees.Values.Where(x => x.Salary == salary && x.Position == position).ToList();
        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;
    }
    
    public Position PositionByGuid(Guid guid)
    {
        if (!this.employees.ContainsKey(guid))
        {
            throw new InvalidOperationException();
        }
        return this.employees[guid].Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        bool result = false;

        foreach (var emp in this.employees.Values)
        {
            if(emp.HireDate.AddMonths(months) <= DateTime.Now)
            {
                double perc = (percent / 100.0d) + 1;
                emp.Salary *= perc;
                result = true;
            }
        }
        return result;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return this.employees.Values.Where(x => x.FirstName == firstName);
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        return this.employees.Values.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Position == position);
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        List<Employee> temp = new List<Employee>();
        foreach (var pos in positions)
        {
            temp.AddRange(this.employees.Values.Where(x => x.Position == pos).ToList());
        }
        return temp;
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        return this.employees.Values.Where(x => x.Salary >= minSalary && x.Salary <= maxSalary).ToList();
    }
    
    public IEnumerator<Employee> GetEnumerator()
    {
        foreach (var emp in this.employees)
        {
            yield return emp.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

