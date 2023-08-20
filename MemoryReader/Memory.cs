using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace MajoraAutoItemTracker
{
    internal class Memory
    {
        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, UIntPtr lpBaseAddress, byte[] lpBuffer, IntPtr dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out IntPtr lpNumberOfBytesWritten);

        #region read data

        public static int ReadInt8(Process p, UIntPtr address, bool bigEndian)
        {
            return ReadBytes(p, address, 1, bigEndian)[0];
        }

        public static int ReadInt16(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToInt16(ReadBytes(p, address, 2, bigEndian), 0);
        }

        public static int ReadInt32(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToInt32(ReadBytes(p, address, 4, bigEndian), 0);
        }

        public static uint ReadUInt32(Process p, UIntPtr address, bool bigEndian)
        {
            return BitConverter.ToUInt32(ReadBytes(p, address, 4, bigEndian), 0);
        }

        public static byte[] ReadBytes(Process p, UIntPtr address, int bytesToRead, bool bigEndian)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[bytesToRead];
            IntPtr bufferLength = new IntPtr(buffer.Length);
            ReadProcessMemory(p.Handle, address, buffer, bufferLength, ref bytesRead);
            if (bigEndian)
                return buffer;
            else
                return buffer.Reverse().ToArray();
        }

        #endregion

        #region write data

        private static bool Write16(Process p, IntPtr address, Int16 value)
        {
            return WriteBytes(p, address, BitConverter.GetBytes(value), 2);
        }

        private static bool Write32(Process p, IntPtr address, int value)
        {
            return WriteBytes(p, address, BitConverter.GetBytes(value), 4);
        }

        private static bool WriteBytes(Process p, IntPtr address, byte[] bytes, int length)
        {
            IntPtr bytesWritten;
            return WriteProcessMemory(p.Handle, address, bytes, length, out bytesWritten);
        }

        #endregion
    }
}
