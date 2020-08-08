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

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = "C:Users/Rehman Ali/Desktop";
            openFileDialog2.Title = "Open File";
            openFileDialog2.FileName = " ";
            openFileDialog2.Filter = "All Files (*.*)|*.*";
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                string filePath = openFileDialog2.FileName;
                string binPath = filePath;
                int index = binPath.IndexOf(".");
                if(index>0)
                {
                    binPath = binPath.Substring(0, index);
                }
                binPath = binPath + ".bin";
                textBox2.Text = binPath;
                textBox1.Text = filePath;

                string extension = Path.GetExtension(filePath);
                if (extension == ".docx")
                {
                    
                    Program.CompressDocxFile(filePath, binPath);
      
                    
                }
                else if (extension == ".txt")
                {
                    Program.CompressTextFile(filePath, binPath);
                    Program.ExtractTextFile(binPath, filePath);
                }
                else if (extension == ".pdf")
                {
                    Program.CompressPdfFile(filePath, binPath);
                }
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
            openFileDialog3.InitialDirectory = "C:Users/Rehman Ali/Desktop";
            openFileDialog3.Title = "Open File";
            openFileDialog3.FileName = " ";
            openFileDialog3.Filter = "Binary File (.bin)|*.bin";
            if (openFileDialog3.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                string filePath = openFileDialog2.FileName;
                string binPath = filePath;
                string ExtractPath = filePath;
                int index = ExtractPath.IndexOf(".");
                if (index > 0)
                {
                    ExtractPath = ExtractPath.Substring(0, index);
                }

                ExtractPath = ExtractPath + ".txt";
                Program.ExtractTextFile(binPath, ExtractPath);
                textBox2.Text = ExtractPath;
                textBox1.Text = filePath;


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
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

