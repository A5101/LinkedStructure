using System;
using System.Collections.Generic;

namespace LinkedStructure
{
    //interface IDequeue<T> : IEnumerable<T>
    //{
    //    int Count { get; }
    //    void PushFront(T value);
    //    void PushBack(T value);
    //    T PeekFront();
    //    T PeekBack();
    //    T PopFront();
    //    T PopBack();
    //}
    public class Deque<T>//:IDequeue<T>
    {
        int count = 0;
        public int Count { get => count; }

        Node<T> first;
        Node<T> last;
        public Deque()
        {

        }

        //public Deque(IEnumerable<T> collection)
        //{

        //}

        public void PushFront(T value)
        {
            Node<T> node = new Node<T>(value);
            node.next = first;
            if (first == null)
            {
                first = node; last = node;
            }
            else
            {
                first.previous = node; first = node;
            }
            count++;
        }

        public void PushBack(T value)
        {
            Node<T> node = new Node<T>(value);
            node.previous = last;
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
            }    
            else throw new NullReferenceException(); 
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
            }
            else throw new NullReferenceException();
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
    }
}
