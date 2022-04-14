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
    }
}