using System.Threading;

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractMemoryListener
    {
        const int CST_DEFAULT_THREAD_DELLAY_MS = 1_000;

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

        protected abstract void OnTick();

        public void StartThread()
        {
            _thread = new Thread(new ThreadStart(ThreadRun));
            _thread.Start();
        }

        public void StopThread()
        {
            _isThreadActive = false;
        }
    }
}
