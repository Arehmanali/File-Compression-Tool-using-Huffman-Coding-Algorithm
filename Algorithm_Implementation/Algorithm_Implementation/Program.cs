    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Microsoft.Office.Interop.Word;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using GemBox.Document;
using System.Drawing;

namespace Algorithm_Implementation
    {
        class Program
        {
       
            // Default folder for read and write operations    
            static readonly string rootFolder =  "C:/Desktop/";    
            //Default files for compression and decompression
            static readonly string textFile = "C:/Users/Rehman Ali/Desktop/abc.txt";
            static readonly string docxFile = "C:/Users/Rehman Ali/Desktop/abc.docx";
            static readonly string pdfFile = "C:/Users/Rehman Ali/Desktop/abc.pdf";
            static readonly string BinaryFile = "C:/Users/Rehman Ali/Desktop/abc.bin";
            static readonly string decompressedFile = "C:/Users/Rehman Ali/Desktop/abcd.txt";
            static void Main(string[] args)
            {
            CompressDocxFile();
            CompressTextFile();
            CompressPdfFile();
            }

        static public void CompressTextFile()
        {
            //Read the text file in string variable
            string inputFile = File.ReadAllText(textFile);

            HuffmanTree huffmanTree = new HuffmanTree();

            Console.WriteLine("Text File Read Successfully\n");

            // Build the Huffman tree
            huffmanTree.Build_Tree(inputFile);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(inputFile);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(BinaryFile, bytes);
            Console.Write("Text File Encoded Successfully\n");
            Console.WriteLine();

            // Decode the bin file and write in txt file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(BinaryFile);
            var bitarray=new BitArray (bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in txt file
            File.WriteAllText(decompressedFile, decoded);
            Console.WriteLine("Text File Decoded Successfuly\n");
        }
        static public void CompressPdfFile()
        {
            string pdfString = GetTextFromPdfFile();
   
            HuffmanTree huffmanTree = new HuffmanTree();

            Console.WriteLine("Pdf File Read Successfully\n");

            // Build the Huffman tree
            huffmanTree.Build_Tree(pdfString);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(pdfString);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(BinaryFile, bytes);
            
            Console.Write("Pdf File Encoded Successfully\n");

            // Decode the bin file and write in pdf file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(BinaryFile);
            var bitarray = new BitArray(bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in pdf file
            iTextSharp.text.Document oDoc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(oDoc, new FileStream("C:/Users/Rehman Ali/Desktop/abcd.pdf", FileMode.Create));
            oDoc.Open();
            oDoc.Add(new iTextSharp.text.Paragraph(decoded));
            oDoc.Close();

            Console.WriteLine("Pdf File Decoded Successfuly\n");

        }

        static public string GetTextFromPdfFile()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(pdfFile))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

        static public string GetTextFromWordFile()
        {
            ComponentInfo.SetLicense("AKSJUY-9IUEY-2YUW7-HSGDT-6NHJY");

            // Load Word document from file's path.
            var document = DocumentModel.Load(docxFile);

            // Get Word document's plain text.
            string text = document.Content.ToString();
            return text;
        }


        static public void CompressDocxFile()
        {
            string docxString = GetTextFromWordFile();

            HuffmanTree huffmanTree = new HuffmanTree();

            Console.WriteLine("Docx File Read Successfully\n");

            // Build the Huffman tree
            huffmanTree.Build_Tree(docxString);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(docxString);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(BinaryFile, bytes);

            Console.Write("Docx File Encoded Successfully\n");

            // Decode the bin file and write in docx file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(BinaryFile);
            var bitarray = new BitArray(bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in docx file
            // Create new empty document.
            var document = new DocumentModel();

            // Add new section with two paragraphs, containing some text and symbols.
            document.Sections.Add(
                new GemBox.Document.Section(document,
                    new GemBox.Document.Paragraph(document,decoded)));

            // Save Word document to file's path.
            document.Save("C:/Users/Rehman Ali/Desktop/abcd.docx");
            Console.WriteLine("Docx File Decoded Successfuly\n");

        }
        
}
}
