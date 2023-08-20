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

        private const uint CST_POSSIBLE_ROM_ADDR_START_1 = 0xDFE40000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_2 = 0xDFE70000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_3 = 0xDFFB0000;

        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_1 = 0x4CD8_19E8; // Not working
        private const uint CST_POSSIBLE_ROM_ADDR_START_EM_2 = 0x4CDA_0000;
        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_3 = 0x4D2A_D69C;
        //private const uint CST_POSSIBLE_ROM_ADDR_START_EM_4 = 0x0011_A5EC;

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

            // Option2
            // Src: 
            // I have found 3 different addresses when connecting to project 64
            foreach (uint romAddrStart in CST_POSSIBLE_ROOM_ADDR_START)
                if (PerformCheckFollowingRomType(romType, romAddrStart)) // ' Try to read what should be the first part of the ZELDAZ check
                    return romAddrStart;
            throw new Exception("Process not found or unable to find Zelda check address");
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
