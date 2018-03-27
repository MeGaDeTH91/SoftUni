using System;
using System.Collections.Generic;
using System.Text;

public interface IStreamProgressInfo
{
    int Length { get; }

    int BytesSent { get; }
}
