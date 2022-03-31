using System;
using System.Collections;
using System.Collections.Generic;
namespace LinkedStructure
{
    //interface IQueue<T>:IEnumerable<T>
    //{
    //    int Count { get; }
    //    T Dequeue();
    //    void Enqueue(T value);
    //    T Peek();
    //}
    public class Queue<T>//:IQueue<T>
    {
        int count;
        public int Count { get => count; }

        Node<T> first;
        Node<T> last;

        public Queue()
        {

        }

        public Queue(IEnumerable<T> collection)
        {

        }

        public T Dequeue()
        {
            Node<T> temp = first;
            if (count == 1)
            {
                first = null;
                last = null;
                count--;
                return temp.Value;
            }
            if (count > 1)
            {
                first = first.next;
                temp.next = null;
                count--;
                return temp.Value;
            }
            else throw new Exception();
        }

        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);
            if (last == null)
            {
                first = node; last = node;
            } 
            else 
            { 
                last.next = node; last = node; 
            }
            count++;
        }

        public T Peek()
        {
            if (count != 0) return last.Value;
            else throw new Exception();
        }
    }
}
