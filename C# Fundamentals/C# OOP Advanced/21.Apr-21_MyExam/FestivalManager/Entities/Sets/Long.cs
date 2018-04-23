namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Set
    {
        private const int hours = 1;
        private const int minutes = 0;
        private const int seconds = 0;

        public Long(string name) : base(name, new TimeSpan(hours, minutes, seconds))
        {

        }
    }
}
