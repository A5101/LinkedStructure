using System;
using System.Collections;
using System.Collections.Generic;
namespace LinkedStructure
{
    interface IQueue<T> : IEnumerable<T>
    {
        int Count { get; }
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        T Dequeue();
        void Enqueue(T value);
        T Peek();
        T[] ToArray();
    }
    /// <summary>
    /// Представляет класс очереди
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>:IQueue<T>
    {
        int count = 0;
        /// <summary>
        /// Количество элементов в очереди
        /// </summary>
        public int Count { get => count; }

        Node<T> first;
        Node<T> last;
        /// <summary>
        /// Инициализирует пустой экземпляр класса
        /// </summary>
        public Queue()
        {

        }
        /// <summary>
        /// Инициализирует экземпляр класса с элементами из заданной коллекции
        /// </summary>
        /// <param name="collection"></param>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }
        /// <summary>
        /// Очистка очереди
        /// </summary>
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
        /// <summary>
        /// Проверка вхождения элемента в очередь
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
                    }
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Копирование коллекции элементов очереди в заданный массив
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
        /// <summary>
        /// Получение первого элемента очереди с последующим его удалением из очереди
        /// </summary>
        /// <returns></returns>
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
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Добавление элемента в конец очереди
        /// </summary>
        /// <param name="value"></param>
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
        /// <summary>
        /// Получение первого элемента очерреди без его удаления
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (count != 0) return first.Value;
            else throw new NullReferenceException();
        }
        /// <summary>
        /// Возврат коллекции элементов очереди в виде массива
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = first;
            for (int i = 0; i < count; i++)
            {
                array[i] = node.Value;
                node = node.next;
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
