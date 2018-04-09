namespace P08_CustomLinkedListTest
{
    using NUnit.Framework;
    using P08_CustomLinkedList;
    using System;
    using System.Reflection;

    public class CustomLinkedListTest
    {
        private const int ExpectedZeroCount = 0;
        private const int ExpectedThreeElementsCount = 3;

        private const int LowerRemoveIndex = -4;
        private const int ValidRemoveIndex = 1;
        private const int HigherRemoveIndex = 10;

        //StringTests
        [Test]
        public void TestStringElementsCountWithEmptyCollectionShouldReturnZero()
        {
            Type dynamicListType = typeof(DynamicList<string>);

            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            int elementsCount = (int)dynamicListType.GetProperty("Count").GetValue(classInstance);

            Assert.That(elementsCount, Is.EqualTo(ExpectedZeroCount));
        }

        [Test]
        public void TestStringElementsCountWithThreeElementsShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Batman", "Superman", "Bane"};

            Type dynamicListType = typeof(DynamicList<string>);

            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int elementsCount = (int)dynamicListType.GetProperty("Count").GetValue(classInstance);
            
            Assert.That(elementsCount, Is.EqualTo(ExpectedThreeElementsCount));


        }

        [Test]
        public void TestGetElementAtSpecificIndexShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Batman", "Superman", "Bane" };

            Type dynamicListType = typeof(DynamicList<string>);

            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);
            
            foreach (var element in initialElements)
            {
                classInstance.Add(element);
            }

            string expectedElement = initialElements[1];
            string actualElement = classInstance[1];

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void TestSetElementAtSpecificIndexShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Batman", "Superman", "Bane", "Dahaka" };

            Type dynamicListType = typeof(DynamicList<string>);

            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            foreach (var element in initialElements)
            {
                classInstance.Add(element);
            }

            string expectedElement = initialElements[1];
            string actualElement = classInstance[1];

            Assert.That(actualElement, Is.EqualTo(expectedElement));

            classInstance[1] = initialElements[3];

            expectedElement = initialElements[3];
            actualElement = classInstance[1];

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void AddOneElementShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Dahaka"};

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);
            FieldInfo head = dynamicListType.GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            string expectedElement = initialElements[0];
            string actualElement = classInstance[0];

            Assert.That(actualElement, Is.EqualTo(expectedElement));
        }

        [Test]
        public void AddThreeElementsShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            for (int index = 0; index < initialElements.Length; index++)
            {
                string actualElement = classInstance[index];
                string expectedElement = initialElements[index];

                Assert.That(actualElement, Is.EqualTo(expectedElement));
            }
        }

        [Test]
        public void RemoveAtInvalidIndexShouldThrowException()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo removeMethod = dynamicListType.GetMethod("RemoveAt", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.RemoveAt(LowerRemoveIndex), "Invalid index: " + LowerRemoveIndex);

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.RemoveAt(HigherRemoveIndex), "Invalid index: " + HigherRemoveIndex);
        }

        [Test]
        public void RemoveAtValidIndexShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            MethodInfo removeMethod = dynamicListType.GetMethod("RemoveAt", BindingFlags.Instance | BindingFlags.Public);

            removeMethod.Invoke(classInstance, new object[] { ValidRemoveIndex });

            initialElements = new string[] { "Dahaka", "Babylon" };

            for (int index = 0; index < initialElements.Length; index++)
            {
                string actualElement = classInstance[index];
                string expectedElement = initialElements[index];

                Assert.That(actualElement, Is.EqualTo(expectedElement));
            }
        }

        [Test]
        public void RemoveSpecificNonExistingElementShouldReturnMinusOne()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo removeMethod = dynamicListType.GetMethod("Remove", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int nonValidElement = (int)removeMethod.Invoke(classInstance, new object[] { "NonExistingElementHere" });
            int expectedReturn = -1;

            Assert.That(nonValidElement, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void RemoveSpecificElementShouldWorkCorrectly()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);

            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            MethodInfo removeMethod = dynamicListType.GetMethod("Remove", BindingFlags.Instance | BindingFlags.Public);

            removeMethod.Invoke(classInstance, new object[] { initialElements[1] });

            initialElements = new string[] { "Dahaka", "Babylon" };

            for (int index = 0; index < initialElements.Length; index++)
            {
                string actualElement = classInstance[index];
                string expectedElement = initialElements[index];

                Assert.That(actualElement, Is.EqualTo(expectedElement));
            }
        }

        [Test]
        public void IndexOfNonExistingElementShouldReturnMinusOne()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo indexOf = dynamicListType.GetMethod("IndexOf", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int nonValidElement = (int)indexOf.Invoke(classInstance, new object[] { "NonExistingElementHere" });
            int expectedReturn = -1;

            Assert.That(nonValidElement, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void IndexOfValidElementShouldReturnCorrectIndex()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo indexOf = dynamicListType.GetMethod("IndexOf", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            int nonValidElement = (int)indexOf.Invoke(classInstance, new object[] { initialElements[2] });
            int expectedReturn = 2;

            Assert.That(nonValidElement, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void ContainsNonExistingElementShouldReturnFalse()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo contains = dynamicListType.GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            bool nonValidElement = (bool)contains.Invoke(classInstance, new object[] { "NonExistingElementHere" });
            bool expectedReturn = false;

            Assert.That(nonValidElement, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void ContainsValidElementShouldReturnTrue()
        {
            string[] initialElements = new string[] { "Dahaka", "The two thrones", "Babylon" };

            Type dynamicListType = typeof(DynamicList<string>);
            DynamicList<string> classInstance = (DynamicList<string>)Activator.CreateInstance(dynamicListType);

            MethodInfo contains = dynamicListType.GetMethod("Contains", BindingFlags.Instance | BindingFlags.Public);

            MethodInfo addMethod = dynamicListType.GetMethod("Add", BindingFlags.Instance | BindingFlags.Public);

            foreach (var element in initialElements)
            {
                addMethod.Invoke(classInstance, new object[] { element });
            }

            bool nonValidElement = (bool)contains.Invoke(classInstance, new object[] { initialElements[0] });
            bool expectedReturn = true;

            Assert.That(nonValidElement, Is.EqualTo(expectedReturn));
        }
    }
}
