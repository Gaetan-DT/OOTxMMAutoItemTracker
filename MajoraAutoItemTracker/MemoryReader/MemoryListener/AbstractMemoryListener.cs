using System.Collections.Generic;
using System.Reactive.Subjects;
using System;
using System.Threading;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;

namespace MajoraAutoItemTracker.MemoryReader
{
    public abstract class AbstractMemoryListener
    {
        const int CST_DEFAULT_THREAD_DELLAY_MS = 2_000;

        private Thread? _thread = null;
        private bool _isThreadActive = false;

        protected AbstractRomController emulatorWrapper;

        // First value should be OcarinaOfTimeItemLogicPopertyName or MM one
        public readonly ReplaySubject<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> callBackEventOot =
            new ReplaySubject<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>>(50);

        public readonly ReplaySubject<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> callBackEventMm =
            new ReplaySubject<List<Tuple<MajoraMaskItemLogicPopertyName, object>>>(50);

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
