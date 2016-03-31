using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReplacer
{
    public partial class MainForm : Form
    {
        private BoundedBuffer buffer;
        private List<string> textIn;
        private Writer writer;

        public MainForm()
        {
            InitializeComponent();


            textIn = new List<string>();

        }


        private void newFile()
        {
            buffer = new BoundedBuffer(textIn.Count, richTextBoxSource, false, "something", "somethingelse");
            writer = new Writer(buffer, textIn);
        }

        private void openTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            using (var sr = new StreamReader(myStream))
                            {
                                string line;
                                textIn = new List<string>();
                                while ((line = sr.ReadLine()) != null)
                                {
                                        textIn.Add(line);
                                }

                                richTextBoxSource.Lines = textIn.ToArray();

                                newFile();

                            }
                        }
                    }
                }
                catch
                    (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

    }
}
