namespace P02_Command
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            Warrior warrior = new Warrior("Mountain", 10, combatLog);
            Dragon dragon = new Dragon("Dracarys", 100, 25, combatLog);

            IExecutor executor = new CommandExecutor();

            ICommand targetCommand = new TargetCommand(warrior, dragon);

            targetCommand.Execute();
        }
    }
}
