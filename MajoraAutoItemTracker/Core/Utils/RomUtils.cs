using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Core.Utils
{
    public class RomUtils
    {

        public static string? ConvertRomNameToString(byte[] data)
        {
            string result = "";
            for (int x = 0; x < 8; x++)
            {
                if (data[x] >= 0x0 && data[x] <= 0x9) // (0-9)
                {
                    result += data[x].ToString();
                }
                else if (data[x] == 0xdf || data[x] == 0x3e) // (space " ")
                {
                    result += " ";
                }
                else
                {
                    if (data[x] >= 0xa && data[x] <= 0x3d) // PAL (A-z)
                    {
                        if (data[x] <= 0x23)
                        {
                            data[x] += 0x37;
                        }
                        else if (data[x] >= 0x24)
                        {
                            data[x] += 0x3d;
                        }
                    }
                    else if (data[x] >= 0xab && data[x] <= 0xde) // NTSC (A-z)
                    {
                        if (data[x] <= 0xc4)
                        {
                            data[x] -= 0x6a;
                        }
                        else if (data[x] >= 0xc5)
                        {
                            data[x] -= 0x64;
                        }
                    }
                    else if (data[x] == 0xea || data[x] == 0x40) // (period ".")
                    {
                        data[x] = 0x2e;
                    }
                    else if (data[x] == 0xe4 || data[x] == 0x3f) // (dash "-")
                    {
                        data[x] = 0x2d;
                    }
                    else return null; // Unable to get name
                    result += (char)data[x];
                }
            }
            return result;
        }

    }
}
