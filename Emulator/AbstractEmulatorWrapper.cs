using System;
using System.Diagnostics;
using System.Linq;
using MajoraAutoItemTracker.Model;

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractEmulatorWrapper : IEmulatorWrapper
    {
        protected const int EMULATOR_ENDIAN_SIZE = 4;

        protected abstract bool IsEmulatorUseBigEndian { get; }

        protected Process m_Process;
        protected uint m_romAddrStart;

        public abstract bool AttachToProcess();
        public abstract bool ProcessExist();
        public abstract string GetDisplayName();

        protected int GetZeldaCheckFollowingEndian()
        {
            return IsEmulatorUseBigEndian ? OOTOffsets.ZELDAZ_CHECK_BE : OOTOffsets.ZELDAZ_CHECK_LE;
        }

        public UIntPtr GetPtrOffsetWithRomStart(uint offset)
        {
            return new UIntPtr(m_romAddrStart + offset);
        }

        public uint ReadUint8InEdianSizeAsInt(uint offset)
        {
            return ReadUint8InEdianBlock(offset, IsEmulatorUseBigEndian, 4);
        }

        public byte ReadUint8InEdianSizeAsByte(uint offset)
        {
            return ReadUint8InEdianBlock(offset, IsEmulatorUseBigEndian, 4);
        }

        public byte ReadUint8InEdianBlock(uint offset, bool useBigEndian, int endianByteSize = 4)
        {
            // Ex:
            // Adress: 00 01 02 03 04 05 06 07
            // Value : 00 1F 00 00 00 00 00 00
            // For reading adress 01, we need to claim address 00 to 03, apply ediam correction, and get value at address 01 inside the pair

            // Findind adress in endian size
            var startAddressInEdian = (offset % 4);
            // Claiming block size as byte array
            var arrayByte = Memory.ReadBytes(m_Process, GetPtrOffsetWithRomStart(offset - startAddressInEdian), 4, IsEmulatorUseBigEndian);
            // Use correction if we use bigEndian
            if (useBigEndian)
                arrayByte = arrayByte.Reverse().ToArray();
            // Claiming specific block in the array
            return arrayByte[startAddressInEdian];
        }


        private int SwapEndianness(int value)
        {
            var b1 = (value >> 0) & 0xff;
            var b2 = (value >> 8) & 0xff;
            var b3 = (value >> 16) & 0xff;
            var b4 = (value >> 24) & 0xff;

            return b1 << 24 | b2 << 16 | b3 << 8 | b4 << 0;
        }

        public bool CheckBitRaiseIn(byte aByte, int pos)
        {
            return (aByte & (1 << pos)) != 0;
        }

        public bool ReadAndCheckIsFF(uint offset)
        {
            return CheckIsFF(ReadUint8InEdianSizeAsByte(offset));
        }

        public bool CheckIsFF(byte aByte)
        {
            return aByte == 0xFF;
        }

        private string GetDebugPrintHex(uint hexValue)
        {
            var hexValueStr = hexValue.ToString("X4");
            var result = "";
            for (int i = 1; i <= hexValueStr.Length; i++)
            {
                bool addSeparator = (i % 4) == 0;
                result += hexValueStr[i - 1];
                if (addSeparator)
                    result += " ";
            }
            return result;
        }
    }
}
