namespace TreeOfNnodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Task1Tree<T> where T : IComparable<T>
    {
        internal Task1Tree()
        {
            this.Childs = new List<Node<T>>();
            this.Size = 0;
        }

        internal List<Node<T>> Childs { get; set; }

        internal int Size { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Childs.Count; i++)
            {
                this.TraverseNode(this.Childs[i], result.ToString());
            }

            return result.ToString();
        }

        internal void Add(Node<T> node)
        {
            this.Size++;
            this.Childs.Add(node);
        }

        internal Node<T> Find(T value)
        {
            Node<T> searchedNode = null;
            for (int i = 0; i < this.Childs.Count; i++)
            {
                searchedNode = this.Find(this.Childs[i], value);
                if (searchedNode != null)
                {
                    return searchedNode;
                }
            }

            return null;
        }

        internal bool Contains(T value)
        {
            if (this.Childs.Count == 0)
            {
                return false;
            }

            bool isFounded = false;
            for (int i = 0; i < this.Childs.Count; i++)
            {
                isFounded = this.Contains(this.Childs[i], value);
                if (isFounded)
                {
                    return isFounded;
                }
            }

            return false;
        }

        internal void RemoveTreeNode(Node<T> theNodeToRemove)
        {
            theNodeToRemove.HasParent = false;
            this.Childs.Remove(theNodeToRemove);
        }

        internal int TheLongestPathInTheTree()
        {
            return this.GetTheLongestPath(this.Childs[0], 0, 0);
        }

        internal List<Node<T>> GetAllLeafs()
        {
            return this.GetAllLeafs(this.Childs[0], new List<Node<T>>());
        }

        internal List<Node<T>> GetAllMiddleLeafs()
        {
            return this.GetAllMiddleLeafs(this.Childs[0], new List<Node<T>>());
        }

        private List<Node<T>> GetAllMiddleLeafs(Node<T> startNode, List<Node<T>> listToFill)
        {
            if (startNode.ChildrenCount != 0 && startNode.HasParent)
            {
                listToFill.Add(startNode);
            }

            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                listToFill = this.GetAllMiddleLeafs(startNode.GetChildAtIndex(i), listToFill);
            }

            return listToFill;
        }

        private List<Node<T>> GetAllLeafs(Node<T> startNode, List<Node<T>> listToFill)
        {
            if (startNode.ChildrenCount == 0)
            {
                listToFill.Add(startNode);
                return listToFill;
            }

            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                listToFill = this.GetAllLeafs(startNode.GetChildAtIndex(i), listToFill);
            }

            return listToFill;
        }

        private int GetTheLongestPath(Node<T> root, int maxLevel, int currentLevel)
        {
            if (maxLevel < currentLevel)
            {
                maxLevel = currentLevel;
            }

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                maxLevel = this.GetTheLongestPath(root.GetChildAtIndex(i), maxLevel, currentLevel + 1);
            }

            return maxLevel;
        }

        private bool Contains(Node<T> startNode, T value)
        {
            if ((dynamic)startNode.Value == (dynamic)value)
            {
                return true;
            }

            bool isFound = false;
            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                isFound = this.Contains(startNode.GetChildAtIndex(i), value);
                if (isFound)
                {
                    return isFound;
                }
            }

            return false;
        }

        private void TraverseNode(Node<T> startNode, string result)
        {
            if (startNode == null)
            {
                return;
            }

            Console.WriteLine(result + startNode.Value);

            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                this.TraverseNode(startNode.GetChildAtIndex(i), result + "  ");
            }
        }

        private Node<T> Find(Node<T> startNode, T value)
        {
            if ((dynamic)startNode.Value == (dynamic)value)
            {
                return startNode;
            }

            Node<T> theserachValue = null;
            for (int i = 0; i < startNode.ChildrenCount; i++)
            {
                theserachValue = this.Find(startNode.GetChildAtIndex(i), value);
                if (theserachValue != null)
                {
                    return theserachValue;
                }
            }

            return null;
        }
    }
}
