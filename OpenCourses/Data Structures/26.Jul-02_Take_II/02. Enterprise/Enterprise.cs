using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Enterprise : IEnterprise
{
    Dictionary<Guid, Employee> employees;
    Dictionary<Position, HashSet<Employee>> empsByPosition;
    

    public Enterprise()
    {
        this.employees = new Dictionary<Guid, Employee>();
        this.empsByPosition = new Dictionary<Position, HashSet<Employee>>();
        this.empsByPosition[Position.Developer] = new HashSet<Employee>();
        this.empsByPosition[Position.Hr] = new HashSet<Employee>();
        this.empsByPosition[Position.Manager] = new HashSet<Employee>();
        this.empsByPosition[Position.Owner] = new HashSet<Employee>();
        this.empsByPosition[Position.TeamLead] = new HashSet<Employee>();
    }

    public int Count => this.employees.Count;

    public void Add(Employee employee)
    {
        if (!this.employees.ContainsKey(employee.Id))
        {
            this.employees.Add(employee.Id, employee);
        }
        this.empsByPosition[employee.Position].Add(employee);
    }

    public IEnumerable<Employee> AllWithPositionAndMinSalary(Position position, double minSalary)
    {
        List<Employee> temp = new List<Employee>();
        if (this.empsByPosition.ContainsKey(position))
        {
            temp = this.empsByPosition[position].Where(x => x.Salary >= minSalary).ToList();
        }
        return temp;
    }

    public bool Change(Guid guid, Employee employee)
    {
        if (this.employees.ContainsKey(guid))
        {
            var emp = this.employees[guid];

            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Position = employee.Position;
            emp.Salary = employee.Salary;
            emp.HireDate = employee.HireDate;
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
            var emp = this.employees[guid];
            this.empsByPosition[emp.Position].Remove(emp);
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
        if (!this.empsByPosition.ContainsKey(position))
        {
            throw new ArgumentException();
        }
        return this.empsByPosition[position];
    }

    public IEnumerable<Employee> GetBySalary(double minSalary)
    {
        var temp = this.employees.Where(x => x.Value.Salary >= minSalary).Select(x => x.Value).ToList();
        if (temp.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return temp;

    }

    public IEnumerable<Employee> GetBySalaryAndPosition(double salary, Position position)
    {
        List<Employee> emps = this.employees.Where(x => x.Value.Salary == salary && x.Value.Position == position).Select(x => x.Value).ToList();

        if(emps.Count < 1)
        {
            throw new InvalidOperationException();
        }
        return emps;
    }

    public Position PositionByGuid(Guid guid)
    {
        if (!employees.ContainsKey(guid))
        {
            throw new InvalidOperationException();
        }

        var emp = this.employees[guid];

        return emp.Position;
    }

    public bool RaiseSalary(int months, int percent)
    {
        List<Employee> emps = this.employees.Where(x => x.Value.HireDate.AddMonths(months) <= DateTime.Now).Select(x => x.Value).ToList();

        foreach (var emp in emps)
        {
            double increase = (percent / 100.0d) + 1;
            this.employees[emp.Id].Salary *= increase;
        }
        if(emps.Count > 0)
        {
            return true;
        }
        return false;
    }

    public IEnumerable<Employee> SearchByFirstName(string firstName)
    {
        return this.employees.Where(x => x.Value.FirstName == firstName).Select(x => x.Value);
    }

    public IEnumerable<Employee> SearchByNameAndPosition(string firstName, string lastName, Position position)
    {
        List<Employee> temp = this.employees.Where(x => x.Value.FirstName == firstName && x.Value.LastName == lastName && x.Value.Position == position).Select(x => x.Value).ToList();

        return temp;
    }

    public IEnumerable<Employee> SearchByPosition(IEnumerable<Position> positions)
    {
        List<Employee> temp = new List<Employee>();
        foreach (var pos in positions)
        {
            if (this.empsByPosition.ContainsKey(pos))
            {
                var emps = empsByPosition[pos];
                temp.AddRange(emps);
            }
        }
        return temp;
    }

    public IEnumerable<Employee> SearchBySalary(double minSalary, double maxSalary)
    {
        List<Employee> emps = this.employees.Where(x => x.Value.Salary >= minSalary && x.Value.Salary <= maxSalary).Select(x => x.Value).ToList();
        
        return emps;
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

