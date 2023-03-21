using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipementBombBag
    {
        None,
        Normal,
        Big,
        Biggest
    }

    static class EquipementBombBagMethod
    {
        public static EquipementBombBag readFromMemory(this int equipementQuiverBombBag)
        {
            var equipementBombBag = (equipementQuiverBombBag >> 3) & 0x3;
            switch(equipementBombBag)
            {
                case 0:
                    return EquipementBombBag.None;
                case 1:
                    return EquipementBombBag.Normal;
                case 2:
                    return EquipementBombBag.Big;
                case 3:
                    return EquipementBombBag.Biggest;
                default:
                    throw new Exception("Unknown EquipementWallet");
            }
        }
    }
}
