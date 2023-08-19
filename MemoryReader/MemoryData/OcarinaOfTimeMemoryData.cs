using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    class OcarinaOfTimeMemoryData : AbstractMemoryData
    {

        #region INVENTORY C-Button Items

        public bool HasOcarina = false;

        #endregion

        public override void ReadDataFromEmulator(AbstractRomController emulatorWrapper)
        {
            HasOcarina = emulatorWrapper.CheckAnykHexValue(Model.OOTOffsets.CST_INVENTORY_ADDRESS_OCARINA, new byte[] { 
                Model.OOTOffsets.CST_INVENTORY_VALUE_OCARINA_VALUE_FAIRY_OCARINA,
                Model.OOTOffsets.CST_INVENTORY_VALUE_OCARINA_VALUE_OCARINA_OF_TIME,
            });
        }
    }

    class OcarinaOfTimeMemoryDataObserver : AbstractMemoryDataObserver
    {
        #region INVENTORY C-Button Items

        public ReplaySubject<bool> HasOcarina = new ReplaySubject<bool>(1);

        #endregion

        public override void BindAllEvent(ReplaySubject<Tuple<MajoraMaskItemLogicPopertyName, object>> replaySubject)
        {
            HasOcarina.Subscribe(value => replaySubject.OnNext(new Tuple<MajoraMaskItemLogicPopertyName, object>(MajoraMaskItemLogicPopertyName.ImgOcarina, value)));
        }
    }
}
