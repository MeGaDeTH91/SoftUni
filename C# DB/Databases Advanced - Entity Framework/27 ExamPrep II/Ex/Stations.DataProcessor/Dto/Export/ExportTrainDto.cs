namespace Stations.DataProcessor.Dto.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExportTrainDto
    {
        public string TrainNumber { get; set; }

        public int DelayedTimes { get; set; }

        public string MaxDelayedTime { get; set; }
    }
}
