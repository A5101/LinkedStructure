using System;
using LinkedStructure;

namespace LinkedApp
{
    class Program
    {
        static void Main()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<int>> qq = new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
            qq.Add(new System.Collections.Generic.List<int> { 5, 5, 7 });
            qq.Add(new System.Collections.Generic.List<int> { 8, 9, 7 });
            qq.Sort();
            Console.WriteLine(string.Join(" ", qq));


            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.Add(7);
            list.Add(new Node<int>(5));
            list.Add(8);
            list.Add(10);
            Console.WriteLine(list.First.Value);
            list.Remove(7);
            Console.WriteLine(list.First.Value);
            foreach (var item in list)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Stack<int> stack = new Stack<int>();
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Count);
            foreach (var item in stack)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Queue<int> q = new Queue<int>();
            q.Enqueue(7);
            q.Enqueue(8);
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Count);
            foreach (var item in q)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            List<int> l = new List<int>();
            l.Add(7);
            l.Add(8);
            l.Insert(9, 2);
            l.Add(12);
            l.Add(54);
            Console.WriteLine(l[2]);
            Console.WriteLine(l.Capacity);
            l.Resize(128);
            Console.WriteLine(l.Capacity);
            l.Delete(0);
            l.DeleteLast();
            l.Add(1);
            Console.WriteLine(l.Count);
            foreach (var item in l)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.WriteLine();
            

            DoublyLinkedList<int> list1 = new DoublyLinkedList<int>();
            list1.AddFirst(5);
            list1.AddFirst(6);
            list1.AddLast(3);
            Console.WriteLine(list1.Last.Value);
            list1.RemoveLast();
            Console.WriteLine(list1.Last.Value);
            Node<int> node = new Node<int>(10);
            list1.AddLast(node);
            list1.AddAfter(node, 7);
            Console.WriteLine(list1.Last.Value);
            foreach (var item in list1)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Deque<int> deq = new Deque<int>();
            deq.PushBack(7);
            deq.PushBack(8);
            deq.PushFront(1);
            deq.PushFront(5);
            Console.WriteLine(deq.PeekBack());
            deq.PopBack();
            Console.WriteLine(deq.PeekBack());
            Console.WriteLine(deq.Count);
            foreach (var item in deq)
            {
                Console.Write(item.Value + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
