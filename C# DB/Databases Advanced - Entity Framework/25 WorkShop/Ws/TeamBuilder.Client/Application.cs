using System;
using TeamBuilder.Data;

namespace TeamBuilder.Client
{
    public class Application
    {
        public static void Main(string[] args)
        {
            //ResetDatabase();

            Engine engine = new Engine(new CommandDispatcher());

            engine.Run();
        }

        private static void ResetDatabase()
        {
            using (var db = new TeamBuilderContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Console.WriteLine("Success!");
            }
        }
    }
}
