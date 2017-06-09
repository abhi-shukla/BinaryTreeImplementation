using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeImplementation
{
    public class BTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public BTNode<T> _head;
        public int Count;

        public void Add(T value)
        {
            if(_head == null)
            {
                _head = new BTNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            Count++;
        }

        private void AddTo(BTNode<T> node, T value)
        {
            if(value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    node.Left = new BTNode<T>(value);
                }
                else
                {
                    AddTo(node, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new BTNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            BTNode<T> parent = null;
            return FindWithParent(value, out parent) != null;
        }

        private BTNode<T> FindWithParent(T value, out BTNode<T> parent)
        {
            BTNode<T> current = _head;
            parent = null;

            while(current != null)
            {
                var compareResult = current.CompareTo(value);

                if(compareResult > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if(compareResult < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public bool Remove(T value)
        {
            BTNode<T> current, parent;

            current = FindWithParent(value, out parent);

            if(current == null)
            {
                return false;
            }

            Count--;

            if(current.Right == null)
            {
                if(parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int res = parent.CompareTo(current.Value);
                    if(res > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if(res < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
