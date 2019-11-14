using LimitedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LimitedListTests
{
    [TestClass]
    public class LimitedListTests
    {
        [TestMethod]
        public void CreateList_WithCapacity_ReturnsCapacity()
        {
            //Arrange
            const int expected = 10;
            var list = new LimitedList<string>(expected);
            //Act
            var actual = list.Capacity;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateList_WithZeroCapacity_Works()
        {
            const int expected = 0;
            var list = new LimitedList<string>(expected);

            var actual = list.Capacity;
            bool added = list.Add("No");
            int count = list.Count;

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(added);
            Assert.AreEqual(expected, count);
        }

        [TestMethod]
        public void CreateList_WithNegativeCapacity_CreatesListWithZero()
        {
            const int capacity = -20;
            const int expected = 0;
            var list = new LimitedList<string>(capacity);

            var actual = list.Capacity;
            bool added = list.Add("No");
            int count = list.Count;

            Assert.AreEqual(expected, actual, "Capacity is not zero");
            Assert.IsFalse(added);
            Assert.AreEqual(expected, count);
        }

        [TestMethod]
        public void Add_ToNotFullList_ReturnsTrue()
        {
            const int expected = 2;
            var list = new LimitedList<int>(expected);
            list.Add(2);

            var added = list.Add(5);

            Assert.AreEqual(true, added);
            Assert.AreEqual(expected, list.Count);
        } 
        
        [TestMethod]
        public void Add_ToFullList_ReturnsFalse()
        {
            const int expected = 2;
            var list = new LimitedList<int>(expected);
            list.Add(2);
            list.Add(2);

            var added = list.Add(5);

            Assert.AreEqual(false, added);
            Assert.AreEqual(expected, list.Count);
        }
    }
}
