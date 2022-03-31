﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStructure
{
    //interface IList<T>:IEnumerable<T>
    //{
    //    int Capacity { get; }
    //    int Count { get; }
    //    void Add(T value);
    //    T Delete();
    //    T Delete(int pos);
    //    void Insert(T value, int pos);
    //    void Resize(int capacity);
    //}
    public class List<T>//:IList<T>
    {
        int capacity;
        public int Capacity { get => capacity; }

        int count;
        public int Count { get => count; }

        T[] A;

        public List()
        {
            count = 0;
            capacity = 4;
            A = new T[capacity];
        }
        public List(int capacity)
        {
            if (capacity < 0) throw new Exception();
            else
            {
                this.capacity = capacity;
                A = new T[capacity];
                count = capacity;
            }
        }

        public void Add(T value)
        {
            Insert(value, count);
        }

        public T DeleteLast()
        {
            return Delete(count-1);
        }

        public T Delete(int pos)
        {
            if (pos >= 0 && pos < count)
            {
                if (pos == count - 1)
                {
                    count--;
                    return A[pos];
                }
                else
                {
                    T c = A[pos];
                    for (int i = pos; i < count; i++)
                    {
                        A[i] = A[i + 1];
                    }
                    count--;
                    return c;
                }
            }
            throw new Exception();
        }

        public void Insert(T value, int pos)
        {
            if (pos >= 0 && pos <= count)
            {
                if (count >= capacity)
                {
                    capacity <<= 1;
                    Resize(capacity);
                }
                if (pos == count)
                {
                    A[count] = value;
                    count++;
                }
                else
                {
                    for (int i = count - 1; i >= pos; i--)
                        A[i + 1] = A[i];
                    A[pos] = value;
                    count++;
                }
            }
            else throw new Exception();
        }

        public void Resize(int capacity)
        {
            T[] temp = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                temp[i] = A[i];
            }
            A = temp;
        }

        public T this[int pos]
        {
            get 
            {
                if (pos >= 0 && pos < count)
                    return A[pos];
                else throw new Exception();
            }
            set
            {
                if (pos >= 0 && pos < count)
                    A[pos] = value;
                else throw new Exception();
            }
        }
    }
}
