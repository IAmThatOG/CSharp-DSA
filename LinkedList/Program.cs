using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var linkedList = new SinglyLinkedList();
            linkedList.AppendWithoutTail(2);
            linkedList.AppendWithoutTail(4);
            linkedList.AppendWithoutTail(6);
            linkedList.AppendWithoutTail(8);
            linkedList.AppendWithoutTail(4);
            linkedList.Traverse();
            var foundNode = linkedList.Search(4);
            Console.WriteLine(foundNode.ToString());
            linkedList.Remove(2);
            linkedList.Traverse();
            var valuePopped = linkedList.Pop();
            Console.WriteLine(valuePopped);

            linkedList.Insert(12, 12);
            linkedList.Traverse();
            var newlist = linkedList.Reverse();
            newlist.Traverse();
        }
    }
}
