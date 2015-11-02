namespace TreeOfNnodes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Tree<T>
    {
        private Node<T> root;
        private int size;

        public Tree(T value)
        {
            this.Root = new Node<T>(value);
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                this.Root.Add(child.Root);
            }
        }

        public Node<T> Root
        {
            get
            {
                return this.root;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(
                        "Cannot insert null value!");
                }

                this.root = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public void TraverseDfs()
        {
            this.TraverseDfs(this.Root, string.Empty);
        }

        public void AttachTo(T parentValue, T childValue)
        {
            Node<T> theNode = null;
            if (!this.Contains(parentValue))
            {
                theNode = this.Find(this.Root, childValue);
                this.Root = new Node<T>(parentValue);
                this.Root.Add(theNode);
            }
            else if (this.Contains(childValue))
            {
                this.AttachExistValue(this.Root, new Node<T>(parentValue), childValue);
            }
            else
            {
                this.AttachTo(this.Root, parentValue, childValue);
            }
        }

        public bool Contains(T value)
        {
            return this.Contains(this.Root, value);
        }

        private Node<T> Find(Node<T> startNode, T value)
        {
            if ((dynamic)startNode.Value == (dynamic)value)
            {
                startNode.HasParent = false;
                return startNode;
            }

            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                startNode = this.Find(startNode.GetChildAtIndex(i), value);
            }

            return startNode;
        }

        private bool Contains(Node<T> startFrom, T value)
        {
            bool isFound = false;
            if ((dynamic)startFrom.Value == (dynamic)value)
            {
                return true;
            }

            Node<T> currentNode = null;
            for (int i = 0; i < startFrom.ChildrenCount; i++)
            {
                currentNode = startFrom.GetChildAtIndex(i);
                isFound = this.Contains(currentNode, value);

                if (isFound)
                {
                    return isFound;
                }
            }

            return isFound;
        }

        private void TraverseDfs(Node<T> root, string spaces)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine("{1}{0}", root.Value, spaces);

            Node<T> currentNode = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                currentNode = root.GetChildAtIndex(i);
                this.TraverseDfs(currentNode, spaces + "   ");
            }
        }

        private void AttachExistValue(Node<T> startNode, Node<T> parentNode, T childValue)
        {
            if ((dynamic)startNode.Value == (dynamic)parentNode.Value)
            {
                parentNode = startNode;
            }

            Node<T> currenNode = null;
            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                currenNode = startNode.GetChildAtIndex(i);
                if ((dynamic)currenNode.Value == (dynamic)childValue)
                {
                    parentNode.Add(currenNode);
                    startNode.RemoveAt(i);
                    return;
                }
            }

            this.AttachExistValue(currenNode, parentNode, childValue);
        }

        private void AttachTo(Node<T> startNode, T parentNodeValue, T childValue)
        {
            if ((dynamic)startNode.Value == (dynamic)parentNodeValue)
            {
                startNode.Add(new Node<T>(childValue));
                return;
            }

            Node<T> currenNode = null;
            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                currenNode = startNode.GetChildAtIndex(i);
                this.AttachTo(currenNode, parentNodeValue, childValue);
            }
        }
    }
}
