using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker
{
    internal class Memory
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out IntPtr lpNumberOfBytesRead);

        /*
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out IntPtr lpNumberOfBytesRead);
        */

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr handle, IntPtr baseAddress, byte[] buffer, int size, out IntPtr lpNumberOfBytesWritten);

        #region read data

        public static int readInt8(Process p, IntPtr address)
        {
            return readBytes(p, address, 1)[0];
        }

        public static int readInt16(Process p, IntPtr address)
        {
            return BitConverter.ToInt16(readBytes(p, address, 2), 0);
        }

        public static int readInt32(Process p, IntPtr address)
        {           
            return BitConverter.ToInt32(readBytes(p, address, 4), 0);
        }

        public static uint readUInt32(Process p, IntPtr address)
        {
            byte[] buffer = new byte[4];
            ReadProcessMemory(p.Handle, address, buffer, buffer.Length, out IntPtr bytesRead);
            return BitConverter.ToUInt32(buffer, 0);
        }

        public static byte[] readBytes(Process p, IntPtr address, int bytesToRead)
        {
            IntPtr bytesRead;
            byte[] buffer = new byte[bytesToRead];
            ReadProcessMemory(p.Handle, address, buffer, buffer.Length, out bytesRead);
            return buffer;
        }

        #endregion

        #region write data

        private static bool write16(Process p, IntPtr address, Int16 value)
        {
            return writeBytes(p, address, BitConverter.GetBytes(value), 2);
        }

        private static bool write32(Process p, IntPtr address, int value)
        {
            return writeBytes(p, address, BitConverter.GetBytes(value), 4);
        }

        private static bool writeBytes(Process p, IntPtr address, byte[] bytes, int length)
        {
            IntPtr bytesWritten;
            return WriteProcessMemory(p.Handle, address, bytes, length, out bytesWritten);
        }

        #endregion
    }
}
