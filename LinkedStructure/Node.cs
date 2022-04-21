using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStructure
{/// <summary>
/// Представлет класс узла
/// </summary>
/// <typeparam name="T"></typeparam>
    public class Node<T>
    {/// <summary>
    /// Значение узла
    /// </summary>
        public T Value;
        internal Node<T> next;
        /// <summary>
        /// Возвращает ссылку на следующий узел
        /// </summary>
        public Node<T> Next => next;
        internal Node<T> previous;
        /// <summary>
        /// Возвращает ссылку на предвдущий узел
        /// </summary>
        public Node<T> Previous => previous;
        /// <summary>
        /// Инициализирует узел с заданным значением
        /// </summary>
        /// <param name="value"></param>
        public Node(T value) => Value = value;
        internal void Annul()
        {
            next = null;
            previous = null;
        }
    }
}
