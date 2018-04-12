using System;

public class CombatLogger : Logger
{

    public override void Handle(LogType logType, string message)
    {
        switch (logType)
        {
            case LogType.ATTACK:
                PrintOnConsole(logType, message);
                break;
            case LogType.MAGIC:
                PrintOnConsole(logType, message);
                break;
            default:
                break;
        }

        this.PassToSuccessor(logType, message);
    }

    private static void PrintOnConsole(LogType logType, string message)
    {
        Console.WriteLine(logType.ToString() + ": " + message);
    }
}
