using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Algorithm_Implementation
{
    class Program
    {
        // Default folder    
        static readonly string rootFolder =  "C:/Desktop/";    
        //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE   
        static readonly string textFile = "C:/Users/Rehman Ali/Desktop/abc.txt";
        static readonly string compressedFile = "C:/Users/Rehman Ali/Desktop/abc.bin";
        static readonly string decompressedFile = "C:/Users/Rehman Ali/Desktop/abcd.txt";
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter the string:");
            string input = File.ReadAllText(textFile);
            HuffmanTree huffmanTree = new HuffmanTree();
            Console.WriteLine("File read Successfully\n");
            // Build the Huffman tree
            huffmanTree.Build(input);

            BitArray bit_array = huffmanTree.Encode(input);
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);
            File.WriteAllBytes(compressedFile, bytes);
            Console.Write("File encoded successfully\n");


            Console.WriteLine();
            // Decode
            byte[] b = File.ReadAllBytes(compressedFile);
            var bitarray=new BitArray (b);
            string decoded = huffmanTree.Decode(bitarray);
            File.WriteAllText(decompressedFile, decoded);
            Console.WriteLine("File Decoded Successfuly\n");
            Console.ReadLine();
        }
    }
}
