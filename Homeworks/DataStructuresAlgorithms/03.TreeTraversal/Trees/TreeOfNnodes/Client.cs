namespace TreeOfNnodes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Write a program to read the tree and find:
    ///     ○ the root node
    ///     ○ all leaf nodes
    ///     ○ all middle nodes
    ///     ○ the longest path in the tree
    ///     ¤ all paths in the tree with given sum `S` of their nodes
    ///     ¤ all subtrees with given sum `S` of their nodes
    /// </summary>
    public class Client
    {
        public static void Main()
        {
            Task1Tree<int> nodes = new Task1Tree<int>();
            StringReader reader = new StringReader(GlobalConstants.Input);

            int nodePairsCount = 0;
            string firstLine = reader.ReadLine();
            if (!int.TryParse(firstLine, out nodePairsCount))
            {
                throw new ArgumentException("Input is not valid");
            }

            for (int i = 0; i < nodePairsCount - 1; i++)
            {
                string[] line = reader.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                int parentValue = int.Parse(line[0]);
                int childValue = int.Parse(line[1]);

                if (!nodes.Contains(parentValue) && !nodes.Contains(childValue))
                {
                    var theNewNode = new Node<int>(parentValue);
                    theNewNode.Add(new Node<int>(childValue));
                    nodes.Add(theNewNode);
                }
                else if (!nodes.Contains(parentValue) && nodes.Contains(childValue))
                {
                    var theNode = new Node<int>(parentValue);
                    var theNodeToAdd = nodes.Find(childValue);
                    nodes.RemoveTreeNode(theNodeToAdd);
                    theNode.Add(theNodeToAdd);
                    nodes.Add(theNode);
                }
                else if (nodes.Contains(parentValue) && !nodes.Contains(childValue))
                {
                    var theNode = nodes.Find(parentValue);
                    theNode.Add(new Node<int>(childValue));
                }
                else
                {
                    var theParentNode = nodes.Find(parentValue);
                    var theChildNode = nodes.Find(childValue);
                    nodes.RemoveTreeNode(theChildNode);
                    theParentNode.Add(theChildNode);
                }
            }

            Console.WriteLine(nodes.ToString());
            Console.WriteLine("Root: " + nodes.Childs[0].Value);
            var leafs = nodes.GetAllLeafs().Select(x => x.Value).ToList();
            Console.WriteLine("Leafs: {0}", string.Join(", ", leafs));
            Console.WriteLine("Max level: {0}*", nodes.TheLongestPathInTheTree());

            //// What means 'all middle nodes' in the current context? - Node that has parent and at least one child.
            var middleNodes = nodes.GetAllMiddleLeafs().Select(x => x.Value).ToList();
            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("* Consider that start level begins from 0.");
            Console.ResetColor();
        }
    }
}
