using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipmentQuiver
    {
        None = 0,
        Normal = 1,
        Large = 2,
        Largest = 3
    }

    static class EquipmentQuiverMethod
    {
        public static EquipmentQuiver ReadFromMemory(this byte equipmentQuiverBombBag)
        {
            var equipmentQuiver = equipmentQuiverBombBag & 0x3;
            var enumValue = (EquipmentQuiver) equipmentQuiver;
            if (enumValue is EquipmentQuiver)
            {
                return enumValue;
            }
            
            throw new Exception("Unknown EquipmentQuiver");
        }
    }
}
