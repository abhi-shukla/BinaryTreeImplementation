using System;

namespace BinaryTreeImplementation
{
    public class BTNode<TNode> : IComparable<TNode>
        where TNode : IComparable<TNode>
    {
        public BTNode(TNode value)
        {
            Value = value;
        }

        public BTNode<TNode> Left { get; set; }
        public BTNode<TNode> Right { get; set; }

        public TNode Value { get; set; }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
