using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Implementation
{
    public class Node
    {
        public char character { get; set; }
        public int frequency { get; set; }
        public Node rightNode { get; set; }
        public Node leftNode { get; set; }

        public List<bool> Traverse_Tree(char symbol, List<bool> data)
        {
            // Leaf
            if (rightNode == null && leftNode == null)
            {
                if (symbol.Equals(this.character))
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> left = null;
                List<bool> right = null;

                if (leftNode != null)
                {
                    List<bool> leftPath = new List<bool>();
                    leftPath.AddRange(data);
                    leftPath.Add(false);

                    left = leftNode.Traverse_Tree(symbol, leftPath);
                }

                if (rightNode != null)
                {
                    List<bool> rightPath = new List<bool>();
                    rightPath.AddRange(data);
                    rightPath.Add(true);
                    right = rightNode.Traverse_Tree(symbol, rightPath);
                }

                if (left != null)
                {
                    return left;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}

