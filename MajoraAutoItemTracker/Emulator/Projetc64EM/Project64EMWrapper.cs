using MajoraAutoItemTracker.Core.Extensions;
using MajoraAutoItemTracker.Core.Utils;
using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Enum;
using MajoraAutoItemTracker.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MajoraAutoItemTracker.MemoryReader.Projetc64EM
{
    public class Project64EMWrapper : AbstractRomController
    {
        const string PROCESS_NAME = "Project64-EM";

        // More info: https://wiki.cloudmodding.com/oot/Save_Format#Save_Context
        private const string zeldazPatternOot = "44 4C 45 5A ?? ?? ?? 41";

        private const string ZeldazPatternMM = "44 4C 45 5A ?? 00 5A 41"; // 
        //private const string ZeldazPatternLoopUpLe = "44 4C 45 5A 07 00 5A 41"; // IDK why last byte can be different

        protected override bool IsEmulatorUseBigEndian => true;

        public Project64EMWrapper(CurrentRom currentRom): base(currentRom)
        {

        }

        protected override bool FindRomStartForRomType(out uint romStart, CurrentRom romType)
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
            var possibleSavedMemory = RomUtils.GetStoredMemoryAddress(currentRom);
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
                            RomUtils.UpdateStoredMemoryAddress(CurrentRom.MajoraMask, ootAddrStart);
                            return true;
                        }
                    }
                    ootAddrStart = 0;
                    return false;
                case CurrentRom.OcarinaOfTIme:
                    listpossibleMemory = MemoryScanner.ScannMultipleMemoryBeta(m_Process, zeldazPatternOot);
                    List<KeyValuePair<uint, string>> listPairSaveNameMemory = ReadFileNameFromZeldazAddress(listpossibleMemory);
                    var selectedMemory = EmitAskForSaveFile(listPairSaveNameMemory);
                    if (selectedMemory != null)
                    {
                        ootAddrStart = selectedMemory.Value - OOTOffsets.ZELDAZ_CHECK_ADDRESS;
                        if (PerformCheckFollowingRomType(CurrentRom.OcarinaOfTIme, ootAddrStart))
                        {
                            RomUtils.UpdateStoredMemoryAddress(CurrentRom.OcarinaOfTIme, ootAddrStart);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ootAddrStart = 0;
                        return false;
                    }
                case CurrentRom.Unknown:
                default:
                    throw new Exception("Unknown rom start");
            }
        }

        private List<KeyValuePair<uint, string>> ReadFileNameFromZeldazAddress(List<uint> zeldaAddrsList)
        {
            var result = new List<KeyValuePair<uint, string>>();
            foreach (var zeldaAddrs in zeldaAddrsList)
            {
                try
                {
                    var startTemplate = zeldaAddrs + 8;
                    var saveNameByteArray = Memory.ReadBytes(
                        m_Process!,
                        new UIntPtr(startTemplate),
                        8,
                        IsEmulatorUseBigEndian);
                    var fileName = RomUtils.ConvertRomNameToString(saveNameByteArray);
                    if (fileName != null)
                        result.Add(new KeyValuePair<uint, string>(zeldaAddrs, fileName));
                } catch (Exception e) { 
                    Debug.WriteLine(e.Message);
                }
            }
            return result;
        }

        private uint? EmitAskForSaveFile(List<KeyValuePair<uint, string>> listMemFileName)
        {
            /*if (listMemFileName.Count == 0)
                return null;
            else if (listMemFileName.Count == 1)
                return listMemFileName[0].Key;*/

            List<string> dataToDisplay = listMemFileName
                .Select((it) => $"{it.Key:X} - {it.Value}")
                .ToList();
            int selectedSaveIndex = -1;
            DialogListBox.Show(
                "Select save",
                "Select save",
                dataToDisplay,
                ref selectedSaveIndex);
            if (selectedSaveIndex == -1)
                return null;
            return listMemFileName[selectedSaveIndex].Key;
        }
    }
}
