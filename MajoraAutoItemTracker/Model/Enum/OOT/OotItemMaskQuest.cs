using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemMaskQuest
    {
        ItemNone,
        ItemKeatonMask,
        ItemSkullMask,
        ItemSpookyMask,
        ItemBunnyHood,
        ItemMaskOfTruth,
        ItemGoronMask,
        ItemZoraMask,
        ItemGerudoMask
    }

    class OotItemMaskQuestMethod
    {
        public static OotItemMaskQuest FromMemoryAddress(byte memoryAddres)
        {
            switch (memoryAddres)
            {
                //21 Weird Egg
                //22 Chicken
                //23 Zelda's Letter
                case 0x24: return OotItemMaskQuest.ItemKeatonMask; //24 Keaton Mask
                case 0x25: return OotItemMaskQuest.ItemSkullMask; //25 Skull Mask
                case 0x26: return OotItemMaskQuest.ItemSpookyMask; //26 Spooky Mask
                case 0x27: return OotItemMaskQuest.ItemBunnyHood; //27 Bunny Hood
                case 0x28: return OotItemMaskQuest.ItemGoronMask; //28 Goron Mask
                case 0x29: return OotItemMaskQuest.ItemZoraMask; //29 Zora Mask
                case 0x2A: return OotItemMaskQuest.ItemGerudoMask; //2A Gerudo Mask
                case 0x2B: return OotItemMaskQuest.ItemMaskOfTruth; //2B Mask of Truth
                //2C SOLD OUT
                default: return OotItemMaskQuest.ItemNone;
            }
            throw new Exception("Not yet implemented");
        }

        public static int ToInterfaceMappingVariant(OotItemMaskQuest ootItemMaskQuest)
        {
            switch (ootItemMaskQuest)
            {
                case OotItemMaskQuest.ItemNone: return 0;
                case OotItemMaskQuest.ItemKeatonMask: return 0;
                case OotItemMaskQuest.ItemSkullMask: return 1;
                case OotItemMaskQuest.ItemSpookyMask: return 2;
                case OotItemMaskQuest.ItemBunnyHood: return 3;
                case OotItemMaskQuest.ItemMaskOfTruth: return 4;
                case OotItemMaskQuest.ItemGoronMask: return 5;
                case OotItemMaskQuest.ItemZoraMask: return 6;
                case OotItemMaskQuest.ItemGerudoMask: return 7;
                default: return 0;
            }
        }

        public static OotItemMaskQuest FromString(string item)
        {
            return (OotItemMaskQuest)System.Enum.Parse(typeof(OotItemMaskQuest), item);
        }

        public static string ToString(OotItemMaskQuest item)
        {
            return item.ToString();
        }
    }
}
