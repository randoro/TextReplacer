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
        private Thread writerThread;
        private BoundedBuffer buffer;
        private List<string> textIn;
        public bool running { get; set; }

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
