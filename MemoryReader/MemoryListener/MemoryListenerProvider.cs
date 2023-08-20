﻿using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class MemoryListenerProvider
    {
        public static AbstractMemoryListener ProvideMemoryListener(
            AbstractRomController emulatorWrapper,
            ReplaySubject<Tuple<OcarinaOfTimeItemLogicPopertyName, object>> ootReplaySubject,
            ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>> mmReplaySubject,
            RomType romType)
        {
            var ootObserver = new OcarinaOfTimeMemoryDataObserver();
            var mmObserver = new MajoraMemoryDataObserver();
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    ootObserver.BindAllEvent(ootReplaySubject);
                    return new OcarinaOfTimeMemoryListener(emulatorWrapper, ootObserver);
                case RomType.MAJORA_MASK_USA_V0:
                    mmObserver.BindAllEvent(mmReplaySubject);
                    return new MajoraMaskMemoryListener(emulatorWrapper, mmObserver);
                case RomType.RANDOMIZE_OOT_X_MM:
                    ootObserver.BindAllEvent(ootReplaySubject);
                    mmObserver.BindAllEvent(mmReplaySubject);
                    return new OOTxMMMemoryListener(emulatorWrapper, ootObserver, mmObserver);
                default:
                    throw new Exception($"Unknown rom type {romType}");
            }
        }
    }
}
