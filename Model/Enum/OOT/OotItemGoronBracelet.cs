using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemGoronBracelet
    {
        ItemGoronBracelet,
        ItemSilverGauntlets,
        ItemGoldGauntlets
    }

    class OotItemGoronBraceletMethod
    {
        public static OotItemGoronBracelet FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemGoronBracelet FromString(string item)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemGoronBracelet item)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
