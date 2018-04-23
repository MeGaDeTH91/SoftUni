// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using System;
    using NUnit.Framework;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void RegisterSetTest()
	    {
            ISet set = new Short("Set1");

            IStage stage = new Stage();

            int hours1 = 0;
            int minutes1 = 1;
            int seconds1 = 2;
            TimeSpan songDuration1 = new TimeSpan(hours1, minutes1, seconds1);

            ISong song = new Song("Song1", songDuration1);

            int hours2 = 0;
            int minutes2 = 1;
            int seconds2 = 2;
            TimeSpan songDuration2 = new TimeSpan(hours2, minutes2, seconds2);

            ISong song2 = new Song("Song2", songDuration2);


            IPerformer performer1 = new Performer("Gosho", 24);
            Drums drum = new Drums();
            performer1.AddInstrument(drum);

            IPerformer performer2 = new Performer("Pesho", 19);
            Guitar guitar = new Guitar();
            Drums drum2 = new Drums();
            performer2.AddInstrument(guitar);

            set.AddPerformer(performer1);
            set.AddPerformer(performer2);
            set.AddSong(song);
            set.AddSong(song2);

            stage.AddSet(set);
            stage.AddSong(song);
            stage.AddSong(song2);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            
            SetController setController = new SetController(stage);

            string expected = "1. Set1:" + Environment.NewLine + "-- 1. Song1 (01:02)" + Environment.NewLine + "-- 2. Song2 (01:02)" + Environment.NewLine + "-- Set Successful";

            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestIfInstrumentsWearDown()
        {
            ISet set = new Short("Set1");
            ISet set2 = new Short("Set2");

            IStage stage = new Stage();

            int hours1 = 0;
            int minutes1 = 1;
            int seconds1 = 2;
            TimeSpan songDuration1 = new TimeSpan(hours1, minutes1, seconds1);

            ISong song = new Song("Song1", songDuration1);

            int hours2 = 0;
            int minutes2 = 1;
            int seconds2 = 2;
            TimeSpan songDuration2 = new TimeSpan(hours2, minutes2, seconds2);

            ISong song2 = new Song("Song2", songDuration2);


            IPerformer performer1 = new Performer("Gosho", 24);
            Drums drum = new Drums();
            performer1.AddInstrument(drum);

            IPerformer performer2 = new Performer("Pesho", 19);
            Guitar guitar = new Guitar();
            performer2.AddInstrument(guitar);

            set.AddPerformer(performer1);
            set.AddPerformer(performer2);
            set.AddSong(song);
            set.AddSong(song2);

            set2.AddPerformer(performer1);
            set2.AddPerformer(performer2);
            set2.AddSong(song);
            set2.AddSong(song2);

            stage.AddSet(set);
            stage.AddSet(set2);
            stage.AddSong(song);
            stage.AddSong(song2);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);

            SetController setController = new SetController(stage);

            string expectedSet1 = "1. Set1:" + Environment.NewLine + "-- 1. Song1 (01:02)" + Environment.NewLine + "-- 2. Song2 (01:02)" + Environment.NewLine + "-- Set Successful";

            string expectedSet2 = Environment.NewLine + "2. Set2:" + Environment.NewLine + "-- Did not perform";

            string expected = expectedSet1 + expectedSet2;

            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void DidNotPerformTest()
        {
            ISet set = new Short("Set1");

            IStage stage = new Stage();

            int hours = 0;
            int minutes = 1;
            int seconds = 2;
            TimeSpan songDuration = new TimeSpan(hours, minutes, seconds);

            ISong song = new Song("Song1", songDuration);

            stage.AddSet(set);
            stage.AddSong(song);

            IPerformer performer1 = new Performer("Gosho", 24);
            Drums drum = new Drums();
            performer1.AddInstrument(drum);

            IPerformer performer2 = new Performer("Pesho", 19);
            Guitar guitar = new Guitar();
            performer1.AddInstrument(guitar);

            set.AddPerformer(performer1);
            set.AddPerformer(performer2);

            SetController setController = new SetController(stage);

            set.AddSong(song);

            string expected = "1. Set1:" + Environment.NewLine + "-- Did not perform";

            string actual = setController.PerformSets();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}