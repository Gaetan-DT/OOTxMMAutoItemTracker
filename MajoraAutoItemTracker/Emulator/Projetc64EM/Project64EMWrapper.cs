using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MajoraAutoItemTracker.MemoryReader.Projetc64EM
{
    class Project64EMWrapper : AbstractRomController
    {
        const string PROCESS_NAME = "Project64-EM";

        private string[] arrayOcarinaOfTimePattern = new string[]
        {
            "44 4C 45 5A ?? 00 5A 41 DF DF AB AB DF DF DF DF",
            "44 4C 45 5A ?? 00 5A 41 AB AB AB AB AB AB AB AB",
        };

        private const string ZeldazPatternMM = "44 4C 45 5A ?? 00 5A 41"; // 
        //private const string ZeldazPatternLoopUpLe = "44 4C 45 5A 07 00 5A 41"; // IDK why last byte can be different

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
                    foreach (var ootPattern in arrayOcarinaOfTimePattern)
                    {
                        listpossibleMemory = MemoryScanner.ScannMultipleMemoryBeta(m_Process, ootPattern);
                        foreach (var possibleMemory in listpossibleMemory)
                        {
                            ootAddrStart = possibleMemory - OOTOffsets.ZELDAZ_CHECK_ADDRESS;
                            if (PerformCheckFollowingRomType(CurrentRom.OcarinaOfTIme, ootAddrStart))
                            {
                                UpdateStoredMemoryAddress(CurrentRom.OcarinaOfTIme, ootAddrStart);
                                return true;
                            }
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
