using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemGoronBracelet
    {
        ItemNone,
        ItemGoronBracelet,
        ItemSilverGauntlets,
        ItemGoldGauntlets
    }

    class OotItemGoronBraceletMethod
    {
        public static OotItemGoronBracelet FromMemoryAddress(byte memoryAddres)
        {
            if ((memoryAddres & OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_GAUNTLETS) == OOTOffsets.CST_INVENTORY_ADDRESS_GOLDEN_GAUNTLETS)
                return OotItemGoronBracelet.ItemGoldGauntlets;
            else if ((memoryAddres & OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_GAUNTLETS) == OOTOffsets.CST_INVENTORY_ADDRESS_SILVER_GAUNTLETS)
                return OotItemGoronBracelet.ItemSilverGauntlets;
            else if ((memoryAddres & OOTOffsets.CST_INVENTORY_ADDRESS_GORON_BRACELET) == OOTOffsets.CST_INVENTORY_ADDRESS_GORON_BRACELET)
                return OotItemGoronBracelet.ItemGoronBracelet;
            return OotItemGoronBracelet.ItemNone;
        }

        public static int ToInterfaceMappingVariant(OotItemGoronBracelet ootItemGoronBracelet)
        {
            switch(ootItemGoronBracelet)
            {
                case OotItemGoronBracelet.ItemNone: return 0;
                case OotItemGoronBracelet.ItemGoronBracelet: return 0;
                case OotItemGoronBracelet.ItemSilverGauntlets: return 1;
                case OotItemGoronBracelet.ItemGoldGauntlets: return 2;
                default: return 0;
            }
        }

        public static OotItemGoronBracelet FromString(string item)
        {
            return (OotItemGoronBracelet)System.Enum.Parse(typeof(OotItemGoronBracelet), item);
        }

        public static string ToString(OotItemGoronBracelet item)
        {
            return item.ToString();
        }
    }
}
