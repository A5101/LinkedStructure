using NUnit.Framework;
using System;
using LinkedStructure;
namespace LinkedTests
{
    public class QueueTests
    {
        [Test]
        public void EnqueueInNotEmptyQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int exp = 5;
            int res = que.Dequeue();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DequeueInNotEmptyQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int exp = 5;
            int res = que.Dequeue();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PeekInNotEmptyQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int exp = 5;
            int res = que.Peek();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DequeueInEmptyQueue()
        {
            Queue<int> que = new Queue<int>();
            Assert.Throws<NullReferenceException>(() => que.Dequeue());
        }
        [Test]
        public void PeekInEmptyQueue()
        {
            Queue<int> deq = new Queue<int>();
            Assert.Throws<NullReferenceException>(() => deq.Peek());
        }
        [Test]
        public void CountNotEmptyTest()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int exp = 4;
            int res = que.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CountEmptyTest()
        {
            Queue<int> que = new Queue<int>();
            int exp = 0;
            int res = que.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void ClearQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            Queue<int> d = new Queue<int>();
            que.Clear();
            Assert.AreEqual(que, d);
        }
        [Test]
        public void ContainsInQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            bool exp = true;
            bool res = que.Contains(5);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void NotContainsInQueue()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            bool exp = false;
            bool res = que.Contains(9);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void QueueToArray()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int[] res = que.ToArray();
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void QueueCopyToNotNullArray()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int[] res = new int[que.Count];
            que.CopyTo(res, 0);
            int[] exp = new int[] { 5, 8, 1, 2 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void QueueCopyToNullArray()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int[] res = null;
            Assert.Throws<ArgumentNullException>(() => que.CopyTo(res, 0));
        }
        [Test]
        public void QueueForeach()
        {
            Queue<int> que = new Queue<int>();
            que.Enqueue(5);
            que.Enqueue(8);
            que.Enqueue(1);
            que.Enqueue(2);
            int res = 0;
            foreach (var item in que)
            {
                res++;
            }
            int exp = que.Count;
            Assert.AreEqual(exp, res);
        }
    }
}