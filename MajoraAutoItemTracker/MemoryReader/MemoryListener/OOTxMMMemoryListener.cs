using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Model.Enum.OOT;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class OOTxMMMemoryListener : AbstractMemoryListener
    {

        private CurrentRom lastCurrentRom = CurrentRom.Unknown; // Used to prevend reading wrong rom each time when in MM

        private OcarinaOfTimeMemoryListener ocarinaOfTimeMemoryListener;
        private MajoraMaskMemoryListener majoraMaskMemoryListener;

        public OOTxMMMemoryListener(AbstractRomController emulatorWrapper): base(emulatorWrapper)
        {
            lastCurrentRom = emulatorWrapper.currentRomType;
            ocarinaOfTimeMemoryListener = new OcarinaOfTimeMemoryListener(emulatorWrapper);
            majoraMaskMemoryListener = new MajoraMaskMemoryListener(emulatorWrapper);

            ocarinaOfTimeMemoryListener.callBackEventOot.Subscribe(callBackEventOot.OnNext);
            majoraMaskMemoryListener.callBackEventMm.Subscribe(callBackEventMm.OnNext);
        }

        public override void StartThread()
        {
            base.StartThread();
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
            var romOrderToLookUp = new Tuple<CurrentRom, CurrentRom>(
                CurrentRom.OcarinaOfTIme,
                CurrentRom.MajoraMask);
            if (lastCurrentRom == CurrentRom.MajoraMask)
            {
                romOrderToLookUp = new Tuple<CurrentRom, CurrentRom>(
                    CurrentRom.MajoraMask,
                    CurrentRom.OcarinaOfTIme);
            }

            //TODO: Export this to emulator class
            uint romStart;
            if (emulatorWrapper.PerformCheckFollowingRomType(romOrderToLookUp.Item1))
            {
                return romOrderToLookUp.Item1;
            }
            else if (!emulatorWrapper.IsAddressFound(romOrderToLookUp.Item1) &&
                emulatorWrapper.FindRomStartForRomType(out romStart, romOrderToLookUp.Item1))
            {
                emulatorWrapper.SetRomAddStartForRomType(romOrderToLookUp.Item1, romStart);
                return romOrderToLookUp.Item1;
            }
            else if (emulatorWrapper.PerformCheckFollowingRomType(romOrderToLookUp.Item2))
            {
                return romOrderToLookUp.Item2;
            }
            else if (!emulatorWrapper.IsAddressFound(romOrderToLookUp.Item2) &&
                emulatorWrapper.FindRomStartForRomType(out romStart, romOrderToLookUp.Item2))
            {
                emulatorWrapper.SetRomAddStartForRomType(romOrderToLookUp.Item2, romStart);
                return romOrderToLookUp.Item2;
            }
            else
            {
                return CurrentRom.Unknown;
            }
        }
    }
}
