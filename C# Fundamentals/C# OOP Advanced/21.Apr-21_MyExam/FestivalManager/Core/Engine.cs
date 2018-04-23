namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    using FestivalManager.Constants;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Factories;
    using System.Collections.Generic;
    using FestivalManager.Entities.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    public class Engine : IEngine
	{
        private bool IsEngineRunning;
	    private IReader reader;
        private IWriter writer;

		private IFestivalController festivalController;
        private ISetController setController;
        
        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
            this.IsEngineRunning = true;
        }
        
        // Run Engine
        public void Run()
		{
			while (IsEngineRunning)
			{
				var input = reader.ReadLine();
                
				try
				{
					var result = this.ProcessCommand(input);
                    if (string.IsNullOrWhiteSpace(result))
                    {
                        break;
                    }
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}

                if (input == Constants.TerminateProgramMessage)
                {
                    this.IsEngineRunning = false;
                }
            }

            var reportResults = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(reportResults);

        }

        public string ProcessCommand(string input)
		{
			var commTokens = input.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

			var currentCommand = commTokens[0];

            string result = string.Empty;

            switch (currentCommand)
            {
                case Constants.RegisterSetCommand:
                    result = this.festivalController.RegisterSet(commTokens.Skip(1).ToArray());
                    break;
                case Constants.SignUpPerformerCommand:
                    result = this.festivalController.SignUpPerformer(commTokens.Skip(1).ToArray());
                    break;
                case Constants.RegisterSongCommand:
                    result = this.festivalController.RegisterSong(commTokens.Skip(1).ToArray());
                    break;
                case Constants.AddSongToSetCommand:
                    result = this.festivalController.AddSongToSet(commTokens.Skip(1).ToArray());
                    break;
                case Constants.AddPerformerToSetCommand:
                    result = this.festivalController.AddPerformerToSet(commTokens.Skip(1).ToArray());
                    break;
                case Constants.RepairInstrumentsCommand:
                    result = this.festivalController.RepairInstruments(commTokens.Skip(1).ToArray());
                    break;
                case Constants.LetsRockCommand:
                    result = this.setController.PerformSets().TrimEnd();
                    break;
                default:
                    break;
            }

            return result;
        }
	}
}