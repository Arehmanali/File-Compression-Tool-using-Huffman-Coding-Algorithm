using Algorithm_Implementation;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCompressionTool
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string filePath = openFileDialog2.FileName;         // save the path of file from open dialogue box into string variable
            string binPath = filePath; path of file 
            string codingSchemePath = filePath;
            
            // Remove the existing extension of input file and change it intp _codingScheme.txt
            int index = codingSchemePath.IndexOf(".");
            if (index > 0)
            {
                codingSchemePath = codingSchemePath.Substring(0, index);
            }
            codingSchemePath = codingSchemePath + "_codingScheme.txt";

            index = binPath.IndexOf(".");
            if (index > 0)
            {
                binPath = binPath.Substring(0, index);
            }
            binPath = binPath + ".bin";
            textBox1.Text = filePath;
            textBox2.Text = binPath;
            
            // Get the extension of input file
            string extension = Path.GetExtension(filePath);
            if (extension == ".docx")
            {
                // call the function CompressDocxFile for compressing the .docx file using given .bn file
                Program.CompressDocxFile(filePath, binPath,codingSchemePath);

            }
            else if (extension == ".txt")
            {
                // Call the function to compress the text file
                Program.CompressTextFile(filePath, binPath,codingSchemePath);
            }
            else if (extension == ".pdf")
            {
                // Call the function to compress the pdf file
                Program.CompressPdfFile(filePath, binPath,codingSchemePath);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "C:";    // open the C drive as default
            openFileDialog2.Title = "Open File";
            openFileDialog2.FileName = " ";
            openFileDialog2.Filter = "All Files (*.*)|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                textBox1.Text = openFileDialog2.FileName;
            }

        }

        static public void showMessage(string message)
        {
            MessageBox.Show(message);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
                string filePath = openFileDialog1.FileName;
                string binPath = filePath;
                string ExtractPath = filePath;
                
                // remove the extension of file and add new extension _extracted.txt
                int index = ExtractPath.IndexOf(".");
                if (index > 0)
                {
                    ExtractPath = ExtractPath.Substring(0, index);
                }
                ExtractPath = ExtractPath + "_extracted.txt";
                textBox4.Text = ExtractPath;
                textBox3.Text = filePath;
                Program.ExtractTextFile(binPath, ExtractPath);

                //ExtractPath = ExtractPath + ".txt";
                //textBox1.Text = binPath;
                //textBox2.Text = ExtractPath;

            


            /* Displays a SaveFileDialog so the user can save the File
            // assigned to extractButton.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:Users/Rehman Ali/Desktop";
            saveFileDialog1.Title = "Save File";
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            //saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text File|*.txt|Pdf File|*.pdf|Word File|*.docx";
            //saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            filePath = saveFileDialog1.FileName;

            string ExtractPath = filePath;
            int index = ExtractPath.IndexOf(".");
            if (index > 0)
            {
                ExtractPath = ExtractPath.Substring(0, index);
            }
            textBox2.Text = ExtractPath;
            textBox1.Text = filePath;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            ExtractPath = ExtractPath + ".txt";
                            textBox2.Text = ExtractPath;
                            textBox1.Text = filePath;
                            Program.ExtractTextFile(binPath, ExtractPath);
                            break;

                        case 2:
                            ExtractPath = ExtractPath + ".pdf";
                            textBox2.Text = ExtractPath;
                            textBox1.Text = filePath;
                            Program.ExtractPdfFile(binPath, ExtractPath);
                            break;

                        case 3:
                            ExtractPath = ExtractPath + ".docx";
                            textBox2.Text = ExtractPath;
                            textBox1.Text = filePath;
                            Program.ExtractDocxFile(binPath, ExtractPath);
                            break;
                    }
                }
            }*/
        }
    

    private void button3_Click(object sender, EventArgs e)
    {
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Browse File";
            openFileDialog1.FileName = " ";
            openFileDialog1.DefaultExt = "bin";
            // brows only for the files that have .bin extension
            openFileDialog1.Filter = "Only Binary File (*.bin*)|*.bin*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                string filePath = openFileDialog1.FileName;
                string binPath = filePath;
                string ExtractPath = filePath;
                
                // change the extension of file to _extracted.pdf
                int index = ExtractPath.IndexOf(".");
                if (index > 0)
                {
                    ExtractPath = ExtractPath.Substring(0, index);
                }
                ExtractPath = ExtractPath + "_extracted.pdf";
                textBox5.Text = ExtractPath;
                textBox6.Text = filePath;
                Program.ExtractPdfFile(binPath, ExtractPath);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
                string filePath = openFileDialog1.FileName;
                string binPath = filePath;
                string ExtractPath = filePath;
                int index = ExtractPath.IndexOf(".");
                // change the extension to _extracted.docx
                if (index > 0)
                {
                    ExtractPath = ExtractPath.Substring(0, index);
                }
                ExtractPath = ExtractPath + "_extracted.docx";
                textBox8.Text = ExtractPath;
                textBox7.Text = filePath;
                Program.ExtractDocxFile(binPath, ExtractPath);
            
        }

        private void button23_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Browse File";
            openFileDialog1.FileName = " ";
            openFileDialog1.DefaultExt = "bin";
            openFileDialog1.Filter = "Only Binary File (*.bin*)|*.bin*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                textBox6.Text = openFileDialog1.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:";
            openFileDialog1.Title = "Browse File";
            openFileDialog1.FileName = " ";
            openFileDialog1.DefaultExt = "bin";
            openFileDialog1.Filter = "Only Binary File (*.bin*)|*.bin*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                textBox7.Text = openFileDialog1.FileName;
            }
        }
    }
}

