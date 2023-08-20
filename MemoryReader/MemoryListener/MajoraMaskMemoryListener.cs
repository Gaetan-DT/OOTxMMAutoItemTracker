using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.MemoryReader.ModLoader64;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;
using System.Reflection;
using System.Threading;

namespace MajoraAutoItemTracker.MemoryReader
{
    class MajoraMaskMemoryListener: AbstractMemoryListener
    {
        private readonly MajoraMemoryDataObserver majoraMemoryDataObserver;
        private MajoraMemoryData previousMajoraMemoryData;

        public MajoraMaskMemoryListener(AbstractRomController emulatorWrapper, MajoraMemoryDataObserver majoraMemoryDataObserver) 
            : base(emulatorWrapper)
        {
            this.majoraMemoryDataObserver = majoraMemoryDataObserver;
        }

        protected override void OnTick()
        {
            var newMajoraMemoryData = new MajoraMemoryData();
            newMajoraMemoryData.ReadDataFromEmulator(emulatorWrapper);
            majoraMemoryDataObserver.CompareAndUpdateAllField(previousMajoraMemoryData, newMajoraMemoryData);
            previousMajoraMemoryData = newMajoraMemoryData;
        }

        private void CompareAndUpdateField(MajoraMemoryData newMajoraMemoryData, String fieldName)
        {            
            bool triggerEventUpdate = true;
            var newMemoryDataProp = newMajoraMemoryData.GetType().GetField(fieldName).GetValue(newMajoraMemoryData);
            if (previousMajoraMemoryData != null && newMemoryDataProp.Equals(previousMajoraMemoryData.GetType().GetField(fieldName).GetValue(previousMajoraMemoryData)))
                triggerEventUpdate = false;
            if (triggerEventUpdate)
            {
                var dataObserverEvent = majoraMemoryDataObserver.GetType().GetField(fieldName).GetValue(majoraMemoryDataObserver);
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
