namespace Calculator.Tests
{
    using CTF.Framework.Asserts;
    using CTF.Framework.Attributes;

    [CTFTestClass]
    public class CalculatorTests
    {
        [CTFTestMethod]
        public void ShouldReturnTrueWhenTwoIntegersAreEqual()
        {
            CTFAssert.AreEqual(1, 1);
        }
    }
}