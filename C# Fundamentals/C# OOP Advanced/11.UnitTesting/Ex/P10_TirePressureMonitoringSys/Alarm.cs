namespace P10_TirePressureMonitoringSys
{
    using System;

    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        readonly ISensor _sensor = new Sensor();

        bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if(psiPressureValue < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty , "Pressure cannot be negative!");
            }

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
