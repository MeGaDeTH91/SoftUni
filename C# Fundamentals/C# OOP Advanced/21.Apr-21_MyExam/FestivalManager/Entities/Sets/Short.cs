namespace FestivalManager.Entities.Sets
{
	using System;

    public class Short : Set
    {
        private const int hours = 0;
        private const int minutes = 15;
        private const int seconds = 0;

        public Short(string name) : base(name, new TimeSpan(hours, minutes, seconds))
        {

        }
    }
}