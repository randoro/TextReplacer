using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextReplacer
{
    class Reader
    {

        private Thread readerThread;
        private BoundedBuffer buffer;
        public bool running { get; set; }

        private int currentString;
        private int lines;

        public Reader(BoundedBuffer buffer, int nrOfStrings)
        {
            this.buffer = buffer;
            currentString = 0;
            lines = nrOfStrings;
            running = true;
            readerThread = new Thread(ReaderLoop);
            readerThread.Start();
        }

        public void ReaderLoop()
        {
            while (running)
            {
                if (lines > 0)
                {
                    buffer.ReadData();
                    currentString = (currentString + 1) % lines;
                }
            }

        }

        public void Dispose()
        {
            running = false;
            readerThread.Abort();
        }
    }
}
