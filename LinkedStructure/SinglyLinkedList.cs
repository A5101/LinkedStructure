using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedStructure
{
    interface ISinglyLinkedList<T> : IEnumerable<T>
    {
        Node<T> First { get; }
        Node<T> Last { get; }
        int Count { get; }
        void Add(T value);
        void Add(Node<T> node);
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        Node<T> Find(T value);
        bool Remove(T value);
        T[] ToArray();
    }
    /// <summary>
    /// Представляет класс односвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>: ISinglyLinkedList<T>, ILinkedStructure<T>
    {
        Node<T> first;
        /// <summary>
        /// Получение первого элемента списка
        /// </summary>
        public Node<T> First => first;

        Node<T> last;
        /// <summary>
        /// Получение последнего элемента списка
        /// </summary>
        public Node<T> Last => last;

        int count;
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count => count;
        /// <summary>
        /// Инициализирует пустой экземпляр списка
        /// </summary>
        public SinglyLinkedList()
        {

        }
        /// <summary>
        /// Инициализирует список со значениями из заданной коллекции
        /// </summary>
        /// <param name="collection"></param>
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);
            if (first == null) InternalInsertInEmptyList(node);
            else InternalInsertAfter(last, node);
        }
        /// <summary>
        /// Добавление узла в конец списка
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            if (first == null) InternalInsertInEmptyList(node);
            else InternalInsertAfter(last, node);
        }
        /// <summary>
        /// Очистка списка
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
        /// Проверка вхождения элемента в список
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value) => Find(value) != null;
        /// <summary>
        /// Копирование элементов списка в заданный массив
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
        /// Возврат узла с заданным значением
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> Find(T value)
        {
            Node<T> node = first;
            if (node != null)
            {
                if (value != null)
                {
                    while (!node.Value.Equals(value) && (node != null))
                    {
                        node = node.next;
                        if (node == null) return null;
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
            node.next = new_node;
            last = new_node;
            ++count;
        }
        /// <summary>
        /// Удаление узла списка с заданным значением
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            Node<T> current = first;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                        if (current.next == null)
                            last = previous;
                    }
                    else
                    {
                        first = first.next;
                        if (first == null)
                            last = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }
        /// <summary>
        /// Возврат коллекции элементов списка в виде массива
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> node = first;
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

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> node = first;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }

        public void AddFirst(T value)
        {
            if (first == null) InternalInsertInEmptyList(new Node<T>(value));
            else 
            {
                Node<T> temp = first;
                Node<T> temp1 = new Node<T>(value);
                first = temp1;
                temp1.next = temp;
                count++;
            }
        }

        public void AddLast(T value)
        {
            Add(value);
        }

        public void RemoveFirst()
        {
            if (first == null) return;
            else { first = first.next; count--; }
        }

        public void RemoveLast()
        {
            Node<T> temp = first;
            for (int i = 0; i < count - 1; i++)
            {
                temp = temp.next;
            }
            temp.next = null;
            last = temp;
        }
    }
}
