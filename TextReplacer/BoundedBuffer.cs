using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReplacer
{
    public enum BufferStatus { Empty, New, Checked }


    class BoundedBuffer
    {


        private string[] strArray; //The actual string buffer array
        private BufferStatus[] status; //An array of BufferStatus objects,
        //one for each element in buffer.
        private int max; //Elements in buffer.

        //Position pointers for each thread.
        private int writePos;
        private int readPos;
        private int findPos;

        //The rich textbox to mark in.
        private RichTextBox rtxBox;

        //The string to search for if any.
        private string findString;

        //The replace string if any.
        private string replaceString;

        //The start position in textbox for marking
        private int start;

        //Replacement counter
        private int nbrReplacement;

        //User notifier
        private bool notify;

        //For mutal exclusion
        private object lockObject = new Object();

        //Delegate used in textbox invoke for MARKING in Rtx box.
        private delegate void Marker();

        //Delegate used in textbox invoke for SELECTING in Rtx box.
        private delegate void Selector();


        public BoundedBuffer(int elements, RichTextBox rtxBox, bool notify, string find, string replace)
        {
            max = elements;
            strArray = new string[max];
            status = new BufferStatus[max];
            this.rtxBox = rtxBox;



        }


        private void Mark()
        {
            if (rtxBox.InvokeRequired)
            {
                Marker newMarker = new Marker(Mark);
                rtxBox.Invoke(newMarker, new object[] { });
            }
            else
            {
                //Mark things
            }
        }

        public void Modify()
        {
            Monitor.Enter(lockObject);
            try
            {

            }
            finally
            {
                Monitor.Exit(lockObject);
            }

        }

        public string ReadData()
        {
            Monitor.Enter(lockObject);
            string str;
            try
            {
                if (status[readPos].Equals(BufferStatus.New)) //change
                {
                    str = strArray[readPos];
                    strArray[readPos] = "";
                    status[readPos] = BufferStatus.Empty; //change
                    readPos = (readPos + 1) % max;
                    return str;
                }
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return null;
        }

        private void ReplaceAt(string strSource, string strReplace, int pos, int size)
        {
            
        }

        private void Select()
        {
            if (rtxBox.InvokeRequired)
            {
                Selector newSelector = new Selector(Select);
                rtxBox.Invoke(newSelector, new object[] { });
            }
            else
            {
                //Select things
            }
        }

        public bool WriteData(string s)
        {
            Monitor.Enter(lockObject);
            try
            {
                if (status[writePos].Equals(BufferStatus.Empty))
                {
                    strArray[writePos] = s;
                    status[writePos] = BufferStatus.New;
                    writePos = (writePos + 1)%max;
                    return true;
                }

            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return false;
        }

    }
}
