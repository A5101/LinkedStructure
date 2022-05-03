using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface IStack<T> : IEnumerable<T>
    {
        int Count { get; }
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        T Pop();
        T Peek();
        void Push(T value);
        T[] ToArray();
    }
    /// <summary>
    /// Представляет класс стека
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>:IStack<T>, ILinkedStructure<T>
    {
        int count = 0;
        /// <summary>
        /// Количество элементов в стеке
        /// </summary>
        public int Count { get => count;}
        Node<T> head;
        /// <summary>
        /// Инициализирует пустой экземпляр стека
        /// </summary>
        public Stack()
        {

        }
        /// <summary>
        /// Инициализирует экземпляр стека с элементами их заданной коллекции
        /// </summary>
        /// <param name="collection"></param>
        public Stack(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Push(item);
            }
        }
        /// <summary>
        /// Очистка стека
        /// </summary>
        public void Clear()
        {
            Node<T> node1 = head;
            while (node1 != null)
            {
                Node<T> node2 = node1;
                node1 = node1.next;
                node2.Annul();
            }
            head = null;
            count = 0;
        }
        /// <summary>
        /// Проверка вхожления элемента в стек
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            Node<T> node = head;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node != null))
                    {
                        node = node.next;
                        if (node == null) return false;
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Копирование коллекции элементов стека в заданный массив
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(T[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException();
            if (array.Length - index < Count)
                throw new ArgumentException();
            Node<T> node = head;
            if (node == null)
                return;
            do
            {
                array[index++] = node.Value;
                node = node.next;
            }
            while (node != null);
        }
        /// <summary>
        /// Получение вершины стека с ее последующим удалением
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (head != null)
            {
                Node<T> temp = head;
                head = head.next;
                count--;
                return temp.Value;
            }
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Получение веришыны стека без ее удаления
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (head != null) return head.Value;
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Добавление элемента в стек
        /// </summary>
        /// <param name="value"></param>
        public void Push(T value)
        {
            Node<T> node = new Node<T>(value);
            node.next = head;
            head = node;
            count++;
        }
        /// <summary>
        /// Возврат элементов стека в виде массива
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = head;
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

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.next;
            }
        }

        public void AddFirst(T value)
        {
            Push(value);
        }

        public void AddLast(T value)
        {
            return;
        }

        public void RemoveFirst()
        {
            Pop();
        }

        public void RemoveLast()
        {
            return;
        }
    }
}