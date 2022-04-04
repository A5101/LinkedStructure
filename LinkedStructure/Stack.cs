using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        T Pop();
        T Peek();
        void Push(T value);
    }
    public class Stack<T>:IStack<T>
    {
        int count;
        public int Count { get => count;}
        Node<T> Head { get; set; }
        public Stack()
        {

        }

        public Stack(IEnumerable<T> collection)
        {

        }

        public T Pop()
        {
            if (Head != null)
            {
                Node<T> temp = Head;
                Head = Head.next;
                count--;
                return temp.Value;
            }
            else throw new Exception();
        }

        public T Peek()
        {
            if (Head != null) return Head.Value;
            else throw new Exception();
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.next = Head;
            Head = node;
            count++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> node = Head;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }
}