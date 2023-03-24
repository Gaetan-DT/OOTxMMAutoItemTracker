using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipmentWallet
    {
        Child = 0,
        Adult = 1,
        Giant = 2
    }

    static class EquipmentWalletMethod
    {
        public static EquipmentWallet ReadFromMemory(this int equipmentWallet)
        {
            equipmentWallet = (equipmentWallet >> 4) & 0x3;
            var enumValue = (EquipmentWallet) equipmentWallet;
            if (enumValue is EquipmentWallet)
            {
                return enumValue;
            }
            
            throw new Exception("Unknown EquipmentWallet");
        }
    }
}
