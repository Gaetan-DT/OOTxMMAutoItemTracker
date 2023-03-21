using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipementQuiver
    {
        None,
        Normal,
        Large,
        Largest
    }

    static class EquipementQuiverMethod
    {
        public static EquipementQuiver readFromMemory(this byte equipementQuiverBombBag)
        {
            var equipementQuiver = equipementQuiverBombBag & 0x3;
            switch (equipementQuiver)
            {
                case 0:
                    return EquipementQuiver.None;
                case 1:
                    return EquipementQuiver.Normal;
                case 2:
                    return EquipementQuiver.Large;
                case 3:
                    return EquipementQuiver.Largest;
                default:
                    throw new Exception("Unknown EquipementWallet");
            }
        }
    }
}
