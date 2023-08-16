using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MajoraAutoItemTracker.MemoryReader.Project64
{
    internal class P64EMWrapper
    {
        private const String PROCESS_NAME = "Project64-EM";
        private const String MODULE_NAME = "GLideN64.dll";
        
        // FIXME: Duplicate
        const int OOT_START_ADRESS = 0x4B46BB4;
        const int MM_START_ADRESS = 0x4B46BB4; // 0x4B46BB4

        private Process m_Process;
        private ProcessModule m_Module;
        private int m_romAddrStart;

        public bool AttachToProcess()
        {
            try {
                var processList = Process.GetProcessesByName(PROCESS_NAME);
                if (processList.Length == 0)
                    throw new Exception($"Unable to find process: {PROCESS_NAME}");
                m_Process = processList[0];
                foreach (ProcessModule module in m_Process.Modules )
                {
                    if (module.ModuleName.ToLower() == MODULE_NAME.ToLower()) {
                        m_Module = module;
                        break;
                    }
                }
                if (m_Module == null)
                    throw new Exception($"Unable to find module: {MODULE_NAME} in process {PROCESS_NAME}");

                // Option 2 to find offset
                // Src: https://github.com/Selene-T/Tracker-of-Time/blob/main/attachToEmulators.vb
                // I have found 3 different addresses when connecting to project 64
                foreach (ProcessModule module in m_Process.Modules)
                {
                    IntPtr romAddrStart = module.BaseAddress;
                    // Try to read what should be the first part of the ZELDAZ check
                    uint ootCheck = 0;
                    try {
                        var adress = romAddrStart + 0x11A5EC;
                        ootCheck = Memory.readUInt32(m_Process, adress);
                    } catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                    //If it matches, set emulator variable and leave the FOR LOOP
                    if (ootCheck == 1514490948)
                        return true;
                }


                // Find start adress
                m_romAddrStart = Memory.readInt32(m_Process, m_Module.BaseAddress + MM_START_ADRESS);
                // TODO: Add check to confirm we read correct rom
                return true; 
            } catch (Exception e) { 
                Debug.WriteLine(e);
                return false;
            }
        }

        public int readInt8(int offset)
        {
            return Memory.readInt8(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public int readInt16(int offset)
        {
            return Memory.readInt16(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public int readInt32(int offset)
        {
            return Memory.readInt32(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public uint readUInt32(int offset)
        {
            return Memory.readUInt32(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public byte[] readByte(int offset, int bytesToRead)
        {
            return Memory.readBytes(m_Process, new IntPtr(m_romAddrStart) + offset, bytesToRead);
        }

        public bool ReadNotFF(int offset)
        {
            var address = readInt8(offset);
            return address != 0xFF;
        }

        public bool ReadItem(int offset, int itemValue)
        {
            var address = readInt8(offset);
            return (address & itemValue) == address;
        }

        public bool CheckHexRaised(int offset, int bitRaised)
        {
            var b = readByte(offset, 1)[0];
            //Debug.WriteLine("byteArray: " + b);
            //Debug.WriteLine("shift0: " + (b & (1 << 0)));
            //Debug.WriteLine("shift1: " + (b & (1 << 1)));
            //Debug.WriteLine("shift2: " + (b & (1 << 2)));
            //Debug.WriteLine("shift3: " + (b & (1 << 3)));
            //Debug.WriteLine("shift4: " + (b & (1 << 4)));
            //Debug.WriteLine("shift5: " + (b & (1 << 5)));
            //Debug.WriteLine("shift6: " + (b & (1 << 6)));
            //Debug.WriteLine("shift7: " + (b & (1 << 7)));
            return (b & (1 << bitRaised)) != 0;
        }

        public static void Test()
        {
            Console.WriteLine("Test");
            new P64EMWrapper().AttachToProcess();
        }

    }
}
