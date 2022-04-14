using NUnit.Framework;
using System;
using LinkedStructure;
namespace LinkedTests
{
    public class StackTests
    {
        [Test]
        public void PopInNotEmptyDeque()
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
        public void PeekInNotEmptyDeque()
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
        public void PopFrontInEmptyDeque()
        {
            Stack<int> stack = new Stack<int>();
            Assert.Throws<NullReferenceException>(() => stack.Pop());
        }
        [Test]
        public void PeekInEmptyDeque()
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
    }
}