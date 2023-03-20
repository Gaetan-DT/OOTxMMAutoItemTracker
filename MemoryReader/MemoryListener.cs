using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    public delegate void BasicCallback(String message);

    class MemoryListener
    {
        private const int CST_THREAD_DELLAY = 500;

        private BasicCallback mBasicCallback;
        private ModLoader64Wrapper mModLoader64Wrapper;
        private MajoraMemoryData memoryDumpHelper = new MajoraMemoryData();
        private Thread mThread;

        public MemoryListener(ModLoader64Wrapper modLoader64Wrapper, BasicCallback basicCallback)
        {
            this.mModLoader64Wrapper = modLoader64Wrapper;
            this.mBasicCallback = basicCallback;
        }

        public MajoraMemoryData getMemoryDump()
        {
            return this.memoryDumpHelper;
        }

        public void start()
        {
            mThread = new Thread(new ThreadStart(this.run));
            mThread.Start();
        }

        public void stop()
        {
            mThread.Abort();
        }

        private void run()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                memoryDumpHelper.UdpateStateData(this.mModLoader64Wrapper);
                this.mBasicCallback.Invoke("Data updated");
                Thread.Sleep(CST_THREAD_DELLAY);
            }
        }
    }
}
