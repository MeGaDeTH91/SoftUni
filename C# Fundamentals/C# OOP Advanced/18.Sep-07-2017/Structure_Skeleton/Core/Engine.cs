using System.Linq;

public class Engine : IEngine
{
    private bool IsEngineRunning;
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

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
            var input = this.reader.ReadLine();
            var data = input.Split().ToList();
            string command = data[0];

            if (command.Equals("Shutdown"))
            {
                this.IsEngineRunning = false;
            }

            string currentCommand = this.commandInterpreter.ProcessCommand(data);

            writer.WriteLine(currentCommand);
        }
    }
}
