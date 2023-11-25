using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.MemoryReader.Projetc64EM
{
    class Project64EMWrapper : AbstractRomController
    {
        const String PROCESS_NAME = "Project64-EM";

        /** Same for MM and OOT **/
        private const string ZeldazPatternLoopUpLe = "44 4C 45 5A 07 00 5A 41";

        private const uint CST_POSSIBLE_ROM_ADDR_START_1 = 0xDFE4_0000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_2 = 0xDFE7_0000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_3 = 0xDFFB_0000;

        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_1 = 0x4CD8_19E8; // Not working
        private const uint CST_POSSIBLE_ROM_ADDR_START_EM_2 = 0x4CDA_0000;  // 
        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_3 = 0x4D2A_D69C;
        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_4 = 0x0011_A5EC;

        // Another possible address
        // 3AF3_BFD4
        // 3AF5_A5EC
        // 3B46_7C88
        // 3B47_0CC4

        //From cheat engin zeldaz start here:
        //          magic number
        // 0x4CE9BFD4 - 0x11A5EC  =
        // 0x4CEBA5EC - 0x11A5EC  =
        // 0x4D3C7C88 - 0x11A5EC  =
        // 0x4D3D0CC4 - 0x11A5EC  =

        private readonly uint[] CST_POSSIBLE_ROOM_ADDR_START = {
            CST_POSSIBLE_ROM_ADDR_START_1,
            CST_POSSIBLE_ROM_ADDR_START_2,
            CST_POSSIBLE_ROM_ADDR_START_3,
            //CST_POSSIBLE_ROM_ADDR_START_EM_1,
            CST_POSSIBLE_ROM_ADDR_START_EM_2,
            //CST_POSSIBLE_ROM_ADDR_START_EM_3,
            //CST_POSSIBLE_ROM_ADDR_START_EM_4
            //0x4D45A5EC - OOTOffsets.ZELDAZ_CHECK_ADDRESS,
        };

        protected override bool IsEmulatorUseBigEndian => true;

        public override bool AttachToProcess(RomType romType)
        {
            try
            {
                m_Process = FindProcessOrThrow();
                m_romAddrStart = FindStratAddressOrThrow(romType);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }

        public override bool ProcessExist()
        {
            return Process.GetProcessesByName(PROCESS_NAME).Length > 0;
        }

        public override string GetDisplayName()
        {
            return "Project64-EM";
        }

        public Process FindProcessOrThrow()
        {
            var processList = Process.GetProcessesByName(PROCESS_NAME);
            if (processList.Length == 0)
                throw new Exception($"Unable to find process: {PROCESS_NAME}");
            return processList[0];
        }

        public uint FindStratAddressOrThrow(RomType romType)
        {
            // Src: https://github.com/SM64-TAS-ABC/STROOP/blob/096d0ced5bd460b71022ac1da8c8800e95c4fb32/STROOP/Config/Config.xml#L19
            // ramStart seems to be at this adress "0x4BAF0000"
            if (PerformCheckFollowingRomType(romType, 0x4BAF0000))
                return 0x4BAF0000;

            // Option2
            // Src: 
            // I have found 3 different addresses when connecting to project 64
            foreach (uint romAddrStart in CST_POSSIBLE_ROOM_ADDR_START)
                if (PerformCheckFollowingRomType(romType, romAddrStart)) // ' Try to read what should be the first part of the ZELDAZ check
                    return romAddrStart;

            // Option 3, manualy lookup to process
            if (ScanMemoryToFindStart(out uint possibleAddrStart))
                return possibleAddrStart;

            throw new Exception("Process not found or unable to find Zelda check address");
        }

        private List<uint> findInAllModule(string pattern, bool log = false)
        {
            List<uint> listPossibleAddress = new List<uint>();
            foreach (var module in m_Process.Modules)
                if (module is ProcessModule)
                    listPossibleAddress.AddRange(findAllInModule(m_Process, (module as ProcessModule), pattern, log));
            return listPossibleAddress;
        }

        private static List<uint> findAllInModule(System.Diagnostics.Process process, ProcessModule module, string pattern, bool log)
        {
            List<uint> listPossibleAddress = new List<uint>();
            try
            {
                bool canContinue = false;
                Reloaded.Memory.ExternalMemory externalMemory = new Reloaded.Memory.ExternalMemory(process);
                uint patternSize = (uint)pattern.Replace(" ", "").Length / 2;
                uint remainingSize = (uint)module.ModuleMemorySize;
                uint baseAddress = (uint)module.BaseAddress;
                do
                {
                    var data = externalMemory.ReadRaw(baseAddress, (int)remainingSize);
                    var findResult = new Reloaded.Memory.Sigscan.Scanner(data).FindPattern(pattern);
                    if (findResult.Found)
                    {
                        uint possibleAddress = (uint)module.BaseAddress + (uint)findResult.Offset;
                        Console.WriteLine($"Found [{pattern}] at module: [{module.ModuleName}], address=[{possibleAddress.ToString("X")}]");
                        listPossibleAddress.Add(possibleAddress);
                        // Update offset and remaining size
                        baseAddress = (uint)module.BaseAddress + (uint)findResult.Offset + patternSize;
                        remainingSize -= (uint)findResult.Offset - patternSize;
                    }
                    canContinue = findResult.Found;
                } while (canContinue);

            }
            catch (Exception e)
            {
                if (log)
                    Console.WriteLine($"Unable to read process: {module.ModuleName}: {e.Message}");
            }
            return listPossibleAddress;
        }

        public bool ScanMemoryToFindStart(out uint ootAddrStart)
        {
            // 4713BFD4
            // 4715A5EC
            // 4766C56C
            // 47675824
            var result = MemoryScanner.ScannMemoryBeta(m_Process, ZeldazPatternLoopUpLe, out ootAddrStart);
            if (!result)
                return false;
            if (AskForStartMajoraMask()) // Find for MM
                ootAddrStart -= MMOffsets.ZELDAZ_CHECK_ADDRESS;
            else // Find for OOT
                ootAddrStart -= OOTOffsets.ZELDAZ_CHECK_ADDRESS;
            return result;
        }

        public static void Test()
        {
            var wrapper = new Project64EMWrapper();
            if (wrapper.AttachToProcess(RomType.OCARINA_OF_TIME_USA_V0))
            {
                var result5 = wrapper.ReadUint8InEdianSizeAsInt(Model.OOTOffsets.CST_INVENTORY_ADDRESS_OCARINA).ToString("X");
                // Ocarina oot adress: 0x0011A648 but 0x8011A64B in emulator memory acces
                // @see https://fr.wiktionary.org/wiki/big-endian & https://fr.wiktionary.org/wiki/little-endian
                Debug.WriteLine("result5: " + result5);
            }
            else
            {
                Debug.WriteLine("Unable to find process :(");
            }
        }
    }
}
