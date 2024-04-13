using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.MemoryReader
{
    class OcarinaOfTimeMemoryListener : AbstractMemoryListener
    {
        private OcarinaOfTimeMemoryData? previousMemoryData;

        readonly Action<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> callBack;

        public OcarinaOfTimeMemoryListener(AbstractRomController emulatorWrapper, Action<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> callBack) 
            : base(emulatorWrapper)
        {
            this.callBack = callBack;
        }

        public override void OnTick()
        {
            var newMemoryData = new OcarinaOfTimeMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            var diffList = newMemoryData.CompareWithPreviousAndReturnDiff(previousMemoryData);
            if (diffList.Count != 0)
                callBack(diffList);
            previousMemoryData = newMemoryData;
        }
    }
}
