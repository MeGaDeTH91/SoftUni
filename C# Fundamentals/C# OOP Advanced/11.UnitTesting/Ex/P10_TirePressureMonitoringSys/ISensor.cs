using System;
using System.Collections.Generic;
using System.Text;

namespace P10_TirePressureMonitoringSys
{
    public interface ISensor
    {
        double PopNextPressurePsiValue();
    }
}
