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
        public static EquipementQuiver readFromMemory(this byte equipementQuiver)
        {
            Debug.WriteLine("equipementQuiver: " + equipementQuiver); // FIXME: Not working
            if ((equipementQuiver & 0x00) == 0x00)
                return EquipementQuiver.None;
            else if ((equipementQuiver & 0x00) == 0x01)
                return EquipementQuiver.Normal;
            else if ((equipementQuiver & 0x00) == 0x02)
                return EquipementQuiver.Large;
            else if ((equipementQuiver & 0x00) == 0x03)
                return EquipementQuiver.Largest;
            else
                throw new Exception("Unknown EquipementWallet");
        }
    }
}
