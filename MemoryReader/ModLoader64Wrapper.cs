using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MajoraAutoItemTracker
{
    class ModLoader64Wrapper
    {
        #region Constants

        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const String MODE_LOADER_PROCESS_NAME = "modloader64-gui";
        const String MODE_LOADER_MUPEN_DLL = "mupen64plus.dll";
        const int OOT_START_ADRESS = 0x4B46BB4;
        const int MM_START_ADRESS = 0x4B46BB4; // 0x4B46BB4

        const bool useBigE = true;

        #endregion

        private static Process m_Process;
        private static ProcessModule m_Module;
        private static uint m_romAddrStart;

        public ModLoader64Wrapper()
        {
            var result = attachToModLoader64x86();
            if (!result)
                throw new Exception("Unable to attache to mod loader 64");
        }

        private bool attachToModLoader64x86()
        {
            try
            {
                var processList = Process.GetProcessesByName(MODE_LOADER_PROCESS_NAME);
                if (processList.Length == 0)
                    return false;
                foreach (var process in processList)
                    foreach (ProcessModule module in process.Modules)
                        if (module.ModuleName.ToLower() == MODE_LOADER_MUPEN_DLL)
                        {
                            m_Process = process;
                            m_Module = module;
                            m_romAddrStart = Memory.ReadUInt32(process, new UIntPtr((uint)(module.BaseAddress + MM_START_ADRESS)), useBigE);
                            Debug.WriteLine("Start address: " + Convert.ToString(m_romAddrStart, 16));
                            var foo = BitConverter.ToString(Memory.ReadBytes(m_Process, new UIntPtr(m_romAddrStart) + 0x9F6853, 8, useBigE));
                            // TODO: Add check to confirm we read correct rom
                            return true;
                        }
            } 
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return false;
        }

        
        public int readInt8(int offset)
        {
            return Memory.ReadInt8(m_Process, new UIntPtr(m_romAddrStart) + offset, useBigE);          
        }

        public int readInt16(int offset)
        {
            return Memory.ReadInt16(m_Process, new UIntPtr(m_romAddrStart) + offset, useBigE);
        }

        public int readInt32(int offset)
        {
            return Memory.ReadInt32(m_Process, new UIntPtr(m_romAddrStart) + offset, useBigE);
        }

        public uint readUInt32(int offset)
        {
            return Memory.ReadUInt32(m_Process, new UIntPtr(m_romAddrStart) + offset, useBigE);
        }

        public byte[] readByte(int offset, int bytesToRead)
        {
            return Memory.ReadBytes(m_Process, new UIntPtr(m_romAddrStart) + offset, bytesToRead, useBigE);
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
    }
}
