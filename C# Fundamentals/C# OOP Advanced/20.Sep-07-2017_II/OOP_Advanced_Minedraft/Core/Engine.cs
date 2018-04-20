using System.Linq;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;
    private bool IsEngineRunning;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
        this.IsEngineRunning = true;
    }

    public void Run()
    {
        while (IsEngineRunning)
        {
            var input = reader.ReadLine();
            var data = input.Split().ToList();
            var commandName = data[0];

            string result = this.commandInterpreter.ProcessCommand(data);

            writer.WriteLine(result);

            if(commandName == "Shutdown")
            {
                this.IsEngineRunning = false;
            }
        }
    }
}
