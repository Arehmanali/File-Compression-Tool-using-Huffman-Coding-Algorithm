# Compression OR Decompression Tool

## Introduction

To reduce the time needed for files to be transmitted over a network, Compression and Decompression techniques are very useful. Developers prefer to write code to compress files before sending them out to the network for a file upload process. Web applications get the most benefit out of it. The .NET Framework provides the System.IO.Compression namespace, which contains the compressing and decompressing libraries and streams. Developers can use these types to read and modify the contents of a compressed file.
## Huffman Coding Algorithm

Huffman coding is a lossless data compression algorithm. In this algorithm, a variable-length code is assigned to input different characters. The code length is related to how frequently characters are used. Most frequent characters have the smallest codes and longer codes for least frequent characters.
There are mainly two major parts in Huffman Coding
1) Build a Huffman Tree from input characters.
2) Traverse the Huffman Tree and assign codes to characters.

Huffman Coding prevents any ambiguity in the decoding process using the concept of prefix code ie. a code associated with a character should not be present in the prefix of any other code.

### Example

For an example, consider some strings “YYYZXXYYX”, the frequency of character Y is larger than X and the character Z has the least frequency. So the length of the code for Y is smaller than X, and code for X will be smaller than Z.
### Time Complexity

Complexity for assigning the code for each character according to their frequency is **O(n log n)

## Greedy Explanation
Huffman coding looks at the occurrence of each character and stores it as a binary string in an optimal way. The idea is to assign variable-length codes to input input characters, length of the assigned codes are based on the frequencies of corresponding characters. We create a binary tree and operate on it in bottom-up manner so that the least two frequent characters are as far as possible from the root. In this way, the most frequent character gets the smallest code and the least frequent character gets the largest code.
