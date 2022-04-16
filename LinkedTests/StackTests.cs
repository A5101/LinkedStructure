using NUnit.Framework;
using System;
using LinkedStructure;
namespace LinkedTests
{
    public class StackTests
    {
        [Test]
        public void PopInNotEmptyStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int exp = 2;
            int res = stack.Pop();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PeekInNotEmptyStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int exp = 2;
            int res = stack.Peek();
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void PopFrontInEmptyStack()
        {
            Stack<int> stack = new Stack<int>();
            Assert.Throws<NullReferenceException>(() => stack.Pop());
        }
        [Test]
        public void PeekInEmptyStack()
        {
            Stack<int> stack = new Stack<int>();
            Assert.Throws<NullReferenceException>(() => stack.Peek());
        }
        [Test]
        public void CountNotEmptyTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int exp = 4;
            int res = stack.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void CountEmptyTest()
        {
            Stack<int> stack = new Stack<int>();
            int exp = 0;
            int res = stack.Count;
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void ClearStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            Stack<int> d = new Stack<int>();
            stack.Clear();
            Assert.AreEqual(stack, d);
        }
        [Test]
        public void ContainsInStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            bool exp = true;
            bool res = stack.Contains(1);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void NotContainsInStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            bool exp = false;
            bool res = stack.Contains(9);
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void StackToArray()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int[] res = stack.ToArray();
            int[] exp = new int[] { 2, 1, 8, 5 };
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void StackCopyToNotNullArray()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int[] res = new int[stack.Count];
            stack.CopyTo(res, 0);
            int[] exp = new int[] { 2, 1, 8, 5};
            Assert.AreEqual(exp, res);
        }
        [Test]
        public void StackCopyToNullArray()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int[] res = null;
            Assert.Throws<ArgumentNullException>(() => stack.CopyTo(res, 0));
        }
        [Test]
        public void StackForeach()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);
            stack.Push(1);
            stack.Push(2);
            int res = 0;
            foreach (var item in stack)
            {
                res++;
            }
            int exp = stack.Count;
            Assert.AreEqual(exp, res);
        }
    }
}