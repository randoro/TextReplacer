using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextReplacer
{
    class Modifier
    {
        /// <summary>
        /// Modify Thread.
        /// </summary>
        private Thread modifyThread;
        /// <summary>
        /// Reference to boundedbuffer.
        /// </summary>
        private BoundedBuffer buffer;
        /// <summary>
        /// Bool stating if thread is still running.
        /// </summary>
        public bool running { get; set; }

        /// <summary>
        /// Counters for string iteration to modify.
        /// </summary>
        private int currentString;
        private int lines;

        public Modifier(BoundedBuffer buffer, int nrOfStrings)
        {
            this.buffer = buffer;
            currentString = 0;
            lines = nrOfStrings;
            running = true;
            modifyThread = new Thread(ModifyLoop);
            modifyThread.Start();
        }

        /// <summary>
        /// Thread start.
        /// </summary>
        private void ModifyLoop()
        {
            while (running)
            {
                if (lines > 0 && currentString < lines)
                {
                    if (buffer.Modify())
                    {
                        currentString = (currentString + 1);
                    }
                }
                else
                {
                    buffer.MarkAll(buffer.rtxBoxSource, buffer.findString, false, false);
                    buffer.MarkAll(buffer.rtxBoxSource, buffer.findString, false, false);
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
            modifyThread.Abort();
        }

    }
}
