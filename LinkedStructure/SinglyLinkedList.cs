using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface ISinglyLinkedList<T> : IEnumerable<T>
    {
        Node<T> First { get; }
        Node<T> Last { get; }
        int Count { get; }
        void Add(T value);
        void Add(Node<T> node);
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        Node<T> Find(T value);
        bool Remove(T value);
        T[] ToArray();
    }
    public class SinglyLinkedList<T>: ISinglyLinkedList<T>
    {
        Node<T> first;
        public Node<T> First => first;

        Node<T> last;
        public Node<T> Last => last;

        int count;
        public int Count => count;

        public SinglyLinkedList()
        {

        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (first == null) InternalInsertInEmptyList(node);
            else InternalInsertAfter(last, node);
        }

        public void Add(Node<T> node)
        {
            if (first == null) InternalInsertInEmptyList(node);
            else InternalInsertAfter(last, node);
        }

        public void Clear()
        {
            Node<T> node1 = first;
            while (node1 != null)
            {
                Node<T> node2 = node1;
                node1 = node1.next;
                node2.Annul();
            }
            first = null;
            count = 0;
        }

        public bool Contains(T value) => Find(value) != null;

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException();
            if (array.Length - index < Count)
                throw new ArgumentException();
            Node<T> node = first;
            if (node == null)
                return;
            do
            {
                array[index++] = node.Value;
                node = node.next;
            }
            while (node != null);
        }

        public Node<T> Find(T value)
        {
            Node<T> node = first;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node.next != null))
                    {
                        node = node.next;
                        if (node.next == null) return null;
                    }
                    return node;
                }
            }
            return null;
        }

        void InternalInsertInEmptyList(Node<T> node)
        {
            first = node;
            last = node;
            ++count;
        }

        void InternalInsertAfter(Node<T> node, Node<T> new_node)
        {
            node.next = new_node;
            last = new_node;
            ++count;
        }

        public bool Remove(T value)
        {
            Node<T> current = first;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                        if (current.next == null)
                            last = previous;
                    }
                    else
                    {
                        first = first.next;
                        if (first == null)
                            last = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = first;
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
            Node<T> node = first;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }
}
