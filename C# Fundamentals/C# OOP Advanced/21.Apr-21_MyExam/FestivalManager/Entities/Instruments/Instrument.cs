﻿namespace FestivalManager.Entities.Instruments
{
    using System;
    using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
        private const int MinWear = 0;
        private const int MaxWear = 100;

		protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, MinWear), MaxWear);
			}
		}

		protected abstract int RepairAmount { get; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= MinWear;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
