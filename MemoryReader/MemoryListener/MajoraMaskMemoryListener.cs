using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader
{
    class MajoraMaskMemoryListener: AbstractMemoryListener
    {
        private MajoraMemoryData? previousMemoryData = null;

        readonly Action<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> callBack;

        public MajoraMaskMemoryListener(AbstractRomController emulatorWrapper, Action<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> callBack) 
            : base(emulatorWrapper)
        {
            this.callBack = callBack;
        }

        public override void OnTick()
        {
            var newMemoryData = new MajoraMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            var diffList = newMemoryData.CompareWithPreviousAndReturnDiff(previousMemoryData);
            if (diffList.Count != 0)
                callBack(diffList);
            previousMemoryData = newMemoryData;
        }
    }
}
