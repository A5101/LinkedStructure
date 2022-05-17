using System;
namespace LinkedStructure
{
    public interface ILinkedStructure<T> : System.Collections.Generic.IEnumerable<T>
    {
        int Count { get; }
        Node<T> First { get; }
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index)
        {
            if (array == null) throw new ArgumentNullException();
            if (index < 0 || index > array.Length) throw new ArgumentOutOfRangeException();
            if (array.Length - index < Count) throw new ArgumentException();
            Node<T> node = First;
            if (node == null) return;
            do
            {
                array[index++] = node.Value;
                node = node.next;
            }
            while (node != null);
        }
        void AddFirst(T value);
        void AddLast(T value);
        void RemoveFirst();
        void RemoveLast();
        T[] ToArray();
    }
}
