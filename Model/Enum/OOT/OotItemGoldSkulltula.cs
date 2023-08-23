using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemGoldSkulltula
    {
        Item10Skultula,
        Item20Skultula,
        Item30Skultula,
        Item40Skultula,
        Item50Skultula,
        Item100Skultula
    }

    class OotItemGoldSkulltulaMethod
    {
        public static OotItemGoldSkulltula FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemGoldSkulltula FromString(string item)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemGoldSkulltula item)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
