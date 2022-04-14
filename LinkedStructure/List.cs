using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface IList<T> : IEnumerable<T>
    {
        int Capacity { get; }
        int Count { get; }
        bool Contains(T value);
        void Add(T value);
        void CopyTo(T[] array, int index);
        T DeleteLast();
        T Delete(int pos);
        int IndexOf(T value);
        int LastIndexOf(T value);
        void Insert(T value, int pos);
        void Resize(int capacity);
        void Sort();
        T[] ToArray();
    }
    public class List<T> : IList<T>
        where T:IComparable<T>
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

        public List(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            Insert(value, count);
        }

        public void Clear()
        {
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    A[i] = default;
                }
                count = 0;
            }
        }

        public bool Contains(T value) => IndexOf(value) != -1;

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException();
            if (array.Length - index < count)
                throw new ArgumentException();
            for (int i = 0; i < count; i++)
            {
                array[index + i] = A[i];
            }
        }

        public T DeleteLast()
        {
            return Delete(count - 1);
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

        public int IndexOf(T value)
        {
            for (int index = 0; index < count; index++)
            {
                if (value.Equals(A[index]))
                    return index;
            }
            return -1;
        }

        public int LastIndexOf(T value)
        {
            for (int index = count - 1; index >= 0; index--)
            {
                if (value.Equals(A[index]))
                    return index;
            }
            return -1;
        }

        public void Resize(int capacity)
        {
            T[] temp = new T[capacity];
            for (int i = 0; i < count; i++)
            {
                temp[i] = A[i];
            }
            A = temp;
            this.capacity = capacity;
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

        public T[] ToArray()
        {
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = A[i];
            }
            return array;
        }

        public void Sort()
        {
            if (count == 0) throw new Exception();
            else Sort(0, count - 1);
        }

        void Sort(int low, int high)
        {
            int i = low;   
            int j = high;   
            T x = A[(low + high) >> 1];    
            do
            {
                while (A[i].CompareTo(x) < 0) ++i;   
                while (A[j].CompareTo(x) > 0) --j;
                if (i <= j)  
                {
                    T temp = A[i];   
                    A[i] = A[j];
                    A[j] = temp;
                    i++;
                    j--;
                }
            } while (i < j);
            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return A[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return A.GetEnumerator();
        }
    }
}
