using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemTradingItem
    {
        ItemPocketEgg,
        ItemPocketCucco,
        ItemCojiro,
        ItemOddMushroom,
        ItemOddPotion,
        ItemPoacherSaw,
        ItemBrokenGoronSword,
        ItemPrescription,
        ItemEyeballFrog,
        ItemWorldFinestEyeDrops,
        ItemClaimCheck
    }

    class OotItemTradingItemMethod
    {
        public static OotItemTradingItem FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemTradingItem FromString(string ootItemTradingItem)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemTradingItem ootItemTradingItem)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
