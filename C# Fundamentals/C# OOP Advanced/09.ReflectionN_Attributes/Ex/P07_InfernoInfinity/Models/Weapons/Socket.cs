namespace P07_InfernoInfinity.Models.Weapons
{
    using P07_InfernoInfinity.Models.Gems;

    public class Socket
    {
        public Gem Gem { get; private set; }

        public Socket(Gem gem)
        {
            this.Gem = gem;
        }

        public Socket()
        {

        }

        public void ChangeGem(Gem newGem)
        {
            this.Gem = newGem;
        }
    }
}
