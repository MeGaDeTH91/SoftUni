namespace Employees.Client
{
    using AutoMapper;
    using Employees.DtoModels;
    using Employees.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeePersonalDto>();
            CreateMap<Employee, ManagerDto>();
        }
    }
}
