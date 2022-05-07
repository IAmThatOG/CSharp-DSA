namespace Stacks
{
    public class Node
    {
        public object Value { get; set; }
        public Node Next { get; set; }

        public Node(object Value)
        {
            Value = Value;
        }
    }
    public class StackWithLinkedList
    {
        private Node _head;
        private int _size;

        public StackWithLinkedList()
        {
            _head = null;
            _size = 0;
        }

        /// <summary>
        /// Push an item to the stack
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="item">The item to add to the stack</param>
        public void Push(object item)
        {
            var newNode = new Node(item);
            if (_size == 0)
            {
                _head = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
            _size += 1;
        }

        /// <summary>
        /// Pop an item from the stack
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns>The item to remove from the stack</returns>
        public object Pop()
        {
            if (_head == null)
            {
                return null;
            }
            var item = _head.Value;
            _head = _head.Next;
            _size -= 1;
            return item;
        }

        public int GetSize() => _size;

        public bool IsEmpty() => _size <= 0;
    }
}