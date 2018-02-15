using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Client.Commands
{
    internal interface ICommand
    {
        string Execute(params string[] args);
    }
}
