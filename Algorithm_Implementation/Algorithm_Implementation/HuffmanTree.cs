
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace Algorithm_Implementation
{
    public class HuffmanTree
    {
        private List<Node> node = new List<Node>();
        public Node rootNode { get; set; }
        public Dictionary<char, int> frequency = new Dictionary<char, int>();


        // build the huffman tree of the input file
        public void Build_Tree(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                // check the tree contains character or not
                if (!frequency.ContainsKey(input[i]))
                {
                    // add the character in tree
                    frequency.Add(input[i], 0);             
                }

                frequency[input[i]]++;
            }

            foreach (KeyValuePair<char, int> symbol in frequency)
            {
                node.Add(new Node() { character = symbol.Key, frequency = symbol.Value });
            }

            while (node.Count > 1)
            {
                // ordering the nodes on the basis of frequency
                List<Node> orderedNodes = node.OrderBy(node => node.frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // Take first two items
                    List<Node> takenNode = orderedNodes.Take(2).ToList<Node>();

                    // Create a parent node by combining the frequencies
                    Node parent = new Node()
                    {
                        character = '*',
                        frequency = takenNode[0].frequency + takenNode[1].frequency,
                        leftNode = takenNode[0],
                        rightNode = takenNode[1]
                    };

                    node.Remove(takenNode[0]);
                    node.Remove(takenNode[1]);
                    node.Add(parent);
                }

                this.rootNode = node.FirstOrDefault();

            }

        }

        // Encode function for encoding the characters in binary form
        public BitArray Encode(string input)
        {
            List<bool> encodedInput = new List<bool>();

            for (int i = 0; i < input.Length; i++)
            {
                List<bool> encodedCharacter = this.rootNode.Traverse_Tree(input[i], new List<bool>());
                encodedInput.AddRange(encodedCharacter);
            }

            BitArray BitArray = new BitArray(encodedInput.ToArray());

            return BitArray;
        }

        public string Decode(BitArray BitArray)
        {
            Node currentNode = this.rootNode;
            string decoded = "";

            foreach (bool bit in BitArray)
            {
                if (bit)
                {
                    if (currentNode.rightNode != null)
                    {
                        currentNode = currentNode.rightNode;
                    }
                }
                else
                {
                    if (currentNode.leftNode != null)
                    {
                        currentNode = currentNode.leftNode;
                    }
                }

                if (IsLeaf(currentNode))
                {
                    decoded += currentNode.character;
                    currentNode = this.rootNode;
                }
            }

            return decoded;
        }

        public bool IsLeaf(Node node)
        {
 
            return (node.leftNode == null && node.rightNode == null);
       
        }
    }
}
