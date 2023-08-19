using MajoraAutoItemTracker.MemoryReader.MemoryData;
using System.Threading;

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractMemoryListener
    {
        const int CST_DEFAULT_THREAD_DELLAY_MS = 2_000;

        private Thread _thread;
        private bool _isThreadActive;

        private AbstractRomController emulatorWrapper;
        private AbstractMemoryDataObserver memoryDataObserver;

        private AbstractMemoryData previousMemoryData;

        public AbstractMemoryListener(AbstractRomController emulatorWrapper, AbstractMemoryDataObserver memoryDataObserver)
        {
            this.emulatorWrapper = emulatorWrapper;
            this.memoryDataObserver = memoryDataObserver;
            // Data observer bind need to be done before now
        }

        private void ThreadRun()
        {
            _isThreadActive = true;
            while (_isThreadActive)
            {
                var newMemoryData = CreateNewMemoryData();
                newMemoryData.ReadDataFromEmulator(emulatorWrapper);
                memoryDataObserver.CompareAndUpdateAllField(previousMemoryData, newMemoryData);
                previousMemoryData = newMemoryData;
                Thread.Sleep(CST_DEFAULT_THREAD_DELLAY_MS);
            }       
        }

        protected abstract AbstractMemoryData CreateNewMemoryData();

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
