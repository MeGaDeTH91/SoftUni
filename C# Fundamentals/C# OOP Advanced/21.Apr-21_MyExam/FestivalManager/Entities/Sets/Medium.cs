namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int hours = 0;
        private const int minutes = 40;
        private const int seconds = 0;

        public Medium(string name) : base(name, new TimeSpan(hours, minutes, seconds))
        {

        }
    }
}