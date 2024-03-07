using MajoraAutoItemTracker.Model.Enum;
using System;
using System.Diagnostics;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader.ModLoader64
{
    class ModLoader64Wrapper : AbstractRomController
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

        protected override bool IsEmulatorUseBigEndian => false;

        public override bool AttachToProcess(RomType romType)
        {
            return attachToModLoader64x86(romType);
        }

        public override bool ProcessExist()
        {
            return System.Diagnostics.Process.GetProcessesByName(MODE_LOADER_PROCESS_NAME).Length > 0;
        }

        public override string GetDisplayName()
        {
            return "ModLoader64";
        }

        private bool attachToModLoader64x86(RomType romType)
        {
            if (romType != RomType.MAJORA_MASK_USA_V0)
                throw new Exception("Not yet supported for modloader64");
            try
            {
                var processList = System.Diagnostics.Process.GetProcessesByName(MODE_LOADER_PROCESS_NAME);
                if (processList.Length == 0)
                    return false;
                foreach (var process in processList)
                    foreach (ProcessModule module in process.Modules)
                        if (module.ModuleName.ToLower() == MODE_LOADER_MUPEN_DLL)
                        {
                            m_Process = process;
                            m_romAddrStart = Memory.ReadUInt32(process, new UIntPtr((uint)(module.BaseAddress + MM_START_ADRESS)), IsEmulatorUseBigEndian);
                            Debug.WriteLine("Start address: " + Convert.ToString(m_romAddrStart, 16));
                            var foo = BitConverter.ToString(Memory.ReadBytes(m_Process, new UIntPtr(m_romAddrStart) + 0x9F6853, 8, IsEmulatorUseBigEndian));
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
            return Memory.ReadInt8(m_Process!, new UIntPtr(m_romAddrStart) + offset, IsEmulatorUseBigEndian);          
        }

        public int readInt16(int offset)
        {
            return Memory.ReadInt16(m_Process!, new UIntPtr(m_romAddrStart) + offset, IsEmulatorUseBigEndian);
        }

        public int readInt32(int offset)
        {
            return Memory.ReadInt32(m_Process!, new UIntPtr(m_romAddrStart) + offset, IsEmulatorUseBigEndian);
        }

        public uint readUInt32(int offset)
        {
            return Memory.ReadUInt32(m_Process!, new UIntPtr(m_romAddrStart) + offset, IsEmulatorUseBigEndian);
        }

        public byte[] readByte(int offset, int bytesToRead)
        {
            return Memory.ReadBytes(m_Process!, new UIntPtr(m_romAddrStart) + offset, bytesToRead, IsEmulatorUseBigEndian);
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
