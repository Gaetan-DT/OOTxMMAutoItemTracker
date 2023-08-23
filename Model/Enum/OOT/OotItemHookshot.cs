using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajoraAutoItemTracker.Model.Enum.OOT
{
    enum OotItemHookshot
    {
        ItemHookshot,
        ItemLongshot
    }

    class OotItemHookshotMethod
    {
        public static OotItemOcarina FromMemoryAddress(byte memoryAddres)
        {
            throw new Exception("Not yet implemented");
        }
        
        public static OotItemOcarina FromString(string item)
        {
            throw new Exception("Not yet implemented");
        }

        public static string ToString(OotItemOcarina item)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
