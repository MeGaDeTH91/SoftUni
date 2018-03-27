using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Interfaces
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}
