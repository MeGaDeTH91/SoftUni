namespace Employees.Services
{
    using Employees.Data;
    using Employees.DtoModels;
    using AutoMapper;
    using Employees.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService
    {
        private readonly EmployeesContext context;

        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public EmployeeDto ById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeDto>(employee);
            
            return employeeDto;
        }
        public void AddEmployee(EmployeeDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            context.Employees.Add(employee);

            context.SaveChanges();
        }
        public string SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            employee.BirthDay = date;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public string SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            employee.Address = address;
            context.SaveChanges();

            return $"{employee.FirstName} {employee.LastName}";
        }

        public EmployeePersonalDto PersonalById(int employeeId)
        {
            var employee = context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeeDto;
        }

        public EmployeePersonalDto SetManager(int employeeId, int managerId)
        {
            var employee = context.Employees
                .Find(employeeId);

            var manager = context.Employees
                .Find(managerId);

            employee.Manager = manager;

            context.SaveChanges();

            var employeePersonalDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeePersonalDto;
        }
        public ManagerDto GetManager(int managerId)
        {
            var employee = context.Employees
                .Include(m => m.ManagedEmployees)
                .SingleOrDefault(m => m.ManagerId == managerId);

            var managerDto = Mapper.Map<ManagerDto>(employee);

            return managerDto;
        }

        public List<EmployeeManagerDto> OlderThan(int age)
        {
            var employees = context.Employees
                .Where(e => e.BirthDay != null && Math.Floor((DateTime.Now - e.BirthDay.Value).TotalDays / 365) > age)
                .Include(e => e.Manager)
                .ProjectTo<EmployeeManagerDto>()
                .ToList();

            return employees;
        }
    }
}
