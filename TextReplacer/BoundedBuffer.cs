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

        /// <summary>
        /// The actual string buffer array.
        /// </summary>
        private string[] strArray;

        /// <summary>
        /// An array of BufferStatus objects,
        /// one for each element in buffer.
        /// </summary>
        private BufferStatus[] status; 
        
        /// <summary>
        /// Elements in buffer.
        /// </summary>
        private int max;


        
        // Position pointers for each thread.
        private int writePos;
        private int readPos;
        private int findPos;

        /// <summary>
        /// The rich textbox to mark in.
        /// </summary>
        public RichTextBox rtxBoxSource { get; private set; }

        /// <summary>
        /// The string to search for if any.
        /// </summary>
        public string findString { get; private set; }

        /// <summary>
        /// The replace string if any.
        /// </summary>
        public string replaceString { get; private set; }

        /// <summary>
        /// The number of Replacements.
        /// </summary>
        public int nrOfReplacments { get; private set; }

        /// <summary>
        /// The startIndex in the rich text box.
        /// </summary>
        public int start { get; private set; }

        /// <summary>
        /// User notifier
        /// </summary>
        private bool notify;

        /// <summary>
        /// For mutal exclusion
        /// </summary>
        private object lockObject = new Object();

        /// <summary>
        /// Delegate used in textbox invoke for MARKING in Rtx box.
        /// </summary>
        /// <param name="rtxBox"></param>
        /// <param name="indexStart"></param>
        /// <param name="length"></param>
        private delegate void Marker(RichTextBox rtxBox, int indexStart, int length);


        /// <summary>
        /// Delegate used in textbox invoke for SELECTING in Rtx box.
        /// </summary>
        /// <param name="rtxBox"></param>
        /// <param name="fString"></param>
        /// <param name="offset"></param>
        /// <param name="toCount"></param>
        private delegate void MarkerAll(RichTextBox rtxBox, string fString, bool offset, bool toCount);

        /// <summary>
        /// Delegate used in textbox invoke for SELECTING in Rtx box.
        /// </summary>
        /// <param name="rtxBoxDest"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        private delegate void Selector(RichTextBox rtxBoxDest, int startIndex, int length);


        public BoundedBuffer(int elements, RichTextBox rtxBoxSource, bool notify, string find, string replace)
        {
            max = elements;
            strArray = new string[max];
            status = new BufferStatus[max];
            this.rtxBoxSource = rtxBoxSource;
            this.notify = notify;

            nrOfReplacments = 0;
            findString = find;
            replaceString = replace;

        }

        /// <summary>
        /// Marks a section of a specific rtxBox.
        /// </summary>
        /// <param name="rtxBox"></param>
        /// <param name="indexStart"></param>
        /// <param name="length"></param>
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

        /// <summary>
        /// Called by Modify Thread. Modifies the buffer.
        /// </summary>
        /// <returns></returns>
        public bool Modify()
        {
            Monitor.Enter(lockObject);
            try
            {
                if (status[findPos].Equals(BufferStatus.New))
                {
                    string str = strArray[findPos];


                    ReplaceAt(str);
                    start += str.Length + 1;
                    status[findPos] = BufferStatus.Checked;
                    findPos = (findPos + 1) % max;
                    return true;
                }
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
            return false;

        }


        /// <summary>
        /// Called by Read Thread. Reads the buffer.
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Replaces string and substrings at the current modify location, if needed.
        /// </summary>
        /// <param name="strSource"></param>
        private void ReplaceAt(string strSource)
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



        /// <summary>
        /// Looks at SOURCE! rtxBox and marks all sections containing the word in the ARGUMENT rtxBox.
        /// </summary>
        /// <param name="rtxBoxDest"></param>
        /// <param name="fString"></param>
        /// <param name="offset"></param>
        /// <param name="toCount"></param>
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

        /// <summary>
        /// Selects a selection in rtxbox.
        /// </summary>
        /// <param name="rtxBoxDest"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
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


        
        /// <summary>
        /// Called by Writer Thread. Writes the buffer.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Gets a list of all indexes where a substring occurs inside of a string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<int> AllIndexesOf(string str, string value)
        {
            List<int> indexes = new List<int>();
            if (String.IsNullOrEmpty(value))
                return indexes;
            
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
