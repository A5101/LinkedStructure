using NUnit.Framework;
using System;
using LinkedStructure;
namespace LinkedTests
{
    public class SLLTests
    {

        [Test]
        public void CountNotEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            int exp = 4;
            int res = list.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CountEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int exp = 0;
            int res = list.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void LastInNotEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            int exp = 1;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void LastInEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int i;
            Assert.Throws<NullReferenceException>(() => i = list.Last.Value); ;
        }
        [Test]
        public void FirstInNotEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            int exp = 5;
            int res = list.First.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void FirstInEmptyTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int i;
            Assert.Throws<NullReferenceException>(() => i = list.First.Value); ;
        }
        [Test]
        public void AddValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            int exp = 6;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddNodeTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(new Node<int>(5));
            list.Add(new Node<int>(6));
            int exp = 6;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void RemoveContainsValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            bool res = list.Remove(5);
            Assert.AreEqual(true, res);
        }
        [Test]
        public void RemoveNotContainsValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            bool res = list.Remove(2);
            Assert.AreEqual(false, res);
        }
        [Test]
        public void FindContainsValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            var res = list.Find(5);
            Assert.IsNotNull(res);
        }
        [Test]
        public void FindNotContainsValueTest()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(1);
            var res = list.Find(2);
            Assert.IsNull(res);
        }
    }
}