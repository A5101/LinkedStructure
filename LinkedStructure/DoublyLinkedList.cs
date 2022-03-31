﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    //interface IDoublyLinkedList<T> : IEnumerable<T>
    //{
    //    Node<T> First { get; set; }
    //    Node<T> Last { get; set; }
    //    int Count { get; }
    //    void AddAfter(Node<T> node, T value);
    //    void AddAfter(Node<T> node, Node<T> new_node);
    //    void AddBefore(Node<T> node, T value);
    //    void AddBefore(Node<T> node, Node<T> new_node);
    //    void AddFirst(T value);
    //    void AddFirst(Node<T> new_node);
    //    void AddLast(T value);
    //    void AddLast(Node<T> new_node);
    //    void Remove(T value);
    //    void Remove(Node<T> node);
    //    void RemoveFirst();
    //    void RemoveLast();
    //}
    public class DoublyLinkedList<T>//:IDoublyLinkedList<T>
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

        //public DoublyLinkedList(IEnumerable<T> collection)
        //{
        //    if (collection == null) throw new ArgumentNullException();
        //    foreach (var item in collection)
        //    {
        //        AddLast(item);
        //    }
        //}

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

        //public void Clear()
        //{
        //    Node<T> node1 = first;
        //    while (node1 != null)
        //    {
        //        Node<T> node2 = node1;
        //        node1 = node1.next;
        //        node2.Annul();
        //    }
        //    first = null;
        //    count = 0;
        //}

        //public bool Contains(T value) => Find(value) != null;

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

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    return (IEnumerator<T>)GetEnumerator();
        //}

        //public IEnumerator<Node<T>> GetEnumerator()
        //{
        //    Node<T> node = first;
        //    while (node != null)
        //    {
        //        yield return node;
        //        node = node.next;
        //    }
        //}
    }
}
