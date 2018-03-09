namespace Classes
{
    using Interfaces;

    public class Minion : IMinion
    {
        public int CompareTo(Minion other)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; private set; }

        public int XCoordinate { get; private set; }

        public int Health { get; set; }
    }
}
