using MyDegueLibrary;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace MyDeque.NunitTest
{
    [TestFixture]
    public class MyDequeTest
    {
        private MyDeque<int> arr;

        [SetUp]
        public void SetUp()
        {
            arr = new MyDeque<int>();
            arr.AddToBack(5);
            arr.AddToBack(19);
            arr.AddToFront(7);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(2)]
        public void Size_AddElements_GetResult(int expected)
        {
            // Arrange
            MyDeque<int> a = new MyDeque<int>();

            // Act
            for (int i = 0; i < expected; i++)
            {
                a.AddToBack(i);
            }
            int actual = a.Size;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase("string")]
        [TestCase(8)]
        [TestCase(1.5)]
        public void AddToBack_AddElement_CheckLastElement<T>(T expected)
        {
            // Arrange
            MyDeque<T> a = new MyDeque<T>();

            // Act
            a.AddToBack(expected);
            T actual = a.Tail.Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddToBack_NullAsParameter_ExceptionExpected()
        {
            // Arrange
            var a = new MyDeque<string>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => a.AddToBack(null));
        }

        [Test]
        [TestCase("string")]
        [TestCase(8)]
        [TestCase(1.5)]
        public void AddToFront_AddElement_CheckFirstElement<T>(T expected)
        {
            // Arrange
            MyDeque<T> a = new MyDeque<T>();

            // Act
            a.AddToFront(expected);
            T actual = a.Head.Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddToFront_NullAsParameter_ExceptionExpected()
        {
            // Arrange
            var a = new MyDeque<string>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => a.AddToFront(null));
        }

        [Test]
        public void RemoveFromBack_RemovingLastElement_19Expected()
        {
            // Arrange

            // Act
            arr.RemoveFromBack();
            int expected = 5;
            int actual = arr.Tail.Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveFromBack_RemovingFromEmptyCollection_InvalidOperationExceptionExpected()
        {
            // Arrange
            var a = new MyDeque<int>();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => a.RemoveFromBack());
        }

        [Test]
        public void RemoveFromFront_RemovingFirstElement_7Expected()
        {
            // Arrange

            // Act
            arr.RemoveFromBack();
            int expected = 5;
            int actual = arr.Tail.Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveFromFront_RemovingFromEmptyCollection_ExceptionExpected()
        {
            // Arrange
            var a = new MyDeque<int>();

            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => a.RemoveFromFront());
        }

        [Test]
        public void PeekBack_GetLastElementOfCollection_19Expected()
        {
            // Arrage

            // Act
            int expected = 19;
            var actual = arr.PeekBack();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PeekBack_GetLastElementFromEmptyCollection_ExceptionExpected()
        {
            // Arrage
            var a = new MyDeque<int>();
            // Act

            // Assert
            Assert.Throws<InvalidOperationException>(() => a.PeekBack());
        }

        [Test]
        public void IsEmpty_CheckEmptyCollection_ExpectedTrue()
        {
            // Arrage
            var a = new MyDeque<int>();

            // Act
            bool actual = a.IsEmpty();

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ToArray_ConvertCollectionToArray_ExpectedArray()
        {
            // Arrage
            int[] expected = new int[] { 7, 5, 19 };

            // Act 
            var actual = arr.ToArray();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void ToArray_ConvertEmptyCollectionToArray_ExpectedException()
        {
            // Arrage
            var a = new MyDeque<int>();

            // Act 

            //Assert
            Assert.Throws<InvalidOperationException>(() => a.ToArray());
        }
    }
}
