namespace TreeOfNnodes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Node<T>
    {
        private T value;
        private bool hasParent;
        private List<Node<T>> children;

        public Node(T value)
        {
            if (value == null)
            {
                throw new ArgumentException("Argument cannot be null!");
            }

            this.Value = value;
            this.children = new List<Node<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }

            set
            {
                this.hasParent = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void Add(Node<T> nodeChild)
        {
            if (nodeChild == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            if (nodeChild.hasParent)
            {
                throw new ArgumentException(
                    "The node already has a parent!");
            }

            nodeChild.HasParent = true;
            this.children.Add(nodeChild);
        }

        public Node<T> GetChildAtIndex(int index)
        {
            return this.children[index];
        }

        public void RemoveAt(int index)
        {
            this.children.RemoveAt(index);
        }
    }
}
