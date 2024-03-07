using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader
{
    class MemoryScanner
    {

        public static bool ScannMemoryBeta(
            Process process,
            string pattern,
            out uint patternStartAddres
        )
        {
            return MemoryScannerBeta.ScannMemoryBeta(process, pattern, out patternStartAddres);
        }

    }

    internal class MemoryScannerBeta
    {

        const uint DEFAULT_STEP = 0x000f_0000;
        // Project64 EM matching -> 44 4C 45 5A 07 00 5A 41

        public static bool ScannMemoryBeta(
            Process process, 
            string pattern, 
            out uint patternStartAddres,
            uint step = DEFAULT_STEP
        )
        {
            var listUintFound = new List<uint>();
            uint offset = 0;
            while (offset < uint.MaxValue)
            {
                //var result = Memory.ReadBytes(process, new UIntPtr(offset), (int)step, false);
                byte[] result = new byte[step];
                int nbByteRead = 0;
                Memory.ReadProcessMemory(process.Handle, new UIntPtr(offset), result, new IntPtr(step), ref nbByteRead);
                var scanner = new Reloaded.Memory.Sigscan.Scanner(result);
                var foudAddress = FindMultipleSigscan(scanner, pattern, offset);
                listUintFound.AddRange(foudAddress);
                if ((offset + step) <= offset)
                    offset = uint.MaxValue;
                else
                    offset += step;
            }

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

        // Test code for debuging/doc purpose
        private static void Test1() 
        {
            uint addressAeldazPart1 = 0x4715A5EC;
            var process = Process.GetProcessesByName("Project64-EM")[0];
            var extMemory = new Reloaded.Memory.ExternalMemory(process);
            var foo = extMemory.Read<uint>(addressAeldazPart1);

            var temp = Memory.ReadBytes(process, new UIntPtr(addressAeldazPart1), 4, false); // 
            var tempFound = new Reloaded.Memory.Sigscan.Scanner(temp).FindPattern("5A 45 4C 44");
            Console.WriteLine($"Address to find: [{addressAeldazPart1.ToString("X")}]");
            Console.WriteLine($"Address Value to find ({tempFound.Found}) -> {0x5A454C44.ToString("X")}");
            Console.WriteLine("--------START LOOKING IN MEMORY ----------");
            //
            uint step = 0x000f_0000;
            var listUintFound = new List<uint>();
            uint offset = 0;
            while (offset < uint.MaxValue)
            {
                var isInLookingRange = addressAeldazPart1 >= offset && addressAeldazPart1 <= offset + step;
                if (isInLookingRange)
                    Console.WriteLine($" -> Checking range: [{offset.ToString("X")}] -> [{addressAeldazPart1.ToString("X")}] -> [{(offset + step).ToString("X")}]");
                //var result = Memory.ReadBytes(process, new UIntPtr(offset), (int)step, false);
                byte[] result = new byte[step];
                int nbByteRead = 0;
                Memory.ReadProcessMemory(process.Handle, new UIntPtr(offset), result, new IntPtr(step), ref nbByteRead);
                var scanner = new Reloaded.Memory.Sigscan.Scanner(result);
                string pattern1 = "5A 45 4C 44";
                string pattern2 = "44 4C 45 5A";
                var foudAddress = FindMultipleSigscan(scanner, pattern2, offset);
                listUintFound.AddRange(foudAddress);
                if ((offset + step) <= offset)
                    offset = uint.MaxValue;
                else
                    offset += step;

                if (isInLookingRange)
                    Console.WriteLine($" -> End of range, found {foudAddress.Count} address; nbByteRead={nbByteRead}");
            }
            Console.WriteLine("--------PARSING RESULT ----------");
            // Addesse location 1 "D L E Z" 
            // Addesse location 2 ". . Z A"

            // 5a 45 4c 44 41 5a 2e 2e

            // 5A45 4C44  4120 4D41
            // 5A45 4C44  4100 414E
            foreach (var addressToCheck in listUintFound)
            {
                var byteArraValue = Memory.ReadBytes(process, new UIntPtr(addressToCheck), 8, false);
                var valueToCheck = BitConverter.ToUInt64(Memory.ReadBytes(process, new UIntPtr(addressToCheck), 8, false), 0);
                Console.WriteLine($"Checking address: [{addressToCheck.ToString("X")}] " +
                    $"value => [{valueToCheck.ToString("X")}] " +
                    $"({Encoding.ASCII.GetString(byteArraValue)})");
                var perfectMatch = "444C455A07005A41";
                var isPerfectMatch = perfectMatch == valueToCheck.ToString("X");
                if (isPerfectMatch)
                    Console.WriteLine($"Perfect match found at addr -> {addressToCheck.ToString("X")}");
            }
            throw new Exception();
        }

    }
}
