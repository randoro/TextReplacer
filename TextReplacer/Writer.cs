using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextReplacer
{
    class Writer
    {
        /// <summary>
        /// Writer thread.
        /// </summary>
        private Thread writerThread;
        /// <summary>
        /// Reference to boundedbuffer.
        /// </summary>
        private BoundedBuffer buffer;
        /// <summary>
        /// List of strings to write
        /// </summary>
        private List<string> textIn;
        /// <summary>
        /// Bool stating if thread is still running.
        /// </summary>
        public bool running { get; set; }

        /// <summary>
        /// Counters for string iteration in 'textIn' list.
        /// </summary>
        private int currentString;
        private int lines;

        public Writer(BoundedBuffer buffer, List<string> textIn)
        {
            this.buffer = buffer;
            this.textIn = textIn;
            currentString = 0;
            lines = textIn.Count;
            running = true;
            writerThread = new Thread(WriterLoop);
            writerThread.Start();
        }


        /// <summary>
        /// Thread start.
        /// </summary>
        private void WriterLoop()
        {
            while (running)
            {
                if (lines > 0 && currentString < lines)
                {
                    if (buffer.WriteData(textIn[currentString]))
                    {
                        currentString = (currentString + 1);
                    }
                }
                else
                {
                    running = false;
                }
            }

        }

        /// <summary>
        /// Disposes of the thread.
        /// </summary>
        public void Dispose()
        {
            running = false;
            writerThread.Abort();
        }

    }
}
