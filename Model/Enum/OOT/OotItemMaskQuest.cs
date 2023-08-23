using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemMaskQuest
    {
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
            throw new Exception("Not yet implemented");
        }

        public static OotItemMaskQuest FromString(string ootItemMaskQuest)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemMaskQuest ootItemMaskQuest)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
