using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReplacer
{
    class Reader
    {

        private Thread readerThread;
        private BoundedBuffer buffer;
        private RichTextBox rtxBox;
        private Label countLabel;
        public bool running { get; set; }

        private int currentString;
        private int lines;

        public List<string> GetText { get; private set; }

        //Delegate used in textbox invoke for COPYING to Rtx box.
        private delegate void Copyer(RichTextBox rtxBox, List<string> GetText, BoundedBuffer buffer);


        public Reader(BoundedBuffer buffer, RichTextBox rtxBox, Label countLabel, int nrOfStrings)
        {
            this.buffer = buffer;
            this.rtxBox = rtxBox;
            this.countLabel = countLabel;
            currentString = 0;
            lines = nrOfStrings;
            GetText = new List<string>();
            running = true;
            readerThread = new Thread(ReaderLoop);
            readerThread.Start();
        }

        public void ReaderLoop()
        {
            while (running)
            {
                if (lines > 0 && currentString < lines)
                {
                    string str = buffer.ReadData();
                    if(str != null)
                    {
                        currentString = (currentString + 1);
                        GetText.Add(str);
                    }
                }
                else
                {
                    Copy(rtxBox, GetText, buffer);
                    running = false;
                }
            }

        }

        public void Dispose()
        {
            running = false;
            readerThread.Abort();
        }


        private void Copy(RichTextBox rtxBox, List<string> GetText, BoundedBuffer buffer)
        {
            if (rtxBox.InvokeRequired)
            {
                Copyer newMarker = new Copyer(Copy);
                rtxBox.Invoke(newMarker, new object[] { rtxBox, GetText, buffer });
            }
            else
            {
                rtxBox.Lines = GetText.ToArray();
                buffer.MarkAll(rtxBox, buffer.findString, true, true);
                buffer.MarkAll(rtxBox, buffer.findString, true, false);

                countLabel.Text = "No. Replacements: " + buffer.nrOfReplacments;
            }
        }
    }
}
