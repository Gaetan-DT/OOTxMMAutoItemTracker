using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader.Projetc64EM
{
    class Project64EMWrapper : AbstractRomController
    {
        const String PROCESS_NAME = "Project64-EM";

        /** Same for MM and OOT **/
        private const string ZeldazPatternLoopUpLe = "44 4C 45 5A ?? 00 5A 41 DF DF AB AB DF DF DF DF";
        private const string ZeldazPatternMM = "44 4C 45 5A ?? 00 5A 41"; // 
        //private const string ZeldazPatternLoopUpLe = "44 4C 45 5A 07 00 5A 41"; // IDK why last byte can be different

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

        public override bool FindRomStartAndRomType(out uint romStart, out CurrentRom romType)
        {
            if (DoFindStart(CurrentRom.OcarinaOfTIme, out romStart))
            {
                romType = CurrentRom.OcarinaOfTIme;
                return true;
            }
            else if (DoFindStart(CurrentRom.MajoraMask, out romStart))
            {
                romType = CurrentRom.MajoraMask;
                return true;
            }                
            else
            {
                romType = CurrentRom.Unknown;
                return false;
            }
        }

        public override bool FindRomStartForRomType(out uint romStart, CurrentRom romType)
        {
            return DoFindStart(romType, out romStart);
        }

        public override bool AttachToProcess(RomType romType)
        {
            try
            {
                m_Process = FindProcessOrThrow();
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

        private bool DoFindStart(CurrentRom currentRom, out uint ootAddrStart)
        {
            if (m_Process == null)
            {
                throw new Exception("Process is null");
            }
            var possibleSavedMemory = GetStoredMemoryAddress(currentRom);
            if (PerformCheckFollowingRomType(currentRom, possibleSavedMemory))
            {
                ootAddrStart = possibleSavedMemory;
                return true;
            }
            List<uint> listpossibleMemory;
            switch (currentRom)
            {
                case CurrentRom.MajoraMask:
                    listpossibleMemory = MemoryScanner.ScannMultipleMemoryBeta(m_Process, ZeldazPatternMM);
                    foreach (var possibleMemory in listpossibleMemory)
                    {
                        ootAddrStart = possibleMemory - MMOffsets.ZELDAZ_CHECK_ADDRESS;
                        if (PerformCheckFollowingRomType(CurrentRom.MajoraMask, ootAddrStart))
                        {
                            UpdateStoredMemoryAddress(CurrentRom.MajoraMask, ootAddrStart);
                            return true;
                        }
                    }
                    ootAddrStart = 0;
                    return false;
                case CurrentRom.OcarinaOfTIme:
                    listpossibleMemory = MemoryScanner.ScannMultipleMemoryBeta(m_Process, ZeldazPatternLoopUpLe);
                    foreach (var possibleMemory in listpossibleMemory)
                    {
                        ootAddrStart = possibleMemory - OOTOffsets.ZELDAZ_CHECK_ADDRESS;
                        if (PerformCheckFollowingRomType(CurrentRom.OcarinaOfTIme, ootAddrStart))
                        {
                            UpdateStoredMemoryAddress(CurrentRom.OcarinaOfTIme, ootAddrStart);
                            return true;
                        }
                    }
                    ootAddrStart = 0;
                    return false;                    
                case CurrentRom.Unknown:
                default:
                    throw new Exception("Unknown rom start");
            }
        }
    }
}
