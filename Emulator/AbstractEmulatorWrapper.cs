using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MajoraAutoItemTracker.Model;
using MajoraAutoItemTracker.Model.Enum;

#nullable enable

namespace MajoraAutoItemTracker.MemoryReader
{
    abstract class AbstractRomController
    {
        protected const int EMULATOR_ENDIAN_SIZE = 4;

        protected abstract bool IsEmulatorUseBigEndian { get; }

        /*protected*/public Process? m_Process;
        protected uint m_romAddrStart;

        public abstract bool AttachToProcess(RomType romType);
        public abstract bool ProcessExist();
        public abstract string GetDisplayName();

        private int GetZeldaCheckFollowingEndianAndRomType(RomType romType)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return IsEmulatorUseBigEndian ? OOTOffsets.ZELDAZ_CHECK_BE : OOTOffsets.ZELDAZ_CHECK_LE;
                case RomType.MAJORA_MASK_USA_V0:
                    return IsEmulatorUseBigEndian ? MMOffsets.ZELDAZ_CHECK_BE : MMOffsets.ZELDAZ_CHECK_LE;
                default:
                    throw new Exception($"Unknown rom type: {romType}");
            }   
        }

        private int GetZeldaCheckPart2FollowingEndiandAndRomType(RomType romType)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return IsEmulatorUseBigEndian ? OOTOffsets.ZELDAZ_CHECK_2_BE : OOTOffsets.ZELDAZ_CHECK_2_LE;
                case RomType.MAJORA_MASK_USA_V0:
                    return IsEmulatorUseBigEndian ? MMOffsets.ZELDAZ_CHECK_2_VALUE_BE : MMOffsets.ZELDAZ_CHECK_2_VALUE_LE;
                default:
                    throw new Exception($"Unknown rom type: {romType}");
            }
        }

        // Perform with current start address
        public bool PerformCheckFollowingRomType(RomType romType)
        {
            return PerformCheckFollowingRomType(romType, m_romAddrStart);
        }

        protected bool AskForStartMajoraMask()
        {
            return MessageBox.Show(
                "Start from majora mask ?",
                "Start",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public bool PerformCheckFollowingRomType(RomType romType, uint possibleRomAddrStart)
        {
            switch (romType)
            {
                case RomType.OCARINA_OF_TIME_USA_V0:
                    return PerformOOTCheck(possibleRomAddrStart);
                case RomType.MAJORA_MASK_USA_V0:
                    return PerformMMCheck(possibleRomAddrStart);
                case RomType.RANDOMIZE_OOT_X_MM:
                    return PerformOOTCheck(possibleRomAddrStart) || PerformMMCheck(possibleRomAddrStart);
            }
            return false;
        }

        private bool PerformOOTCheck(uint possibleRomAddrStart)
        {
            var ootCheck = Memory.ReadInt32(m_Process!, new UIntPtr(possibleRomAddrStart + OOTOffsets.ZELDAZ_CHECK_ADDRESS), IsEmulatorUseBigEndian);
            var ootCheckPart2 = Memory.ReadInt32(m_Process!, new UIntPtr(possibleRomAddrStart + OOTOffsets.ZELDAZ_CHECK_ADDRESS), IsEmulatorUseBigEndian);

            var isOotCheckPart1Ok = (ootCheck == GetZeldaCheckFollowingEndianAndRomType(RomType.OCARINA_OF_TIME_USA_V0));
            var isOotCheckPart2Ok = (ootCheckPart2 == GetZeldaCheckPart2FollowingEndiandAndRomType(RomType.OCARINA_OF_TIME_USA_V0));

            if (isOotCheckPart1Ok)
                return true;
            return false;
        }

        private bool PerformMMCheck(uint possibleRomAddrStart)
        {
            //FIXME: Not working
            var mmCheck = Memory.ReadInt32(m_Process!, new UIntPtr(possibleRomAddrStart + MMOffsets.ZELDAZ_CHECK_ADDRESS), IsEmulatorUseBigEndian);
            if (mmCheck == GetZeldaCheckFollowingEndianAndRomType(RomType.MAJORA_MASK_USA_V0))
                return true;
            return false;
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
            var arrayByte = Memory.ReadBytes(m_Process!, GetPtrOffsetWithRomStart(offset - startAddressInEdian), 4, IsEmulatorUseBigEndian);
            // Use correction if we use bigEndian
            if (useBigEndian)
                arrayByte = arrayByte.Reverse().ToArray();
            // Claiming specific block in the array
            return arrayByte[startAddressInEdian];
        }

        public bool CheckIsNotFF(uint offset)
        {
            return !CheckBitEqualTo(offset, 0xFF);
        }

        public bool CheckBitRaiseIn(byte aByte, int pos)
        {
            return (aByte & (1 << pos)) != 0;
        }

        public bool CheckBitEqualTo(uint offset, byte hexValue)
        {
            var aByte = ReadUint8InEdianSizeAsByte(offset);
            return aByte == hexValue;
        }

        public bool CheckBitEqualTo(byte aByte, byte hexValue)
        {
            return aByte == hexValue;
        }

        public bool CheckBitRaise(uint offset, byte hexValue)
        {
            var aByte = ReadUint8InEdianSizeAsByte(offset);
            return CheckBitRaise(aByte, hexValue);
        }

        public bool CheckBitRaise(byte aByte, byte hexValue)
        {
            return (hexValue & aByte) == hexValue;
        }

        public bool CheckAnyHexValueEqualTo(uint offset, byte[] hexValues)
        {
            if (hexValues.Length == 0)
                return false;
            var aByte = ReadUint8InEdianSizeAsByte(offset);
            return CheckAnyHexValueEqualTo(aByte, hexValues);
        }

        public bool CheckAnyHexValueEqualTo(byte aByte, byte[] hexValues)
        {
            foreach (var hexValue in hexValues)
                if (CheckBitEqualTo(aByte, hexValue))
                    return true;
            return false;
        }

        public bool CheckAnyHexValueRaised(uint offset, byte[] hexValues)
        {
            if (hexValues.Length == 0)
                return false;
            var aByte = ReadUint8InEdianSizeAsByte(offset);
            return CheckAnyHexValueRaised(aByte, hexValues);
        }

        public bool CheckAnyHexValueRaised(byte aByte, byte[] hexValues)
        {
            foreach (var hexValue in hexValues)
                if (CheckBitRaise(aByte, hexValue))
                    return true;
            return false;
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
