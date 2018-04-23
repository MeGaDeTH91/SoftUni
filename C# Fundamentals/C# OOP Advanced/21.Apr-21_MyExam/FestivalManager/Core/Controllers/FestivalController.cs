namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Constants;
    using System.Collections.Generic;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";
        private ISongFactory songFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

        private IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.songFactory = new SongFactory();
            this.performerFactory = new PerformerFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
        }

        public string AddPerformerToSet(string[] args)
        {
            return this.PerformerRegistrationCheck(args);
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(Constants.AddSongToSetInvalidSetMessage);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(Constants.AddSongToSetInvalidSongMessage);
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return string.Format(Constants.AddSongToSetSuccessMessage, song.ToString(), set.Name);
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            int totalMinutes = (int)totalFestivalLength.TotalMinutes;
            int totalSeconds = (int)totalFestivalLength.Seconds;

            result += (string.Format(Constants.ProduceReportFirstLineFestivalLenght, totalMinutes, totalSeconds)) + Environment.NewLine;

            foreach (var set in this.stage.Sets)
            {
                int setTotalMinutes = (int)set.ActualDuration.TotalMinutes;
                int setTotalSeconds = (int)set.ActualDuration.Seconds;

                result += (string.Format(Constants.ProduceReportSetDetails, set.Name, setTotalMinutes, setTotalSeconds)) + Environment.NewLine;

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            string setName = args[0];
            string setType = args[1];

            ISet set =  this.setFactory.CreateSet(setName, setType);

            this.stage.AddSet(set);

            string result = string.Format(Constants.RegisterSetSuccessMessage, setType);
            return result;
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];

            string[] timeSplit = args[1].Split(':').ToArray();

            int hours = 0;
            int minutes = int.Parse(timeSplit[0]);
            int seconds = int.Parse(timeSplit[1]);

            TimeSpan songDuration = new TimeSpan(hours, minutes, seconds);

            ISong song = this.songFactory.CreateSong(songName, songDuration);

            this.stage.AddSong(song);

            return string.Format(Constants.RegisterSongSuccessMessage, song.ToString());
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return string.Format(Constants.RepairedInstrumentsCount, instrumentsToRepair.Length);
        }

        public string SignUpPerformer(string[] args)
        {
            string performerName = args[0];
            int performerAge = int.Parse(args[1]);

            List<string> stringInstruments = args.Skip(2).ToList();

            List<IInstrument> performerInstrumentsToAdd = new List<IInstrument>();

            foreach (var instrument in stringInstruments)
            {
                IInstrument currentInstrumentToAdd = this.instrumentFactory.CreateInstrument(instrument);

                performerInstrumentsToAdd.Add(currentInstrumentToAdd);
            }

            IPerformer performer = this.performerFactory.CreatePerformer(performerName, performerAge);

            foreach (var addInstrument in performerInstrumentsToAdd)
            {
                performer.AddInstrument(addInstrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(Constants.SignUpPerformerSuccessMessage, performerName);
        }

        private string PerformerRegistrationCheck(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            
            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            
            return string.Format(Constants.AddPerformerToSetSuccessMessage, performer.Name, set.Name);
        }
    }
}