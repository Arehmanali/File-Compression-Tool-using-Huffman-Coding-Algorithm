# Huffman's Coding

## Compression Technique
The technique works by creating a binary tree of nodes. These can stored in a regular array, the size of which depends on the number of symbols, n.
A node can either be a leaf node or an internal node. Initially all nodes are leaf nodes, which contain the symbol itself, its frequency and optionally,
a link to its child nodes. As a convention, bit '0' represents left child and bit '1' represents right child. Priority queue is used to store the
nodes, which provides the node with lowest frequency when popped.

## Pseudocode
Huffman_Compression(C):     // C is the set of n characters and related information
n = C.size
Q = priority_queue()
for i = 1 to n
    n = node(C[i])
    Q.push(n)
while Q.size() is not equal to 1
    Z = new node()
    Z.left = x = Q.pop
    Z.right = y = Q.pop
    Z.frequency = x.frequency + y.frequency
    Q.push(Z)
Return Q

## Decompression Technique
The process of decompression is simply a matter of translating the stream of prefix codes to individual byte value, usually by traversing the Huffman
tree node by node as each bit is read from the input stream. Reaching a leaf node necessarily terminates the search for that particular byte value. 
The leaf value represents the desired character. Usually the Huffman Tree is constructed using statistically adjusted data on each compression 
cycle, thus the reconstruction is fairly simple. Otherwise, the information to reconstruct the tree must be sent separately.

## Pseudocode
Huffman_Decompression(root, S):            // root represents the root of Huffman Tree
n = S.length                              // S refers to bit-stream to be decompressed
for i = 1 to n
    current = root
    while current.left != NULL and current.right != NULL
        if S[i] is equal to '0'
            current = current.left
        else
            current = current.right
        i = i+1
    print current.symbol
