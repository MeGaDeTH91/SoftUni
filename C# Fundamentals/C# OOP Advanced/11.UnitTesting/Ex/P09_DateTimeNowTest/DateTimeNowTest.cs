namespace P09_DateTimeNowTest
{
    using Moq;
    using NUnit.Framework;
    using P09_DateTimeNow;
    using System;
    using System.Globalization;

    public class DateTimeNowTest
    {
        private static DateTime DateTimeNow = DateTime.Parse("04/09/2018", CultureInfo.InvariantCulture);
        private static DateTime DateTimeMinValue = DateTime.MinValue;
        private static DateTime DateTimeMaxValue = DateTime.MaxValue;

        private const int AddDaysToMiddle = 11;
        private const int AddDaysToEnd = 20;
        private const int AddDaysToNextMonth = 26;
        private const int AddDaysToPreviousMonth = -15;
        private const int AddDayInLeapYear = 1;
        private const int AddOneDay = 1;
        private const int SubtractOneDay = -1;

        [Test]
        public void AddDaysToTheMiddleOfMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            
            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToMiddle));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeNow.AddDays(AddDaysToMiddle).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToTheEndOfMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToEnd));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeNow.AddDays(AddDaysToEnd).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToNextMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToNextMonth));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeNow.AddDays(AddDaysToNextMonth).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDaysToPreviousMonthShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeNow.AddDays(AddDaysToPreviousMonth));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeNow.AddDays(AddDaysToPreviousMonth).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void AddDayToLeapYearShouldWorkCorrectly()
        {
            DateTime leapYear = DateTime.Parse("02/28/2020", CultureInfo.InvariantCulture);

            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(leapYear.AddDays(AddDayInLeapYear));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = leapYear.AddDays(AddDayInLeapYear).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);

            bool dayIsCorrect = mockDateTimeNow.Object.GiveMeDateTimeNow().Day.ToString().Equals("29");

            Assert.AreEqual(dayIsCorrect, true);
        }

        [Test]
        public void AddDayToNonLeapYearShouldWorkCorrectly()
        {
            DateTime leapYear = DateTime.Parse("02/28/2018", CultureInfo.InvariantCulture);

            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(leapYear.AddDays(AddDayInLeapYear));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = leapYear.AddDays(AddDayInLeapYear).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);

            bool dayIsCorrect = mockDateTimeNow.Object.GiveMeDateTimeNow().Day.ToString().Equals("1");

            Assert.AreEqual(dayIsCorrect, true);
        }

        [Test]
        public void AddDayToMinValueShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeMinValue.AddDays(AddOneDay));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeMinValue.AddDays(AddOneDay).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }

        [Test]
        public void SubtractDayFromMinValueShouldThrowException()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeMinValue.AddDays(SubtractOneDay)));
        }

        [Test]
        public void AddDayToMaxValueShouldThrowException()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();
            
            Assert.Throws<ArgumentOutOfRangeException>(() => mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeMaxValue.AddDays(AddOneDay)));
        }

        [Test]
        public void SubtractDayFromMaxValueShouldWorkCorrectly()
        {
            Mock<IDateTimeNow> mockDateTimeNow = new Mock<IDateTimeNow>();

            mockDateTimeNow.Setup(d => d.GiveMeDateTimeNow()).Returns(DateTimeMaxValue.AddDays(SubtractOneDay));

            var actualDate = mockDateTimeNow.Object.GiveMeDateTimeNow().Date.ToString();
            var expectedDate = DateTimeMaxValue.AddDays(SubtractOneDay).Date.ToString();

            Assert.AreEqual(actualDate, expectedDate);
        }
    }
}
