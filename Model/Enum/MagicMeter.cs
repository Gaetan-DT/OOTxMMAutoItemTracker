using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum
{
    enum MagicMeter
    {
        None = 0,
        Small = 1,
        Large = 2
    }

    static class MagicMeterMethod
    {
        public static MagicMeter ReadFromMemory(this int magicMeter)
        {
            if (System.Enum.IsDefined(typeof(MagicMeter), magicMeter))
            {
                return (MagicMeter)magicMeter;
            }
            
            throw new Exception("Unknown MagicMeter");
        }
    }
}
