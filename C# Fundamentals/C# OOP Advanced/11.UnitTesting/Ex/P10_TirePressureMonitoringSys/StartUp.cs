namespace P10_TirePressureMonitoringSys
{
    using System;
    using System.Reflection;

    public class StartUp
    {
        public static void Main()
        {
            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);

            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);
        }
    }
}
