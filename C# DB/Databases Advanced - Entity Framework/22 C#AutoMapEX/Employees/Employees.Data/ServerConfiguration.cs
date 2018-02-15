using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data
{
    public class ServerConfiguration
    {
        public static string ConnectionString => @"Server = DESKTOP-76VJURB\SQLEXPRESS; Database = EmployeesDb; Integrated Security = true";
    }
}
