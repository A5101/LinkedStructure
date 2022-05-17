namespace LinkedStructure
{
    public class Node<T>
    {
        public T Value;
        internal Node<T> next;
        public Node<T> Next => next;
        internal Node<T> previous;
        public Node<T> Previous => previous;
        public Node(T value) => Value = value;
        internal void Annul()
        {
            next = null;
            previous = null;
        }
    }
}
