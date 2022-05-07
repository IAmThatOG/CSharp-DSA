using System;
using System.Text.Json;

namespace Stacks
{
    public class ArrayStack
    {
        public object[] Arr { get; set; }
        public uint Size { get; set; }
        public uint NextIndex { get; set; }

        public ArrayStack(uint initialSize = 10)
        {
            Arr = new object[initialSize];
            Size = 0;
            NextIndex = 0;
        }

        /// <summary>
        /// Adds an item to the stack<br/>
        /// Time Complexity: O(n) - when the array limit is reached and needs increase
        /// </summary>
        /// <param name="value">the value to add to the stack</param>
        public void Push(object value)
        {
            if (Arr.Length == NextIndex)
            {
                Console.WriteLine("Index out of range! Increasing size...");
                IncreaseArrSize();
            }
            Arr[NextIndex] = value;
            Size++;
            NextIndex++;
        }

        public void IncreaseArrSize()
        {
            var oldArray = Arr;
            Arr = new object[Arr.Length * 2];
            for (int i = 0; i < oldArray.Length; i++)
            {
                Arr[i] = oldArray[i];
            }
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetches an item from the stack<br/>
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns>The item fetched</returns>
        public object Pop()
        {
            if (Arr.Length <= 0)
            {
                NextIndex = 0;
                Size = 0;
                return null;
            }
            var value = Arr[NextIndex];
            NextIndex -= 1;
            Size -= 1;
            return value;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}