using System.Collections.Generic;
using System.Linq;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum RomType
    {
        OCARINA_OF_TIME_USA_V0,
        MAJORA_MASK_USA_V0,
        RANDOMIZE_OOT_X_MM
    }

    class RomTypeMethod
    {
        public static List<RomType> getAsList()
        {
            return System.Enum.GetValues(typeof(RomType)).Cast<RomType>().ToList();
        }
    }
}
