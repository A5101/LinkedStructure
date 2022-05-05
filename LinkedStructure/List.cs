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
        void AddRange(IEnumerable<T> collection);
        void CopyTo(T[] array, int index);
        void RemoveLast();
        T Delete(int pos);
        int IndexOf(T value);
        int LastIndexOf(T value);
        void Insert(T value, int pos);
        void Reverse();
        void Resize(int capacity);
        int Search(T findery);
        void Sort();
        T[] ToArray();
    }
    /// <summary>
    /// Представлет класс списка с доступом по индексу,
    /// поддерживающий операции вставки и удаления
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class List<T> : IList<T>, ILinkedStructure<T>
        where T:IComparable<T>
    {
        int capacity;
        /// <summary>
        /// Емкость коллекции
        /// </summary>
        public int Capacity => capacity;
        
        int count;
        /// <summary>
        /// Размер коллекции
        /// </summary>
        public int Count => count;

        T[] A;
        /// <summary>
        /// Инициализирует пустой экземпляр класса с емкостью по умолчанию
        /// </summary>
        public List()
        {
            count = 0;
            capacity = 4;
            A = new T[capacity];
        }
        /// <summary>
        /// Инициализирует пустой экземпляр класса с введенной емкостью
        /// </summary>
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
        /// <summary>
        /// Инициализирует экземпляр класса с элементами из данной коллекции
        /// </summary>
        public List(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            count = 0;
            capacity = 4;
            A = new T[capacity];
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Добавляет элемент в конец коллекции
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Insert(value, count);
        }
        /// <summary>
        /// Добавляет коллекцию в конец списка
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Insert(item, count);
            }
        }
        /// <summary>
        /// Очистка списка
        /// </summary>
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
        /// <summary>
        /// Проверка вхождения элемента в список
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) => IndexOf(value) != -1;
        /// <summary>
        /// Копирование списка в массив
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
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
        /// <summary>
        /// Удаление последнего элемента из списка
        /// </summary>
        /// <returns></returns>
        public void RemoveLast()
        {
            Delete(count - 1);
        }
        /// <summary>
        /// Удаление элемента из выбранной позиции
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Вставка элемента в конкретную позицию
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
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
        /// <summary>
        /// Нахождение индекса первого вхождения элемента
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(T value)
        {
            for (int index = 0; index < count; index++)
            {
                if (value.Equals(A[index]))
                    return index;
            }
            return -1;
        }
        /// <summary>
        /// Нахождение последнего индекса вхождения элемента
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int LastIndexOf(T value)
        {
            for (int index = count - 1; index >= 0; index--)
            {
                if (value.Equals(A[index]))
                    return index;
            }
            return -1;
        }
        /// <summary>
        /// Изменение емкости списка
        /// </summary>
        /// <param name="capacity"></param>
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
        /// <summary>
        /// Разворот списка в обратном порядке
        /// </summary>
        public void Reverse()
        {
            if (A == null) throw new NullReferenceException();
            for (int i = 0; i < count >> 1; i++)
            {
                T c = A[i];
                A[i] = A[count - i - 1];
                A[count - i - 1] = c;
            }
        }
        /// <summary>
        /// Доступ к элементам коллекции по индексу
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Преобразование коллекции в массив
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = A[i];
            }
            return array;
        }
        /// <summary>
        /// Поиск индекса вхождения элемента в отсортированном списке
        /// </summary>
        /// <param name="findery"></param>
        /// <returns></returns>
        public int Search(T findery)
        {
            int start = 0,
                end = count - 1,
                mid = (start + end) >> 1;
            while (A[mid].CompareTo(findery) != 0)
            {
                if (A[mid].CompareTo(findery) < 0)
                    start = mid + 1;
                else end = mid - 1;
                mid = (start + end) >> 1;
                if (mid < start || mid > end)
                {
                    mid = -1;
                    break;
                }
            }
            return mid;
        }
        /// <summary>
        /// Сортировка списка
        /// </summary>
        public void Sort()
        {
            if (count == 0) return;
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
        public void RemoveFirst()
        {
            Delete(0);
        }

        public void AddFirst(T value)
        {
            Insert(value, 0);
        }

        public void AddLast(T value)
        {
            Add(value);
        }
    }
}
