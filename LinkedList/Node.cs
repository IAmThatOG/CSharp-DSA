using System;
using System.Text.Json;

namespace LinkedList
{
    public class Node
    {
        public object Value { get; set; }
        public Node Next { get; set; }

        public Node(object value)
        {
            Value = value;
            Next = null;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}