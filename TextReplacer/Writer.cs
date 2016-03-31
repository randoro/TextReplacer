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

        public void WriterLoop()
        {
            while (running)
            {
                if (textIn.Count > 0)
                {
                    buffer.WriteData(textIn[currentString]);
                    currentString = (currentString + 1)%textIn.Count;
                }
            }

        }

        public void Dispose()
        {
            running = false;
            writerThread.Abort();
        }

    }
}
