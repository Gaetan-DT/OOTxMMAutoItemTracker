using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum MagicMeter
    {
        None,
        Small,
        Large
    }

    static class MagicMeterMethod
    {
        public static MagicMeter ReadFromMemory(this int magicMerger)
        {
            switch (magicMerger)
            {
                case 0x00:
                    return MagicMeter.None;
                case 0x01:
                    return MagicMeter.Small;
                case 0x02:
                    return MagicMeter.Large;
                default:
                    throw new Exception("Unknown MagicMeter");
            }
        }
    }
}
