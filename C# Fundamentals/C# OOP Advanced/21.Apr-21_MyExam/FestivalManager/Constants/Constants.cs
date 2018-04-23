using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Constants
{
    public class Constants
    {
        public const string SongOverSetLimit = "Song is over the set limit!";

        public const string RegisterSetCommand = "RegisterSet";
        public const string RegisterSetSuccessMessage = "Registered {0} set";

        public const string SignUpPerformerCommand = "SignUpPerformer";
        public const string SignUpPerformerSuccessMessage = "Registered performer {0}";

        public const string RegisterSongCommand = "RegisterSong";
        // 0 -> Song name; 1 - duration:mm\\:ss
        public const string RegisterSongSuccessMessage = "Registered song {0}";

        public const string AddSongToSetCommand = "AddSongToSet";
        public const string AddSongToSetInvalidSetMessage = "Invalid set provided";
        public const string AddSongToSetInvalidSongMessage = "Invalid song provided";
        // 0 -> SongToString; 2 -> setName
        public const string AddSongToSetSuccessMessage = "Added {0} to {1}";

        public const string AddPerformerToSetCommand = "AddPerformerToSet";
        public const string AddPerformerNonExistingPerformer = "Invalid performer provided";
        public const string AddPerformerNonExistingSet = "Invalid set provided";
        // 0 -> performerName ; 1-> setName
        public const string AddPerformerToSetSuccessMessage = "Added {0} to {1}";

        public const string RepairInstrumentsCommand = "RepairInstruments";
        // 0 -> instrumentsCount
        public const string RepairedInstrumentsCount = "Repaired {0} instruments";

        public const string LetsRockCommand = "LetsRock";
        public const string LetsRockCannotPerformSetMessage = "-- Did not perform";
        // 0 -> songIndex; 1 -> songName; 2 -> songDuration:mm\\:ss
        public const string LetsRockCommandPerformMessage = "-- {0}. {1} ({2})";
        public const string LetsRockSuccessfulSetMessage = "-- Set Successful";

        public const string ProduceReportFirstLineFestivalLenght = "Festival length: {0:D2}:{1:D2}";
        // 0 -> setName; 1 -> setActualDuration
        public const string ProduceReportSetDetails = "--{0} ({1:D2}:{2:D2}):";

        public const string TerminateProgramMessage = "END";
    }
}
