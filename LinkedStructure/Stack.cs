using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        T Pop();
        T Peek();
        void Push(T value);
        T[] ToArray();
    }
    public class Stack<T>:IStack<T>
    {
        int count = 0;
        public int Count { get => count;}
        Node<T> head;
        public Stack()
        {

        }

        public Stack(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public void Clear()
        {
            Node<T> node1 = head;
            while (node1 != null)
            {
                Node<T> node2 = node1;
                node1 = node1.next;
                node2.Annul();
            }
            head = null;
            count = 0;
        }

        public bool Contains(T value)
        {
            Node<T> node = head;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node != null))
                    {
                        node = node.next;
                        if (node == null) return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException();
            if (array.Length - index < Count)
                throw new ArgumentException();
            Node<T> node = head;
            if (node == null)
                return;
            do
            {
                array[index++] = node.Value;
                node = node.next;
            }
            while (node != null);
        }

        public T Pop()
        {
            if (head != null)
            {
                Node<T> temp = head;
                head = head.next;
                count--;
                return temp.Value;
            }
            else throw new NullReferenceException();
        }

        public T Peek()
        {
            if (head != null) return head.Value;
            else throw new NullReferenceException();
        }

        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.next = head;
            head = node;
            count++;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = head;
            for (int i = 0; i < count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }
            return array;
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
            Node<T> node = head;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }
}