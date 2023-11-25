using System;
using System.Collections.Generic;
using System.Threading;

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractMemoryListener
    {
        const int CST_DEFAULT_THREAD_DELLAY_MS = 2_000;

        private Thread _thread;
        private bool _isThreadActive;

        protected AbstractRomController emulatorWrapper;

        public AbstractMemoryListener(AbstractRomController emulatorWrapper)
        {
            this.emulatorWrapper = emulatorWrapper;
        }

        private void ThreadRun()
        {
            _isThreadActive = true;
            while (_isThreadActive)
            {
                OnTick();
                Thread.Sleep(CST_DEFAULT_THREAD_DELLAY_MS);
            }       
        }

        public abstract void OnTick();

        public virtual void StartThread()
        {
            _thread = new Thread(new ThreadStart(ThreadRun));
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void StopThread()
        {
            _isThreadActive = false;
            _thread = null;
        }
    }
}
