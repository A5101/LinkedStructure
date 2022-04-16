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
        [Test]
        public void ClearDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            Deque<int> d = new Deque<int>();
            deq.Clear();
            Assert.AreEqual(deq, d);
        }
        [Test]
        public void ContainsInDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            bool exp = true;
            bool res = deq.Contains(8);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void NotContainsInDeque()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            bool exp = false;
            bool res = deq.Contains(9);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DequeToArray()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int[] res = deq.ToArray();
            int[] exp = new int[] { 2, 1, 5, 8 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DequeCopyToNotNullArray()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int[] res = new int[deq.Count];
            deq.CopyTo(res, 0);
            int[] exp = new int[] { 2, 1, 5, 8 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void DequeCopyToNullArray()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int[] res = null;
            Assert.Throws<ArgumentNullException>(() => deq.CopyTo(res, 0));
        }
        [Test]
        public void DequeForeach()
        {
            Deque<int> deq = new Deque<int>();
            deq.PushBack(5);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(2);
            int res = 0;
            foreach (var item in deq)
            {
                res++;
            }
            int exp = deq.Count;
            Assert.AreEqual(exp, res);
        }
    }
}