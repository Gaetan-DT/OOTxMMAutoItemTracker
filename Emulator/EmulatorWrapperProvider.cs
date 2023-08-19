using System;
using System.Collections.Generic;

namespace MajoraAutoItemTracker.MemoryReader
{
    class EmulatorWrapperProvider
    {
        private static AbstractRomController[] GetArrayEmulator()
        {
            return new AbstractRomController[]
            {
                new Project64.Project64Wrapper(),
                new Projetc64EM.Project64EMWrapper(),
                new ModLoader64.ModLoader64Wrapper()
            };
        }

        public static AbstractRomController ProvideEmulatorWrapper()
        {
            foreach (var emulatorWrapper in GetArrayEmulator())
                if (emulatorWrapper.ProcessExist())
                    return emulatorWrapper;
            throw new Exception("No emulator found");
        }

        public static List<AbstractRomController> ProvideEmulatorWrapperList()
        {
            List<AbstractRomController> result = new List<AbstractRomController>();
            foreach ( var emulatorWrapper in GetArrayEmulator() )
                if (emulatorWrapper.ProcessExist())
                    result.Add(emulatorWrapper);
            return result;
        }
    }
}
