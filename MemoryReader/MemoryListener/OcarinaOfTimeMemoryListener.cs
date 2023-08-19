using MajoraAutoItemTracker.MemoryReader.MemoryData;

namespace MajoraAutoItemTracker.MemoryReader
{
    class OcarinaOfTimeMemoryListener : AbstractMemoryListener
    {
        public OcarinaOfTimeMemoryListener(AbstractEmulatorWrapper emulatorWrapper, OcarinaOfTimeMemoryDataObserver memoryDataObserver) 
            : base(emulatorWrapper, memoryDataObserver)
        {

        }

        protected override AbstractMemoryData CreateNewMemoryData()
        {
            return new OcarinaOfTimeMemoryData();
        }
    }
}
