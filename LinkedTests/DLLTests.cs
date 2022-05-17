using LinkedStructure;
using NUnit.Framework;
using System;
namespace LinkedTests
{
    public class DLLTests
    {
        [Test]
        public void CountNotEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            int exp = 4;
            int res = list.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CountEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int exp = 0;
            int res = list.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void LastInNotEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            int exp = 6;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void LastInEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int i;
            Assert.Throws<NullReferenceException>(() => i = list.Last.Value);
        }
        [Test]
        public void FirstInNotEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            int exp = 1;
            int res = list.First.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void FirstInEmptyTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            int i;
            Assert.Throws<NullReferenceException>(() => i = list.First.Value); ;
        }
        [Test]
        public void AddValueLastTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            int exp = 6;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddNodeLastTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(new Node<int>(5));
            list.AddLast(new Node<int>(6));
            int exp = 6;
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddValueFirstTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(5);
            list.AddFirst(6);
            int exp = 6;
            int res = list.First.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddNodeFirstTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFirst(new Node<int>(5));
            list.AddFirst(new Node<int>(6));
            int exp = 6;
            int res = list.First.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddNodeAfterTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(6);
            Node<int> node3 = new Node<int>(2);
            list.AddLast(node1);
            list.AddLast(node2);
            list.AddAfter(node1, node3);
            int exp = 2;
            int res = list.First.Next.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddNodeBeforeTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(6);
            Node<int> node3 = new Node<int>(2);
            list.AddLast(node1);
            list.AddLast(node2);
            list.AddBefore(node2, node3);
            int exp = 2;
            int res = list.First.Next.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddValueAfterTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(6);
            list.AddLast(node1);
            list.AddLast(node2);
            list.AddAfter(node1, 2);
            int exp = 2;
            int res = list.First.Next.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void AddValueBeforeTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Node<int> node1 = new Node<int>(1);
            Node<int> node2 = new Node<int>(6);
            list.AddLast(node1);
            list.AddLast(node2);
            list.AddBefore(node2, 2);
            int exp = 2;
            int res = list.First.Next.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void RemoveFirstTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            int exp = 7;
            list.RemoveFirst();
            int res = list.First.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void RemoveLastTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            int exp = 5;
            list.RemoveLast();
            int res = list.Last.Value;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void RemoveContainsValueTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            bool res = list.Remove(5);
            Assert.AreEqual(true, res);
        }
        [Test]
        public void RemoveNotContainsValueTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            bool res = list.Remove(2);
            Assert.AreEqual(false, res);
        }
        [Test]
        public void FindContainsValueTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            var res = list.Find(1);
            Assert.IsNotNull(res);
        }
        [Test]
        public void FindNotContainsValueTest()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(6);
            list.AddFirst(7);
            list.AddFirst(1);
            var res = list.Find(2);
            Assert.IsNull(res);
        }
        [Test]
        public void ClearDLL()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            DoublyLinkedList<int> d = new DoublyLinkedList<int>();
            list.Clear();
            Assert.AreEqual(list, d);
        }
        [Test]
        public void ContainsInDLL()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            bool exp = true;
            bool res = list.Contains(2);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void NotContainsInDLL()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            bool exp = false;
            bool res = list.Contains(9);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DllToArray()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            int[] res = list.ToArray();
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DLLCopyToNotNullArray()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            int[] res = new int[list.Count];
            list.CopyTo(res, 0);
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DLLCopyToNullArray()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
            int[] res = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(res, 0));
        }
        [Test]
        public void DLLForeach()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(5);
            list.AddLast(8);
            list.AddLast(1);
            list.AddLast(2);
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