using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedStructure;

namespace LinkedApp
{
    class Program
    {
        static void Main()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int> (new int[] { 5, 7, 9, 8, 3 });
            list.Remove(7);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.Value);
            //}
            LinkedList<int> list1 = new LinkedList<int>();
            list1.AddLast(5);
            list1.AddLast(6);
            list1.Remove(7);
        }
    }
}
