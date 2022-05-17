using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    public class SinglyLinkedList<T> : ILinkedStructure<T>
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
            foreach (var item in collection) Add(item);
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
            if (array == null) throw new ArgumentNullException();
            if (index < 0 || index > array.Length) throw new ArgumentOutOfRangeException();
            if (array.Length - index < Count) throw new ArgumentException();
            Node<T> node = first;
            if (node == null) return;
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
                    while (!node.Value.Equals(value) && (node != null))
                    {
                        node = node.next;
                        if (node == null) return null;
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
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = first;
            while (node != null)
            {
                yield return node.Value;
                node = node.next;
            }
        }
        public void AddFirst(T value)
        {
            if (first == null) InternalInsertInEmptyList(new Node<T>(value));
            else
            {
                Node<T> temp = first;
                Node<T> temp1 = new Node<T>(value);
                first = temp1;
                temp1.next = temp;
                count++;
            }
        }
        public void AddLast(T value) { Add(value); }
        public void RemoveFirst()
        {
            if (first == null) return;
            else { first = first.next; count--; }
        }
        public void RemoveLast()
        {
            Node<T> temp = first;
            for (int i = 0; i < count - 2; i++)
            {
                temp = temp.next;
            }
            temp.next = null;
            last = temp;
            count--;
        }
    }
}
