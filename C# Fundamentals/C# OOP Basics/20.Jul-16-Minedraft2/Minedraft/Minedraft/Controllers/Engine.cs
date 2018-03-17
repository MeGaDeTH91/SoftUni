using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string[] commTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string commType = commTokens[0];

                switch (commType)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(this.draftManager.RegisterHarvester(commTokens.Skip(1).ToList()));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(this.draftManager.RegisterProvider(commTokens.Skip(1).ToList()));
                        break;
                    case "Day":
                        Console.WriteLine(this.draftManager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(this.draftManager.Mode(commTokens.Skip(1).ToList()));
                        break;
                    case "Check":
                        Console.WriteLine(this.draftManager.Check(commTokens.Skip(1).ToList()));
                        break;
                    case "Shutdown":
                        Console.WriteLine(this.draftManager.ShutDown());
                        return;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
