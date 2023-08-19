using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.MemoryReader.MemoryListener;
using MajoraAutoItemTracker.MemoryReader.ModLoader64;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class MainUIController
    {
        private AbstractMemoryListener memoryListener = null;
        public ReplaySubject<bool> isMemoryListenerStartedSubject = new ReplaySubject<bool>();
        public ReplaySubject<Tuple<ItemLogicPopertyName, object>> OnAnyItemLogicChange = new ReplaySubject<Tuple<ItemLogicPopertyName, object>>();

        public MainUIController()
        {
            isMemoryListenerStartedSubject.OnNext(false);
        }

        public bool StartMemoryListener(
            AbstractEmulatorWrapper emulatorWrapper,
            RomType romType,
            Action<Tuple<ItemLogicPopertyName, object>> onItemLogicChange, 
            out string error)
        {
            error = "";
            if (emulatorWrapper == null)
            {
                error = "No emulator selected";
                return false;
            }
            if (!emulatorWrapper.AttachToProcess())
            {
                error = "Unable to attach to process emulator";
                return false;
            }
            try
            {
                memoryListener = MemoryListenerProvider.ProvideMemoryListener(emulatorWrapper, OnAnyItemLogicChange, romType);
                memoryListener.StartThread();
                OnAnyItemLogicChange.Subscribe(onItemLogicChange);
                isMemoryListenerStartedSubject.OnNext(true);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                error = e.Message;
                return false;
            }
        }

        public void StopMemoryListener()
        {
            try
            {
                memoryListener.StartThread();
                memoryListener = null;
            }
            finally
            {
                isMemoryListenerStartedSubject.OnNext(false);
            }
        }
    }
}
