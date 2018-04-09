namespace P03_IteratorTest
{
    using NUnit.Framework;
    using P03_Iterator;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class IteratorTest
    {
        [Test]
        public void TestConstructorWithNullShouldThrowException()
        {
            ListIterator list = new ListIterator();

            Assert.That(() => list = new ListIterator(null), Throws.ArgumentNullException.With.Message.EqualTo("No elements provided!"));
        }

        [Test]
        public void TestConstructorWithValidValuesShouldWorkCorrectly()
        {
            string[] expectedElements = new string[] { "Stefcho", "Goshky" };

            Type listType = typeof(ListIterator);

            FieldInfo field = listType.GetField("elements", BindingFlags.Instance | BindingFlags.NonPublic);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { expectedElements });

            List<string> actualElements = (List<string>)field.GetValue(classInstance);
            
            Assert.That(actualElements, Is.EquivalentTo(expectedElements));
        }

        [Test]
        public void MoveIfIndexIsLastShouldReturnFalse()
        {
            string[] expectedElements = new string[] { "Batman", "Superman" };

            Type listType = typeof(ListIterator);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { expectedElements });

            MethodInfo move = listType.GetMethod("Move");

            move.Invoke(classInstance, null);

            Assert.That(() => move.Invoke(classInstance, null), Is.EqualTo(false));
        }

        [Test]
        public void MoveIfIndexIsNotLastShouldReturnTrue()
        {
            string[] expectedElements = new string[] { "Batman", "Superman" };

            Type listType = typeof(ListIterator);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { expectedElements });

            MethodInfo move = listType.GetMethod("Move");

            Assert.That(() => move.Invoke(classInstance, null), Is.EqualTo(true));
        }

        [Test]
        public void HasNextIndexIsLastShouldReturnFalse()
        {
            string[] expectedElements = new string[] { "Superman", "Batman"};

            Type listType = typeof(ListIterator);

            MethodInfo hasNext = listType.GetMethod("HasNext", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo move = listType.GetMethod("Move", BindingFlags.Instance | BindingFlags.Public);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { expectedElements });

            move.Invoke(classInstance, null);

            Assert.That(() => hasNext.Invoke(classInstance, null), Is.EqualTo(false));
        }

        [Test]
        public void HasIndexShouldReturnTrue()
        {
            string[] expectedElements = new string[] { "Superman", "Batman" };

            Type listType = typeof(ListIterator);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { expectedElements });

            MethodInfo hasNext = listType.GetMethod("HasNext", BindingFlags.Instance | BindingFlags.Public);
                        
            Assert.That(() => hasNext.Invoke(classInstance, null), Is.EqualTo(true));
        }

        [Test]
        public void PrintEmptyCollectionShouldThrowException()
        {
            Type listType = typeof(ListIterator);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, true);

            Assert.That(() => classInstance.Print(), Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
        }

        [Test]
        public void PrintValidElementShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Batman", "Superman" };

            Type listType = typeof(ListIterator);

            ListIterator classInstance = (ListIterator)Activator.CreateInstance(listType, new object[] { initialElements });

            FieldInfo field = listType.GetField("currentPrint", BindingFlags.Instance | BindingFlags.NonPublic);

            MethodInfo print = listType.GetMethod("Print", BindingFlags.Instance | BindingFlags.Public);

            print.Invoke(classInstance, null);

            string expectedPrintElement = initialElements[0];
            string actualPrintElement = field.GetValue(classInstance).ToString();

            Assert.That(() => actualPrintElement, Is.EqualTo(expectedPrintElement));
        }
    }
}
