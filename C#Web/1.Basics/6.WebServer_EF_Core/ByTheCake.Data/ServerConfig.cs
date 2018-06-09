namespace ByTheCake.Data
{
    using System;

    public class ServerConfig
    {
        internal static string ConnectionString => @"Server = .; Database = ByTheCakeApplication; Integrated Security = true";
    }
}
