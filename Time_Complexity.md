# Time Complexity of Algorithm
<pre>
Huffman_Compression(C)
n = C.size()							        	                O(1)
Q = priority_queue() 							                O(n)
For i = 1 to n							                      	O(n)
     n = node(C[i]) 							                 O(n-1)
     Q.push(n)							                       O(n-1)
while Q.size() is not equal to 1 						     O(n)
     Z = new node() 							                      O(n-1)
     Z.left = x = Q.pop						                    O(n-1)
     Z.right = y = Q.pop					                   	O(n-1)
     Z.frequency = x.frequency + y.frequency				 O(n-1)
     Q.push(Z)							                            O(n-1)
Return Q


Huffman_Decompression(root, S) 
n = S.length 									                          O(1)
for i = 1 to n 								                        	O(n)
    current = root 								                     O(n-1)
    while current.left != NULL and current.right != NULL 		       	O(n-1)
    if S[i] is equal to '0' 						                                 O(n-1)
       current = current.left 					                                O(n-1)
    else 
       current = current.right					                                O(n-1)
    i = i+1 									                                              O(n-1)
    print current.symbol                                           O(n-1)
</pre>


Although linear-time given sortinput, in general cases of arbitrary input, using this algorithm requires pre-sorting. Thus, since sorting takes O(nlogn) time in general cases, both methods have same complexity. Since n here is the number of symbols in the alphabet, which is typically very small number (compared to the length of the message to be encoded), time complexity is not very important in the choice of this algorithm.
