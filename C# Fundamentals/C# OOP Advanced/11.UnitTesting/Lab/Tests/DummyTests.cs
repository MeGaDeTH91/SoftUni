namespace Tests
{
    using NUnit.Framework;

    public class DummyTests
    {
        private static Dummy dummy;
        private const int InitialHealth = 100;
        private const int InitialExperience = 100;

        private const string DummyIsDeadExceptionMessage = "Dummy is dead.";
        private const string DummyIsNotDeadExceptionMessage = "Target is not dead.";

        private const int DummyHealthAfterNonLethalAttack = 95;
        private const int NonLethalAttackPoints = 5;
        private const int LethalAttackPoints = 100;

        [SetUp]
        public void InitializeDummy()
        {
            dummy = new Dummy(InitialHealth, InitialExperience);
        }
        
        [Test]
        public void DummyLosesHealtOnAttack()
        {
            dummy.TakeAttack(NonLethalAttackPoints);

            Assert.AreEqual(dummy.Health, DummyHealthAfterNonLethalAttack);
        }
        [Test]
        public void DeadDummyThrowsExceptionOnAttack()
        {
            dummy.TakeAttack(LethalAttackPoints);

            Assert.That(() => dummy.TakeAttack(NonLethalAttackPoints), Throws.InvalidOperationException.With.Message.EqualTo(DummyIsDeadExceptionMessage));
        }
        [Test]
        public void DeadDummyGivesExperience()
        {
            dummy.TakeAttack(LethalAttackPoints);

            Assert.AreEqual(dummy.GiveExperience(), InitialExperience);
        }
        [Test]
        public void AliveDummyDoesNotGiveExperience()
        {
            dummy.TakeAttack(NonLethalAttackPoints);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo(DummyIsNotDeadExceptionMessage));
        }
    }
}
