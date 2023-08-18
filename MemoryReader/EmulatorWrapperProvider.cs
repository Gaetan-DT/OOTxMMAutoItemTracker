using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.MemoryReader
{
    class EmulatorWrapperProvider
    {
        private static AbstractEmulatorWrapper[] GetArrayEmulator()
        {
            return new AbstractEmulatorWrapper[]
            {
                new Project64.Project64Wrapper(),
                new Projetc64EM.Project64EMWrapper()
            };
        }

        public static AbstractEmulatorWrapper ProvideEmulatorWrapper()
        {
            foreach (var emulatorWrapper in GetArrayEmulator())
                if (emulatorWrapper.AttachToProcess())
                    return emulatorWrapper;
            throw new Exception("No emulator found");
        }

        public static List<AbstractEmulatorWrapper> ProvideEmulatorWrapperList()
        {
            List<AbstractEmulatorWrapper> result = new List<AbstractEmulatorWrapper>();
            foreach ( var emulatorWrapper in GetArrayEmulator() )
                if (emulatorWrapper.AttachToProcess())
                    result.Add(emulatorWrapper);
            return result;
        }
    }
}
