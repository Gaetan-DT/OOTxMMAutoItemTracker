using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.Model.Enum.OOT;

namespace MajoraAutoItemTracker.MemoryReader
{
    class OcarinaOfTimeMemoryListener : AbstractMemoryListener
    {
        private OcarinaOfTimeMemoryDataObserver memoryDataObserver;
        private OcarinaOfTimeMemoryData previousMemoryData;

        public OcarinaOfTimeMemoryListener(AbstractRomController emulatorWrapper, OcarinaOfTimeMemoryDataObserver memoryDataObserver) 
            : base(emulatorWrapper)
        {
            this.memoryDataObserver = memoryDataObserver;
        }

        protected override void OnTick()
        {
            var newMemoryData = new OcarinaOfTimeMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            memoryDataObserver.CompareAndUpdateAllField(previousMemoryData, newMemoryData);
            previousMemoryData = newMemoryData;
        }
    }
}
