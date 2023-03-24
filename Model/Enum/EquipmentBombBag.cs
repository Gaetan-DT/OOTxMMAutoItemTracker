using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipmentBombBag
    {
        None = 0,
        Normal = 1,
        Big = 2,
        Biggest = 3
    }

    static class EquipmentBombBagMethod
    {
        public static EquipmentBombBag ReadFromMemory(this byte equipmentQuiverBombBag)
        {
            var equipmentBombBag = (equipmentQuiverBombBag >> 3) & 0x3;
            var enumValue = (EquipmentBombBag) equipmentBombBag;
            if (enumValue is EquipmentBombBag)
            {
                return enumValue;
            }
            
            throw new Exception("Unknown EquipmentBombBag");
        }
    }
}
