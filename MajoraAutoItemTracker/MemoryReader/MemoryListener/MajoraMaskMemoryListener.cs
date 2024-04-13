using MajoraAutoItemTracker.MemoryReader.MemoryData;

namespace MajoraAutoItemTracker.MemoryReader
{
    class MajoraMaskMemoryListener: AbstractMemoryListener
    {
        private MajoraMemoryData? previousMemoryData = null;

        public MajoraMaskMemoryListener(AbstractRomController emulatorWrapper) : base(emulatorWrapper)
        {

        }

        public override void OnTick()
        {
            var newMemoryData = new MajoraMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            var diffList = newMemoryData.CompareWithPreviousAndReturnDiff(previousMemoryData);
            if (diffList.Count != 0)
                callBackEventMm.OnNext(diffList);
            previousMemoryData = newMemoryData;
        }
    }
}
