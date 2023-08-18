using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractEmulatorWrapper : IEmulatorWrapper
    {
        // To find it we need to check 32byte that match:   'ZELD' ->  0x5A454C44 (1514490948)
        // If done the next 32 byte should match :          'AZ  ' ->  0x415A0000 (1096417280)
        protected const int ZELDAZ_CHECK_BE = 0x5A454C44;
        protected const int ZELDAZ_CHECK_2_BE = 0x415A0000;

        protected const int ZELDAZ_CHECK_LE = 0x444C455A;

        protected abstract bool UseBigEndian { get; }

        protected Process m_Process;
        protected uint m_romAddrStart;

        public abstract bool AttachToProcess();

        protected int GetZeldaCheckFollowingEndian()
        {
            return UseBigEndian ? ZELDAZ_CHECK_BE : ZELDAZ_CHECK_LE;
        }

        public UIntPtr GetCorrectPtrAddress(uint offset)
        {
            uint offsetCorrection = 0;
            if (!UseBigEndian)
                offsetCorrection = offset % 4;
            var address = (m_romAddrStart + offset) - offsetCorrection;
            return new UIntPtr(address);
        }

        public int ReadInt8(uint offset)
        {
            return Memory.ReadInt8(m_Process, GetCorrectPtrAddress(offset), UseBigEndian);
        }

        public int ReadInt16(uint offset)
        {
            return Memory.ReadInt16(m_Process, GetCorrectPtrAddress(offset), UseBigEndian);
        }

        public int ReadInt32(uint offset)
        {
            return Memory.ReadInt32(m_Process, GetCorrectPtrAddress(offset), UseBigEndian);
        }

        public uint ReadUInt32(uint offset)
        {
            return Memory.ReadUInt32(m_Process, GetCorrectPtrAddress(offset), UseBigEndian);
        }

        public byte[] ReadByte(uint offset, int bytesToRead)
        {
            return Memory.ReadBytes(m_Process, GetCorrectPtrAddress(offset), bytesToRead, UseBigEndian);
        }

        public String ReadToHexString(uint offset, int size)
        {
            return ByteArrayToString(Memory.ReadBytes(m_Process, GetCorrectPtrAddress(offset), size, UseBigEndian));
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public bool ReadNotFF(uint offset)
        {
            var address = ReadInt8(offset);
            return address != 0xFF;
        }

        public bool ReadItem(uint offset, int itemValue)
        {
            var address = ReadInt8(offset);
            return (address & itemValue) == address;
        }

        public bool CheckHexRaised(uint offset, int bitRaised)
        {
            var b = ReadByte(offset, 1)[0];
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
