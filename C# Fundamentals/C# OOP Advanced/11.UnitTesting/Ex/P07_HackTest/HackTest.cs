namespace P07_HackTest
{
    using Moq;
    using NUnit.Framework;
    using P07_Hack;
    using System;

    public class HackTest
    {
        private const int NegativeValue = -10;
        private const int ExpectedAbsoluteValue = 10;

        [Test]
        public void MathAbsIntegerShouldWorkCorrectly()
        {
            Mock<IInteger> mockInteger = new Mock<IInteger>();

            mockInteger.Setup(i => i.GetMathAbs(NegativeValue)).Returns(Math.Abs(NegativeValue));

            int expectedInteger = ExpectedAbsoluteValue;
            int actualInteger = mockInteger.Object.GetMathAbs(-10);

            Assert.AreEqual(expectedInteger, actualInteger);

            int expectedZeroInteger = 0;
            int actualZeroInteger = Math.Abs(0);

            Assert.AreEqual(expectedZeroInteger, actualZeroInteger);
        }

        [Test]
        public void MathAbsDecimalShouldWorkCorrectly()
        {
            decimal expectedDecimal = 1000.0m;
            decimal actualDecimal = Math.Abs(-1000.0m);

            Assert.AreEqual(expectedDecimal, actualDecimal);
        }

        [Test]
        public void MathAbsDoubleShouldWorkCorrectly()
        {
            double expectedDouble = 100.0d;
            double actualDouble = Math.Abs(-100.0d);

            Assert.AreEqual(expectedDouble, actualDouble);

            double expectedPositiveDouble = 100.0d;
            double actualPositiveDouble = Math.Abs(100.0d);

            Assert.AreEqual(expectedPositiveDouble, actualPositiveDouble);
        }

        [Test]
        public void MathFloorDoublePositiveShouldWorkCorrectly()
        {
            double expectedPositiveDouble = 100.0d;
            double actualPositiveDouble = Math.Floor(100.897d);

            Assert.AreEqual(expectedPositiveDouble, actualPositiveDouble);
        }

        [Test]
        public void MathFloorDoubleNegativeShouldWorkCorrectly()
        {
            double expectedNegativeDouble = -1001.0d;
            double actualNegativeDouble = Math.Floor(-1000.897d);

            Assert.AreEqual(expectedNegativeDouble, actualNegativeDouble);
        }

        [Test]
        public void MathFloorDecimalPositiveShouldWorkCorrectly()
        {
            decimal expectedPositiveDecimal = 100.0m;
            decimal actualPositiveDecimal = Math.Floor(100.897m);

            Assert.AreEqual(expectedPositiveDecimal, actualPositiveDecimal);
        }

        [Test]
        public void MathFloorDecimalNegativeShouldWorkCorrectly()
        {
            decimal expectedNegativeDecimal = -1001.0m;
            decimal actualNegativeDecimal = Math.Floor(-1000.897m);

            Assert.AreEqual(expectedNegativeDecimal, actualNegativeDecimal);
        }
    }
}
