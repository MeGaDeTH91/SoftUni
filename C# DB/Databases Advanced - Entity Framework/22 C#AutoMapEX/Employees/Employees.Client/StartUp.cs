namespace Employees.Client
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using Employees.Data;
    using Microsoft.EntityFrameworkCore;
    using Employees.Services;
    using AutoMapper;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var engine = new Engine(serviceProvider);

            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesContext>(options => 
            options.UseSqlServer(ServerConfiguration.ConnectionString));

            serviceCollection.AddTransient<EmployeeService>();

            serviceCollection.AddAutoMapper(cfg =>
            cfg.AddProfile<AutoMapperProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
