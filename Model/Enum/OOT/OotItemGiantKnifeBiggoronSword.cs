using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemGiantKnifeBiggoronSword
    {
        ItemGiantKnife,
        ItemBiggoronSword
    }

    class OotItemGiantKnifeBiggoronSwordMethod
    {
        public static OotItemGiantKnifeBiggoronSword FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }

        public static OotItemGiantKnifeBiggoronSword FromString(string item)
        {
            return (OotItemGiantKnifeBiggoronSword)System.Enum.Parse(typeof(OotItemGiantKnifeBiggoronSword), item);
        }

        public static string ToString(OotItemGiantKnifeBiggoronSword item)
        {
            return item.ToString();
        }
    }
}
