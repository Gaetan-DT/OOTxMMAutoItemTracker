using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemScale
    {
        ItemSilverScale,
        ItemGoldenScale
    }

    class OotItemScaleMethod
    {
        public static OotItemScale FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemScale FromString(string item)
        {
            return (OotItemScale)System.Enum.Parse(typeof(OotItemScale), item);
        }

        public static string ToString(OotItemScale item)
        {
            return item.ToString();
        }
    }
}
