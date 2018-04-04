namespace _03BarracksFactory.Core.Commands
{
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Attributes;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            this.repository.RemoveUnit(unitType);
            string output = unitType + " retired!";
            return output;
        }
    }
}
