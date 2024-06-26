﻿using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader
{
    public enum EmulatorName
    {
        Project64EM
    }

    class EmulatorWrapperProvider
    {
        private static IEnumerable<EmulatorName> GetArrayEmulator()
        {
            return Enum.GetValues(typeof(EmulatorName)).Cast<EmulatorName>();
        }

        public static AbstractRomController? CreateEmulatorFromEnum(
            EmulatorName emulatorName,
            CurrentRom currentRom)
        {
            switch (emulatorName)
            {
                case EmulatorName.Project64EM:
                    return new Projetc64EM.Project64EMWrapper(currentRom);
                default:
                    return null;
            }
        }

        public static List<EmulatorName> ProvideEmulatorWrapperList()
        {
            var result = new List<EmulatorName>();
            foreach (var emulatorWrapper in GetArrayEmulator())
                //if (emulatorWrapper.ProcessExist())
                    result.Add(emulatorWrapper);
            return result;
        }
    }
}
