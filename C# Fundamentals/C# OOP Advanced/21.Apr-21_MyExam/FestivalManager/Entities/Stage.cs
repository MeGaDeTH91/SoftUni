namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;

    public class Stage : IStage
	{
		private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(x => x.Name == name);

            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(x => x.Name == name);

            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(x => x.Name == name);

            return song;
        }

        public bool HasPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(x => x.Name == name);

            if(performer == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(x => x.Name == name);

            if(set == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(x => x.Name == name);

            if (song == null)
            {
                return false;
            }

            return true;
        }
    }
}
