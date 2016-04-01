using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public RichTextBox rtxBoxSource { get; private set; }

        //The rich textbox to mark in.
        public RichTextBox rtxBoxDest { get; private set; }

        //The string to search for if any.
        public string findString { get; private set; }

        //The replace string if any.
        public string replaceString { get; private set; }

        //The number of Replacements.
        public int nrOfReplacments { get; private set; }

        //The startIndex in the rich text box.
        public int start { get; private set; }

        //User notifier
        private bool notify;

        //For mutal exclusion
        private object lockObject = new Object();

        //Delegate used in textbox invoke for MARKING in Rtx box.
        private delegate void Marker(RichTextBox rtxBox, int indexStart, int length);


        //Delegate used in textbox invoke for SELECTING in Rtx box.
        private delegate void MarkerAll(RichTextBox rtxBox, string fString, bool offset, bool toCount);

        //Delegate used in textbox invoke for SELECTING in Rtx box.
        private delegate void Selector(RichTextBox rtxBoxDest, int startIndex, int length);


        public BoundedBuffer(int elements, RichTextBox rtxBoxSource, RichTextBox rtxBoxDest, bool notify, string find, string replace)
        {
            max = elements;
            strArray = new string[max];
            status = new BufferStatus[max];
            this.rtxBoxSource = rtxBoxSource;
            this.rtxBoxDest = rtxBoxDest;
            this.notify = notify;

            nrOfReplacments = 0;
            findString = find;
            replaceString = replace;

        }


        private void Mark(RichTextBox rtxBox, int indexStart, int length)
        {
            if (rtxBox.InvokeRequired)
            {
                Marker newMarker = new Marker(Mark);
                rtxBox.Invoke(newMarker, new object[] { rtxBox, indexStart, length });
            }
            else
            {
                rtxBox.SelectionBackColor = Color.Green;
                rtxBox.SelectionStart = indexStart;
                rtxBox.SelectionLength = length;
            }
        }

        //private void MarkDest(int indexStart, int length)
        //{
        //    if (rtxBoxDest.InvokeRequired)
        //    {
        //        Marker newMarker = new Marker(MarkDest);
        //        rtxBoxDest.Invoke(newMarker, new object[] { indexStart, length });
        //    }
        //    else
        //    {
        //        rtxBoxDest.SelectionBackColor = Color.Green;
        //        rtxBoxDest.SelectionStart = indexStart;
        //        rtxBoxDest.SelectionLength = length;
        //    }
        //}

        public bool Modify()
        {
            Monitor.Enter(lockObject);
            try
            {
                if (status[findPos].Equals(BufferStatus.New))
                {
                    string str = strArray[findPos];


                    ReplaceAt(str);
                    //string newString = Regex.Replace(str, findString, replaceString, RegexOptions.IgnoreCase);
                    //strArray[findPos] = newString;

                    //List<int> indexesSource = AllIndexesOf(str, findString);
                    //for (int i = 0; i < indexesSource.Count; i++)
                    //{
                    //    MarkSource(startSource + indexesSource[i], findString.Length);
                    //    nbrReplacement++;
                    //}

                    //List<int> indexesDest = AllIndexesOf(newString, replaceString);
                    //for (int i = 0; i < indexesDest.Count; i++)
                    //{
                    //    MarkDest(startDest + indexesDest[i], replaceString.Length);
                    //}

                    start += str.Length + 1;
                    status[findPos] = BufferStatus.Checked;
                    findPos = (findPos + 1) % max;
                    //startSource += str.Length + 1;
                    //startDest += newString.Length + 1;
                    return true;
                }
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return false;

        }

        public string ReadData()
        {
            Monitor.Enter(lockObject);
            try
            {
                if (status[readPos].Equals(BufferStatus.Checked)) //change
                {
                    string str = strArray[readPos];
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

        private void ReplaceAt(string strSource) //, string strReplace, int pos, int size)
        {
            if (!String.IsNullOrEmpty(strSource) && !String.IsNullOrEmpty(findString) && !String.IsNullOrEmpty(replaceString))
            {
                int index = 0;
                int oldStart = 0;
                int oldWordOffset = 0;
                while (true)
                {
                    index = strSource.IndexOf(findString, oldStart, StringComparison.CurrentCultureIgnoreCase);
                    if (index != -1)
                    {
                        

                        Select(rtxBoxSource, start + index + oldWordOffset, findString.Length);
                        Select(rtxBoxSource, start + index + oldWordOffset, findString.Length);

                        if (notify)
                        {
                            string message = "Are you sure that you want to replace '" + findString + "' with '" +
                                             replaceString +
                                             "'?";
                            string caption = "Replace with.";
                            var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                strSource = strSource.Remove(index, findString.Length);
                                strSource = strSource.Insert(index, replaceString);
                                oldStart = index + replaceString.Length;
                                oldWordOffset += (findString.Length - replaceString.Length);
                            }
                            else
                            {
                                oldStart = index + findString.Length;
                            }
                        }
                        else
                        {
                            strSource = strSource.Remove(index, findString.Length);
                            strSource = strSource.Insert(index, replaceString);
                            oldStart = index + replaceString.Length;
                            oldWordOffset += (findString.Length - replaceString.Length);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                strArray[findPos] = strSource;
            }




        }

        public void MarkAll(RichTextBox rtxBoxDest, string fString, bool offset, bool toCount)
        {
            if (rtxBoxSource.InvokeRequired)
            {
                MarkerAll newSelector = new MarkerAll(MarkAll);
                rtxBoxSource.Invoke(newSelector, new object[] { rtxBoxDest, fString, offset, toCount });
            }
            else
            {
                int chars = 0;
                int intOffset = 0;
                if (offset)
                {
                    intOffset = replaceString.Length - fString.Length;
                }


                for (int i = 0; i < rtxBoxSource.Lines.Length; i++)
                {
                    string str = rtxBoxSource.Lines[i];
                    List<int> indexesSource = AllIndexesOf(str, fString);
                    for (int j = 0; j < indexesSource.Count; j++)
                    {
                        Mark(rtxBoxDest, chars + indexesSource[j], fString.Length + intOffset);
                        chars += intOffset;

                        if (toCount)
                        {
                            nrOfReplacments++;
                        }
                    }
                    chars += str.Length + 1;
                }
            }

        }

        public void Select(RichTextBox rtxBoxDest, int startIndex, int length)
        {

            if (rtxBoxSource.InvokeRequired)
            {
                Selector newSelector = new Selector(Select);
                rtxBoxSource.Invoke(newSelector, new object[] { rtxBoxDest, startIndex, length });
            }
            else
            {
                if (startIndex != -1)
                {
                    rtxBoxDest.SelectionBackColor = Color.CadetBlue;
                    rtxBoxDest.SelectionStart = startIndex;
                    rtxBoxDest.SelectionLength = length;
                }
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
                    writePos = (writePos + 1) % max;
                    return true;
                }

            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return false;
        }

        public static List<int> AllIndexesOf(string str, string value)
        {
            List<int> indexes = new List<int>();
            if (String.IsNullOrEmpty(value))
                return indexes;
                //throw new ArgumentException("The string to find may not be empty", value);
            
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index, StringComparison.CurrentCultureIgnoreCase);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

    }
}
