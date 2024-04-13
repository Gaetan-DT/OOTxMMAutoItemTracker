using MajoraAutoItemTracker.MemoryReader.MemoryData;

namespace MajoraAutoItemTracker.MemoryReader
{
    class OcarinaOfTimeMemoryListener : AbstractMemoryListener
    {
        private OcarinaOfTimeMemoryData? previousMemoryData;

        public OcarinaOfTimeMemoryListener(AbstractRomController emulatorWrapper) : base(emulatorWrapper)
        {
            
        }

        public override void OnTick()
        {
            var newMemoryData = new OcarinaOfTimeMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            var diffList = newMemoryData.CompareWithPreviousAndReturnDiff(previousMemoryData);
            if (diffList.Count != 0)
                callBackEventOot.OnNext(diffList);
            previousMemoryData = newMemoryData;
        }
    }
}
