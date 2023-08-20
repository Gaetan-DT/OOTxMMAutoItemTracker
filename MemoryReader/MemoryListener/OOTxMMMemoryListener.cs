using MajoraAutoItemTracker.MemoryReader.MemoryData;
using MajoraAutoItemTracker.MemoryReader.MemoryOffset;
using MajoraAutoItemTracker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.MemoryReader.MemoryListener
{
    class OOTxMMMemoryListener : AbstractMemoryListener
    {
        private enum CurrentRom { OcarinaOfTIme, MajoraMask, Unknown }

        private CurrentRom lastCurrentRom = CurrentRom.OcarinaOfTIme; // Used to prevend reading wrong rom each time when in MM

        private OcarinaOfTimeMemoryDataObserver ootMemoryDataObserver;
        private MajoraMemoryDataObserver mmMemoryDataObserver;

        private OcarinaOfTimeMemoryData previousOOTMemoryData;
        private MajoraMemoryData previousMMMemoryData;

        public OOTxMMMemoryListener(
            AbstractRomController emulatorWrapper, 
            OcarinaOfTimeMemoryDataObserver ootMemoryDataObserver,
            MajoraMemoryDataObserver mmMemoryDataObserver)
            : base(emulatorWrapper)
        {
            this.ootMemoryDataObserver = ootMemoryDataObserver;
            this.mmMemoryDataObserver = mmMemoryDataObserver;
        }

        protected override void OnTick()
        {
            var currentRom = CheckCurrentRom();
            switch (currentRom)
            {
                case CurrentRom.OcarinaOfTIme:
                    Debug.WriteLine("Tick on OOT ROM");
                    OnOOTTick();
                    break;
                case CurrentRom.MajoraMask:
                    Debug.WriteLine("Tick on MM ROM");
                    OnMMTick();
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

        private void OnOOTTick()
        {
            var newMemoryData = new OcarinaOfTimeMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            ootMemoryDataObserver.CompareAndUpdateAllField(previousOOTMemoryData, newMemoryData);
            previousOOTMemoryData = newMemoryData;
        }

        private void OnMMTick()
        {
            var newMemoryData = new MajoraMemoryData();
            newMemoryData.ReadDataFromEmulator(emulatorWrapper);
            mmMemoryDataObserver.CompareAndUpdateAllField(previousMMMemoryData, newMemoryData);
            previousMMMemoryData = newMemoryData;
        }
    }
}
