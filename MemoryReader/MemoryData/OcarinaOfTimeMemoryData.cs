﻿using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.MemoryReader.MemoryData
{
    class OcarinaOfTimeMemoryData : AbstractMemoryData
    {

        #region INVENTORY C-Button Items

        public bool HasOcarina = false;

        #endregion

        public override void ReadDataFromEmulator(AbstractEmulatorWrapper emulatorWrapper)
        {
            HasOcarina = !emulatorWrapper.ReadAndCheckIsFF(Model.OOTOffsets.CST_INVENTORY_OCARINA);
        }
    }

    class OcarinaOfTimeMemoryDataObserver : AbstractMemoryDataObserver
    {
        #region INVENTORY C-Button Items

        public ReplaySubject<bool> HasOcarina = new ReplaySubject<bool>(1);

        #endregion

        public override void BindAllEvent(ReplaySubject<Tuple<ItemLogicPopertyName, object>> replaySubject)
        {
            HasOcarina.Subscribe(value => replaySubject.OnNext(new Tuple<ItemLogicPopertyName, object>(ItemLogicPopertyName.ImgOcarina, value)));
        }
    }
}
