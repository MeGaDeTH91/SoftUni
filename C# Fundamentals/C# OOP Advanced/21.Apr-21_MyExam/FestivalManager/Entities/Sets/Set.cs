namespace FestivalManager.Entities.Sets
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using FestivalManager.Constants;
	using Contracts;

	public abstract class Set : ISet
	{
		private List<IPerformer> performers;
		private List<ISong> songs;

		protected Set(string name, TimeSpan maxDuration)
		{
			this.Name = name;
			this.MaxDuration = maxDuration;

			this.performers = new List<IPerformer>();
			this.songs = new List<ISong>();
		}

		public string Name { get; }

		public TimeSpan MaxDuration { get; }
        // TODO: Fix if problems
		public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

		public IReadOnlyCollection<IPerformer> Performers
		{
			get { return performers.AsReadOnly(); }
		}

		public IReadOnlyCollection<ISong> Songs
		{
			get { return songs.AsReadOnly(); }
		}

		public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

		public void AddSong(ISong song)
		{
            if (song.Duration + this.ActualDuration > this.MaxDuration)
            {
                throw new InvalidOperationException(string.Format(Constants.SongOverSetLimit));
            }

            this.songs.Add(song);

        }

		public bool CanPerform()
		{
            bool atLeastOnePerformer = this.performers.Count > 0;
            if (!atLeastOnePerformer)
            {
                return false;
            }

            bool atLeastOneSong = this.songs.Count > 0;
            if (!atLeastOneSong)
            {
                return false;
            }

            bool atLeastOneNonBrokenInstrument = true;

            foreach (var performer in this.performers)
            {
                List<IInstrument> performerInstruments = performer.Instruments.Where(x => x.IsBroken == false).ToList();

                if (performerInstruments.Count < 1)
                {
                    atLeastOneNonBrokenInstrument = false;
                }
            }

            if (!atLeastOneNonBrokenInstrument)
            {
                return false;
            }

            return true;
        }

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.AppendLine(string.Join(", ", this.Performers));

			foreach (var song in this.Songs)
			{
				sb.AppendLine($"-- {song}");
			}

			var result = sb.ToString();
			return result;
		}
	}
}
