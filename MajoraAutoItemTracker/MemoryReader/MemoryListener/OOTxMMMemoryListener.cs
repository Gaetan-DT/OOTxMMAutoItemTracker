using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Diagnostics;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class OOTxMMMemoryListener : AbstractMemoryListener
    {

        private CurrentRom lastCurrentRom;

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
            var currentRom = emulatorWrapper.CheckCurrentRom(lastCurrentRom);
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

        
    }
}
