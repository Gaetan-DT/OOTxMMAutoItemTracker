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

        #endregion

        private static Process m_Process;
        private static ProcessModule m_Module;
        private static int m_romAddrStart;

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
                            m_romAddrStart = Memory.readInt32(process, module.BaseAddress + MM_START_ADRESS);
                            Debug.WriteLine("Start address: " + Convert.ToString(m_romAddrStart, 16));
                            var foo = BitConverter.ToString(Memory.readBytes(m_Process, new IntPtr(m_romAddrStart) + 0x9F6853, 8));
                            Debug.WriteLine("Foo: " + foo);
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
            Debug.WriteLine("Reading 8bit starting offset: " + offset);
            return Memory.readInt8(m_Process, new IntPtr(m_romAddrStart) + offset);          
        }

        public int readInt16(int offset)
        {
            Debug.WriteLine("Reading 16bit starting offset: " + offset);
            return Memory.readInt16(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public int readInt32(int offset)
        {
            Debug.WriteLine("Reading 32bit starting offset: " + offset);
            return Memory.readInt32(m_Process, new IntPtr(m_romAddrStart) + offset);
        }

        public uint readUInt32(int offset)
        {
            Debug.WriteLine("Reading 32 unsigned bit starting offset: " + offset);
            return Memory.readUInt32(m_Process, new IntPtr(m_romAddrStart) + offset);
        }
    }
}
