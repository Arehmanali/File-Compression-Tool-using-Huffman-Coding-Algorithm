# Compression OR Decompression Tool

## Introduction

To reduce the time needed for files to be transmitted over a network, Compression and Decompression techniques are very useful. Developers prefer to write code to compress files before sending them out to the network for a file upload process. Web applications get the most benefit out of it. The .NET Framework provides the System.IO.Compression namespace, which contains the compressing and decompressing libraries and streams. Developers can use these types to read and modify the contents of a compressed file.
## Huffman Coding Algorithm

Huffman coding is a lossless data compression algorithm. In this algorithm, a variable-length code is assigned to input different characters. The code length is related to how frequently characters are used. Most frequent characters have the smallest codes and longer codes for least frequent characters.

There are mainly **two** parts. First one to create a Huffman tree, and another one to traverse the tree to find codes.
### Example

For an example, consider some strings “YYYZXXYYX”, the frequency of character Y is larger than X and the character Z has the least frequency. So the length of the code for Y is smaller than X, and code for X will be smaller than Z.
### Time Complexity

Complexity for assigning the code for each character according to their frequency is **O(n log n)
