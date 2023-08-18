using MajoraAutoItemTracker.MemoryReader;
using System.Collections.Generic;
using System.Reactive.Subjects;

namespace MajoraAutoItemTracker.UI.MainUI
{
    class EmulatorController
    {

        public ReplaySubject<List<AbstractEmulatorWrapper>> subEmulatorList = new ReplaySubject<List<AbstractEmulatorWrapper>>();

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
    }
}
