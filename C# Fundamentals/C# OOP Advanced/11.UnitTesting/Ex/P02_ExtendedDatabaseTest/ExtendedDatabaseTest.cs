namespace P02_ExtendedDatabaseTest
{
    using NUnit.Framework;
    using P02_ExtendedDatabase;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendedDatabaseTest
    {
        [Test]
        public void TestConstructorExceedCapacityShouldThrowException()
        {
            List<Person> initialPeople = new List<Person>();

            for (int i = 1; i < 20; i++)
            {
                Person currentPerson = new Person(i, $"Rocky{i}");
                initialPeople.Add(currentPerson);
            }

            Person[] exceededCapacityArray = initialPeople.ToArray();

            ExtendedDatabase db = new ExtendedDatabase();

            Assert.That(() => db = new ExtendedDatabase(exceededCapacityArray), Throws.InvalidOperationException.With.Message.EqualTo("Database capacity exceeded!"));
        }

        [Test]
        public void TestConstructorWithValidPeopleCapacityShouldAddThem()
        {
            List<Person> validCapacityArray = new List<Person>();

            for (int i = 1; i < 12; i++)
            {
                Person currentPerson = new Person(i, $"Creed{i}");
                validCapacityArray.Add(currentPerson);
            }

            ExtendedDatabase db = new ExtendedDatabase(validCapacityArray.ToArray());

            string expected = string.Join(" ", validCapacityArray);
            string actual = string.Join(" ", db.DatabasePeople);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddOperationExceedCapacityShouldThrowException()
        {
            List<Person> validCapacityArray = new List<Person>();

            for (int i = 1; i <= 16; i++)
            {
                Person currentPerson = new Person(i, $"Creed{i}");
                validCapacityArray.Add(currentPerson);
            }

            ExtendedDatabase db = new ExtendedDatabase(validCapacityArray.ToArray());

            Person personToFailAdding = new Person(40, "Vancho");

            Assert.That(() => db.Add(personToFailAdding), Throws.InvalidOperationException.With.Message.EqualTo("Database capacity exceeded!"));
        }

        [Test]
        public void AddOperationWithValidIndexShouldAddCorrectly()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Person person1 = new Person(1, "Vanko1");
            Person person2 = new Person(2, "Vanko2");
            Person person3 = new Person(3, "Vanko3");

            Person[] expectedPeople = new Person[] { person1, person2, person3 };

            db.Add(expectedPeople[0]);
            db.Add(expectedPeople[1]);
            db.Add(expectedPeople[2]);

            string expected = string.Join(" ", expectedPeople.Select(x => x.ToString()));
            string actual = string.Join(" ", db.DatabasePeople);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddExistingUserIdShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Person person = new Person(1, "Vanko1");
            Person person2 = new Person(1, "Vanko5");

            db.Add(person);

            Assert.That(() => db.Add(person2), Throws.InvalidOperationException.With.Message.EqualTo("User with this id already exists!"));
        }

        [Test]
        public void AddExistingUserUsernameShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Person person = new Person(1, "Vanko1");
            Person person2 = new Person(2, "Vanko1");

            db.Add(person);

            Assert.That(() => db.Add(person2), Throws.InvalidOperationException.With.Message.EqualTo("User with this username already exists!"));
        }

        [Test]
        public void RemoveOperationEmptyCollectionShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("No elements in Database!"));
        }

        [Test]
        public void RemoveOperationWithValidElementShouldRemoveCorrectly()
        {
            Person person = new Person(1, "Vanko1");
            Person person2 = new Person(2, "Vanko2");
            Person person3 = new Person(3, "Vanko3");

            Person[] initialPeople = { person, person2, person3 };

            ExtendedDatabase db = new ExtendedDatabase(initialPeople);

            Person[] expectedPeople = { person, person2 };

            db.Remove();

            Assert.That(db.DatabasePeople, Is.EquivalentTo(expectedPeople));
        }

        [Test]
        public void FindNonExistingUsernameShouldThrowException()
        {
            Person person = new Person(1, "Vanko1");
            Person seekPerson = new Person(1, "Vanko5");

            ExtendedDatabase db = new ExtendedDatabase(person);

            Assert.That(() => db.FindByUsername(seekPerson.Username), Throws.InvalidOperationException.With.Message.EqualTo("No such username in Database!"));
        }

        [Test]
        public void FindNullUsernameShouldThrowException()
        {
            ExtendedDatabase db = new ExtendedDatabase();

            Assert.That(() => db.FindByUsername(default(string)), Throws.ArgumentNullException.With.Message.EqualTo("Username cannot be null!"));
        }

        [Test]
        public void FindValidUsernameShouldReturnCorrectly()
        {
            Person person = new Person(1, "Vanko1");
            
            ExtendedDatabase db = new ExtendedDatabase(person);

            Person seekPerson = db.FindByUsername(person.Username);

            Assert.That(seekPerson, Is.EqualTo(person));
        }

        [Test]
        public void FindInvalidUserIdShouldThrowException()
        {
            Person person = new Person(1, "Vanko1");

            ExtendedDatabase db = new ExtendedDatabase(person);


            Assert.That(() => db.FindById(2), Throws.InvalidOperationException.With.Message.EqualTo("No user with this Id in Database!"));
        }

        [Test]
        public void FindNegativeUserIdShouldThrowException()
        {
            Person person = new Person(1, "Vanko1");

            ExtendedDatabase db = new ExtendedDatabase(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindValidUserIdShouldReturnCorrectly()
        {
            Person person = new Person(1, "Vanko1");

            ExtendedDatabase db = new ExtendedDatabase(person);

            Person seekPerson = db.FindById(person.Id);

            Assert.That(seekPerson, Is.EqualTo(person));
        }
    }
}
