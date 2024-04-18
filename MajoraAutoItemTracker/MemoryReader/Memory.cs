using Reloaded.Memory.Sigscan.Definitions.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

#nullable enable

namespace MajoraAutoItemTracker
{
    public struct SYSTEM_INFO
    {
        public ushort processorArchitecture;
        ushort reserved;
        public uint pageSize;
        public IntPtr minimumApplicationAddress;  // minimum address
        public IntPtr maximumApplicationAddress;  // maximum address
        public IntPtr activeProcessorMask;
        public uint numberOfProcessors;
        public uint processorType;
        public uint allocationGranularity;
        public ushort processorLevel;
        public ushort processorRevision;
    }

    public struct MEMORY_BASIC_INFORMATION
    {
        public int BaseAddress;
        public int AllocationBase;
        public int AllocationProtect;
        public int RegionSize;   // size of the region allocated by the program
        public int State;   // check if allocated (MEM_COMMIT)
        public int Protect; // page protection (must be PAGE_READWRITE)
        public int lType;
    }

    internal class Memory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, IntPtr dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, UInt64 lpBaseAddress, byte[] lpBuffer, IntPtr dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        private static bool FindModuleBaseAddressAndMemorySize(
            Process process,
            string moduleName,
            out int baseAddress,
            out int moduleMemoryName
        )
        {
            foreach (var module in process.Modules)
            {
                if (module is ProcessModule && ((ProcessModule)module).ModuleName == moduleName)
                {
                    baseAddress = (module as ProcessModule)!.BaseAddress.ToInt32();
                    moduleMemoryName = (module as ProcessModule)!.ModuleMemorySize;
                    return true;
                }
            }
            baseAddress = -1;
            moduleMemoryName = -1;
            return false;
        }

        private static List<int> FindListInMemoryPerChunk(
            Reloaded.Memory.ExternalMemory externalMemory,
            int startAddress,
            int memorySize,
            string hexPattern,
            int consumingChunkSize = 20248
        )
        {
            List<int> listAddressLocation = new List<int>();
            bool addressFound;
            int currentAdrressLookup = startAddress;
            int remainingMemorySize = memorySize;
            do
            {
                addressFound = Memory.FindInMemoryPerChunk(
                    externalMemory,
                    currentAdrressLookup/*startAddress*/,
                    remainingMemorySize/*memorySize*/,
                    hexPattern,
                    out int addressLocation,
                    consumingChunkSize
                );

                if (addressFound)
                {
                    var zeldazPart1 = externalMemory.Read<uint>((uint)addressLocation);
                    var zeldazPart2 = externalMemory.Read<uint>((uint)addressLocation + 4);
                    Console.WriteLine(
                        $"ZELDAZ found at address {addressLocation.ToString("X")}, " +
                        $"value part1={zeldazPart1.ToString("X")} " +
                        $"part2={zeldazPart2.ToString("X")}"
                    );
                    listAddressLocation.Add(addressLocation);
                    currentAdrressLookup = addressLocation + (hexPattern.Replace(" ", "").Count() / 2);
                    remainingMemorySize = memorySize - (addressLocation - startAddress) - (hexPattern.Replace(" ", "").Count() / 2);
                }
            } while (addressFound);
            return listAddressLocation;
        }

        private static bool FindInMemoryPerChunk(
            Reloaded.Memory.ExternalMemory externalMemory,
            int startAddress,
            int memorySize,
            string hexPattern,
            out int addressFound,
            int consumingChunkSize = 20048
        )
        {
            var remainingSize = memorySize;

            var dataAsByteArray = externalMemory.ReadRaw((uint)startAddress, memorySize);
            var findResult = new Reloaded.Memory.Sigscan.Scanner(dataAsByteArray).FindPattern(hexPattern);

            PatternScanResult[] findResultArray;
            using (var memoryScanner = new Reloaded.Memory.Sigscan.Scanner(dataAsByteArray))
            {
                findResultArray = memoryScanner.FindPatterns(new String[] { hexPattern });
            }
            addressFound = findResult.Offset;
            return findResult.Found;
        }

        public static List<int> FindMultipleInProcessModule(Process process,string moduleName,string hexPattern)
        {
            if (!FindModuleBaseAddressAndMemorySize(process, moduleName, out int baseAddress, out int moduleMemorySize))
                return new List<int>();
            var externalMemory = new Reloaded.Memory.ExternalMemory(process);
            return FindListInMemoryPerChunk(
                externalMemory,
                baseAddress,
                moduleMemorySize,
                hexPattern
            );
        }

        public static bool FindInProcessModule(
            Process process, 
            string moduleName, 
            string hexPattern,
            out int addressLocation
        )
        {
            addressLocation = -1;
            if (!FindModuleBaseAddressAndMemorySize(process, moduleName, out int baseAddress, out int moduleMemorySize))
                return false;
            var externalMemory = new Reloaded.Memory.ExternalMemory(process);
            bool addressFound = FindInMemoryPerChunk(
                externalMemory,
                baseAddress,
                moduleMemorySize,
                hexPattern,
                out addressLocation
            );
            if (addressFound)
            {
                var zeldazPart1 = externalMemory.Read<uint>((uint)addressLocation);
                var zeldazPart2 = externalMemory.Read<uint>((uint)addressLocation + 4);
                Console.WriteLine(
                    $"ZELDAZ found at address {addressLocation.ToString("X")}, " +
                    $"value part1={zeldazPart1.ToString("X")} " +
                    $"part2={zeldazPart2.ToString("X")}"
                );
            }
            return addressFound;
        }

        #region read data

        public static int ReadInt8(Process p, UIntPtr address, bool bigEndian)
        {
            return ReadBytes(p, address, 1, bigEndian)[0];
        }

        public static int ReadInt16(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToInt16(ReadBytes(p, address, 2, bigEndian), 0);
        }

        public static int ReadInt32(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToInt32(ReadBytes(p, address, 4, bigEndian), 0);
        }

        public static uint ReadUInt32(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToUInt32(ReadBytes(p, address, 4, bigEndian), 0);
        }

        public static byte[] ReadBytes(Process p, UIntPtr address, int bytesToRead, bool bigEndian)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[bytesToRead];
            IntPtr bufferLength = new IntPtr(buffer.Length);
            ReadProcessMemory(p.Handle, address, buffer, bufferLength, ref bytesRead);
            if (bigEndian)
                return buffer;
            else
                return buffer.Reverse().ToArray();
        }

        #endregion

        #region write data

        private static bool Write16(Process p, IntPtr address, Int16 value)
        {
            return WriteBytes(p, address, BitConverter.GetBytes(value), 2);
        }

        private static bool Write32(Process p, IntPtr address, int value)
        {
            return WriteBytes(p, address, BitConverter.GetBytes(value), 4);
        }

        private static bool WriteBytes(Process p, IntPtr address, byte[] bytes, int length)
        {
            IntPtr bytesWritten;
            return WriteProcessMemory(p.Handle, address, bytes, length, out bytesWritten);
        }

        #endregion
    }
}
