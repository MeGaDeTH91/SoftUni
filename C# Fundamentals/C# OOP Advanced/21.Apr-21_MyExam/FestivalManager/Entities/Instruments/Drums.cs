namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
		private const int DrumRepairAmount = 20;

        public Drums()
        {
        }

        protected override int RepairAmount => DrumRepairAmount;
    }
}
