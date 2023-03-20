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
        public static EquipementBombBag readFromMemory(this int equipementBombBag)
        {
            if ((equipementBombBag & 0x00) == 0x00) // FIXME: Not working
                return EquipementBombBag.None;
            else if ((equipementBombBag & 0x00) == 0x08)
                return EquipementBombBag.Normal;
            else if ((equipementBombBag & 0x00) == 0x10)
                return EquipementBombBag.Big;
            else if ((equipementBombBag & 0x00) == 0x18)
                return EquipementBombBag.Biggest;
            else
                throw new Exception("Unknown EquipementWallet");
        }
    }
}
