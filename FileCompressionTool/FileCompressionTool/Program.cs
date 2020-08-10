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
using System.Threading.Tasks;
using System.Windows.Forms;
using FileCompressionTool;

namespace Algorithm_Implementation
{
    class Program
    {
        static public HuffmanTree huffmanTree = new HuffmanTree();
        static string message = "";

        [STAThread]

        static void Main(string[] args)
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }

        static public void CompressTextFile(string filePath,string binFilePath,string codingSchemePath)
        {
            //Read the text file in string variable
            string inputFile = File.ReadAllText(filePath);

            // Build the Huffman tree
            huffmanTree.Build_Tree(inputFile);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(inputFile);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(binFilePath, bytes);
            message = "Text File Encoded Successfully";
            Form1.showMessage(message);

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < bit_array.Count; i++)
            {
                char bitChar = bit_array[i] ? '1' : '0';
                stringBuilder.Append(bitChar);
            }
            var stringBuilder2 = stringBuilder.ToString();
            File.WriteAllText(codingSchemePath, stringBuilder2);
            message = "Coding Scheme File Created Successfully";
            Form1.showMessage(message);

        }
        static public void CompressPdfFile(string filePath, string binFilePath,string codingSchemePath)
        {
            
            string pdfString = GetTextFromPdfFile(filePath);
            
            // Build the Huffman tree
            huffmanTree.Build_Tree(pdfString);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(pdfString);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(binFilePath, bytes);

            message="Pdf File Encoded Successfully";
            Form1.showMessage(message);

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < bit_array.Count; i++)
            {
                char bitChar = bit_array[i] ? '1' : '0';
                stringBuilder.Append(bitChar);
            }
            var stringBuilder2 = stringBuilder.ToString();
            File.WriteAllText(codingSchemePath, stringBuilder2);
            message = "Coding Scheme File Created Successfully";
            Form1.showMessage(message);

        }

        static public void ExtractTextFile(string binFilePath,string extractFilePath)
        {
           
            // Decode the bin file and write in txt file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(binFilePath);
            var bitarray = new BitArray(bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in txt file
            File.WriteAllText(extractFilePath, decoded);

            message = "Text File Decoded Successfuly";
            Form1.showMessage(message);

        }

        static public void ExtractPdfFile(string binFilePath,string extractFilePath)
        {
           
            // Decode the bin file and write in pdf file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(binFilePath);
            var bitarray = new BitArray(bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in pdf file
            iTextSharp.text.Document oDoc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(oDoc, new FileStream(extractFilePath, FileMode.Create));
            oDoc.Open();
            oDoc.Add(new iTextSharp.text.Paragraph(decoded));
            oDoc.Close();

            message = "Pdf File Decoded Successfuly";
            Form1.showMessage(message);
        }

        static public void ExtractDocxFile(string binFilePath,string extractFilePath)
        {
            
            ComponentInfo.SetLicense("AKSJUY-9IUEY-2YUW7-HSGDT-6NHJY");
            // Decode the bin file and write in docx file
            // read all the bytes from binary file
            byte[] bytes2 = File.ReadAllBytes(binFilePath);
            var bitarray = new BitArray(bytes2);

            // decode the huffman tree
            string decoded = huffmanTree.Decode(bitarray);

            // write the decoded file in docx file
            // Create new empty document.
            var document = new DocumentModel();

            // Add new section with two paragraphs, containing some text and symbols.
            document.Sections.Add(
                new GemBox.Document.Section(document,
                    new GemBox.Document.Paragraph(document, decoded)));

            // Save Word document to file's path.
            document.Save(extractFilePath);
            message = "Docx File Decoded Successfuly";
            Form1.showMessage(message);
        }

        static public string GetTextFromPdfFile(string filePath)
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(filePath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
        }

        static public string GetTextFromWordFile(string filePath)
        {
            ComponentInfo.SetLicense("AKSJUY-9IUEY-2YUW7-HSGDT-6NHJY");

            // Load Word document from file's path.
            var document = DocumentModel.Load(filePath);

            // Get Word document's plain text.
            string text = document.Content.ToString();
            return text;
        }


        static public void CompressDocxFile(string filePath, string binFilePath,string codingSchemePath)
        {
            string docxString = GetTextFromWordFile(filePath);

            // Build the Huffman tree
            huffmanTree.Build_Tree(docxString);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(docxString);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(binFilePath, bytes);

            message="Docx File Encoded Successfully";
            Form1.showMessage(message);

            // Creating the coding scheme file
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < bit_array.Count; i++)
            {
                char bitChar = bit_array[i] ? '1' : '0';
                stringBuilder.Append(bitChar);
            }
            var stringBuilder2 = stringBuilder.ToString();
            File.WriteAllText(codingSchemePath, stringBuilder2);
            message = "Coding Scheme File Created Successfully";
            Form1.showMessage(message);
        }

    }
}
