namespace LinkedStructure
{
    public interface ILinkedStructure<T>:System.Collections.Generic.IEnumerable<T>
    {
        int Count { get; }
        void Clear();
        bool Contains(T value);
        void CopyTo(T[] array, int index);
        void AddFirst(T value);
        void AddLast(T value);
        void RemoveFirst();
        void RemoveLast();
        T[] ToArray();
    }
}
