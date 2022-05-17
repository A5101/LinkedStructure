﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    public class Deque<T> : ILinkedStructure<T>
    {
        int count = 0;
        public int Count { get => count; }
        Node<T> first;
        Node<T> last;
        public Deque()
        {

        }
        public Deque(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection) PushBack(item);
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
        public bool Contains(T value)
        {
            Node<T> node = first;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node != null))
                    {
                        node = node.next;
                        if (node == null) return false;
                    } return true;
                }
            } return false;
        }
        public void CopyTo(T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (index < 0 || index > array.Length) throw new ArgumentOutOfRangeException();
            if (array.Length - index < count) throw new ArgumentException();
            Node<T> node = first;
            if (node == null) return;
            do
            {
                array[index++] = node.Value;
                node = node.next;
            } while (node != null);
        }
        public void PushFront(T value)
        {
            Node<T> node = new Node<T>(value);
            node.next = first;
            if (first == null)
            {
                first = node; last = node;
            } else
            {
                first.previous = node; first = node;
            } count++;
        }
        public void PushBack(T value)
        {
            Node<T> node = new Node<T>(value);
            node.previous = last;
            if (last == null)
            {
                first = node; last = node;
            } else
            {
                last.next = node; last = node;
            } count++;
        }
        public T PopFront()
        {
            Node<T> temp = first;
            if (count > 1)
            {
                first = temp.next;
                first.previous = null;
                temp.next = null;
                count--;
                return temp.Value;
            }
            if (count == 1)
            {
                first = null;
                last = null;
                count--;
                return temp.Value;
            } else throw new NullReferenceException();
        }
        public T PopBack()
        {
            Node<T> temp = last;
            if (count > 1)
            {
                last = temp.previous;
                last.next = null;
                temp.previous = null;
                count--;
                return temp.Value;
            }
            if (count == 1)
            {
                first = null;
                last = null;
                count--;
                return temp.Value;
            }  else throw new NullReferenceException();
        }
        public T PeekFront()
        {
            if (count != 0) return first.Value;
            else throw new NullReferenceException();
        }
        public T PeekBack()
        {
            if (count != 0) return last.Value;
            else throw new NullReferenceException();
        }
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = first;
            for (int i = 0; i < count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            } return array;
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
        public void AddFirst(T value) { PushFront(value); }
        public void AddLast(T value) { PushBack(value); }
        public void RemoveFirst() { PopFront(); }
        public void RemoveLast() { PopBack(); }
    }
}