using MajoraAutoItemTracker.Model.Enum;
using System;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class MemoryListenerProvider
    {
        public static AbstractMemoryListener ProvideMemoryListener(
            AbstractRomController emulatorWrapper,
            RomType romType)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return new OcarinaOfTimeMemoryListener(emulatorWrapper);
                case RomType.MAJORA_MASK_USA_V0:
                    return new MajoraMaskMemoryListener(emulatorWrapper);
                case RomType.RANDOMIZE_OOT_X_MM:
                    return new OOTxMMMemoryListener(emulatorWrapper);
                default:
                    throw new Exception($"Unknown rom type {romType}");
            }
        }
    }
}
