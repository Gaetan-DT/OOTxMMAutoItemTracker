using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class EmulatorController
    {

        public readonly BehaviorSubject<List<AbstractEmulatorWrapper>> subEmulatorList = new BehaviorSubject<List<AbstractEmulatorWrapper>>(new List<AbstractEmulatorWrapper>());
        public readonly BehaviorSubject<List<RomType>> subRomList = new BehaviorSubject<List<RomType>>(RomTypeMethod.getAsList());

        public void RefreshEmulatorAndGameList()
        {
            RefreshEmulatorList();
            RefreshGameList();
        }

        private void RefreshEmulatorList()
        {
            subEmulatorList.OnNext(EmulatorWrapperProvider.ProvideEmulatorWrapperList());
        }

        private void RefreshGameList()
        {
            subRomList.OnNext(RomTypeMethod.getAsList());
        }

        public AbstractEmulatorWrapper GetSelectedEmulator(int index)
        {
            return subEmulatorList.Value[index];
        }

        public RomType GetSelectedRomType(int index)
        {
            return subRomList.Value[index];
        }
    }
}
