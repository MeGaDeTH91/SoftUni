namespace HTTPServer.GameStoreApplication.Data
{
    using GameStore.Models;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class GameData
    {
        private const string DatabaseFile = @"GameStoreApplication\Data\database.csv";

        public void Add(string name, string price)
        {
            var streamReader = new StreamReader(DatabaseFile);
            var id = streamReader.ReadToEnd().Split(Environment.NewLine).Length;
            streamReader.Dispose();

            using (var streamWriter = new StreamWriter(DatabaseFile, true))
            {
                streamWriter.WriteLine($"{id},{name},{price}");
            }
        }

        public IEnumerable<Game> All()
            => File
                .ReadAllLines(DatabaseFile)
                .Where(l => l.Contains(','))
                .Select(l => l.Split(','))
                .Select(l => new Game
                {
                    Id = int.Parse(l[0]),
                    Title = l[1],
                    Price = decimal.Parse(l[2])
                });

        public Game Find(int id)
            => this.All().FirstOrDefault(c => c.Id == id);
    }
}
