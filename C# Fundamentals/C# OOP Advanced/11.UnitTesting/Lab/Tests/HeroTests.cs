namespace Tests
{
    using Moq;
    using NUnit.Framework;

    public class HeroTests
    {
        private const int MockDummyHealth = 0;
        private const int MockDummyExperience = 20;
        private const int ExpectedHeroExperience = 20;

        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            Mock<IWeapon> mockAxe = new Mock<IWeapon>();
            Mock<ITarget> mockDummy = new Mock<ITarget>();

            mockDummy.Setup(p => p.Health).Returns(MockDummyHealth);
            mockDummy.Setup(p => p.GiveExperience()).Returns(MockDummyExperience);
            mockDummy.Setup(p => p.IsDead()).Returns(true);

            Hero hero = new Hero("Rambo_First_Blood", mockAxe.Object);

            hero.Attack(mockDummy.Object);

            int heroExperience = hero.Experience;

            Assert.AreEqual(ExpectedHeroExperience, heroExperience);
        }
    }
}
