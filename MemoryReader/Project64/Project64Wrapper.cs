using System;
using System.Diagnostics;

namespace MajoraAutoItemTracker.MemoryReader.Project64
{
    internal class Project64Wrapper : AbstractEmulatorWrapper
    {
        const String PROCESS_NAME = "Project64";

        private const uint ZELDAZ_ADDRESS = 0xA800003C; // Size 4byte ?

        private const uint CST_POSSIBLE_ROM_ADDR_START_1 = 0xDFE40000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_2 = 0xDFE70000;
        private const uint CST_POSSIBLE_ROM_ADDR_START_3 = 0xDFFB0000;

        private readonly uint[] CST_POSSIBLE_ROOM_ADDR_START = {
            CST_POSSIBLE_ROM_ADDR_START_1,
            CST_POSSIBLE_ROM_ADDR_START_2,
            CST_POSSIBLE_ROM_ADDR_START_3
        };

        protected override bool IsEmulatorUseBigEndian => true;

        public override bool AttachToProcess()
        {
            try {
                m_Process = FindProcessOrThrow();
                m_romAddrStart = FindStratAddressOrThrow();
                return true;
            } catch (Exception e) { 
                Debug.WriteLine(e);
                return false;
            }
        }

        public Process FindProcessOrThrow()
        {
            var processList = Process.GetProcessesByName(PROCESS_NAME);
            if (processList.Length == 0)
                throw new Exception($"Unable to find process: {PROCESS_NAME}");
            return processList[0];
        }
        
        public uint FindStratAddressOrThrow()
        {
            // Src: https://github.com/SM64-TAS-ABC/STROOP/blob/096d0ced5bd460b71022ac1da8c8800e95c4fb32/STROOP/Config/Config.xml#L19
            // ramStart seems to be at this adress "0x4BAF0000"

            // Option2
            // Src: 
            // I have found 3 different addresses when connecting to project 64
            foreach (uint romAddrStart in CST_POSSIBLE_ROOM_ADDR_START)
            {
                // ' Try to read what should be the first part of the ZELDAZ check
                int ootCheck = 0;
                try
                {
                    ootCheck = Memory.ReadInt32(m_Process, new UIntPtr(romAddrStart + 0x11A5EC), IsEmulatorUseBigEndian);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                if (ootCheck == GetZeldaCheckFollowingEndian())
                    return romAddrStart;
            }
            throw new Exception("Process not found");
        }

        public static void Test()
        {
            var wrapper = new Project64Wrapper();
            if (wrapper.AttachToProcess())
            {
                var result5 = wrapper.ReadUint8InEdianSize(Model.OOTOffsets.CST_INVENTORY_OCARINA).ToString("X");
                // Ocarina oot adress: 0x0011A648 but 0x8011A64B in emulator memory acces
                // @see https://fr.wiktionary.org/wiki/big-endian & https://fr.wiktionary.org/wiki/little-endian
                Debug.WriteLine("result5: " + result5);
            } else
            {
                Debug.WriteLine("Unable to find process :(");
            }
        }
    }
}
