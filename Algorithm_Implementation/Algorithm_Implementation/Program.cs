using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Office.Interop.Word;

using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

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

            /* Read the text file in string variable
            string inputFile = File.ReadAllText(textFile);

            HuffmanTree huffmanTree = new HuffmanTree();

            Console.WriteLine("File read Successfully\n");

            // Build the Huffman tree
            huffmanTree.Build_Tree(inputFile);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(inputFile);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(BinaryFile, bytes);
            Console.Write("File encoded successfully\n");
            Console.WriteLine();

            // Decode the bin file and write in txt file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(BinaryFile);
            var bitarray=new BitArray (bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in txt file
            File.WriteAllText(decompressedFile, decoded);
            Console.WriteLine("File Decoded Successfuly\n");*/

            string wordString = GetTextFromWord();
            Console.WriteLine(wordString);
            Console.ReadLine();
               
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

        static public string GetTextFromWord()
        {
            StringBuilder text = new StringBuilder();
            Application word = new Application();
            object miss = System.Reflection.Missing.Value;
            object path = docxFile;
            object readOnly = true;
            Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

            for (int i = 0; i < docs.Paragraphs.Count; i++)
            {
                text.Append(" \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString());
            }

            return text.ToString();
        }

        // for word file compression
        static void wordfile()
        {
            /*Application application = new Application();
            Document document = application.Documents.Open(docxFile);

            // Loop through all words in the document.
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                string text = document.Words[i].Text;
                
            }
            Console.WriteLine(document);
            // Close word.
            application.Quit();


            /*
            DocX doc = DocX.Load(docxFile);
            string text = DocX.Create(docxFile);
            TextExtractor extractor = new TextExtractor(docxFile);
            string text = extractor.ExtractText(); //The string 'text' is now loaded with the text from the Word Document
            Console.WriteLine(text);


            HuffmanTree huffmanTree = new HuffmanTree();

            /* Console.WriteLine("File read Successfully\n");

             // Build the Huffman tree
             huffmanTree.Build_Tree(file1);

         // Encode the input file in BitArray in binary form
         BitArray bit_array = huffmanTree.Encode(inputFile);

         // Byte array for storing the bits from BitArray to save in bin file
         byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
         bit_array.CopyTo(bytes, 0);

         // write all the bits from byte array in bin file
         File.WriteAllBytes(BinaryFile, bytes);
         Console.Write("File encoded successfully\n");
         Console.WriteLine();

         // Decode the bin file and write in txt file
         // read all the bytes from binary file
         byte[] bytes2 = File.ReadAllBytes(BinaryFile);
         var bitarray = new BitArray(bytes2);

         // decode the huffman tree
         string decoded = huffmanTree.Decode(bitarray);

         // write the decoded file in txt file
         File.WriteAllText(decompressedFile, decoded);
         Console.WriteLine("File Decoded Successfuly\n");
         Console.ReadLine();



         Application word = new Application();

         Microsoft.Office.Interop.Word.ApplicationClass wordApp = new ApplicationClass();

         object file = "C:/Users/Rehman Ali/Desktop/abc.docx";

         object missed = System.Reflection.Missing.Value;

         Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref file, ref missed, ref missed,

                                               ref missed, ref missed, ref missed,

                                               ref missed, ref missed, ref missed,

                                               ref missed, ref missed, ref missed);

         doc.ActiveWindow.Selection.WholeStory();

         doc.ActiveWindow.Selection.Copy();

         object Clipboard = null;
         IDataObject data = Clipboard.GetDataObject();
         object txtFileContent = null;
         txtFileContent.Text = data.GetData(DataFormats.Text).ToString();

         doc.Close();*/
        }

    }
    }
