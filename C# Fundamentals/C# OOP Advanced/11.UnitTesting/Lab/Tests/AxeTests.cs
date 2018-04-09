namespace Tests
{
    using NUnit.Framework;

    public class AxeTests
    {
        private const int InitialAxeAttackPoints = 10;
        private const int InitialAxeDurability = 3;

        private const int InitialDummyHealth = 30;
        private const int InitialDummyExperience = 10;

        private const string AxeDurabilityNotChangedExceptionMessage = "Axe durability did not change after attack!";
        private const string AxeIsBrokenExceptionMessage = "Axe is broken.";
        private const int AxeDurabilityPointsAfterAttacks = 1;

        private static Axe axe;
        private static Dummy dummy;

        [SetUp]
        public void InitializeAxeAndDummy()
        {
            axe = new Axe(InitialAxeAttackPoints, InitialAxeDurability);
            dummy = new Dummy(InitialDummyHealth, InitialDummyExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints.Equals(AxeDurabilityPointsAfterAttacks), AxeDurabilityNotChangedExceptionMessage);
        }
        [Test]
        public void AttackWithBrokenAxeMustThrowException()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo(AxeIsBrokenExceptionMessage));
        }
    }
}
