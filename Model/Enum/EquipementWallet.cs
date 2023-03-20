using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum EquipementWallet
    {
        Child,
        Adult,
        Giant
    }

    static class EquipementWalletMethod
    {
        public static EquipementWallet ReadFromMemory(this int equipementWallet)
        {
            switch (equipementWallet)
            {
                case 0x00:
                    return EquipementWallet.Child;
                case 0x10:
                    return EquipementWallet.Adult;
                case 0x20:
                    return EquipementWallet.Giant;
                default:
                    throw new Exception("Unknown EquipementWallet");
            }
        }
    }
}
