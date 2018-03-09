namespace Classes
{
    using Interfaces;

    public class Mine : IMine
    {
        public int CompareTo(Mine other)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; private set; }

        public int Delay { get; set; }

        public int Damage { get; private set; }

        public int XCoordinate { get; private set; }

        public Player Player { get; private set; }
    }
}
