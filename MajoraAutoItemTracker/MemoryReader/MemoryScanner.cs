using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MajoraAutoItemTracker.MemoryReader
{
    class MemoryScanner
    {

        public static bool ScannMemoryBeta(Process process, string pattern, out uint patternStartAddres)
        {
            return MemoryScannerBeta.ScannMemoryBeta(process, pattern, out patternStartAddres);
        }

        public static List<uint> ScannMultipleMemoryBeta(Process process, string pattern)
        {
            return MemoryScannerBeta.ScannMemoryListBeta(process, pattern);
        }

    }

    internal class MemoryScannerBeta
    {

        const uint DEFAULT_STEP = 0x000f_0000;
        // Project64 EM matching -> 44 4C 45 5A 07 00 5A 41

        public static List<uint> ScannMemoryListBeta(
            Process process,
            string pattern,
            uint step = DEFAULT_STEP
        )
        {
            var listUintFound = new List<uint>();
            uint offset = 0;
            while (offset < uint.MaxValue)
            {
                byte[] result = new byte[step];
                int nbByteRead = 0;
                Memory.ReadProcessMemory(process.Handle, new UIntPtr(offset), result, new IntPtr(step), ref nbByteRead);
                using (var scanner = new Reloaded.Memory.Sigscan.Scanner(result))
                {
                    var foudAddress = FindMultipleSigscan(scanner, pattern, offset);
                    listUintFound.AddRange(foudAddress);
                }
                if ((offset + step) <= offset)
                    offset = uint.MaxValue;
                else
                    offset += step;
            }
            return listUintFound;
        }

        public static bool ScannMemoryBeta(
            Process process, 
            string pattern, 
            out uint patternStartAddres,
            uint step = DEFAULT_STEP
        )
        {
            var listUintFound = ScannMemoryListBeta(process, pattern, step);
            patternStartAddres = listUintFound.FirstOrDefault();
            return listUintFound.Count != 0;
        }

        private static List<uint> FindMultipleSigscan(Reloaded.Memory.Sigscan.Scanner scanner, string pattern, uint baseOffSet)
        {
            bool canContinue = false;
            var listResult = new List<uint>();
            uint patternOffset = 0;
            do
            {
                var scanResult = scanner.FindPattern(pattern, (int)patternOffset);
                if (scanResult.Found)
                {
                    uint addressFound = (baseOffSet + (uint)scanResult.Offset);
                    listResult.Add(addressFound);
                    patternOffset = ((uint)scanResult.Offset + (uint)1);
                }
                canContinue = scanResult.Found;
            } while (canContinue);
            return listResult;
        }
    }
}
