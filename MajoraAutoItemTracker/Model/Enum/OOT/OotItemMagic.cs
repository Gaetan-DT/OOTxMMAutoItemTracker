using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemMagic
    {
        ItemHalfMagic,
        ItemFullMagic
    }

    class OotItemMagicMethod
    {
        public static OotItemMagic FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemMagic FromString(string item)
        {
            return (OotItemMagic)System.Enum.Parse(typeof(OotItemMagic), item);
        }

        public static string ToString(OotItemMagic item)
        {
            return item.ToString();
        }
    }
}
