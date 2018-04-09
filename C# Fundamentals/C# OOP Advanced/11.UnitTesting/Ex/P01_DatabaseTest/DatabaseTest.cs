namespace P01_DatabaseTest
{
    using NUnit.Framework;
    using P01_Database;

    public class DatabaseTest
    {
        [Test]
        public void TestConstructorExceedCapacityShouldThrowException()
        {
            int[] exceededCapacityArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

            Database db = new Database();

            Assert.That(() => db = new Database(exceededCapacityArray), Throws.InvalidOperationException.With.Message.EqualTo("Database capacity exceeded!"));
        }

        [Test]
        public void TestConstructorWithValidCapacityShouldAddThem()
        {
            int[] validCapacityArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            Database db = new Database(validCapacityArray);

            string expected = string.Join(" ", validCapacityArray);
            string actual = string.Join(" ", db.DatabaseNumbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddOperationExceedCapacityShouldThrowException()
        {
            int[] validCapacityArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Database db = new Database(validCapacityArray);
            
            Assert.That(() => db.Add(5), Throws.InvalidOperationException.With.Message.EqualTo("Database capacity exceeded!"));
        }

        [Test]
        public void TestAddOperationWithValidIndexShouldAddCorrectly()
        {
            Database db = new Database();
            int[] expectedNumbers = new int[] { 10, 15, 20 };

            db.Add(expectedNumbers[0]);
            db.Add(expectedNumbers[1]);
            db.Add(expectedNumbers[2]);

            string expected = string.Join(" ", expectedNumbers);
            string actual = string.Join(" ", db.DatabaseNumbers);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRemoveOperationEmptyCollectionShouldThrowException()
        {
            Database db = new Database();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("No elements in Database!"));
        }

        [Test]
        public void TestRemoveOperationWithValidElementShouldRemoveCorrectly()
        {
            int[] initialNumbers = { 10, 15, 20 };

            Database db = new Database(initialNumbers);

            int[] expectedNumbers = new int[] { 10, 15 };

            db.Remove();

            string expected = string.Join(" ", expectedNumbers);
            string actual = string.Join(" ", db.DatabaseNumbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFetchOperationShouldReturnCorrectElements()
        {
            int[] initialNumbers = { 10, 15, 20 };

            Database db = new Database(initialNumbers);

            int[] actualNumbers = db.Fetch();

            string expected = string.Join(" ", initialNumbers);
            string actual = string.Join(" ", actualNumbers);
            
            Assert.AreEqual(expected, actual);
        }
    }
}
