using NUnit.Framework;
using System;
using LinkedStructure;
namespace LinkedTests
{
    public class ListTests
    {
        [Test]
        public void CountTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            int exp = 3;
            int res = list.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CapacityTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(8);
            int exp = 8;
            int res = list.Capacity;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CapacityBuilderTest()
        {
            List<int> list = new List<int>(8);
            int exp = 8;
            int res = list.Capacity;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CapacityLowerZeroBuilderTest()
        {
            Assert.Throws<Exception>(() => new List<int>(-8));
        }
        [Test]
        public void AddTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            int exp = 3;
            int res = list[2];
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DeleteLastTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.DeleteLast();
            int i;
            Assert.Throws<Exception>(() => i = list[2]);
        }
        [Test]
        public void DeleteFromPosTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Delete(2);
            int i;
            Assert.Throws<Exception>(() => i = list[2]);
        }
        [Test]
        public void InsertTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(7, 1);
            int exp = 7;
            int res = list[1];
            Assert.AreEqual(exp,res);
        }
        [Test]
        public void InsertIncorrectPosTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.Throws<Exception>(() => list.Insert(5, 5));
        }
        [Test]
        public void ClearList()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            List<int> d = new List<int>(list.Capacity);
            list.Clear();
            Assert.AreEqual(list, d);
        }
        [Test]
        public void ContainsInList()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            bool exp = true;
            bool res = list.Contains(5);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void NotContainsInList()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            bool exp = false;
            bool res = list.Contains(9);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void ListToArray()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            int[] res = list.ToArray();
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void ListCopyToNotNullArray()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            int[] res = new int[list.Count];
            list.CopyTo(res, 0);
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void ListCopyToNullArray()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            int[] res = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(res, 0));
        }
        [Test]
        public void ListForeach()
        {
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(8);
            list.Add(1);
            list.Add(2);
            int res = 0;
            foreach (var item in list)
            {
                res++;
            }
            int exp = list.Count;
            Assert.AreEqual(exp, res);
        }
    }
}