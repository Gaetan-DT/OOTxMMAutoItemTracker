using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Diagnostics;
using System.Reactive.Subjects;
using System.Reflection;
using System.Threading;

namespace MajoraAutoItemTracker
{
    public delegate void BasicCallback(String message);

    class MemoryListener
    {
        private const int CST_THREAD_DELLAY = 1000;

        private readonly BasicCallback _basicCallback;
        private readonly ModLoader64Wrapper _modLoader64Wrapper;
        private readonly MajoraMemoryDataObserver _majoraMemoryDataObserver;

        private Thread _thread;
        private bool _isThreadActive;

        private MajoraMemoryData _previousMajoraMemoryData;

        public MemoryListener(
            ModLoader64Wrapper modLoader64Wrapper, 
            MajoraMemoryDataObserver majoraMemoryDataObserver,
            BasicCallback basicCallback)
        {
            _modLoader64Wrapper = modLoader64Wrapper;
            _majoraMemoryDataObserver = majoraMemoryDataObserver;
            _basicCallback = basicCallback;
        }

        public void Start()
        {
            _thread = new Thread(new ThreadStart(Run));
            _thread.Start();
        }

        public void Stop()
        {
            _isThreadActive = false;
        }

        private void Run()
        {
            _isThreadActive = true;
            while (_isThreadActive)
            {
                var newMajoraMemoryData = new MajoraMemoryData(_modLoader64Wrapper);
                foreach (var field in _majoraMemoryDataObserver.GetType().GetFields())
                    CompareAndUpdateField(newMajoraMemoryData, field.Name);
                _previousMajoraMemoryData = newMajoraMemoryData;
                //_basicCallback?.Invoke("Data updated");
                Thread.Sleep(CST_THREAD_DELLAY);
            }
        }

        private void CompareAndUpdateField(MajoraMemoryData newMajoraMemoryData, String fieldName)
        {            
            bool triggerEventUpdate = true;
            var newMemoryDataProp = newMajoraMemoryData.GetType().GetField(fieldName).GetValue(newMajoraMemoryData);
            if (_previousMajoraMemoryData != null && newMemoryDataProp.Equals(_previousMajoraMemoryData.GetType().GetField(fieldName).GetValue(_previousMajoraMemoryData)))
                triggerEventUpdate = false;
            if (triggerEventUpdate)
            {
                var dataObserverEvent = _majoraMemoryDataObserver.GetType().GetField(fieldName).GetValue(_majoraMemoryDataObserver);
                dataObserverEvent.GetType().InvokeMember(
                    "OnNext",
                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, 
                    null, 
                    dataObserverEvent, 
                    new object[] { newMemoryDataProp });
            }
        }
    }
}
