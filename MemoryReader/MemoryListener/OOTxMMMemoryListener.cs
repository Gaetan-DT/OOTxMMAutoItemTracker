using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class OOTxMMMemoryListener : AbstractMemoryListener
    {
        private enum CurrentRom { OcarinaOfTIme, MajoraMask, Unknown }

        private CurrentRom lastCurrentRom = CurrentRom.OcarinaOfTIme; // Used to prevend reading wrong rom each time when in MM

        private OcarinaOfTimeMemoryListener ocarinaOfTimeMemoryListener;
        private MajoraMaskMemoryListener majoraMaskMemoryListener;

        public OOTxMMMemoryListener(
            AbstractRomController emulatorWrapper,
            Action<List<Tuple<OcarinaOfTimeItemLogicPopertyName, object>>> callBackOOT,
            Action<List<Tuple<MajoraMaskItemLogicPopertyName, object>>> callBackMM)
            : base(emulatorWrapper)
        {
            ocarinaOfTimeMemoryListener = new OcarinaOfTimeMemoryListener(emulatorWrapper, callBackOOT);
            majoraMaskMemoryListener = new MajoraMaskMemoryListener(emulatorWrapper, callBackMM);
        }

        public override void OnTick()
        {
            var currentRom = CheckCurrentRom();
            switch (currentRom)
            {
                case CurrentRom.OcarinaOfTIme:
                    Debug.WriteLine("Tick on OOT ROM");
                    ocarinaOfTimeMemoryListener.OnTick();
                    break;
                case CurrentRom.MajoraMask:
                    Debug.WriteLine("Tick on MM ROM");
                    majoraMaskMemoryListener.OnTick();
                    break;
                case CurrentRom.Unknown:
                    Debug.WriteLine("Unknown current ROM");
                    break;
            }
            lastCurrentRom = currentRom;
        }

        private CurrentRom CheckCurrentRom()
        {
            var arrayRoomToCheck = new List<CurrentRom>{ CurrentRom.OcarinaOfTIme, CurrentRom.MajoraMask };
            if (lastCurrentRom == CurrentRom.MajoraMask)
                arrayRoomToCheck.Reverse();
            foreach(var roomToCheck in arrayRoomToCheck)
                if (roomToCheck == CurrentRom.OcarinaOfTIme && emulatorWrapper.PerformCheckFollowingRomType(Model.Enum.RomType.OCARINA_OF_TIME_USA_V0))
                    return CurrentRom.OcarinaOfTIme;
                else if (roomToCheck == CurrentRom.MajoraMask && emulatorWrapper.PerformCheckFollowingRomType(Model.Enum.RomType.MAJORA_MASK_USA_V0))
                    return CurrentRom.MajoraMask;
            return CurrentRom.Unknown;
        }
    }
}
