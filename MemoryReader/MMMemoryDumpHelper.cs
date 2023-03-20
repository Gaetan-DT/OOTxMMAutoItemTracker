using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MMMemoryDumpHelper
    {
        public int currentLinkTransformation = -1;

        public void UdpateStateData(ModLoader64Wrapper mModLoader64Wrapper)
        {
            currentLinkTransformation = mModLoader64Wrapper.readInt8(MMOffsets.CURRENT_TRANSFORMATION);
        }
    }
}
