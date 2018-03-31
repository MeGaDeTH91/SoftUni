namespace Classes
{
    using Interfaces;

    public class Player : IPlayer
    {
        public int CompareTo(Player other)
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; private set; }

        public int Radius { get; private set; }

        public int Score { get; set; }
    }
}
