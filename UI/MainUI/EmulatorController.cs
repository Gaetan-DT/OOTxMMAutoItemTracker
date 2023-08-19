using MajoraAutoItemTracker.MemoryReader;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class EmulatorController
    {

        public BehaviorSubject<List<AbstractEmulatorWrapper>> subEmulatorList = new BehaviorSubject<List<AbstractEmulatorWrapper>>(new List<AbstractEmulatorWrapper>());

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
            //TODO: Implement game gestion
        }

        public AbstractEmulatorWrapper GetSelectedEmulator(int index)
        {
            if (index < 0)
                return null;
            return subEmulatorList.Value[index];
        }
    }
}
