using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class MemoryListenerProvider
    {
        public static AbstractMemoryListener ProvideMemoryListener(
            AbstractEmulatorWrapper emulatorWrapper,
            ReplaySubject<Tuple<ItemLogicPopertyName, object>> replaySubject,
            RomType romType)
        {
            AbstractMemoryDataObserver observer = ProvideAbstractMemoryDataObserver(romType);
            observer.BindAllEvent(replaySubject);
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return new OcarinaOfTimeMemoryListener(emulatorWrapper, (OcarinaOfTimeMemoryDataObserver)observer);
                case RomType.MAJORA_MASK_USA_V0:
                    throw new Exception("Not yet implemented"); // TODO
                    //return new MajoraMaskMemoryListener(emulatorWrapper, observer);
                default:
                    throw new Exception($"Unknown rom type {romType}");
            }
        }

        private static AbstractMemoryDataObserver ProvideAbstractMemoryDataObserver(RomType romType)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return new OcarinaOfTimeMemoryDataObserver();
                case RomType.MAJORA_MASK_USA_V0:
                    throw new Exception("Not yet implemented"); // TODO
                    //observer = new MajoraMemoryDataObserver();
                default:
                    throw new Exception($"Unknown rom type {romType}");
            }
        }
    }
}
