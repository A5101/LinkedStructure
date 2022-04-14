using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface IDoublyLinkedList<T> : IEnumerable<T>
    {
        Node<T> First { get; }
        Node<T> Last { get; }
        int Count { get; }
        void AddAfter(Node<T> node, T value);
        void AddAfter(Node<T> node, Node<T> new_node);
        void AddBefore(Node<T> node, T value);
        void AddBefore(Node<T> node, Node<T> new_node);
        void AddFirst(T value);
        void AddFirst(Node<T> new_node);
        void AddLast(T value);
        void AddLast(Node<T> new_node);
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        Node<T> Find(T value);
        Node<T> FindLast(T value);
        bool Remove(T value);
        //void Remove(Node<T> node);
        void RemoveFirst();
        void RemoveLast();
        T[] ToArray();
    }
    public class DoublyLinkedList<T>:IDoublyLinkedList<T>
    {
        Node<T> first;
        public Node<T> First => first;

        Node<T> last;
        public Node<T> Last => last;

        int count = 0;
        public int Count => count;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddAfter(Node<T> node, T value)
        {
            Node<T> new_node = new Node<T>(value);
            InternalInsertAfter(node, new_node);
        }

        public void AddAfter(Node<T> node, Node<T> new_node)
        {
            InternalInsertAfter(node, new_node);
        }

        public void AddBefore(Node<T> node, T value)
        {
            Node<T> new_node = new Node<T>(value);
            InternalInsertBefore(node, new_node);
        }

        public void AddBefore(Node<T> node, Node<T> new_node)
        {
            InternalInsertBefore(node, new_node);
        }

        public void AddFirst(T value)
        {
            Node<T> new_node = new Node<T>(value);
            if (first != null)
            {
                InternalInsertBefore(first, new_node);
            }
            else
            {
                InternalInsertInEmptyList(new_node);
            }
        }

        public void AddFirst(Node<T> new_node)
        {
            if (first != null)
            {
                InternalInsertBefore(first, new_node);
            }
            else
            {
                InternalInsertInEmptyList(new_node);
            }
        }

        public void AddLast(T value)
        {
            Node<T> new_node = new Node<T>(value);
            if (last != null)
            {
                InternalInsertAfter(last, new_node);
            }
            else
            {
                InternalInsertInEmptyList(new_node);
            }
        }

        public void AddLast(Node<T> new_node)
        {
            if (last != null)
            {
                InternalInsertAfter(last, new_node);
            }
            else
            {
                InternalInsertInEmptyList(new_node);
            }
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

        public bool Contains(T value) => Find(value) != null;

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

        public Node<T> FindLast(T value)
        {
            Node<T> node = last;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node.previous != null))
                    {
                        node = node.previous;
                        if (node.previous == null) return null;
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
            if (node == last)
            {
                node.next = new_node;
                new_node.previous = node;
                last = new_node;
            }
            else
            {
                new_node.next = node.next;
                node.next.previous = new_node;
                node.next = new_node;
                new_node.previous = node;
            }
            ++count;
        }

        void InternalInsertBefore(Node<T> node, Node<T> new_node)
        {
            if (node == first) 
            {
                node.previous = new_node;
                new_node.next = node;
                first = new_node;
            }
            else
            {
                new_node.next = node;
                new_node.previous = node.previous;
                node.previous.next = new_node;
                node.previous = new_node;
            }
            ++count;
        }

        void InternalRemoveNode(Node<T> node)
        {
            if (count == 1) { first = null; last = null; }
            else
            {
                if ((node.next == null) || (node.previous == null))
                {
                    if (node.next == null) node.previous.next = node.next;
                    else node.next.previous = node.previous;
                }
                else
                {
                    node.previous.next = node.next;
                    node.next.previous = node.previous;
                }
            }
            node.Annul();
            --count;
        }

        public bool Remove(T value)
        {
            var node = Find(value);
            if (node != null)
            {
                InternalRemoveNode(Find(value));
                return true;
            }
            else return false;
        }

        //public void Remove(Node<T> node)
        //{
        //    InternalRemoveNode(node);
        //}

        public void RemoveFirst()
        {
            if (first == null) throw new Exception();
            Node<T> node = first.next;
            InternalRemoveNode(first);
            first = node;
        }

        public void RemoveLast()
        {
            if (last == null) throw new Exception();
            Node<T> node = last.previous;
            InternalRemoveNode(last);
            last = node;
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
