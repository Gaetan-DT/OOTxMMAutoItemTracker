﻿using MajoraAutoItemTracker.MemoryReader;
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
        private MajoraMaskMemoryListener memoryListener = null;
        public ReplaySubject<bool> isMemoryListenerStartedSubject = new ReplaySubject<bool>();

        public MainUIController()
        {
            isMemoryListenerStartedSubject.OnNext(false);
        }

        public bool StartMemoryListener(
            AbstractEmulatorWrapper abstractEmulatorWrapper, // TODO Use AbstractEmulatorWrapper 
            Action<Tuple<ItemLogicPopertyName, object>> onItemLogicChange, 
            out string error)
        {
            error = "";
            try
            {
                ModLoader64Wrapper modLoader64Wrapper = new ModLoader64Wrapper(); // TODO: Change with abstract implementation
                MajoraMemoryDataObserver majoraMemoryDataObserver = new MajoraMemoryDataObserver();
                memoryListener = new MajoraMaskMemoryListener(modLoader64Wrapper, majoraMemoryDataObserver);
                memoryListener.Start();
                memoryListener.OnAnyItemLogicChange.Subscribe(onItemLogicChange);
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
                memoryListener.Stop();
                memoryListener = null;
            }
            finally
            {
                isMemoryListenerStartedSubject.OnNext(false);
            }
        }
    }
}
