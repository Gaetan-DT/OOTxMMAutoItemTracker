using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemOcarina
    {
        ItemFairyOcarina,
        ItemOcarinaOfTime
    }

    class OotItemOcarinaMethod
    {
        public static OotItemOcarina FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemOcarina FromString(string item)
        {
            return (OotItemOcarina)System.Enum.Parse(typeof(OotItemOcarina), item);
        }

        public static string ToString(OotItemOcarina item)
        {
            return item.ToString();
        }
    }
}
