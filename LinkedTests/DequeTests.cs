using System;
using NUnit.Framework;
using LinkedStructure;
namespace LinkedTests
{
    public class DequeueTests
    {
        [Test]
        public void PopFrontInNotEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int exp = 2;
            int res = deq.PopFront();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PopBackInNotEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int exp = 8;
            int res = deq.PopBack();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PeekFrontInNotEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int exp = 2;
            int res = deq.PeekFront();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PeekBackInNotEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int exp = 8;
            int res = deq.PeekBack();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PopFrontInEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            Assert.Throws<NullReferenceException>(() => deq.PopFront());
        }
        [Test]
        public void PopBackInEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            Assert.Throws<NullReferenceException>(() => deq.PopBack());
        }
        [Test]
        public void PeekFrontInEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            Assert.Throws<NullReferenceException>(() => deq.PeekFront());
        }
        [Test]
        public void PeekBackInEmptyDeque()
        {
            Deque<int> deq = new Deque<int>();
            Assert.Throws<NullReferenceException>(() => deq.PeekBack());
        }
        [Test]
        public void CountNotEmptyTest()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int exp = 4;
            int res = deq.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CountEmptyTest()
        {
            Deque<int> deq = new Deque<int>();
            int exp = 0;
            int res = deq.Count;
            Assert.AreEqual(exp, res);
        }
    }
}