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
        public void DequeueInEmptyDeque()
        {
            Queue<int> que = new Queue<int>();
            Assert.Throws<NullReferenceException>(() => que.Dequeue());
        }
        [Test]
        public void PeekInEmptyDeque()
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
    }
}