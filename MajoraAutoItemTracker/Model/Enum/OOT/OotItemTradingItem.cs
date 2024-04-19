
namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemTradingItem
    {
        ItemNone,
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
            switch (memoryAddres)
            {
                case 0x2D: return OotItemTradingItem.ItemPocketEgg;     //2D     Pocket Egg
                case 0x2E: return OotItemTradingItem.ItemPocketCucco;   //2E     Pocket Cucco
                case 0x2F: return OotItemTradingItem.ItemCojiro;        //2F     Cojiro
                case 0x30: return OotItemTradingItem.ItemOddMushroom;   //30     Odd Mushroom
                case 0x31: return OotItemTradingItem.ItemOddPotion;     //31     Odd Potion
                case 0x32: return OotItemTradingItem.ItemPoacherSaw;    //32     Poacher's Saw
                case 0x33: return OotItemTradingItem.ItemBrokenGoronSword;      //33     Goron's Sword (Broken)
                case 0x34: return OotItemTradingItem.ItemPrescription;  //34     Prescription
                case 0x35: return OotItemTradingItem.ItemEyeballFrog;   //35     Eyeball Frog
                case 0x36: return OotItemTradingItem.ItemWorldFinestEyeDrops;   //36     Eye Drops
                case 0x37: return OotItemTradingItem.ItemClaimCheck;    //37     Claim Check
                default: return OotItemTradingItem.ItemNone;
            }
        }

        public static int ToInterfaceMappingVariant(OotItemTradingItem ootItemTradingItem)
        {
            switch (ootItemTradingItem)
            {
                case OotItemTradingItem.ItemNone: return 0;
                case OotItemTradingItem.ItemPocketEgg: return 0;
                case OotItemTradingItem.ItemPocketCucco: return 1;
                case OotItemTradingItem.ItemCojiro: return 2;
                case OotItemTradingItem.ItemOddMushroom: return 3;
                case OotItemTradingItem.ItemOddPotion: return 4;
                case OotItemTradingItem.ItemPoacherSaw: return 5;
                case OotItemTradingItem.ItemBrokenGoronSword: return 6;
                case OotItemTradingItem.ItemPrescription: return 7;
                case OotItemTradingItem.ItemEyeballFrog: return 8;
                case OotItemTradingItem.ItemWorldFinestEyeDrops: return 9;
                case OotItemTradingItem.ItemClaimCheck: return 10;
                default: return 0;
            }
        }

        public static OotItemTradingItem FromString(string item)
        {
            return (OotItemTradingItem)System.Enum.Parse(typeof(OotItemTradingItem), item);
        }

        public static string ToString(OotItemTradingItem item)
        {
            return item.ToString();
        }
    }
}
