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
        public static EquipmentWallet ReadFromMemory(this uint equipmentWallet)
        {
            equipmentWallet = (equipmentWallet >> 4) & 0x3;
            switch(equipmentWallet)
            {
                case 0: return EquipmentWallet.Child;
                case 1: return EquipmentWallet.Adult;
                default:
                case 2: return EquipmentWallet.Giant;
            }
        }

        public static int ToForVariantMajoraMask(EquipmentWallet equipmentWallet)
        {
            switch (equipmentWallet)
            {
                case EquipmentWallet.Child:
                    return 0;
                case EquipmentWallet.Adult:
                    return 1;
                case EquipmentWallet.Giant:
                    return 2;
                default: return 0;
            }
        }
    }
}
