using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class MemoryListenerProvider
    {
        public static AbstractMemoryListener ProvideMemoryListener(
            AbstractRomController emulatorWrapper,
            Action<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> ootReplaySubject,
            Action<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> mmReplaySubject,
            RomType romType)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return new OcarinaOfTimeMemoryListener(emulatorWrapper, ootReplaySubject);
                case RomType.MAJORA_MASK_USA_V0:
                    return new MajoraMaskMemoryListener(emulatorWrapper, mmReplaySubject);
                case RomType.RANDOMIZE_OOT_X_MM:
                    return new OOTxMMMemoryListener(emulatorWrapper, ootReplaySubject, mmReplaySubject);
                default:
                    throw new Exception($"Unknown rom type {romType}");
            }
        }
    }
}
