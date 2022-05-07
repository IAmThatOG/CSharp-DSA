using System;

namespace LinkedList
{
    public class SinglyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Append to the list without tracking tail.<br/>
        /// takes O(n) 
        /// </summary>
        /// <param name="value">The data to append to the list</param>
        public void AppendWithoutTail(object value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                return;
            }
            var currentNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = new Node(value);
        }

        /// <summary>
        /// Append to the list with tail being tracked.<br/>
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="value">The data to append to the list</param>
        public void AppendWithTail(object value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                Tail = Head;
                return;
            }
            Tail.Next = new Node(value);
            Tail = Tail.Next;
        }

        /// <summary>
        /// Adds a new node to the start of the linked list as the head.<br/>
        ///Time Complexity: O(1)
        /// </summary>
        /// <param name="value">The data to prepend to the list</param>
        public void Prepend(object value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                Tail = Head;
                return;
            }
            var newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
        }

        /// <summary>
        /// Searches the LinkedList for a node with a specified value and returns that node if found
        /// </summary>
        /// <param name="value">The data to search for</param>
        /// <returns>found node with specified value</returns>
        public Node Search(object value)
        {
            var currentNode = Head;
            while (currentNode is not null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }
            return null;
        }

        /// <summary>
        /// Remove first occurrence of value.<br/>
        /// Time Complexity: O(n)
        /// </summary>
        /// <param name="value">The value to remove form the list</param>
        public void Remove(object value)
        {
            if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                return;
            }
            var previousNode = Head;
            var currentNode = Head.Next;
            while (currentNode is not null)
            {
                if (currentNode.Value.Equals(value))
                {
                    previousNode.Next = currentNode.Next;
                    return;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        /// <summary>
        /// Return the first node's value and remove it from the list.<br/>
        ///Time Complexity: O(n)
        /// </summary>
        /// <param name="value">the value to pop out of the list</param>
        /// <returns>the popped value</returns>
        public object Pop()
        {
            if (Head is not null)
            {
                var value = Head.Value;
                Head = Head.Next is not null ? Head.Next : null;
                return value;
            }
            return null;
        }

        /// <summary>
        /// Insert value at pos position in the list. If pos is larger than the
        ///length of the list, append to the end of the list.<br/>
        ///Time Complexity: O(n)
        /// </summary>
        /// <param name="value">The data to insert into the list</param>
        /// <param name="pos">The index at which the data should be inserted</param>
        public void Insert(object value, int pos)
        {
            var newNode = new Node(value);
            if (pos == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }
            Node previousNode = null;
            var currentNode = Head;
            var index = 0;
            while (currentNode is not null)
            {
                if (pos == index)
                {
                    newNode.Next = currentNode;
                    previousNode.Next = newNode;
                    return;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
                index += 1;
            }
            newNode.Next = currentNode;
            previousNode.Next = newNode;
        }

        /// <summary>
        /// Return the size or length of the linked list.<br/>
        ///Time Complexity: O(n)
        /// </summary>
        /// <returns>the number of nodes in the linked list</returns>
        public int GetSize()
        {
            var size = 0;
            var currentNode = Head;
            while (currentNode is not null)
            {
                size += 1;
                currentNode = currentNode.Next;
            }
            return size;
        }

        /// <summary>
        /// Traverse through the linked list.<br/>
        ///Time Complexity: O(n)
        /// </summary>
        public void Traverse()
        {
            var currentNode = Head;
            var output = string.Empty;
            while (currentNode != null)
            {
                output += $"{currentNode.Value}==>";
                currentNode = currentNode.Next;
            }
            Console.WriteLine($"output: {output}");
        }

        /// <summary>
        /// Reverse the inputted linked list<br/>
        ///Time Complexity: O(n)<br/>
        ///TTo Reverse a linked list, create a new empty linked list and iterate through the old linked list doing a prepend to the new linked list for each node
        /// </summary>
        /// <returns>The reversed linked list</returns>
        public SinglyLinkedList Reverse()
        {
            var newLinkedList = new SinglyLinkedList();
            var currentNode = Head;
            while (currentNode is not null)
            {
                var node = currentNode;
                node.Next = newLinkedList.Head;
                newLinkedList.Head = node;
                // newLinkedList.Prepend(currentNode.Value);
                currentNode = currentNode.Next;
            }
            return newLinkedList;
        }

        /// <summary>
        /// Reverse the inputted linked list<br/>
        ///Time Complexity: O(n)<br/>
        /// To convert a list into a reversed linked list, create a new empty linked list and iterate through the items of the old list doing a prepend to the new linked list for each node
        /// </summary>
        /// <param name="linkedList">the array to be converted to a reversed linked list</param>
        /// <returns>The reversed linked list</returns>
        public static SinglyLinkedList Reverse(object[] linkedList)
        {
            var newLinkedList = new SinglyLinkedList();
            foreach (var item in linkedList)
            {
                var node = new Node(item);
                node.Next = newLinkedList.Head;
                newLinkedList.Head = node;
            }
            return newLinkedList;
        }

        /// <summary>
        /// Determine whether the Linked List is circular or not
        /// Time Complexity: O(n)<br/>
        ///  To tell if a linked list is circular you need 2 pointers
        /// A slow pointer that moves one step through the list
        /// A fast pointer that moves two steps through the list<br/>
        /// if at any point on iteration both pointers are on the same node then it's circular
        /// </summary>
        /// <returns>True if circular, False if otherwise</returns>
        public bool isCircular()
        {
            var slow = Head;
            var fast = Head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast.Next == slow)
                {
                    return true;
                }
            }
            return false;
        }

        // public IEnumerator GetEnumerator()
        // {
        //     var currentNode = Head;
        //     while (currentNode is not null)
        //     {
        //         yield currentNode;
        //     }
        // }
    }
}