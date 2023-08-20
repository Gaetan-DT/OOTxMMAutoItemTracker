using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class EmulatorController
    {

        public readonly BehaviorSubject<List<AbstractRomController>> subEmulatorList = new BehaviorSubject<List<AbstractRomController>>(new List<AbstractRomController>());
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

        public AbstractRomController GetSelectedEmulator(int index)
        {
            return subEmulatorList.Value[index];
        }

        public RomType GetSelectedRomType(int index)
        {
            return subRomList.Value[index];
        }
    }
}
