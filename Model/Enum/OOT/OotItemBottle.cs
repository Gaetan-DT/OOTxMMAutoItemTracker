using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemBottle
    {
        ItemEmptyBottle,
        ItemRedPotion,
        ItemGreenPotion,
        ItemBluePotion,
        ItemBottledFairy,
        ItemFish,
        ItemLonLonMilkBottle,
        ItemRutosLetter,
        ItemBlueFire,
        ItemBug,
        ItemBigPoe,
        ItemLonLonMilkHalf,
        ItemPoe
    }

    class OotItemBottleMethod
    {
        public static OotItemBottle FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemBottle FromString(string item)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemBottle item)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
