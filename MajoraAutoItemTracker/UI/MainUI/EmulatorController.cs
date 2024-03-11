using MajoraAutoItemTracker.MemoryReader;
using MajoraAutoItemTracker.Model.Enum;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class EmulatorController
    {

        public readonly BehaviorSubject<List<EmulatorName>> subEmulatorList = new BehaviorSubject<List<EmulatorName>>(new List<EmulatorName>());
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
            var list = RomTypeMethod.getAsList();
            list.Reverse(); // To display oot x mm first
            subRomList.OnNext(list);
        }

        public EmulatorName GetSelectedEmulator(int index)
        {
            return subEmulatorList.Value[index];
        }

        public RomType GetSelectedRomType(int index)
        {
            return subRomList.Value[index];
        }
    }
}
